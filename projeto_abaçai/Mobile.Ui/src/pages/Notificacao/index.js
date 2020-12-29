import React from 'react';
import s from './style';
import { View, FlatList, Text, TouchableOpacity, ActivityIndicator } from 'react-native';
import { Api } from '../../services/api';
import { Feather } from '@expo/vector-icons';
import { useNavigation } from '@react-navigation/native';
import Perfil from '../Perfil';

console.disableYellowBox = true;
export default class Notificacao extends React.Component {
    constructor() {
        super();
        this.state = {
            isLoading: false,
            notificacao: [],
            errorMessage: null,
        };
    }

    componentDidMount() {
        new Api("Notificacao/GetNotificacaoUsuarioLogado").get({ AttributeBehavior: "GetNotificacaoUsuarioLogado" }).then(data => {
            var dataList = data.dataList;
            console.log("aceito", dataList)
            this.setState({
                isLoading: true,
                notificacao: dataList
            })
        })
    }

    render() {
        return (
            <View style={s.container}>
                <TouchableOpacity onPress={() => { this.props.navigation.navigate('Perfil') }}>
                    <Feather name='arrow-left-circle' size={28} color='#2AB940'></Feather>
                </TouchableOpacity>
                <Text style={s.titulo}>Minhas Notificações</Text>
                {this.state.isLoading == true ?
                    <FlatList
                        data={this.state.notificacao}
                        style={s.listaProjetos}
                        keyExtractor={(item, index) => index.toString()}
                        renderItem={({ item, index }) => (
                            <View>
                                {item.ehAceito ?
                                    <View style={s.notificacaoAceito}>
                                        <Text style={s.projetoTipo}>Situação: <Text style={s.projetoAceito}>{item.titulo}</Text> </Text>
                                        <Text style={s.projetoTipo}>Descrição:</Text>
                                        <Text style={s.projetoNome} numberOfLines={3}>{item.descricao}</Text>
                                    </View> :
                                    <View style={s.notificacaoRecusado}>
                                        <Text style={s.projetoTipo}>Situação: <Text style={s.projetoRecusado}>{item.titulo}</Text></Text>
                                        <Text style={s.projetoTipo}>Descrição:</Text>
                                        <Text style={s.projetoNome} numberOfLines={3}>{item.descricao}</Text>
                                    </View>
                                }
                            </View>
                        )}
                    /> : <ActivityIndicator size="large" color="black" />}
            </View>
        );
    }
}
