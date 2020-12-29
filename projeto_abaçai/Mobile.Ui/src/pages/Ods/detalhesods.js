import React, { Component } from 'react';
import { Api } from '../../services/api';
import { Text, View, Image, TouchableOpacity, FlatList, Dimensions, StyleSheet, Button, ScrollView, ImageBackground, ActivityIndicator } from 'react-native';
import img from './odsImage';
import s from './style'
import { FontAwesome, Feather } from '@expo/vector-icons';
import Constants from 'expo-constants';

const numColumns = 3;
const numStars = 5;
console.disableYellowBox = true;
export default class DetalhesOds extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: false,
      imageName: null,
      descricao: null,
      ehInstituicao: false,
      resultData: [],
      stars: 0,
      filled: false
    }
  }

  componentDidMount() {
    const { data } = this.props.route ? this.props.route.params : null;
    this.setState({ imageName: data.imageName, descricao: data.descricao, ehInstituicao: data.ehInstituicao });

    console.log("instituicao", this.state.ehInstituicao, data.ehInstituicao)
    if (data.ehInstituicao) {
      new Api("Projeto/GetOdsDetalhes").get({ attributeBehavior: "DetalhesOds", OdsId: data.odsId }).then(data => {
        var dataList = data.dataList;
        this.setState({
          resultData: dataList,
          isLoading: true,
          ehInstituicao: true,
        })
      })
    }
    else {
      new Api("UsuarioProjetoAtividade/GetOdsDetalhes").get({ attributeBehavior: "DetalhesOds", OdsId: data.odsId }).then(data => {
        var dataList = data.dataList;
        var avaliacao = data.dataList.map((item) => { return item.avaliacao })
        this.setState({
          resultData: dataList,
          stars: avaliacao[0],
          isLoading: true,
          ehInstituicao: false,
        })
      })
    }

  }

  render() {
    let stars = [];
    for (let x = 1; x <= numStars; x++) {
      stars.push(
        <Star filled={x <= this.state.stars ? true : false} />
      )
    }

    return (
      <View style={styles.container}>


        <ImageBackground source={img.obs[this.state.imageName]} blurRadius={2} style={styles.cardImg}>
          <Image source={img.obs[this.state.imageName]} style={styles.odsImg} />

        </ImageBackground>
        <TouchableOpacity style={s.btnHome} onPress={() => { this.props.navigation.navigate('Ods'); }}>
          <Feather name='arrow-left-circle' size={28} color='#ffff'></Feather>
        </TouchableOpacity>
        <View style={{ width: '100%', alignItems: "center", height: 60 }}>
          {this.state.ehInstituicao ? null : <View style={{ flexDirection: "row", top: 20 }}>{stars}</View>}
        </View>
        <ScrollView>
          {this.state.isLoading == true ?
            <View>
              <View style={styles.listContainer}>
                <Text style={styles.projetoTipo}>Descrição:</Text>
                <Text style={styles.projetoNome}>{this.state.descricao}.</Text>
              </View>
              <View style={styles.listContainer}>
                <Text style={styles.projetoTipo}>Projetos:</Text>
                {this.state.resultData.map((item, i) => { return (<Text style={styles.projetoNome}>{i + 1} - {item.projeto}</Text>) })}
              </View>
              <View style={styles.listContainer}>
                <Text style={styles.projetoTipo}>Atividades:</Text>
                {this.state.resultData.map((item, i) => { return (<Text style={styles.projetoNome}>{i + 1} - {item.atividade}</Text>) })}
              </View>
            </View> : <ActivityIndicator size="large" color="black" />}
        </ScrollView>
      </View>
    )
  }
}
class Star extends Component {

  render() {
    return (
      <FontAwesome style={styles.starsRating} name={this.props.filled === true ? "star" : "star-o"} size={25} color="#edd318" />
    )
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: Constants.statusBarHeight,
    alignItems: "center",
  },
  cardImg: {
    justifyContent: "center",
    alignItems: "center",
    minHeight: 180,
    maxHeight: 180,
    width: '100%',
    borderColor: 'white',
    borderWidth: 1,
  },
  odsImg: {
    position: 'absolute',
    borderColor: 'white',
    borderWidth: 1,
    height: '95%',
    width: '50%',
    borderRadius: 8
  },
  listContainer: {
    margin: 10,
    padding: 15,
    borderRadius: 10,
    backgroundColor: '#fff',
    marginBottom: 16,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 12,
    },
    shadowOpacity: 0.58,
    shadowRadius: 16.00,

    elevation: 4,
  },
  projetoTipo: {
    fontSize: 14,
    color: '#41414d',
    fontWeight: 'bold'
  },
  projetoNome: {
    marginTop: 1,
    fontSize: 15,
    marginBottom: 1,
    color: '#737380'
  },
  starsRating: {
    alignItems: "center",
    marginHorizontal: 6,
  },
  btnCompartilhar: {
    backgroundColor: "#0059ff",
    alignItems: "center",
    borderWidth: 1,
    height: 42,
    width: "50%",
    justifyContent: "center",
    borderRadius: 20
  },
  compartilhar: {
    margin: 10,
    padding: 15,
    borderRadius: 10,
    backgroundColor: '#fff',
    marginBottom: 16,
    borderWidth: 2,
    borderColor: 'gray',
    alignItems: "center",
    bottom: 10
  }
});