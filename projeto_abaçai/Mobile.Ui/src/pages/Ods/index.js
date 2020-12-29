import React, { Component } from 'react';
import { Api } from '../../services/api';
import { Text, View, Image, TouchableOpacity, FlatList, Dimensions, ActivityIndicator } from 'react-native';
import { navigation } from '@react-navigation/native';
import s from './style';
import img from './odsImage';
import { Feather } from '@expo/vector-icons';


const numColumns = 3;
console.disableYellowBox = true;
export default class Ods extends Component {
  constructor() {
    super();
    this.state = {
      isLoading: false,
      resultData: [],
      temOds: true
    }
  }
  componentDidMount() {
    new Api("Ods/GetOdsUserLogged").get({ attributeBehavior: "PegarTodosOsOdsDoUsuarioLogado" }).then(data => {
      var dataList = data.dataList;
      const totalRows = Math.floor(dataList.length / numColumns)
      let totalLastRow = dataList.length - (totalRows * numColumns)

      while (totalLastRow !== numColumns) {
        dataList.push({ key: 'blank', empty: true });
        totalLastRow++
      }

      this.setState({
        isLoading: true,
        resultData: dataList
      })
    })


  }

  _renderItem = ({ item, index }) => {
    if (item.empty) {
      return <View style={s.container}><View style={s.itemInvisible} /></View>
    }
    return (
      <View style={s.container}>
        <TouchableOpacity onPress={() => { item.temOds ? this.props.navigation.navigate('DetalhesOds', { data: item }) : null }}>
          <View style={s.cards}>
            <Image source={img.obs[item.imageName]} style={s.cardOds} />
            {!item.temOds ? <Image source={img.obs[item.imageName]} style={s.grayScale} /> : null}
          </View>
        </TouchableOpacity>
      </View>
    )
  }

  render() {
    return (
      <View style={s.container}>
        <TouchableOpacity style={s.btnHome} onPress={() => { this.props.navigation.navigate('Perfil'); }}>
          <Text>
            {<Feather name='arrow-left-circle' size={28} color='#2AB940' />}
          </Text>
        </TouchableOpacity>
        <Text style={s.titulo}>ODS</Text>
        {this.state.isLoading == true ?
          <FlatList
            data={this.state.resultData}
            renderItem={this._renderItem}
            style={s.listaProjetos}
            numColumns={numColumns}
            keyExtractor={(item, index) => index.toString()}
          /> : <ActivityIndicator size="large" color="black" />}
      </View>
    )
  }
}
