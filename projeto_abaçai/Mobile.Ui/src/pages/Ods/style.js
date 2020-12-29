import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';
import { Dimensions } from 'react-native';

const numColumns = 3;
const WIDTH = Dimensions.get('window').width;

export default StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 5,
    paddingTop: 10,
  },
  titulo: {
    fontSize: 30,
    marginBottom: 16,
    marginTop: 48,
    color: '#2AB940',
    fontWeight: 'bold',
    textAlign: 'center'
    },
    btnHome: {
    position: 'absolute',
    left: 10,
    paddingTop: Constants.statusBarHeight + 20,
    alignItems: 'center',
    justifyContent: 'center',
    },
    cards:{
      backgroundColor:'white',
      alignItems: 'center',
      justifyContent: 'center',
      height:100,
      flex:1,
      borderRadius: 8,
      height: WIDTH/ numColumns,
    },
    cardOds:{
      position: 'absolute',
      height:'100%',
      width: '100%',
      borderRadius: 8
    },
    grayScale:{
      opacity: 0.8,
      tintColor:"gray",
      height:'100%',
      width: '100%',
      borderRadius: 8
    },
    itemInvisible:{
        backgroundColor: 'transparent'
    }
   
});
