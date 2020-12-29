import React, { useState } from 'react';
import { Alert, BackHandler } from 'react-native'
import {
  KeyboardAvoidingView,
  View,
  TextInput,
  TouchableOpacity,
  Text,
  Animated,
} from 'react-native';

import Styles from './styles';

import * as Auth from '../../services/auth';
import { LinearGradient } from 'expo-linear-gradient';

import Spinner from 'react-native-loading-spinner-overlay';

import { useFocusEffect } from '@react-navigation/native';

import { Feather } from '@expo/vector-icons';
console.disableYellowBox = true;
export default function Login({ navigation }, props) {

  useFocusEffect(
    React.useCallback(() => {

      async function logado() {

        if (await Auth.isLogado())
          navigation.navigate("Home");
      }

      logado();
    }, [])
  );



  const [offset] = useState(new Animated.ValueXY({ x: 0, y: 95 }))
  const [opacity] = useState(new Animated.Value(0))
  const [logo] = useState(new Animated.ValueXY({ x: 250, y: 280 }))

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [spinner, setSpinner] = useState(false)

  signIn = async () => {
    if (email == '' || password == '') {
      Alert.alert('Atenção!', 'É necessário preencher o campo de E-mail e Senha.');
      return;
    }

    setSpinner(true);

    const access_token = await Auth.signInAsync(email, password);

    setSpinner(false);

    if (access_token != null)
      navigation.navigate("Home")
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

            <TextInput
              style={Styles.input}
              keyboardType='email-address'
              autoCapitalize='none'
              placeholder="E-mail"
              autoCorrect={false}
              onChangeText={email => setEmail(email)}
            />

            <TextInput
              secureTextEntry={true}
              autoCapitalize='none'
              style={Styles.input}
              placeholder="Senha"
              autoCorrect={false}
              onChangeText={password => setPassword(password)}
            />

            <TouchableOpacity style={Styles.btnSubmit} onPress={signIn}>
              <Text style={Styles.submitText}>Acessar</Text>
            </TouchableOpacity>

          </View>

          <TouchableOpacity style={Styles.btnReset} onPress={() => { navigation.navigate("ForgottenPassword") }}>
            <Text style={Styles.esqueciMinhaSenhaText}>Esqueci minha senha?</Text>
          </TouchableOpacity>

        </View>

        <View style={Styles.CreateAccount}>
          <TouchableOpacity style={Styles.btnRegister} onPress={() => { navigation.navigate("CreateAccount") }}>
            <Text style={Styles.registerText}>Cadastre-se no Abraçaí</Text>
          </TouchableOpacity>
        </View>

      </KeyboardAvoidingView>
    </LinearGradient>
  );
}