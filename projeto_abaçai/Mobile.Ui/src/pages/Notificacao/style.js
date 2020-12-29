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

    notificacaoAceito: {
        padding: 24,
        borderRadius: 8,
        backgroundColor: '#fff',
        marginBottom: 16,
        borderBottomWidth: 2,
        borderBottomLeftRadius: 8,
        borderBottomRightRadius: 8,
        borderBottomColor: '#2AB940',
        shadowColor: "#000",
        shadowOffset: {
          width: 0,
          height: 6,
        },
        shadowOpacity: 1.00,
        shadowRadius: 18.00,    
        elevation: 4,
    },
    notificacaoRecusado: {
        padding: 24,
        borderRadius: 8,
        backgroundColor: '#fff',
        marginBottom: 16,
        borderBottomWidth: 2,
        borderBottomLeftRadius: 8,
        borderBottomRightRadius: 8,
        borderBottomColor: '#BB0000',
        shadowColor: "#000",
        shadowOffset: {
          width: 0,
          height: 6,
        },
        shadowOpacity: 1.00,
        shadowRadius: 18.00,    
        elevation: 4,
    },

    projetoAceito: {
        fontSize: 14,
        color: '#2AB940',
        fontWeight: 'bold'
    },
    projetoRecusado: {
        fontSize: 14,
        color: '#BB0000',
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
    btnHome: {
        position: 'absolute',
        left: 10,
        top: 30,
        alignItems: 'center',
        justifyContent: 'center',
    },
});