import styles from './styles';

import React, { Component } from 'react';
import { Api } from '../../services/api';
import { Text, View, Image, TouchableOpacity, FlatList, ImageBackground } from 'react-native';

import Loading from '../../services/Loading'
console.disableYellowBox = true;
export default class UserProject extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoading: true,
            resultData: [],
        }
    }


    componentDidMount() {
        const { idProjeto } = this.props.route ? this.props.route.params : null;

        this.setState({ isLoading: true });

        new Api("Projeto/GetUserProject").get({ attributeBehavior: "UsuariosProjetoEspecifico", projetoId: idProjeto }).then(data => {
            var dataList = data.dataList;

            this.setState({
                isLoading: false,
                resultData: dataList,
            })
        })
    }

    _renderItem = ({ item, index }) => {
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
                        <Text style={styles.projetoTipo}>{item.nome}</Text>
                    </View>
                </View>
            </View>
        )
    }

    render() {
        return (
            <View style={styles.container}>
                <Text style={styles.textInitial}>Participantes do Projeto</Text>


                {this.state.isLoading == true ?
                    <View style={styles.loader}>
                        <Loading array={[1, 2, 3, 4]}></Loading>
                    </View>
                    : null}

                {this.state.resultData.length > 0 ?
                    <FlatList
                        data={this.state.resultData}
                        renderItem={this._renderItem}
                        keyExtractor={(item, index) => index.toString()}
                    /> : null}
                    {this.state.resultData.length <= 0 && this.state.isLoading == false  ?
                        <View style={styles.containerNotResult}>
                        <Text style={styles.titleNotResult}>Opss!</Text>
                        <Text style={styles.textNotResult}>Seu projeto ainda não tem participantes.</Text>
                    </View> : null
                    }
            </View>
        )
    }
}