import React from 'react';
import s from './style';
import { Api } from '../../services/api';
import { View, FlatList, Text, TouchableOpacity, ActivityIndicator } from 'react-native';
import { Feather } from '@expo/vector-icons';


console.disableYellowBox = true;
export default class NotificacaoInstituto extends React.Component {
    constructor() {
        super();
        this.state = {
            isLoading: false,
            projetos: [],
            errorMessage: null,
        };
    }

    componentDidMount() {
        new Api("Match/GetProjetosInstituicao").get({ AttributeBehavior: "GetProjetosInstituicao" }).then(data => {
            var dataList = data.dataList;

            this.setState({
                isLoading: true,
                projetos: dataList
            })
        })
    }

    render() {
        return (
            <View style={s.container}>
                <TouchableOpacity onPress={() => { this.props.navigation.navigate('Perfil'); }}>
                    <Feather name='arrow-left-circle' size={28} color='#2AB940'></Feather>
                </TouchableOpacity>
                <Text style={s.titulo}>Minhas Notificações</Text>
                {this.state.isLoading == true ?
                    <FlatList
                        data={this.state.projetos}
                        style={s.listaProjetos}
                        keyExtractor={(item, index) => index.toString()}
                        renderItem={({ item, index }) => (
                            <View style={s.projeto}>
                                <TouchableOpacity onPress={() => { this.props.navigation.navigate("detalhesNotificacao", { projetoAtividadeId: item.projetoAtividadeId }) }} >
                                    {item.temNotificaco ? <Feather style={s.iconNotificacao} name='bell' size={20} color='red'></Feather> : null}
                                    <View>
                                        <Text style={s.projetoTipo}>Projeto:</Text>
                                        <Text style={s.projetoNome}>{item.nome}</Text>
                                        <Text style={s.projetoTipo}>Atividade:</Text>
                                        <Text style={s.projetoNome}>{item.atividade}</Text>
                                        <Text style={s.projetoTipo}>Descrição:</Text>
                                        <Text style={s.projetoNome}>{item.descricao}</Text>
                                    </View>
                                </TouchableOpacity>
                            </View>
                        )}
                    /> : <ActivityIndicator size="large" color="black" />}
            </View>
        );
    }
}
