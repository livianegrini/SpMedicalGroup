import { Component } from "react";
import { AsyncStorage } from '@react-native-async-storage/async-storage';

import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Email: "",
            Senha: ""
        }
    }

    FazerLogin = async () => {
        const Resposta = await applicationCache.post('/Login', {
            Email: this.state.Email,
            Senha: this.state.Senha
        });

        const Token = Resposta.data.Token;
        await AsyncStorage.setItem('Usuario-Token', Token)
        console.warn(Token)
    };


    render() {
        return (
            <View>
                <TextInput
                    placeholder="Username"
                    placeholderTextColor="#000"
                    keyboardType="email-address"
                    // Evento para fazermos algo enquanto o texto muda
                    onChangeText={Email => this.setState({ Email })}
                />
            </View>
        )
    }
}


