import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';


export default StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 24,
    paddingTop: Constants.statusBarHeight,
    backgroundColor: '#F5F2F2',    
  },
  titulo: {
    fontSize: 22,
    marginBottom: 16,
    marginTop: 20,
    color: '#737380',
    fontWeight: 'bold',
    textAlign: 'center'
  },

  containerInput: {
    alignItems: 'center',
    justifyContent: 'center'
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
    elevation: 10,
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
    flexDirection: 'row',
    justifyContent: 'center',
    alignItems: 'center'
  },
  input: {
    backgroundColor: '#FFF',
    width: '90%',
    marginBottom: 15,
    color: '#222',
    fontSize: 17,
    borderRadius: 20,
    padding: 10,
    borderBottomWidth: 1,
    borderColor: '#CCC',
    textAlign:'center',
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 4,
      height: 10,
    },
    elevation: 10
  },

  inputDate: {
    backgroundColor: '#FFF',
    width: '75%',
    marginBottom: 15,
    color: '#222',
    fontSize: 17,
    borderRadius: 20,
    padding: 10,
    borderBottomWidth: 1,
    borderColor: '#CCC',
    textAlign:'center',
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 4,
      height: 10,
    },
    elevation: 10
  },
  icon: {
    marginTop: 20
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
  calendarButton: {
    marginBottom:15,
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
  containerDate: {
    marginTop: 10,
    flexDirection: 'row',
    justifyContent: 'space-between'
  },
  top: {
    width:'90%',
    paddingTop: 20,
    marginHorizontal: 20,
    flexDirection: "row",
    justifyContent: 'space-between',
    alignItems: "center"
  },

});