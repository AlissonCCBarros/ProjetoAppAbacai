import { StyleSheet, Dimensions } from 'react-native';
import Constants from 'expo-constants';


export default StyleSheet.create({
	container: {
		flex: 1,
		paddingHorizontal: 24,
		paddingTop: Constants.statusBarHeight + 20,
	},

	header: {
		paddingTop: '3%',
		marginHorizontal: 10,
		flexDirection: "row",
		// justifyContent: "flex-end",
		alignItems: "center"
	},

	listaProjetos: {
		marginTop: 0
	},

	projeto: {
		padding: 24,
		marginBottom: 0,
		borderBottomWidth: 1,
		borderBottomColor: "#2AB940"
	},

	projetoTipo: {
		fontSize: 14,
		color: '#41414d',
		marginTop: 5,
		fontWeight: 'bold'
	},

	projetoTipoE: {
		fontSize: 14,
		color: '#41414d',
		marginTop: 5,
		fontWeight: 'bold',
		marginBottom: 20,
		marginTop: -5
	},

	projetoNome: {
		fontSize: 14,
		color: '#737380'
	},

	searchInput: {
		flex: 1,
		height: 45,
		backgroundColor: "#fff",
		color: "#363636",
		borderRadius: 25,
		paddingHorizontal: 20,
		fontSize: 14,
		shadowColor: "#000",
		shadowOffset: {
			width: 4,
			height: 4,
		},
		elevation: 4,
	},
	searchInputM: {
		height: 45,
		width: '100%',
		marginBottom: 20,
		backgroundColor: "#fff",
		color: "#363636",
		borderRadius: 25,
		paddingHorizontal: 20,
		fontSize: 14,
		shadowColor: "#000",
		shadowOffset: {
			width: 4,
			height: 4,
		},
		elevation: 4,
	},
	loadButton: {
		width: 45,
		height: 45,
		backgroundColor: "#2AB940",
		borderRadius: 25,
		justifyContent: "center",
		alignItems: "center",
		marginLeft: 15,
		shadowColor: "#000",
		shadowOffset: {
			width: 4,
			height: 4,
		},
		elevation: 4,
	},
	centeredView: {
		flex: 1,
		justifyContent: "center",
		alignItems: "center",
		marginTop: 22
	},
	modalView: {
		marginTop: '35%',
		margin: 20,
		backgroundColor: "white",
		borderRadius: 20,
		padding: 35,
		alignItems: "center",
		shadowColor: "#000",
		shadowOffset: {
			width: 0,
			height: 2
		},
		shadowOpacity: 0.25,
		shadowRadius: 3.84,
		elevation: 5
	},
	openButton: {
		backgroundColor: "#2AB940",
		borderRadius: 20,
		padding: 10,
		elevation: 2,
		flexDirection: 'row'
	},
	textStyle: {
		color: "white",
		fontWeight: "bold",
		textAlign: "center"
	},
	modalText: {
		marginBottom: 15,
		textAlign: "center"
	},
	Buttons: {
		marginTop: 20,
		flexDirection: 'row',
		alignSelf: 'center',
	},
	botaoDetalhes: {
		justifyContent: 'center',
		alignItems: 'center',
		flexDirection: 'row'
	},
	spinnerTextStyle: {
		color: '#FFF'
	},
	textLimparFiltro: {
		color: '#2AB940',
		justifyContent: 'flex-end',
		marginBottom: 20
	},
	headerText: {
		padding: 10,
		marginTop: Dimensions.get('window').height / 3,
		height: 40,
	},
	textNoData: {
		textAlign: 'center',
		fontSize: 20,
		color: '#2AB940',
	}

});