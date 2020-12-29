import React, { useState } from 'react';
import {
    Text,
    View,
    FlatList
} from 'react-native';

import styles from './styles';

import { LinearGradient } from 'expo-linear-gradient';
import { Feather } from '@expo/vector-icons';

import {
    Placeholder,
    PlaceholderMedia,
    PlaceholderLine,
    Fade,
    Loader,
    Shine,
    ShineOverlay,
} from 'rn-placeholder';
console.disableYellowBox = true;
export default function Loading(props) {

    return (

        <FlatList
            data={props.array}
            style={styles.listaProjetos}
            keyExtractor={projetos => String(projetos.idAtividate)}
            renderItem={() => (
                <View style={styles.projeto}>
                    <Placeholder
                        Left={PlaceholderMedia}
                        Animation={Shine}>
                        <PlaceholderLine width={100} height={30} />
                        <PlaceholderLine width={80} height={30} />
                        <PlaceholderLine width={80} height={30} />
                        <PlaceholderLine width={100} height={30} />
                    </Placeholder>
                </View>
            )}
        />
        // <FlatList
        //     data={[1, 2, 3, 4]}
        //     renderItem={() => (
        //         <View style={styles.container}>
        //             <Placeholder
        //                 Left={PlaceholderMedia}
        //                 Animation={Shine}>
        //                 <PlaceholderLine width={100} height={30} />
        //                 <PlaceholderLine width={80} height={30} />
        //                 <PlaceholderLine width={80} height={30} />
        //                 <PlaceholderLine width={100} height={30} />
        //             </Placeholder>
        //         </View>
        //     )}
        // />

        /* <View style={styles.firstDegrade}>
            <LinearGradient
                style={{ flex: 1, width: '100%', alignItems: 'center', borderRadius: 100 }}
                colors={['#A9A9A9', '#C0C0C0', '#D3D3D3']}
                start={[0, 0]}
                end={[1, 0]}
            >
                <Feather name='loader' size={22} color='black'></Feather>
            </LinearGradient>
        </View>

        <View style={styles.secondDegrade}>
            <LinearGradient
                style={{ flex: 1, width: '100%', alignItems: 'center', borderRadius: 20 }}
                colors={['#A9A9A9', '#C0C0C0', '#D3D3D3']}
                start={[0, 0]}
                end={[1, 0]}
            >
                <Text style={styles.textLoading}>Carregando...</Text>
            </LinearGradient>
        </View>

        <View style={styles.threeDegrade}>
            <LinearGradient
                style={{ flex: 1, width: '100%', alignItems: 'center', borderRadius: 20 }}
                colors={['#A9A9A9', '#C0C0C0', '#D3D3D3']}
                start={[0, 0]}
                end={[1, 0]}
            >
                <Text style={styles.textLoading}>Carregando...</Text>
            </LinearGradient>
        </View>

        <View style={styles.fourDegrade}>
            <LinearGradient
                style={{ flex: 1, width: '100%', alignItems: 'center', borderRadius: 20 }}
                colors={['#A9A9A9', '#C0C0C0', '#D3D3D3']}
                start={[0, 0]}
                end={[1, 0]}
            >
                <Text style={styles.textLoading}>Carregando...</Text>
            </LinearGradient>
        </View> */
    );
}