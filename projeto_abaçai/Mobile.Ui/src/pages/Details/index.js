import React from 'react';
import { Feather } from '@expo/vector-icons';
import { useNavigation, useRoute } from '@react-navigation/native';
import { View, FlatList, Image, Text, TouchableOpacity } from 'react-native';
import { format, parseISO } from 'date-fns';
import pt from 'date-fns/locale/pt';

import { Api } from '../../services/api';

import styles from './styles';

console.disableYellowBox = true;

export default function Detail() {
  const navigation = useNavigation();
  const route = useRoute();
  const [endereco, setEndereco] = React.useState({});

  const projetos = route.params.projetos;

  const dataInicio = parseISO(projetos.dataInicioProjeto);
  const dataInicioFormatada = format(
    dataInicio,
    "'Dia' dd 'de' MMMM 'de' yyyy",
    { locale: pt }
  );

  const dataFim = parseISO(projetos.dataFimProjeto);
  const dataFimFormatada = format(
    dataFim,
    "'Dia' dd 'de' MMMM 'de' yyyy",
    { locale: pt }
  );

  function navigateBack() {
    navigation.goBack()
  }

  function getEndereco() {
    new Api("Endereco/GetEnderecoProjeto").get({ EnderecoId: projetos.enderecoId }).then(data => {
      var enderecoP = data.data
      setEndereco(enderecoP),
        console.log('dataLit', endereco)
    })
  }

  React.useEffect(() => {

    getEndereco()

  }, []);


  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <TouchableOpacity onPress={navigateBack}>
          <Feather name='arrow-left-circle' size={28} color='#2AB940' />
        </TouchableOpacity>

      </View><Text style={[styles.titulo, { marginTop: -40 }]}>Detalhes</Text>

      <View style={styles.projeto}>
        <Text style={[styles.projetoTipo, { marginTop: 0 }]}>Intituição/Projeto:</Text>
        <Text style={styles.projetoNome}>{projetos.nomeProjeto}</Text>

        <Text style={styles.projetoTipo}>Descrição do Projeto:</Text>
        <Text style={styles.projetoNome}>{projetos.descricaoProjeto}</Text>
      </View>

      <View style={styles.projeto}>
        <Text style={[styles.projetoTipo, { marginTop: 0 }]}>Endereço:</Text>
        <Text style={styles.projetoNome}>{endereco.rua}, Nº {endereco.numero} / {endereco.bairro} / {endereco.cidade} / {endereco.estado}</Text>
      </View>

      <View style={[styles.projeto]}>
        <Text style={[styles.projetoTipo, { marginTop: 0 }]}>Data de Início do Projeto:</Text>
        <Text style={styles.projetoNome}>{dataInicioFormatada}</Text>

        <Text style={styles.projetoTipo}>Data de Encerramento do Projeto:</Text>
        <Text style={styles.projetoNome}>{projetos.dataFimProjeto < projetos.dataInicioProjeto ? "O Projeto ainda não foi encerrado." : dataFimFormatada}</Text>

      </View>

    </View>
  )
}