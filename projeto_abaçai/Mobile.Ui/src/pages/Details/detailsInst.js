import React from 'react';
import { Feather } from '@expo/vector-icons';
import { useNavigation, useRoute } from '@react-navigation/native';
import { View, FlatList, Image, Text, TouchableOpacity } from 'react-native';
import { format, parseISO } from 'date-fns';
import pt from 'date-fns/locale/pt';

import { Api } from '../../services/api';

import styles from './styles';

export default function Detail() {
  const navigation = useNavigation();
  const route = useRoute();

  const [endereco, setEndereco] = React.useState({});
  const [atividades, setAtividades] = React.useState([]);

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


  function getEndereco() {
    new Api("Endereco/GetEnderecoProjeto").get({ EnderecoId: projetos.enderecoId }).then(data => {
      var enderecoP = data.data
      setEndereco(enderecoP),
        console.log('dataLit', endereco)
    })
  }

  function getAtividades() {
    new Api("ProjetoAtividade/GetAtividadesProjeto").get({ ProjetoId: projetos.idProjeto, attributeBehavior: "ListarAtividadesDoProjeto" }).then(data => {
      var atividadesP = data.dataList
      setAtividades(atividadesP),
        console.log('dataLit', atividades)
    })
  }

  function navigateBack() {
    navigation.goBack()
  }

  React.useEffect(() => {

    getEndereco();
    getAtividades();

  }, []);


  return (
    <View style={styles.container}>

      <View style={styles.top}>
        <TouchableOpacity onPress={navigateBack}>
          <Feather name='arrow-left-circle' size={28} color='#2AB940' />
        </TouchableOpacity>

        <Text style={styles.titulo}>Atividades</Text>

        <TouchableOpacity onPress={() => {navigation.navigate("CreateTask", { idProjeto: projetos.idProjeto }) }} style={styles.loadButton}>
          <Feather name="plus-circle" size={28} color="#FFF" />
        </TouchableOpacity>
      </View>


      <View style={styles.projeto}>
        <Text style={[styles.projetoTipo, { marginTop: 0 }]}>Informações do Projeto: {projetos.nomeProjeto}</Text>

        <Text style={styles.projetoNome}>{endereco.rua}, Nº {endereco.numero} / {endereco.bairro} / {endereco.cidade} / {endereco.estado}</Text>
        <Text style={styles.projetoNome}>Data de Início: {dataInicioFormatada}</Text>
        {projetos.dataFimProjeto < projetos.dataInicioProjeto ? null : <Text style={styles.projetoNome}>Data de Término: {dataFimFormatada}</Text>}
      </View>

      <FlatList
        data={atividades}
        style={styles.listaProjetos}
        keyExtractor={atividades => String(atividades.idAtividade)}
        renderItem={({ item: atividades }) => (
          <View style={styles.projeto}>

            <Text style={[styles.projetoTipo, { marginTop: 0 }]}>Atividade:</Text>
            <Text style={styles.projetoNome}>{atividades.nomeAtividade}</Text>

            <Text style={styles.projetoTipo}>Descrição da Atividade:</Text>
            <Text style={styles.projetoNome}>{atividades.descricaoAtividade}</Text>

            <Text style={styles.projetoTipo}>Habilidade Necessária:</Text>
            <Text style={styles.projetoNome}>{atividades.habilidade}</Text>

            <Text style={styles.projetoTipo}>Objetivos de Desenvolvimento Sustentável:</Text>
            <View style={{ flexDirection: "row" }}>              
              <Image source={require('../../assets/ods_imagem_logo.png')} style={styles.circleImg} />
              <Text style={styles.projetoNome}>{atividades.ods}</Text>
            </View>

          </View>
        )}
      />

    </View>
  )
}