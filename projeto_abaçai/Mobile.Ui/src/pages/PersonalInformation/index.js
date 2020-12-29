import React, { Component } from 'react';
import {
    KeyboardAvoidingView, TextInput, Image, View, Button, FlatList, Alert, Platform,
    StyleSheet,
    Text,
    ScrollView,
    Switch,
    TouchableWithoutFeedback,
    TouchableOpacity,
    ActivityIndicator,
    Dimensions,
    LayoutAnimation,
} from 'react-native';
import { Api } from '../../services/api';
console.disableYellowBox = true;
import { TextInputMask } from 'react-native-masked-text'
import { Feather } from '@expo/vector-icons';
import Styles from './style';
import SectionedMultiSelect from 'react-native-sectioned-multi-select';
import Spinner from 'react-native-loading-spinner-overlay';
import * as Auth from '../../services/auth';
import { Colors } from 'react-native/Libraries/NewAppScreen';
import { set } from '../../services/cache';
const img = require('./z.jpg');
console.disableYellowBox = true;
const items = [
    {
        title: 'Musica',
        id: 0,

        children: [
            {
                title: 'Violão',
                id: 1,
            },
            {
                title: 'Teclado',
                id: 2,
            },
            {
                title: 'Violino',
                id: 3,
            },
        ],
    },
    {
        title: 'Esportes',
        id: 10,
        icon: 'cake',
        children: [
            {
                title: 'Luta',
                id: 4,
            },
            {
                title: 'Atletismo',
                id: 5,
            },
            {
                title: 'Dança',
                id: 6,
            },
            {
                title: 'Ginástica',
                id: 7,
            },
        ],
    }
]

export default class Login extends Component {
    constructor(props) {
        super(props)

        this.state = {
            selectedItems: [],
            usuariox: {},
            enderecox: {},
            Usuario: {
                nome: '',
                email: '',
                cpF_CNPJ: '',
                iE_RG: '',
                telefone: '',
                celular: '',
                usuarioId: '',
                enderecoId: '',
                Endereco: {
                    cEP: '',
                    rua: '',
                    numero: 0,
                    cidade: '',
                    bairro: '',
                    estado: '',
                    enderecoId: 0
                },
                Account: {
                    Password: '',
                },
            },

            UsuarioHabilidade: {
                usuarioId: 0,
                habilidadeId: 0,
                usuarioHabilidadeId: 0,
                UsuarioHabilidades: []
            },

            nome: '',
            email: '',
            cpF_CNPJ: '',
            iE_RG: '',
            telefone: '',
            celular: '',
            usuarioId: '',
            verificarRG: '',


            //endereco
            cEP: ' ',
            enderecoId: '',
            rua: '',
            numero: 0,
            cidade: '',
            bairro: '',
            estado: '',

            //Account
            passwordx: '',
            Account: {
                accountId: 0,
                name: '',
                email: '',
                password: '',
                admin: '',
            },
            spinner: false,
            ehInstituicao: false,
        };
    }

    SalvarAlteracoes(item) {

        this.state.Usuario.nome = this.state.nome;
        this.state.Usuario.email = this.state.email;
        this.state.Usuario.cpF_CNPJ = this.state.cpF_CNPJ;
        this.state.Usuario.iE_RG = this.state.iE_RG;
        this.state.Usuario.telefone = this.state.telefone;
        this.state.Usuario.celular = this.state.celular;
        this.state.Usuario.usuarioId = this.state.usuarioId;
        this.state.Usuario.enderecoId = this.state.usuariox.enderecoId;

        //endereco

        if (this.state.bairro == '' || this.state.rua == '' || this.state.cEP == '' || this.state.estado == '' || this.state.cidade == '') {
            Alert.alert('Atenção', 'É necessário preencher todas as informações de endereco para editar seu perfil.')
            return;
        }
        this.state.Usuario.Endereco.bairro = this.state.bairro;
        this.state.Usuario.Endereco.rua = this.state.rua;
        this.state.Usuario.Endereco.cEP = this.state.cEP;
        this.state.Usuario.Endereco.estado = this.state.estado;
        this.state.Usuario.Endereco.cidade = this.state.cidade;
        // this.state.Usuario.Endereco.numero = this.state.numero;


        this.state.UsuarioHabilidade.UsuarioHabilidades = this.state.selectedItems;
        this.setState({ spinner: true });

        if (this.state.ehInstituicao == true) {
            new Api("UsuarioHabilidade/InserirHabilidade").post(item.UsuarioHabilidade).then()
        }

        if (this.state.usuariox.enderecoId != null) {
            this.state.Usuario.Endereco.enderecoId = this.state.Usuario.enderecoId;
        }

        //Account L[ogica] INICIO ----------------

        if (this.state.passwordx != '') {
            this.state.Usuario.Account.Password = this.state.passwordx;
        }
        else {
            this.state.Usuario.Account = null;
        }

        this.state.Usuario.AttributeBehavior = "EditarUsuario";

        //Account Logica FIM -------------------

        new Api("Usuario/SalvarEdicao").put(this.state.Usuario).then(data => {
            this.setState({ spinner: false });
            Alert.alert(
                'Sucesso',
                "Seu perfil foi alterado",
                [
                    { text: 'OK' }
                ]
            )
        })

    };


