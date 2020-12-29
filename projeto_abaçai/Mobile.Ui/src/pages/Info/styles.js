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
    marginTop: 20
  },
  container: {
    alignItems: 'center',
    justifyContent: 'center',
    width: '100%',
    height: '20%',
  },
  main: {
    alignItems: 'center',
    width: '95%',
    backgroundColor: '#fff',
    borderRadius: 10,
    height: '90%'
  },
  txtGreen: {
    fontSize: 30,
    marginBottom: 16,
    marginTop: '100%',
    color: '#3A5276',
    fontWeight: 'bold',
    textAlign: 'center'
  },
  txtDescQuestion: {
    fontSize: 14,
    marginBottom: 20,
    fontWeight: 'bold',
  },
  txtDesc: {
    fontSize: 14,
  },
  txtInfoUser: {
    fontSize: 14,
    marginTop: 20,
  },
  containerDesc: {
    width: '95%',
    marginBottom: 35
  },
  body: {
    flexDirection: 'row',
    height: 80,
  },
  containerImage: {
    width: '30%',
    alignItems: 'center'
  },
  imgUser: {
    width: 70,
    height: 70,
  },
  user: {
    width: '70%',
    alignItems: 'flex-start',
  },
  infoUsers: {
    marginTop: 5,
    width: '100%'
  },
  txtNome:{
    fontWeight: 'bold',
  },
  iconEmail: {
    fontWeight: 'bold',
    marginRight: 20,
  },
  containerIcons: {
    flexDirection: 'row',
    alignItems: 'flex-end',
    marginTop: 8,
  }
})

export default styles;