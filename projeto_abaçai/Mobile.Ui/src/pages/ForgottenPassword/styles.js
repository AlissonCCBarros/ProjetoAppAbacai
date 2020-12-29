import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  background: {
    flex: 1,
    width: '100%',
    alignItems: 'center',
    justifyContent: 'center',
  },
  containerLogo: {
    justifyContent: 'center',
    marginBottom: '20%',
    marginTop: '5%'
  },
  container: {
    alignItems: 'center',
    justifyContent: 'center',
    width: '100%',
    height: '28%',
    marginTop: '-10%'
  },
  main: {
    alignItems: 'center',
    justifyContent: 'center',
    width: '95%',
    backgroundColor: '#fff',
    borderRadius: 10
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
    alignItems: 'center',
    justifyContent: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 4,
      height: 10,
    },
    elevation: 10
  },
  btnSubmit: {
    marginTop: 10,
    backgroundColor: '#70D66C',
    width: '50%',
    height: 45,
    alignItems: 'center',
    justifyContent: 'center',
    borderRadius: 20,
    shadowColor: '#000',
    shadowOffset: {
      width: 4,
      height: 10,
    },
    elevation: 10
  },
  submitText: {
    color: '#FFF',
    fontSize: 18
  },
  btnRegister: {
    marginTop: 10
  },
  registerText: {
    color: '#FFF'
  },
  btnReset: {
    marginTop: '15%'

  },
  textEmail:{
    marginBottom: 10
  },
  textRecuperar:{
    fontSize: 25,
    //fontWeight: "bold",
    marginBottom: 15
  },
  spinnerTextStyle: {
    color: '#FFF'
  },
  btnInfo: {
    marginTop: '15%',
    marginRight: '10%',
    alignSelf: 'flex-end',
    borderRadius: 40 / 2,
  }
})

export default styles;