import React, { Component } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

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
            Email: 'adm@gmail.com',
            Senha: '123'
        };
    }

   

    FazerLogin = async () => {

        // console.warn(this.state.Email + ' ' + this.state.Senha);


        const Resposta = await api.post('/login', {
            email: this.state.Email,
            senha: this.state.Senha
        });

        const token = Resposta.data.token;
        console.warn(token)

        await AsyncStorage.setItem('UsuarioToken', token);

        if (Resposta.status === 200) {

            console.warn("token")
            this.props.navigation.navigate('ListarConsultas');
        }
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
                            <View style={styles.ImagemLogo}>
                                <Image
                                    source={require('../../assets/iconlogin.png')}
                                />
                            </View>

                            <TextInput style={styles.Inputs}
                                placeholder="Email"
                                placeholderTextColor="#fff"
                                keyboardType="email-address"
                                onChangeText={Email => this.setState({ Email })}
                            />
                            <TextInput style={styles.Inputs}
                                placeholder="Senha"
                                placeholderTextColor="#fff"
                                keyboardType="default"
                                secureTextEntry={true} //para proteger a senha
                                onChangeText={Senha => this.setState({ Senha })}
                            />
                            <TouchableOpacity
                                style={styles.BotaoLogin}
                                onPress={this.FazerLogin}>
                                <Text style={styles.BotaoLoginConteudo}>Login</Text>
                            </TouchableOpacity>
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
        flex: 1
    },

    // ImagemLogo: {
    //     width: 10,
    //     height: 10,
    //     alignItems: 'center',
    //     justifyContent: 'center'
    // },

    BotaoLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 35,
        width: 120,
        backgroundColor: '#3B92D8',
        borderColor: '#3B92D8',
        borderWidth: 1,
        borderRadius: 4,
        shadowOffset: { height: 1, width: 1 },
    },

    BotaoLoginConteudo: {
        fontSize: 18,
        fontFamily: 'Open Sans Light', 
        color: 'white',
        fontWeight: 'bold'
    },


})

