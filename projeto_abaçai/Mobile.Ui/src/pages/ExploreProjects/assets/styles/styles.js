import { StyleSheet, Dimensions } from "react-native";

const DIMENSION_WIDTH = Dimensions.get("window").width;
const DIMENSION_HEIGHT = Dimensions.get("window").height;
const fullWidth = Dimensions.get('window').width;

export default StyleSheet.create({
	containerCardItem: {
		top: '5%',
		flex: 0.90,
		backgroundColor: "#FFFFFF",
		borderRadius: 8,
		alignItems: "center",
		padding: 20,
		shadowOpacity: 0.05,
		shadowRadius: 10,
		shadowColor: "#000",
		shadowOffset: { height: 4, width: 4 },
		elevation: 4
	},
	descriptionCardItem: {
		marginHorizontal: 5,
		color: "#757E90",
		textAlign: "center"
	},

	actionsCardItem: {
		flexDirection: "row",
		alignItems: "center",
		paddingVertical: 30,
	},
	button: {
		width: 60,
		height: 60,
		borderRadius: 30,
		backgroundColor: "#FFFFFF",
		marginHorizontal: 7,
		alignItems: "center",
		justifyContent: "center",
		shadowOpacity: 0.15,
		shadowRadius: 20,
		shadowColor: "#000",
		shadowOffset: { height: 10, width: 0 }
	},

	like: {
		color: "#B644B2"
	},
	dislike: {
		color: "#363636"
	},

	filters: {
		top: 10,
		backgroundColor: "#FFFFFF",
		padding: 10,
		borderRadius: 20,
		width: 70,
		shadowOpacity: 0.05,
		shadowRadius: 10,
		shadowColor: "#000",
		shadowOffset: { height: 0, width: 0 }
	},
	filtersText: {
		color: "#363636",
		fontSize: 13,
		textAlign: "center"
	},

	bg: {
		flex: 1,
	},
	bgSemProjeto: {
		flex: 1,
		alignItems: "center"
	},
	top: {
		paddingTop: 30,
		marginHorizontal: 10,
		flexDirection: "row",
		justifyContent: "flex-end",
		alignItems: "center",
		position: "absolute"
	},
	title: { paddingBottom: 10, fontSize: 22, color: "#363636" },
	icon: {
		fontSize: 20,
		color: "#363636",
		paddingRight: 10
	},

	containerHome: { marginHorizontal: 10 },

	searchInput: {
		flex: 1,
		height: 50,
		backgroundColor: "#fff",
		color: "#363636",
		borderRadius: 25,
		paddingHorizontal: 20,
		fontSize: 16,
		shadowColor: "#000",
		shadowOffset: {
			width: 4,
			height: 4,
		},
		elevation: 4,
	},
	loadButton: {
		top: -10,
		left: '98%',
		width: 40,
		height: 40,
		backgroundColor: "#2AB940",
		borderRadius: 25,
		justifyContent: "center",
		alignItems: "center",
		marginLeft: 15,
		shadowOpacity: 0.05,
		shadowRadius: 10,
		shadowColor: "#000",
		shadowOffset: { height: 4, width: 4 },
		position: 'absolute',
	},

	nameStyle: {
		paddingTop: 15,
		paddingBottom: 5,
		color: '#363636',
		fontSize: 15,
		textAlign: "center",

	},

	nameStyleSemProjeto: {
		paddingTop: 15,
		paddingBottom: 5,
		color: '#363636',
		fontSize: 15,
		textAlign: "center"
	},

	imageStyle:
	{
		borderRadius: 8,
		width: 300,
		height: 170,
		margin: 15,
	},

	imageStyleAbacai:
	{
		borderRadius: 8,
		width: 300,
		height: 135,
		margin: 15,
	},

	spinnerTextStyle: {
		color: '#FFF'
	},

	viewSemProjetos: {
		top: '12%',
		width: '90%',
		marginVertical: 200,
		flex: 0.55,
		backgroundColor: "#FFFFFF",
		borderRadius: 8,
		alignItems: "center",
		justifyContent: "center",
		padding: 20,
		shadowColor: "#000",
		shadowOffset: {
			width: 0,
			height: 12,
		},
		shadowOpacity: 0.58,
		shadowRadius: 16.00,

		elevation: 24,
	}

});
