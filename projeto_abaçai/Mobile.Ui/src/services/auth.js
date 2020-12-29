import { AsyncStorage, Alert } from 'react-native'
import * as Cache from '../services/cache';
import { Api } from '../services/api';

export const signOutAsync = async () => {
    Cache.remove("ACCESS_TOKEN");
    Cache.remove("EH_INSTITUICAO");
    Cache.remove("USER_ID");
    Cache.clear();
    return ""
}

export const signInAsync = async (email, pass) => {
    try {
        const { data } = await new Api("User").post({
            email: email,
            password: pass
        });

        if (data == null || data.token == null) {
            Alert.alert('Opss!',
                'Usuário ou senha inválidos, caso não tenha criado uma conta clique em Criar Conta.')

            return;
        }

        Cache.set("EH_INSTITUICAO", data.ehInstituicao.toString());
        Cache.set("ACCESS_TOKEN", data.token);
        Cache.set("SUB", data.accountId.toString());

        return data.token;
    }
    catch (error) {
        Alert.alert('Opss!',
            'Não conseguimos nos conectar com o servidor, tente novamente em instantes.');

        return;
    }
}

export async function isLogado() {
    let access_token = await Cache.get("ACCESS_TOKEN");
    if (!access_token || access_token == null) {
        return false;
    }

    return true;
}

export async function isInstituicao() {
    let ehInstituicao = await Cache.get("EH_INSTITUICAO");
    if (JSON.parse(ehInstituicao)) return true;

    return false;
}

export async function GetUserId() {
    let user_id = await Cache.get("USER_ID");
    if (user_id == null) return null;

    return user_id;
}