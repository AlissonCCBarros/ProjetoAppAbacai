//import { AsyncStorage, } from 'react-native';
import AsyncStorage from '@react-native-community/async-storage';

export const get = async valor => {
    let value = await AsyncStorage.getItem(valor) || null;
    return value;
}

export const set = async (chave, valor) => {
    await AsyncStorage.setItem(chave, valor);
    return;
}

export const remove = async (chave) => {
    await AsyncStorage.removeItem(chave);
    return;
}

export const reset = async () => {
    await AsyncStorage.reset();
}

export const clear = async () => {
    await AsyncStorage.clear();
}

export const getAll = async () => {
    let value = await AsyncStorage.getAllKeys();
    return value;
}