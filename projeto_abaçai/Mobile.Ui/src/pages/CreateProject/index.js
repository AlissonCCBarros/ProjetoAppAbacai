import React, { useState } from 'react';
import { Feather } from '@expo/vector-icons';
import { View, ScrollView, Text, TouchableOpacity, TextInput, ImageBackground,Alert } from 'react-native';
import DateTimePicker from '@react-native-community/datetimepicker';
import { Api } from '../../services/api';
import { TextInputMask } from 'react-native-masked-text'

import { 
  parseISO, 
  formatRelative, 
  formatDistance,
} from 'date-fns';

import { format } from 'date-fns-tz';

import styles from './styles';
console.disableYellowBox = true;

export default function CreateProject({ navigation }) {

  const [NomeProjeto, setNomeProjeto] = useState('');
  const [cep, setCep] = useState('');
  const [rua, setEndereco] = useState('');
  const [numero, setNumero] = useState('');
  const [comp, setComp] = useState('');
  const [bairro, setBairro] = useState('');
  const [cidade, setCidade] = useState('');
  const [estado, setEstado] = useState('');
  const [descricao, setDescricao] = useState('');
  const [NovaData, setNovaData] = useState();

  const [date, setDate] = useState('');

  const [projeto, setProjeto] = useState({});

  function SalvarProjeto() {
    setProjeto(
      {
        Nome: NomeProjeto,
        Descricao: descricao,
        AttributeBehavior: "NovoProjeto",
        Endereco: {
          CEP: cep,
          Numero: numero,
          Rua: rua,
          Complemento: comp,
          Bairro: bairro,
          Cidade: cidade,
          Estado: estado
        },
        Data: date

      });

      if (bairro == '' || rua == '' || cep == '' || estado == '' || cidade == '' || numero == '' || NomeProjeto == '' || comp == '' || descricao == '' || date == '') {
        Alert.alert('Atenção', 'É necessário preencher todas as informações')
        return;
      }

        new Api("Projeto/NovoProjeto").post(projeto).then(data =>  Alert.alert(
          
          'Sucesso',
          "Seu projeto foi criado com sucesso",
          [
            { text: 'OK', onPress: () => { navigation.navigate("Home") }}
          ]
        ))
      
  };


  return (
    <View style={styles.container}>
      <View style={styles.top}>
        <TouchableOpacity onPress={() => navigation.navigate("Home")}>
          <Feather name='arrow-left-circle' size={30} color='#2AB940'></Feather>
        </TouchableOpacity>
        <Text style={styles.titulo}>Cadastro de Projetos</Text>
        <TouchableOpacity style={styles.loadButton} onPress={() => SalvarProjeto()}>
          <Feather name="save" size={20} color="#FFF" />
        </TouchableOpacity>
      </View>

      <ScrollView
        contentContainerStyle={{ flexGrow: 1, alignItems: 'center', marginTop: 10 }}

      >
        <TextInput
          style={[styles.input, { marginTop: 10 }]}
          placeholder='Nome do Projeto'
          autoCorrect={false}
          autoCapitalize='words'
          //value={text}
          onChangeText={setNomeProjeto}
        />

        
        <TextInputMask
          type={'datetime'}
          options={{
            format: 'DD/MM/YYYY'
          }}
          style={styles.input}
          placeholder={"Data Inicio"}
          value={date}
          onChangeText={setDate}
        />

        <TextInputMask
          type={"custom"}
          options={{
            mask: "99999-999"
          }}
          style={[styles.input, { marginTop: 10 }]}
          placeholder='CEP'
          autoCorrect={false}
          keyboardType='numeric'
          value={cep}
          onChangeText={setCep}
        />

        <TextInput
          style={[styles.input, { marginTop: 10 }]}
          placeholder='Endereço'
          autoCorrect={false}
          autoCapitalize='words'
          value={rua}
          onChangeText={setEndereco}
        />

        <TextInput
          style={[styles.input, { marginTop: 10 }]}
          placeholder='Nº'
          autoCorrect={false}
          keyboardType='numeric'
          value={numero}
          onChangeText={setNumero}
        />

        <TextInput
          style={[styles.input, { marginTop: 10 }]}
          placeholder='Complemento'
          autoCorrect={false}
          autoCapitalize='words'
          value={comp}
          onChangeText={setComp}
        />

        <TextInput
          style={[styles.input, { marginTop: 10 }]}
          placeholder='Bairro'
          autoCorrect={false}
          autoCapitalize='words'
          value={bairro}
          onChangeText={setBairro}
        />

        <TextInput
          style={[styles.input, { marginTop: 10 }]}
          placeholder='Cidade'
          autoCorrect={false}
          autoCapitalize='words'
          value={cidade}
          onChangeText={setCidade}
        />

        <TextInput
          style={[styles.input, { marginTop: 10 }]}
          placeholder='Estado'
          autoCapitalize='words'
          autoCorrect={false}
          value={estado}
          onChangeText={setEstado}
        />

        <TextInput
          style={[styles.input, { marginBottom: '10%' }, { marginTop: 15 }]}
          placeholder='Descrição'
          multiline
          autoCorrect={false}
          numberOfLines={5}
          value={descricao}
          onChangeText={setDescricao}
        />


      </ScrollView>

    </View>
  );
}