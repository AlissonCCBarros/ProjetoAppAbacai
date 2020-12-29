import React, { useState } from 'react';
import { Feather } from '@expo/vector-icons';
import { useRoute } from '@react-navigation/native';
import {
  View, ScrollView, Text, TouchableOpacity, TextInput, Picker, Alert
} from 'react-native';

import { Api } from '../../services/api';

import Styles from './styles';
console.disableYellowBox = true;

export default function CreateTask({ navigation }) {

  const route = useRoute();

  const [nome, setNome] = useState('');
  const [descricao, setDescricao] = useState('');
  const [ods, setOds] = useState('');
  const [habilidade, setHab] = useState('');
  const [atividade, setAtividade] = useState('');


  const idProjeto = route.params.idProjeto;


  function SalvarAtividade() {
    if (nome == '' || descricao == '' || ods == '' || habilidade == '' || idProjeto == '' || habilidade == 0 || ods == 0) {
      Alert.alert("Atenção", "Preencha todos os campos");
      return;
    }
    setAtividade(
      {
        Nome: nome,
        Descricao: descricao,
        OdsId: ods,
        HabilidadeId: habilidade,
        ProjetoId: idProjeto
      });

    new Api("Atividade/InserirAtividade").post(atividade).then(data => Alert.alert(
      'Sucesso',
      "Sua atividade foi registrada com sucesso",
      [
        { text: 'OK', onPress: () => { navigation.navigate("Home") } }
      ]
    ))
  };

  return (
    <View style={Styles.container}>
      <View style={Styles.top}>
        <TouchableOpacity onPress={() => navigation.navigate("DetailsInst")}>
          <Feather name='arrow-left-circle' size={30} color='#2AB940'></Feather>
        </TouchableOpacity>
        <Text style={Styles.titulo}>Cadastro de Atividades</Text>
        <TouchableOpacity style={Styles.loadButton} onPress={() => SalvarAtividade()}>
          <Feather name="save" size={20} color="#FFF" />
        </TouchableOpacity>
      </View>

      <ScrollView
        contentContainerStyle={{ flexGrow: 1, alignItems: 'center', marginTop: 10 }}

      >
        <TextInput
          style={[Styles.input, { marginTop: 10 }]}
          placeholder='Nome da Atividade'
          autoCorrect={false}
          autoCapitalize='words'
          value={nome}
          onChangeText={setNome}
        />

        <View style={[Styles.select, { borderBottomEndRadius: 20 }]}>
          <Picker
            style={[{ color: '#CCC' }]}
            selectedValue={ods}
            onValueChange={(itemValue, itemIndex) => setOds(itemValue)}
          >
            <Picker.Item label='Selecione uma ODS' value={0} />
            <Picker.Item label='Erradicação da pobreza' value={1} />
            <Picker.Item label='Fome Zero e Agricultura Sustentável' value={2} />
            <Picker.Item label='Saude e Bem Estar' value={3} />
            <Picker.Item label='Educação de Qualidade' value={4} />
            <Picker.Item label='Igualdade de Gênero' value={5} />
            <Picker.Item label='Água Potável e Saneamento' value={6} />
            <Picker.Item label='Energia Acessível e Limpa' value={7} />
            <Picker.Item label='Trabalho Decente e Crescimento Econômico' value={8} />
            <Picker.Item label='Indústria, Inovação e Infraestrutura' value={9} />
            <Picker.Item label='Redução da Desigualdades' value={10} />
            <Picker.Item label='Cidades e Comunidades Sustentáveis' value={11} />
            <Picker.Item label='Consumo e Produção Responsáveis' value={12} />
            <Picker.Item label='Ação Contra a Mudança Global do Clima' value={13} />
            <Picker.Item label='Vida na Água' value={14} />
            <Picker.Item label='Vida Terrestre' value={15} />
            <Picker.Item label='Paz, Justiça e Instituições Eficazes' value={16} />
            <Picker.Item label='Parcerias e Meios de Implementação' value={17} />

          </Picker>
        </View>

        <View style={[Styles.select]}>
          <Picker
            style={{ color: '#CCC' }}
            selectedValue={habilidade}
            onValueChange={(itemValue, itemIndex) => setHab(itemValue)}
          >
            <Picker.Item label='Selecione uma Habilidade' value={0} />
            <Picker.Item label='Violão' value={1} />
            <Picker.Item label='Teclado' value={2} />
            <Picker.Item label='Violino' value={3} />
            <Picker.Item label='Luta' value={4} />
            <Picker.Item label='Atletismo' value={5} />
            <Picker.Item label='Dança' value={6} />
            <Picker.Item label='Ginástica' value={7} />
            <Picker.Item label='Informática' value={8} />
            <Picker.Item label='Inglês' value={9} />
            <Picker.Item label='Cooperação e trabalho em equipe' value={10} />
            <Picker.Item label='Resolução de problemas e conflitos' value={11} />

          </Picker>
        </View>

        <TextInput
          style={[Styles.input, { marginBottom: '10%' }, { marginTop: 15 }]}
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