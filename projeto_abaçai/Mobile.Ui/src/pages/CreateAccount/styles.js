import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  containerLogo: {
    flex: 1,
    marginTop: '20%',
    alignItems: 'center',
    justifyContent: 'center',
  },
  main: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  background: {
    marginTop: '10%',
    alignItems: "center",
    width: '95%',
    height: '80%',
    backgroundColor: '#FDFDFD',
    borderRadius: 10
  },
   input: {
    backgroundColor: '#FFF',
    width: '90%',
    marginLeft: 18,
    color: '#222',
    fontSize: 17,
    borderRadius: 20,
    marginBottom: 15,
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
    backgroundColor: '#70D66C',
    width: '50%',
    height: 45,
    alignItems: 'center',
    justifyContent: 'center',
    borderRadius: 20,
    marginBottom: -20,
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
  scrollview: {
    width: '90%',
    height: '100%'
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