    getEndereco(id) {
        new Api("Endereco").get({ EnderecoId: id }).then(data => {
            var enderecoP = data.dataList[0]
            this.setState({
                isLoading: true,
                enderecox: enderecoP,
            })

            if (enderecoP.cep != null) {
                this.state.cEP = enderecoP.cep
            };
            if (enderecoP.cidade != null) {
                this.state.cidade = enderecoP.cidade
            };
            if (enderecoP.estado != null) {
                this.state.estado = enderecoP.estado
            };
            // if (enderecoP.numero != null) {
            //     this.state.numero = enderecoP.numero
            // };
            if (enderecoP.rua != null) {
                this.state.rua = enderecoP.rua
            };
            if (enderecoP.bairro != null) {
                this.state.bairro = enderecoP.bairro
            };

        })
    }


    componentDidMount() {

        async function ehIntituicao() {

            this.setState({ ehInstituicao: await Auth.isLogado() })
        }

        ehIntituicao();

        new Api("Usuario").get({ AttributeBehavior: "GetInfoUsuarioPerfil" }).then(data => {
            var dataList = data.dataList[0];

            this.setState({
                isLoading: true,
                usuariox: dataList

            })

            this.setNome(this.state.usuariox.nome)
            this.setEmail(this.state.usuariox.email)
            this.setCpf(this.state.usuariox.cpF_CNPJ)
            { this.state.usuariox.iE_RG == null ? this.setIE_RG("") : this.setIE_RG(this.state.usuariox.iE_RG) }
            { this.state.usuariox.telefone == null ? this.setTelefone("") : this.setTelefone(this.state.usuariox.telefone) }
            this.setCelular(this.state.usuariox.celular)
            this.setUsuarioId(this.state.usuariox.usuarioId)
            this.state.usuariox.ehInstituicao == false ? this.state.verificarRG = "rg" : this.state.verificarRG = "ie"


            if (this.state.usuariox.enderecoId != null) {
                this.getEndereco(this.state.usuariox.enderecoId);
            } else {

                this.state.Usuario.Endereco.cEP = "";

                this.state.Usuario.Endereco.cidade = "";

                this.state.Usuario.Endereco.estado = "";

                // this.state.Usuario.Endereco.numero = 0;

                this.state.Usuario.Endereco.rua = "";

                this.state.Usuario.Endereco.bairro = "";

                this.state.Usuario.enderecoId = null;

            }

        })
    }

    logArrayElements(element, index, array) {
        this.setState({
            UsuarioHabilidade: {
                HabilidadeId: element
            }
        })
        new Api("UsuarioHabilidade").post(this.state.UsuarioHabilidade).then()
    }

    setUsuarioId = (text) => {
        this.setState({ usuarioId: text })
    }

    setNome = (text) => {
        this.setState({ nome: text })
    }
    setEmail = (text) => {
        this.setState({ email: text })
    }

    setCpf = (text) => {
        this.setState({ cpF_CNPJ: text })
    }

    setIE_RG = (text) => {
        this.setState({ iE_RG: text })
    }

    setTelefone = (text) => {
        this.setState({ telefone: text })
    }

    setCelular = (text) => {
        this.setState({ celular: text })
    }

    //endereco
    setCEP = (text) => {
        this.setState({ cEP: text })
    }

    setRua = (text) => {
        this.setState({ rua: text })

    }

    // setNumero = (text) => {
    //     this.setState({ numero: text })
    // }

    setCidade = (text) => {
        this.setState({ cidade: text })
    }

    setBairro = (text) => {
        this.setState({ bairro: text })
    }

    setEstado = (text) => {
        this.setState({ estado: text })
    }

    setPassword = (text) => {
        this.setState({ passwordx: text })
    }

