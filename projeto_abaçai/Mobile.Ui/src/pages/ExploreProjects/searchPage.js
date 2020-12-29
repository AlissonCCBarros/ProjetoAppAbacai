import React from 'react';
import { Feather } from '@expo/vector-icons';
import { useNavigation } from '@react-navigation/native';
import { View, FlatList, Image, Text, TouchableOpacity, TextInput, Modal, Alert } from 'react-native';
import { Api } from '../../services/api';
import Spinner from 'react-native-loading-spinner-overlay';

import styles from './assets/styles/searchPageStyle';

export default function SearchProjects() {
  const navigation = useNavigation();

  const [modalVisible, setModalVisible] = React.useState(false);
  const [projeto, setProjeto] = React.useState('');
  const [atividade, setAtividade] = React.useState('');
  const [cidade, setCidade] = React.useState('');
  const [ods, setOds] = React.useState('');

  const [atividades, setAtividades] = React.useState([]);

  const [spinner, setSpinner] = React.useState(false);

  function navigateBack() {
    navigation.goBack()
  }

  function getAtividades() {
    new Api("ProjetoAtividade/GetAtividadesProjeto").get({ NomeProjeto: projeto, NomeAtividade: atividade, Cidade: cidade, Ods: ods, attributeBehavior: "BuscarProjetoAtividadePesquisa" }).then(data => {
      var dataList = data.dataList
      setAtividades(dataList)
    })
  }

  function Match(ProjetoAtividadeId) {
    setSpinner(true);
    new Api("Match")
      .post({ ProjetoAtividadeId: ProjetoAtividadeId, AttributeBehavior: "SalvarMatch" })
      .then(data => {
        setSpinner(false);
        Alert.alert('Solicitação enviada!', 'Por favor, aguarde o retorno da Instituição sobre a sua solicitação de participação.')
        getAtividades();
      })
      .catch(err => {
        setSpinner(false);
      });
  }

  function LimparFiltros() {
    setProjeto('')
    setAtividade('')
    setCidade('')
    setOds('')
  }

  ListEmptyView = () => {
    return (
      <View style={styles.headerText}>
        <Text style={styles.textNoData}> Sem dados da pequisa...</Text>
      </View>
    );
  }

  return (
    <View style={styles.container}>

      <Spinner
        visible={spinner}
        textContent={'Realizando Inscrição...'}
        textStyle={styles.spinnerTextStyle}
      />

      <View style={styles.header}>
        <TouchableOpacity onPress={navigateBack} style={{ marginRight: 15 }}>
          <Feather name='arrow-left-circle' size={28} color='#2AB940' />
        </TouchableOpacity>
        <TouchableOpacity
          style={styles.openButton}
          onPress={() => {
            setModalVisible(true);
          }}
        >
          <Text style={styles.textStyle}>   Pesquise novos Projetos e Atividades    </Text><Feather name="search" size={20} color="#FFF" />
        </TouchableOpacity>
      </View>

      <Modal
        animationType="fade"
        transparent={true}
        visible={modalVisible}
      >
        <View style={styles.modalView}>
          <View style={styles.header}>
            <Text style={styles.projetoTipoE}>Digite os filtros para sua pesquisa!        </Text>
            <TouchableOpacity onPress={() => { setModalVisible(!modalVisible) }}>
              <Feather name="x-circle" size={28} color="#2AB940" style={{ marginBottom: 20 }} />
            </TouchableOpacity>
          </View>

          <TextInput
            style={styles.searchInputM}
            placeholder="Instituição/Projeto..."
            placeholderTextColor="#999"
            autoCapitalize="words"
            autoCorrect={false}
            value={projeto}
            onChangeText={setProjeto}
          />
          <TextInput
            style={styles.searchInputM}
            placeholder="Atividade..."
            placeholderTextColor="#999"
            autoCapitalize="words"
            autoCorrect={false}
            value={atividade}
            onChangeText={setAtividade}
          />
          <TextInput
            style={styles.searchInputM}
            placeholder="Ods..."
            placeholderTextColor="#999"
            autoCapitalize="words"
            autoCorrect={false}
            value={ods}
            onChangeText={setOds}
          />
          <TextInput
            style={styles.searchInputM}
            placeholder="Cidade..."
            placeholderTextColor="#999"
            autoCapitalize="words"
            autoCorrect={false}
            value={cidade}
            onChangeText={setCidade}
          />


          <TouchableOpacity onPress={() => { LimparFiltros() }}>
            <Text style={styles.textLimparFiltro}>Limpar Filtros</Text>
          </TouchableOpacity>

          <TouchableOpacity
            style={{ ...styles.openButton, backgroundColor: "#2AB940" }}
            onPress={() => { getAtividades(), setModalVisible(!modalVisible) }}
          >
            <Feather name="search" size={20} color="#FFF" />
          </TouchableOpacity>
        </View>

      </Modal>




      <FlatList
        data={atividades}
        showsVerticalScrollIndicator={false}
        style={styles.listaProjetos}
        keyExtractor={atividades => String(atividades.projetoAtividadeId)}
        renderItem={({ item: atividades }) => (
          <View style={styles.projeto}>
            <Text style={styles.projetoTipo}>Projeto:</Text>
            <Text style={styles.projetoNome}>{atividades.nomeProjeto}</Text>

            <Text style={styles.projetoTipo}>Descrição do Projeto:</Text>
            <Text style={styles.projetoNome}>{atividades.descricaoProjeto}</Text>

            <Text style={styles.projetoTipo}>Atividade:</Text>
            <Text style={styles.projetoNome}>{atividades.nomeAtividade}</Text>

            <Text style={styles.projetoTipo}>Descrição da Atividade:</Text>
            <Text style={styles.projetoNome}>{atividades.descricaoAtividade}</Text>

            <Text style={styles.projetoTipo}>Habilidade Necessária:</Text>
            <Text style={styles.projetoNome}>{atividades.habilidade}</Text>

            <Text style={styles.projetoTipo}>Objetivos de Desenvolvimento Sustentável (ODS):</Text>
            <Text style={styles.projetoNome}>{atividades.ods}</Text>

            <Text style={styles.projetoTipo}>Endereço:</Text>
            <Text style={styles.projetoNome}>{atividades.endereco}, Nº {atividades.numero} / {atividades.bairro} / {atividades.cidade} / {atividades.estado}</Text>

            <View style={styles.Buttons}>

              <TouchableOpacity style={styles.botaoDetalhes} onPress={() => { Match(atividades.projetoAtividadeId) }}>
                <Text style={styles.projetoNome}>Inscrever-se </Text>
                <Feather name='check-circle' size={28} color='#2AB940' />
              </TouchableOpacity>

            </View>

          </View>
        )}
        ListEmptyComponent={ListEmptyView}
      />

    </View >
  );
};
