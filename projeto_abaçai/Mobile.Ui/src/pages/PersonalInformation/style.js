import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';

const styles = StyleSheet.create({
    background: {
        flex: 1,
        alignItems: 'center',
        justifyContent: "center",
        backgroundColor: '#FFF',
        paddingTop: Constants.statusBarHeight + 20,
    },
    inputa: {
        backgroundColor: '#ffff',
        width: 280,
        marginBottom: 15,
        borderColor: '#27b341',
        color: '#333',
        fontSize: 17,
        borderRadius: 15,
        padding: 10,
        borderRightWidth: 3,
        borderLeftWidth: 3,
        borderTopWidth: 2,
        borderBottomWidth: 2,
    },

    btnSalvar: {
        width: 70,
        height: 70,
        backgroundColor: '#2AB940',
        borderRadius: 70 / 2,
        justifyContent: 'center',
        alignItems: 'center',
        right: 99,
    },
    
    btnCancelar: {
        width: 70,
        height: 70,
        backgroundColor: '#2AB940',
        borderRadius: 70 / 2,
        justifyContent: 'center',
        alignItems: 'center',
        left: 99
    },

    viewOrientada: {
        alignItems: 'flex-start'
        
    },

    spinnerTextStyle: {
        color: '#FFF'
      },

    inputOrient: {
        backgroundColor: '#fff',
        width: '68%',
        marginBottom: 15,
        color: '#222',
        fontSize: 17,
        borderRadius: 20,
        padding: 10,
        alignItems: 'center',
        textAlign:'center',
        justifyContent: 'center',
        borderBottomWidth: 1,
        borderColor: '#CCC',
        shadowColor: '#000',
        shadowOffset: {
          width: 4,
          height: 10,
        },
        elevation: 10
    },

    inputOrient2: {
        backgroundColor: '#FFF',
        width: '20%',
        marginLeft: 10,
        marginBottom: 15,
        color: '#222',
        fontSize: 17,
        borderRadius: 20,
        padding: 10,
        borderBottomWidth: 1,
        borderColor: '#CCC',
        alignItems: 'center',
        textAlign:'center',
        justifyContent: 'center',
        shadowColor: '#000',
        shadowOffset: {
          width: 4,
          height: 10,
        },
        elevation: 10
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

    action: {
        flexDirection: "row",
        paddingBottom: 30
    },

    text: {
        color: "#333333"
    },

    top: {
        width:'90%',
        paddingTop: 20,
        marginHorizontal: 20,
        flexDirection: "row",
        justifyContent: 'space-between',
        alignItems: "center"
    },

    titulo: {
        fontSize: 22,
        marginBottom: 16,
        marginTop: 20,
        color: '#737380',
        fontWeight: 'bold',
        textAlign: 'center'
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
})

export default styles;