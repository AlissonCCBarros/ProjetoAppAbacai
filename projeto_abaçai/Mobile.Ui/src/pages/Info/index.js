import {
    KeyboardAvoidingView,
    View,
    Text,
    Animated,
    Image,
    Linking,
    Button
} from 'react-native';

import Styles from './styles';
import React from 'react';
import { LinearGradient } from 'expo-linear-gradient';
import { Feather } from '@expo/vector-icons';

export default function Info() {

    return (
        <LinearGradient
            style={{ flex: 1, alignItems: 'center' }}
            colors={['#7BD94A', '#199559', '#1C7F63']}
        >

            <KeyboardAvoidingView style={Styles.background}>

                <View style={Styles.main}>
                    <View style={Styles.containerLogo}>
                        <Animated.Image
                            style={{
                                width: 350,
                                height: 140,
                                borderRadius: 20
                            }}
                            source={require('../../../src/assets/ESAMC.png')}
                        />
                    </View>

                    <View style={Styles.container}>

                        <Text style={Styles.txtGreen}>Olá!</Text>
                        <View style={Styles.containerDesc}>
                            <Text style={Styles.txtDescQuestion}>
                                Você sabia que o aplicativo Abraçaí foi desenvolvido como um projeto de conclusão de curso?
                        </Text>
                            <Text style={Styles.txtDesc}>
                                Cursamos Análise e Desenvolvimento de Sistemas pela faculdade ESAMC Sorocaba e trabalhamos com uma
                                equipe de quatro alunos durante um semestre para esse aplicativo se tornar realidade.
                        </Text>
                        </View>

                        <View style={Styles.body}>
                            <View style={Styles.containerImage}>
                                <Image style={Styles.imgUser} source={require('../../assets/avatar1.png')}>
                                </Image>
                            </View>
                            <View style={Styles.user}>
                                <View style={Styles.infoUsers}>
                                    <Text style={Styles.txtNome}>Alisson Caique Cardoso de Barros</Text>
                                    <View style={Styles.containerIcons}>
                                        <Text style={Styles.iconEmail} onPress={() => Linking.openURL('mailto:cardoso_barros16@hotmail.com')}>
                                            <Feather name='mail' size={25} color='#1E90FF'></Feather>
                                        </Text>
                                        <Text style={Styles.iconLinkedin} onPress={() => Linking.openURL('http://www.linkedin.com/profile/view?id=alisson-barros-356828162')}>
                                            <Feather name='linkedin' size={25} color='#4169E1'></Feather>
                                        </Text>
                                    </View>
                                </View>
                            </View>
                        </View>

                        <View style={Styles.body}>
                            <View style={Styles.containerImage}>
                                <Image style={Styles.imgUser} source={require('../../assets/avatar2.png')}>
                                </Image>
                            </View>
                            <View style={Styles.user}>
                                <View style={Styles.infoUsers}>
                                    <Text style={Styles.txtNome}>Gabriel Drey Seco</Text>
                                    <View style={Styles.containerIcons}>
                                        <Text style={Styles.iconEmail} onPress={() => Linking.openURL('mailto:gabriel.drey.seco@outlook.com')}>
                                            <Feather name='mail' size={25} color='#1E90FF'></Feather>
                                        </Text>
                                        <Text style={Styles.iconLinkedin} onPress={() => Linking.openURL('http://www.linkedin.com/profile/view?id=gabriel-seco-62062715b')}>
                                            <Feather name='linkedin' size={25} color='#4169E1'></Feather>
                                        </Text>
                                    </View>
                                </View>
                            </View>
                        </View>

                        <View style={Styles.body}>
                            <View style={Styles.containerImage}>
                                <Image style={Styles.imgUser} source={require('../../assets/avatar3.png')}>
                                </Image>
                            </View>
                            <View style={Styles.user}>
                                <View style={Styles.infoUsers}>
                                    <Text style={Styles.txtNome}>João Antonio Da Silva Junior</Text>
                                    <View style={Styles.containerIcons}>
                                        <Text style={Styles.iconEmail} onPress={() => Linking.openURL('mailto:silva_junior99@hotmail.com')}>
                                            <Feather name='mail' size={25} color='#1E90FF'></Feather>
                                        </Text>
                                        <Text style={Styles.iconLinkedin} onPress={() => Linking.openURL('http://www.linkedin.com/profile/view?id=joao-silva-0526b9176')}>
                                            <Feather name='linkedin' size={25} color='#4169E1'></Feather>
                                        </Text>
                                    </View>
                                </View>
                            </View>
                        </View>

                        <View style={Styles.body}>
                            <View style={Styles.containerImage}>
                                <Image style={Styles.imgUser} source={require('../../assets/avatar4.png')}>
                                </Image>
                            </View>
                            <View style={Styles.user}>
                                <View style={Styles.infoUsers}>
                                    <Text style={Styles.txtNome}>Matheus Gonçalves Barbieri Seco</Text>
                                    <View style={Styles.containerIcons}>
                                        <Text style={Styles.iconEmail} onPress={() => Linking.openURL('mailto:matheus.gbseco@gmail.com')}>
                                            <Feather name='mail' size={25} color='#1E90FF'></Feather>
                                        </Text>
                                        <Text style={Styles.iconLinkedin} onPress={() => Linking.openURL('http://www.linkedin.com/profile/view?id=matheusgbs')}>
                                            <Feather name='linkedin' size={25} color='#4169E1'></Feather>
                                        </Text>
                                    </View>
                                </View>
                            </View>
                        </View>
                    </View>

                </View>

            </KeyboardAvoidingView>
        </LinearGradient>
    );
}