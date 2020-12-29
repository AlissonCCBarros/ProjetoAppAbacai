import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';


export default StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 24,
    paddingTop: Constants.statusBarHeight + 20,
  },
  titulo: {
    fontSize: 26,
    marginBottom: 16,
    marginTop: 0,
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
      width: 4,
      height: 4,
    },
    elevation: 4,
  },

  projetoTipo: {
    fontSize: 14,
    color: '#41414d',
    fontWeight: 'bold',
  },

  projetoNome: {
    fontSize: 15,
    marginBottom: 10,
    color: '#737380'
  },

  botoesMatch: {
    alignItems: 'center',
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginTop: 10,
    paddingHorizontal: '10%'
  },

  botaoAceite: {
    alignItems: 'flex-start'
  },
  botaoRecusar: {
    alignItems: 'flex-start',
    marginLeft: '25%'

  },
  iconNotificacao: {
    justifyContent: "center",
    alignItems: 'center',
    marginLeft: '50%',
  },

  body: {
    flexDirection: 'row',
    height: '100%'
  },
  containerImage: {
    width: '30%',
    marginTop: '10%'
  },
  imgUser: {
    width: 90,
    height: 90,
    borderRadius: 150 / 2,
  },
  user: {
    width: '100%',
    padding: 15,
    borderRadius: 8,
    alignItems: 'flex-start',
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
    width: '100%',
  },
  starsRating: {
    alignItems: "center",
    marginHorizontal: 6,
  },
});