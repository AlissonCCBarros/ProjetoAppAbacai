import React from 'react';
import { Feather } from '@expo/vector-icons';
import { View, FlatList, Text, TouchableOpacity, Alert, Image } from 'react-native';

import styles from './styles';

import * as Auth from '../../services/auth';

import Spinner from 'react-native-loading-spinner-overlay';

import { Api } from '../../services/api';

import Loading from '../../services/Loading'
console.disableYellowBox = true;
export default function Home({ navigation }) {


  const [ehInstituicao, setEhInstituicao] = React.useState();
  const [spinner, setSpinner] = React.useState(false);
  const [projetos, setProjetos] = React.useState([]);
  const [loading, setLoading] = React.useState(true);

  function carregarProjetos() {
    setLoading(true);
    new Api("Projeto/GetUserProject").get({ attributeBehavior: "ListarProjetosUsuario" }).then(data => {
      var dataList = data.dataList
      console.log('testeeaaaaaaaaa', dataList);
      setProjetos(dataList)
      setLoading(false);
    })
  }

  React.useEffect(() => {

    async function isInstituicao() {

      setEhInstituicao(
        await Auth.isInstituicao()
      );
    }

    isInstituicao();
    carregarProjetos();
  }, []);

  function deletarProjeto(id) {
    Alert.alert("Confirmação",
      "Tem certeza que deseja deletar esse projeto?",
      [
        {
          text: 'Cancelar',
          style: 'cancel'
        },
        {
          text: 'Deletar',
          onPress: () => {
            setSpinner(true);
            new Api("Projeto")
              .post({ ProjetoId: id, AttributeBehavior: "DeletarProjeto" })
              .then(data => {
                setSpinner(false);
                Alert.alert(
                  'Sucesso!',
                  "Seu projeto foi deletado."
                )
                carregarProjetos()
              })
              .catch(err => {
                setSpinner(false);
                if (err.data != null && err.data.errors.length > 0)
                  Alert.alert('Opss!', err.data.errors[0]);
                else
                  Alert.alert('Opss!', "Não conseguimos nos conectar com nosso servidor, tente novamente em instantes.");
              });
          }
        }
      ])
  }

  function encerrarProjeto(id) {
    Alert.alert("Confirmação",
      "Ao clicar em encerrar, seu projeto será encerrado e todos os participantes ganharão uma avaliação.",
      [
        {
          text: 'Cancelar',
          style: 'cancel'
        },
        {
          text: 'Encerrar',
          onPress: () => {
            setSpinner(true);
            new Api("Projeto")
              .post({ ProjetoId: id, AttributeBehavior: "EncerrarProjeto" })
              .then(data => {
                setSpinner(false);
                Alert.alert(
                  'Sucesso!',
                  "Seu projeto foi encerrado."
                )
                carregarProjetos()
              })
              .catch(err => {
                setSpinner(false);
                if (err.data != null && err.data.errors.length > 0)
                  Alert.alert('Opss!', err.data.errors[0]);
                else
                  Alert.alert('Opss!', "Não conseguimos nos conectar com nosso servidor, tente novamente em instantes.");
              });
          }
        }
      ])
  }

  return (
    <View style={styles.container}>

      <Spinner
        visible={spinner}
        textContent={'Carregando...'}
        textStyle={styles.spinnerTextStyle}
      />

      {ehInstituicao == true ? <TouchableOpacity onPress={() => { navigation.navigate("CreateProject") }} style={styles.loadButton}>
        <Feather name="plus-circle" size={30} color="#FFF" />
      </TouchableOpacity> : null}

      <Text style={styles.titulo}>Olá!</Text>
      {ehInstituicao == true ? <Text style={styles.descricao}>Projetos que você criou</Text> : <Text style={styles.descricao}>Projetos que você fez a diferença</Text>}

      { loading == true ? <Loading array={[1, 2, 3, 4]}></Loading> :

      <FlatList
        data={projetos}
        style={styles.listaProjetos}
        keyExtractor={projetos => String(projetos.idProjeto)}
        renderItem={({ item: projetos }) => (
          <View style={styles.projeto}>

            <View style={styles.containerImgProjeto}>

              {projetos.foto == null || projetos.foto == '' ?
                <Image style={styles.imgProjeto} source={require('../../assets/AbacaiHome.png')}>
                </Image>
                : <Image style={styles.imgProjeto} source={{ uri: projetos.foto }}>
                </Image>
              }

            </View>
            <Text style={styles.projetoTipo}>Intituição/Projeto:</Text>
            <Text style={styles.projetoNome}>{projetos.nomeProjeto}</Text>

            {ehInstituicao == true ? null : <Text style={styles.projetoTipo}>Atividade:</Text>}
            {ehInstituicao == true ? null : <Text style={styles.projetoNome}>{projetos.nomeAtividade}</Text>}

            <Text style={styles.projetoTipo}>{ehInstituicao == true ? "Descrição do Projeto:" : "Descrição da Atividade:"}</Text>
            <Text style={styles.projetoNome}>{ehInstituicao == true ? projetos.descricaoProjeto : projetos.descricaoAtividate}</Text>

            <View style={styles.Buttons}>
              {ehInstituicao == true
                ?
                <TouchableOpacity style={styles.botaoDetalhes} onPress={() => { navigation.navigate("DetailsInst", { projetos }) }}>
                  <Feather name='plus-circle' size={28} color='#2AB940' />
                </TouchableOpacity>
                :
                <TouchableOpacity style={styles.botaoDetalhes} onPress={() => { navigation.navigate("Details", { projetos }) }}>
                  <Feather name='plus-circle' size={28} color='#2AB940' />
                </TouchableOpacity>
              }

              <TouchableOpacity style={styles.botaoUser} onPress={() => { navigation.navigate("UserProject", { idProjeto: projetos.idProjeto }) }}>
                <Feather name='users' size={28} color='#00BFFF' />
              </TouchableOpacity>

              {ehInstituicao == true ?
                <TouchableOpacity style={styles.botaoDelete} onPress={() => { deletarProjeto(projetos.idProjeto) }}>
                  <Feather name='trash-2' size={28} color='red' />
                </TouchableOpacity>
                : null}

              {ehInstituicao == true && projetos.podeEncerrarProjeto == true ?
                <TouchableOpacity style={styles.botaoDelete} onPress={() => { encerrarProjeto(projetos.idProjeto) }}>
                  <Feather name='check-square' size={28} color='#DAA520' />
                </TouchableOpacity>
                : null}
            </View>

          </View>
        )}
      />}


    </View>
  );
}