import React from 'react';
import styles from './style';
import { Api } from '../../services/api';
import { View, FlatList, Text, TouchableOpacity, Image, ActivityIndicator } from 'react-native';
import { Feather, FontAwesome } from '@expo/vector-icons';

const numStars = 5;
console.disableYellowBox = true;
export default class detalhesNotificacao extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoading: false,
            usuarios: [],
            errorMessage: null,
            filled: false,
            projetoAtividadeId: null,
        };
    }

    componentDidMount() {
        const { projetoAtividadeId } = this.props.route ? this.props.route.params : null;
        this.setState({ projetoAtividadeId: projetoAtividadeId })
        new Api("Match/GetProjetosInstituicao").get({ AttributeBehavior: "GetMatchUsuariosDoProjeto", ProjetoAtividadeId: projetoAtividadeId }).then(data => {
            var dataList = data.dataList;

            console.log("usuarios desse projeto", dataList)
            this.setState({
                isLoading: true,
                usuarios: dataList
            })
        })
    }
    aprovarUsuario(usuarioId) {
        new Api("UsuarioProjetoAtividade").post({ AttributeBehavior: "SalvarUsuarioAprovado", ProjetoAtividadeId: this.state.projetoAtividadeId, UsuarioId: usuarioId }).then(data => {
            this.componentDidMount()
        })
    }
    recusarUsuario(usuarioId, matchId) {
        new Api("Match").delete({ AttributeBehavior: "DeletarUsuarioRecusado", ProjetoAtividadeId: this.state.projetoAtividadeId, UsuarioId: usuarioId, MatchId: matchId }).then(data => {
            this.componentDidMount()
        })
    }

    _renderItem = ({ item, index }) => {
        let stars = [];
        for (let x = 1; x <= numStars; x++) {
            stars.push(
                <Star filled={x <= item.avaliacao ? true : false} />
            )
        }

        return (
            <View style={styles.body}>
                <View style={styles.containerImage}>
                    {item.foto == null ?
                        <Image style={styles.imgUser} source={require('../../assets/avatar.png')}>
                        </Image> :
                        <Image style={styles.imgUser} source={{ uri: item.foto }}>
                        </Image>
                    }
                </View>
                <View style={styles.user}>
                    <View style={styles.infoUsers}>
                        <View style={{ flexDirection: "row" }}>{stars}</View>
                        <Text style={styles.projetoTipo}>Nome: {item.nome}</Text>
                        <Text style={styles.projetoTipo}>Email: {item.email}</Text>
                        <Text style={styles.projetoTipo}>Contato: {item.telefone}</Text>
                    </View>
                    <View style={styles.botoesMatch}>
                        <TouchableOpacity style={styles.botaoAceite} onPress={() => { this.aprovarUsuario(item.usuarioId) }}>
                            <Feather name='check-circle' size={35} color='#2AB940' />
                        </TouchableOpacity>
                        <TouchableOpacity style={styles.botaoRecusar} onPress={() => { this.recusarUsuario(item.usuarioId, item.matchId) }}>
                            <Feather name='x-circle' size={35} color='red' />
                        </TouchableOpacity>
                    </View>
                </View>
            </View>
        )
    }


    render() {
        return (
            <View style={styles.container}>
                <TouchableOpacity onPress={() => { this.props.navigation.navigate('NotificacaoInstituto'); }}>
                    <Feather name='arrow-left-circle' size={28} color='#2AB940'></Feather>
                </TouchableOpacity>
                <Text style={styles.titulo}>Aceites</Text>
                {this.state.isLoading == true ?
                    <FlatList
                        data={this.state.usuarios}
                        renderItem={this._renderItem}
                        keyExtractor={(item, index) => index.toString()}
                    /> : <ActivityIndicator size="large" color="black" />}
            </View>
        );
    }

}
class Star extends React.Component {

    render() {
        return (
            <FontAwesome style={styles.starsRating} name={this.props.filled === true ? "star" : "star-o"} size={25} color="#edd318" />
        )
    }
}
