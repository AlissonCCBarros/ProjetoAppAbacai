import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';


export default StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 24,
    paddingTop: Constants.statusBarHeight,
    alignItems: 'center'
  },

  body: {
    flexDirection: 'row',
    height: 105
  },

  projetoTipo: {
    fontSize: 14,
    color: '#41414d',
    fontWeight: 'bold'
  },

  containerImage: {
    width: '30%',
  },

  imgUser: {
    width: 90,
    height: 90,
    borderRadius: 150 / 2,
  },

  user: {
    width: '70%',
    alignItems: 'flex-start',
    padding: 15,
    borderRadius: 8,
    backgroundColor: '#fff',
    marginBottom: 16,
    shadowColor: "#000",
    shadowOffset: {
      width: 4,
      height: 4,
    },
    elevation: 1,
  },

  infoUsers: {
    width: '70%',
    marginTop: 12,
    marginLeft: '15%'
  },

  buttons: {
    alignItems: 'center'
  },

  buttonsUser: {
    width: '30%',
    marginTop: '5%',
    flexDirection: 'row',
    alignItems: 'center'
  },
  botaoDetalhes: {
    justifyContent: 'center',
    alignItems: 'center',
  },

  botaoDelete: {
    justifyContent: 'center',
    alignItems: 'center'
  },
  textInitial: {
    marginTop: '10%',
    fontSize: 20,
    color: '#2AB940',
    fontWeight: 'bold',
    marginBottom: '10%',
    justifyContent: 'center',
    alignItems: 'center'
  },
  shimmer: {
    height: 35,
    margin: 10,
    borderRadius: 10
  },
  containerNotResult: {
    backgroundColor: '#FFF',
    width: '90%',
    height: 150,
    borderRadius: 20,
    marginTop: '50%',
    justifyContent: 'center',
    alignItems: 'center',
    shadowColor: "#000",
    shadowOffset: {
      width: 4,
      height: 4,
    },
    elevation: 10,
  },
  titleNotResult: {
    fontSize: 20,
    marginTop: '35%'
  },
  loader: {
    flex: 1,
    width: '100%'
  }

});