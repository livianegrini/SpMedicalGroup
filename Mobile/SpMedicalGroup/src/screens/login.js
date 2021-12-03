import React, { Component } from 'react'
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
                <ImageBackground
                    source={require('../../assets/FundoLogin.png')}
                    style={styles.BackGround}
                >
                    <View style={styles.Container}>
                        <View style={styles.DivConteudos}>
                            <Image
                                source={require('../../assets/iconlogin.png')}
                            />
                            <TextInput style={styles.Inputs}
                                placeholder="Email"
                                placeholderTextColor="#fff"
                                keyboardType="email-address"
                                onChangeText={Email => this.setState({ Email })}
                            />
                            <TextInput style={styles.Inputs}
                                placeholder="Senha"
                                placeholderTextColor="#fff"
                                keyboardType="senha-address"
                                onChangeText={Email => this.setState({ Email })}
                            />
                        </View>
                    </View>

                </ImageBackground>
            </View>
        )
    }
}

const styles = StyleSheet.create({

    BackGround: {
        height: '100%'
    },

    Inputs: {
        color: 'white',
        fontSize: 18,
        fontWeight: 'bold',
        borderBottomColor: 'white',
        borderBottomWidth: 2,
    },

    Container: {
        marginLeft: 63,
        marginRight: 63,
        justifyContent: 'center',
        flex:1
    },

    DivConteudos: {
      
    }
})

