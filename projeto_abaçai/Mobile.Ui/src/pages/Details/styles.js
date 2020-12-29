import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';


export default StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 24,
    paddingTop: Constants.statusBarHeight,
  },

  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 20,
    marginTop: 20
  },

  titulo: {
    fontSize: 22,
    marginBottom: 16,
    marginTop: 20,
    color: '#737380',
    fontWeight: 'bold',
    textAlign: 'center'
  },

  top: {
    width: '90%',
    paddingTop: 20,
    marginHorizontal: 20,
    flexDirection: "row",
    justifyContent: 'space-between',
    alignItems: "center",
    marginBottom: 6

  },

  projeto: {
    padding: 24,
    borderRadius: 8,
    backgroundColor: '#fff',
    marginBottom: 8,
    marginTop: 6,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 12,
    },
    shadowOpacity: 0.58,
    shadowRadius: 16.00,

    elevation: 10,
  },
  circleImg: {
    width: 38,
    height: 38,
    marginRight: 10,   
},

  loadButton: {
    width: 50,
    height: 50,
    backgroundColor: "#2AB940",
    borderRadius: 25,
    justifyContent: "center",
    alignItems: "center",
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
    marginTop: 24,
    fontWeight: 'bold'
  },

  projetoNome: {
    marginTop: 8,
    fontSize: 15,
    color: '#737380'
  },

});