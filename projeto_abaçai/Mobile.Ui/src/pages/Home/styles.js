import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';


export default StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 24,
    paddingTop: Constants.statusBarHeight,
  },
  titulo: {
    fontSize: 30,
    marginBottom: 16,
    marginTop: 10,
    color: '#2AB940',
    fontWeight: 'bold',
    textAlign: 'center'
  },

  descricao: {
    fontSize: 16,
    lineHeight: 24,
    color: '#737380',
    textAlign: 'center'
  },

  listaProjetos: {
    marginTop: 32
  },

  projeto: {
    padding: 24,
    borderRadius: 8,
    backgroundColor: '#fff',
    marginBottom: 16,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 12,
    },
    shadowOpacity: 0.58,
    shadowRadius: 16.00,

    elevation: 2,
  },

  projetoTipo: {
    fontSize: 14,
    color: '#41414d',
    fontWeight: 'bold'
  },

  projetoNome: {
    marginTop: 8,
    fontSize: 15,
    marginBottom: 16,
    color: '#737380'
  },

  botaoDetalhes: {
    justifyContent: 'center',
    alignItems: 'center',
    marginRight: 35
  },

  botaoDelete: {
    justifyContent: 'center',
    alignItems: 'center',
    marginLeft: 35
  },
  searchInput: {
    flex: 1,
    height: 50,
    backgroundColor: "#fff",
    color: "#363636",
    borderRadius: 25,
    paddingHorizontal: 20,
    fontSize: 16,
    shadowColor: "#000",
    shadowOffset: {
      width: 4,
      height: 4,
    },
    elevation: 4,
  },
  loadButton: {
    marginTop: 10,
    right: 10,
    width: 50,
    height: 50,
    backgroundColor: "#2AB940",
    borderRadius: 25,
    justifyContent: "center",
    alignItems: "center",
    marginLeft: 15,
    shadowColor: "#000",
    shadowOffset: {
      width: 4,
      height: 4,
    },
    elevation: 4,
    alignSelf: "flex-end"
  },
  Buttons: {
    flexDirection: 'row',
    alignSelf: 'center'
  },
  spinnerTextStyle: {
    color: '#FFF'
  },
  containerImgProjeto: {
    alignSelf: 'center',
    marginBottom: 20,
  },
  imgProjeto: {
    height: 150,
    width: 200,
    resizeMode: 'contain',
    borderRadius: 20
  },
  NotificationCount: {
    position: 'absolute',
    width: 20,
    height: 20,
    backgroundColor: '#BB0000',
    borderRadius: 40 / 2,
    borderColor: 'white',
    borderWidth: 2,
    bottom: 50,
    right: 7,
    alignItems: 'center',
    justifyContent: 'center',
  },
  circleImg: {
    width: 38,
    height: 38,
    marginRight: 10,
  },

});