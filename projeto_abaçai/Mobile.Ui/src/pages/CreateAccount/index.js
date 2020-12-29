import Styles from './styles'
import React from "react";
import {
  View,
  Text,
  TouchableOpacity,
  Animated,
  ScrollView,
  Alert,
  TextInput
} from "react-native";

import { RadioButton } from 'react-native-paper';

import { LinearGradient } from 'expo-linear-gradient';

import { Api } from '../../services/api';

import { TextInputMask } from 'react-native-masked-text'

import { validateCnpj } from 'react-native-masked-text/dist/lib/masks/cnpj.mask'

import { validateCPF } from 'react-native-masked-text/dist/lib/masks/cpf.mask'

import Spinner from 'react-native-loading-spinner-overlay';

import { Feather } from '@expo/vector-icons';
console.disableYellowBox = true;
export default class App extends React.Component {
  constructor(props) {
    super(props);
    this.createAccount = this.createAccount.bind(this);
  }

  validaSeTodasAsInformacoesForamPreenchidas() {
    return this.state.Name == '' || this.state.Email == '' || this.state.Password == '' || this.state.CpfCnpj == '' || this.state.Celular == '';
  }

  validaEmail() {
    const expression = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return expression.test(String(this.state.Email).toLowerCase())
  }

  validaCpfCnpj() {
    return validateCnpj(this.state.CpfCnpj) || validateCPF(this.state.CpfCnpj);
  }

  createAccount() {
    if (this.validaSeTodasAsInformacoesForamPreenchidas()) {
      Alert.alert("Atenção!", "É necessário preencher todas as informações do formulário.");
      return;
    }

    if (!this.validaEmail()) {
      Alert.alert("Atenção!", "O e-mail inserido não é válido.");
      return;
    }

    if (!this.validaCpfCnpj()) {
      Alert.alert("Atenção!", "O CPF/CNPJ não é válido.");
      return;
    }

    this.state.AttributeBehavior = this.state.value;

    Alert.alert(
      "Termo de Aceite",
      "\n I - CONDIÇÕES GERAIS DE USO \n"
      + "\n a) Reconhece que o presente Termo se formaliza, vinculando as Partes, com a sua aceitação eletrônica pelo usuário, o que se fará mediante o clique no botão “Aceito o Termo de Uso”;"
      + "\n\n b) Declara sob as penas da lei que os dados fornecidos para o cadastro são verídicos e se referem a sua pessoa e/ou empresa sendo o usuário único e exclusivo responsável por qualquer dano causado pela inveracidade ou má-fé no fornecimento destes dados;"
      + "\n \n II – PRIVACIDADE"
      + "\n \n a) As informações cedidas pelo usuário e registradas no aplicativo poderão ser usadas na divulgação de seu perfil para outros usuários;",
      [
        {
          text: 'Cancelar',
          style: 'cancel'
        },
        {
          text: 'Aceito o Termo de Uso', onPress: () => {
            this.setState({ spinner: true });

            new Api("Account/NewAccount")
              .post(this.state)
              .then(data => {
                this.setState({ spinner: false });
                Alert.alert(
                  'Sucesso!',
                  "Sua conta foi criada.",
                  [
                    { text: 'OK', onPress: () => { this.props.navigation.navigate('Login') } }
                  ]
                )
              })
              .catch(err => {
                this.setState({ spinner: false });
                if (err.data != null && err.data.errors.length > 0)
                  Alert.alert('Opss!', err.data.errors[0]);
                else
                  Alert.alert('Opss!', "Não conseguimos criar sua conta, tente novamente em instantes.");
              });
          }
        }
      ]

    )
  }

  state = {
    Email: '',
    Password: '',
    Name: '',
    CpfCnpj: '',
    Celular: '',
    value: 'Instituicao',
    AttributeBehavior: '',
    typeCpfCnpj: '',
    spinner: false
  };

  render() {

    return (
      <View style={Styles.main}>

        <LinearGradient
          style={{ flex: 1, width: '100%', alignItems: 'center' }}
          colors={['#7BD94A', '#199559', '#1C7F63']}
        >

          <Spinner
            visible={this.state.spinner}
            textContent={'Carregando...'}
            textStyle={Styles.spinnerTextStyle}
          />

          <TouchableOpacity style={Styles.btnInfo} onPress={() => { this.props.navigation.navigate('Info') }}>
            <Feather name='help-circle' size={22} color='white'></Feather>
          </TouchableOpacity>

          <View style={Styles.background}>

            <View style={Styles.containerLogo}>
              <Animated.Image
                style={{
                  width: 150,
                  height: 141
                }}
                source={require('../../../src/assets/logo.png')}
              />
            </View>

            <Text style={{
              marginTop: '23%',
              marginBottom: 25
            }}>
              Olá, qual é o intuito da sua conta?
              </Text>


            <ScrollView style={Styles.scrollview}
            >

              <Animated.View style={{ marginBottom: 10 }}>

                <RadioButton.Group
                  onValueChange={value => this.setState({ value })}
                  value={this.state.value}>

                  <View style={{
                    flexDirection: 'row',
                    justifyContent: "center",
                    alignItems: "center",
                    marginBottom: 15
                  }}>
                    <View style={{
                      flexDirection: 'row'
                    }}>
                      <Text style={{ paddingTop: 5 }}>Instituição</Text>
                      <RadioButton value="Instituicao" color='#70D66C' />
                    </View>
                    <View style={{
                      flexDirection: 'row'
                    }}>
                      <Text style={{ paddingTop: 5 }}>Voluntário</Text>
                      <RadioButton value="Voluntario" color='#70D66C' />
                    </View>
                  </View>

                </RadioButton.Group>

                <TextInput
                  maxLength={100}
                  style={Styles.input}
                  autoCapitalize='words'
                  placeholder="Nome"
                  autoCorrect={false}
                  onChangeText={(Name) => this.setState({ Name: Name })}
                />


                <TextInput
                  keyboardType="email-address"
                  maxLength={60}
                  style={Styles.input}
                  autoCapitalize='none'
                  placeholder="E-mail"
                  autoCorrect={false}
                  onChangeText={(Email) => this.setState({ Email: Email })}
                />

                <TextInput
                  style={Styles.input}
                  secureTextEntry={true}
                  autoCapitalize='none'
                  placeholder="Senha"
                  autoCorrect={false}
                  onChangeText={(Password) => this.setState({ Password: Password })}
                />

                <TextInputMask
                  style={Styles.input}
                  type="custom"
                  options={{
                    mask: this.state.typeCpfCnpj === 'cpf' ? '999.999.999-99*' : '99.999.999/9999-99'
                  }}
                  placeholder="CPF/CNPJ"
                  value={this.state.CpfCnpj}
                  keyboardType="numeric"
                  onChangeText={CpfCnpj =>
                    this.setState({
                      CpfCnpj: CpfCnpj,
                      typeCpfCnpj: CpfCnpj.length > 14 ? 'cnpj' : 'cpf',
                    })
                  }
                />

                <TextInputMask
                  style={Styles.input}
                  placeholder="Celular"
                  type={'cel-phone'}
                  options={{
                    maskType: 'BRL',
                    withDDD: true,
                    dddMask: '(99) '
                  }}
                  value={this.state.Celular}
                  onChangeText={(Celular) => this.setState({ Celular: Celular })}
                />


              </Animated.View>
            </ScrollView>

            <TouchableOpacity style={Styles.btnSubmit} onPress={this.createAccount}>
              <Text style={Styles.submitText}>Criar Conta</Text>
            </TouchableOpacity>
          </View>
        </LinearGradient>
      </View>

    );
  }
}