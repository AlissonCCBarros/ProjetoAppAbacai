import React, { useState, useEffect, Component } from 'react';
import { Alert } from 'react-native'
import {
  KeyboardAvoidingView,
  View,
  TextInput,
  TouchableOpacity,
  Text,
  ScrollView,
  Animated,
  Keyboard
} from 'react-native';

import Styles from './styles';

import { LinearGradient } from 'expo-linear-gradient';

import { Api } from '../../services/api';

import Spinner from 'react-native-loading-spinner-overlay';

import { Feather } from '@expo/vector-icons';
console.disableYellowBox = true;
export default function Login({ navigation }, props) {

  const [email, setEmail] = useState('')
  const [spinner, setSpinner] = useState(false)

  async function forgottenPassword() {
    if (email == '') {
      Alert.alert('Atenção!', 'É necessário preencher o campo de E-mail.');
      return;
    }
    setSpinner(true);

    new Api("User/ForgottenPassword")
      .post({ Email: email })
      .then(data => {
        setSpinner(false);
        console.log(data.data)
        if (data.data == true) {
          Alert.alert(
            'Sucesso!',
            "Sua nova senha foi enviada no e-mail."
          )
        }
        else {
          Alert.alert(
            'Opss!',
            "Não encontramos nenhuma conta registrada com esse e-mail."
          )
        }
      })
      .catch(err => {
        setSpinner(false);
        Alert.alert('Opss!', "Não conseguimos enviar um e-mail com sua nova senha, tente novamente em instantes.");
      });
  }

  return (
    <LinearGradient
      style={{ flex: 1, alignItems: 'center' }}
      colors={['#7BD94A', '#199559', '#1C7F63']}
    >
      <Spinner
        visible={spinner}
        textContent={'Carregando...'}
        textStyle={Styles.spinnerTextStyle}
      />

      <TouchableOpacity style={Styles.btnInfo} onPress={() => { navigation.navigate("Info") }}>
        <Feather name='help-circle' size={22} color='white'></Feather>
      </TouchableOpacity>

      <KeyboardAvoidingView style={Styles.background}>
        <View style={Styles.main}>

          <Text style={Styles.textRecuperar}>Recuperar Conta</Text>

          <View style={Styles.containerLogo}>
            <Animated.Image
              style={{
                width: 150,
                height: 140
              }}
              source={require('../../../src/assets/logo.png')}
            />
          </View>



          <View style={Styles.container}>

            <Text style={Styles.textEmail}>Vamos enviar um e-mail com sua nova senha</Text>

            <TextInput
              style={Styles.input}
              keyboardType='email-address'
              autoCapitalize='none'
              placeholder="Qual é o seu e-mail?"
              autoCorrect={false}
              onChangeText={email => setEmail(email)}
            />

            <TouchableOpacity style={Styles.btnSubmit} onPress={forgottenPassword}>
              <Text style={Styles.submitText}>Enviar E-mail</Text>
            </TouchableOpacity>

          </View>

        </View>

      </KeyboardAvoidingView>
    </LinearGradient>
  );
}