    onSelectedItemsChange = (selectedItems) => {
        this.setState({ selectedItems });
    };
    render() {
        const { nome } = this.state.nome
        const { email } = this.state.email
        const { cpF_CNPJ } = this.state.cpF_CNPJ
        const { iE_RG } = this.state.iE_RG
        //const { telefone } = this.state.telefone
        const { celular } = this.state.celular

        //endereco
        const { cEP } = this.state.cEP
        const { rua } = this.state.rua
        // const { numero } = this.state.numero
        const { cidade } = this.state.cidade
        const { bairro } = this.state.bairro
        const { estado } = this.state.estado



        //Account
        const { password } = this.state.passwordx
        return (
            <ScrollView contentContainerStyle={{ flexGrow: 1, alignItems: 'center', marginTop: 20 }}>

                <Spinner
                    visible={this.state.spinner}
                    textContent={'Salvando...'}
                    textStyle={Styles.spinnerTextStyle}
                />

                <View style={Styles.top}>
                    <TouchableOpacity onPress={() => this.props.navigation.navigate('Perfil')}>
                        <Feather name='arrow-left-circle' size={30} color='#2AB940'></Feather>
                    </TouchableOpacity>
                    <Text style={Styles.titulo}>Perfil</Text>
                    <TouchableOpacity style={Styles.loadButton} onPress={() => this.SalvarAlteracoes(this.state)}>
                        <Feather name="save" size={20} color="#FFF" />
                    </TouchableOpacity>
                </View>

                <TextInput
                    style={Styles.input}
                    defaultValue={this.state.usuariox.nome}
                    placeholder="Nome Completo"
                    autoCorrect={false}
                    onChangeText={this.setNome}
                    value={nome}
                />

                <TextInput
                    style={Styles.input}
                    placeholder="CPF"
                    autoCorrect={false}
                    defaultValue={this.state.usuariox.cpF_CNPJ}
                    onChangeText={this.setCpf}
                    value={cpF_CNPJ}
                />


                <TextInputMask
                    type={'custom'}
                    options={{
                        mask: this.state.verificarRG === "rg" ? '99.999.999-9' : '9999999999999999'
                    }}
                    style={Styles.input}
                    defaultValue={this.state.iE_RG}
                    placeholder={"RG"}
                    value={this.state.iE_RG}
                    onChangeText={text => {
                        this.setState({
                            iE_RG: text
                        })
                    }}
                />

                <TextInputMask
                    type={'cel-phone'}
                    options={{
                        maskType: 'BRL',
                        withDDD: true,
                        dddMask: '(99) '
                    }}
                    style={Styles.input}
                    defaultValue={this.state.telefone}
                    placeholder={"Telefone"}
                    value={this.state.telefone}
                    onChangeText={text => {
                        this.setState({
                            telefone: text
                        })
                    }}
                />

                <TextInputMask
                    type={'cel-phone'}
                    options={{
                        maskType: 'BRL',
                        withDDD: true,
                        dddMask: '(99) '
                    }}
                    style={Styles.input}
                    defaultValue={this.state.celular}
                    placeholder={"Celular"}
                    value={this.state.celular}
                    onChangeText={text => {
                        this.setState({
                            celular: text
                        })
                    }}
                />


                <TextInputMask
                    type={'custom'}
                    options={{
                        mask: "99999*999"
                    }}
                    style={Styles.input}
                    defaultValue={this.state.cEP}
                    placeholder={"CEP"}
                    value={this.state.cEP}
                    onChangeText={text => {
                        this.setState({
                            cEP: text
                        })
                    }}
                />

                <TextInput
                    style={Styles.input}
                    selectionColor='#737380'
                    placeholder="Endereço"
                    defaultValue={this.state.enderecox.rua}
                    autoCorrect={false}
                    onChangeText={this.setRua}
                    value={rua}
                />


                <TextInput
                    style={Styles.input}
                    selectionColor='#737380'
                    placeholder="Cidade"
                    defaultValue={this.state.enderecox.cidade}
                    autoCorrect={false}
                    onChangeText={this.setCidade}
                    value={cidade}
                />

                <View style={{ flexDirection: 'row' }}>
                    <TextInput
                        style={Styles.inputOrient}
                        selectionColor='#737380'
                        placeholder="Bairro"
                        defaultValue={this.state.enderecox.bairro}
                        autoCorrect={false}
                        onChangeText={this.setBairro}
                        value={bairro}
                    />

                    <TextInput
                        style={Styles.inputOrient2}
                        selectionColor='#737380'
                        placeholder="Estado"
                        defaultValue={this.state.enderecox.estado}
                        autoCorrect={false}
                        onChangeText={this.setEstado}
                        value={estado}
                    />
                </View>

                <TextInput
                    style={Styles.input}
                    selectionColor='#737380'
                    passwordRules={true}
                    placeholder="Password"
                    autoCorrect={false}
                    onChangeText={this.setPassword}
                    value={password}
                    secureTextEntry={true}
                />

                <SectionedMultiSelect
                    items={items}
                    ref={(SectionedMultiSelect) => (this.SectionedMultiSelect = SectionedMultiSelect)}
                    displayKey="title"
                    uniqueKey="id"
                    subKey="children"
                    confirmText="Selecionar"
                    selectText="Escolha algumas opção"
                    showDropDowns={true}
                    readOnlyHeadings={true}
                    onSelectedItemsChange={this.onSelectedItemsChange}
                    showCancelButton={true}
                    showRemoveAll={true}
                    colors={{ primary: '#2AB940', success: '#2AB940' }}
                    selectedItems={this.state.selectedItems}
                    styles={{
                        selectedItem: {
                            backgroundColor: 'rgba(0,0,0,0.1)',
                        },
                        selectedSubItem: {
                            backgroundColor: 'rgba(0,0,0,0.1)',
                        },
                        scrollView: { paddingHorizontal: 0 },
                    }}
                />
            </ScrollView>
        );
    }
}