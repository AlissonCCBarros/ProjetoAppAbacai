import React from 'react';
import { Api } from '../../services/api';
import { Text, View, Image, TouchableOpacity, ImageBackground, Modal, ActivityIndicator, NativeModules } from 'react-native';
import s from './style';
import { Feather } from '@expo/vector-icons';
import * as ImagePicker from 'expo-image-picker';
import UserPermissions from '../../services/UserPermissions'
import * as Auth from '../../services/auth';
console.disableYellowBox = true;

export default class Perfil extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: false,
      usuario: {},
      temNotificacao: false,
      errorMessage: null,
      ehInstituicao: true
    };
  }

  logOut = async () => {
    await Auth.signOutAsync();

    NativeModules.DevSettings.reload();
  };

  async componentDidMount() {
    this.setState({ ehInstituicao: await Auth.isInstituicao() })

    new Api("Usuario").get({ AttributeBehavior: "GetInfoUsuarioPerfil" }).then(data => {
      var dataList = data.dataList[0];


      new Api("ProjetoAtividade/GetTemNotificacao").get().then(data => {
        var result = data.data;

        this.setState({
          isLoading: true,
          temNotificacao: result
        })
      })

      this.setState({
        isLoading: true,
        usuario: dataList
      })
    })
  }

  handlePickAvatar = async () => {
    UserPermissions.getCameraPermission();

    let result = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.Images,
      allowsEditing: true,
      aspect: [4, 3]
    })
    if (!result.cancelled) {
      this.setState({ usuario: { ...this.state.usuario, foto: result.uri } })
      new Api("Usuario").put(this.state.usuario).then(data => { this.componentDidMount() })
    }
  };

  render() {
    return (

      <View style={s.container} visible={this.state.isLoading}>

        {this.state.usuario.foto ?
          <Image source={{ uri: this.state.usuario.foto }} blurRadius={5} style={s.imgBackground} /> :
          <Image source={require('../../assets/avatar.png')} blurRadius={5} style={s.imgBackground} />
        }

        <TouchableOpacity style={s.btnEditPerfil} onPress={() => { this.props.navigation.navigate('PersonalInformation') }}>
          <Feather name='settings' size={22} color='#2AB940'></Feather>
        </TouchableOpacity>

        <TouchableOpacity style={s.btnNotificacao} onPress={() => { this.state.usuario.ehInstituicao ? this.props.navigation.navigate('NotificacaoInstituto') : this.props.navigation.navigate('Notificacao') }}>
          {this.state.temNotificacao ? <View style={s.NotificationCount}></View> : null}
          <Feather name='bell' size={22} color='#2AB940'></Feather>
        </TouchableOpacity>


        <TouchableOpacity style={s.btnOds} onPress={() => { this.props.navigation.navigate('Ods') }}>
          <Feather name='award' size={22} color='#2AB940'></Feather>
        </TouchableOpacity>


        <TouchableOpacity style={s.btnLogout} onPress={this.logOut}>
          <Feather name='log-out' size={22} color='white'></Feather>
        </TouchableOpacity>

        <TouchableOpacity style={s.btnInfo} onPress={() => { this.props.navigation.navigate('Info') }}>
          <Feather name='help-circle' size={22} color='white'></Feather>
        </TouchableOpacity>

        <View >
          <View style={s.circleImgConteiner}>
            {this.state.usuario.foto ?
              <Image style={s.circleImg} source={{ uri: this.state.usuario.foto }} /> :
              <Image style={s.circleImg} source={require('../../assets/avatar.png')} />
            }
          </View>
          <TouchableOpacity style={s.btnTrocarImg} onPress={this.handlePickAvatar}>
            <Feather name='camera' size={16} color='#2AB940'></Feather>
          </TouchableOpacity>

        </View>
        {this.state.isLoading == true ? <Text style={s.userName}> {this.state.usuario.nome} </Text> : <ActivityIndicator size="large" color="#FFF" />}
        <Text style={s.userSubTitulo}> {this.state.usuario.email} </Text>
      </View>

    );
  }
}
