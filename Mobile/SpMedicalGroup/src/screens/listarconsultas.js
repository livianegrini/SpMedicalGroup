import AsyncStorage from '@react-native-async-storage/async-storage';
import React, { Component } from 'react';
import { FlatList, ImageBackground, StyleSheet, Text, View } from 'react-native';
import api from "../services/api";

export default class Consultas extends Component {
    constructor(Props) {
        super(Props);
        this.state = {
            ListarConsultas: []
        };
    }


    BuscarConsultas = async () => {

        try {

            const token = await AsyncStorage.getItem('UsuarioToken')

            // Definindo uma constante pra receber a resposta da requisição.
            const Resposta = await api.get('/Consultas', {
                headers: {
                    Authorization: 'Bearer ' + token
                }
            });

            if (Resposta.status === 200) {

                const DadosApi = Resposta.data;

                this.setState({ ListarConsultas: DadosApi });
            }

        } catch (error) {
            console.warn(error);
        }

    };


    // Componente renderizado
    componentDidMount() {

        // invocandon função
        this.BuscarConsultas();

    }

    render() {
        return (

            <ImageBackground
                source={require('../../assets/FundoListar.png')}
                style={styles.Fundo}>

                <View style={styles.Container}>

                    <View style={styles.Box_tiutlo}>
                        <Text style={styles.Titulo}>
                            {'Consultas'.toUpperCase()}
                        </Text>
                    </View>

                    <FlatList
                        data={this.state.ListarConsultas}
                        keyExtractor={item => item.idProjeto}
                        renderItem={this.renderItem}
                    />
                </View>
            </ImageBackground>

        );
    }

    renderItem = ({ item }) => (
        // console.warn(item)
        <View>

            <View style={styles.ListarDiv}>

                <View style={styles.Consulta}>

                    <View >
                        <Text style={styles.TituloListar}>
                            {'Consulta'}
                        </Text>
                    </View>

                    <View style={styles.ConteudoListar}>

                        <Text style={styles.ListarTitulo}>{'Data: '}
                        </Text>
                        <Text style={styles.ListarConteudo}>
                            {Intl.DateTimeFormat("pt-BR", {
                                year: 'numeric', month: 'numeric', day: 'numeric'
                            }).format(new Date(item.dataCon))}
                        </Text>
                    </View>


                    <View style={styles.ConteudoListar}>
                        <Text style={styles.ListarTitulo}>
                            {'Hora: '}
                        </Text>
                        <Text style={styles.ListarConteudo}>
                            {item.hora}
                        </Text>
                    </View>

                    <View style={styles.ConteudoListar}>
                        <Text style={styles.ListarTitulo}>
                            {'Situação: '}
                        </Text>
                        <Text style={styles.ListarConteudo}>
                            {item.idSituacaoNavigation.tipoSituacao}
                        </Text>
                    </View>
                </View>

                <View style={styles.Medico}>

                    <View >
                        <Text style={styles.TituloListar}>
                            {'Paciente'}
                        </Text>
                    </View>

                    <View style={styles.ConteudoListar}>
                        <Text style={styles.ListarTitulo}>
                            {'Nome: '}
                        </Text>
                        <Text style={styles.ListarConteudo}>
                            {item.idPacienteNavigation.nome}
                        </Text>
                    </View>
                </View>



                <View style={styles.Medico}>

                    <View >
                        <Text style={styles.TituloListar}>
                            {'Médico'}
                        </Text>
                    </View>

                    <View style={styles.ConteudoListar}>
                        <Text style={styles.ListarTitulo}>
                            {'Nome: '}
                        </Text>
                        <Text style={styles.ListarConteudo}>
                            {item.idMedicoNavigation.nome}
                        </Text>
                    </View>

                    <View style={styles.ConteudoListar}>
                        <Text style={styles.ListarTitulo}>
                            {'Especialidade: '}
                        </Text>
                        <Text style={styles.ListarConteudo}>
                            {item.idMedicoNavigation.idEspecialidadeNavigation.especialidade1}
                        </Text>
                    </View>
                </View>

                <View style={styles.Descricao}>
                    <View style={styles.ConteudoListar}>
                        <Text style={styles.ListarTitulo}>
                            {'Descrição: '}
                        </Text>
                        <Text style={styles.ListarConteudo}>
                            {item.descricao}
                        </Text>
                    </View>
                </View>


            </View>
        </View>
    );

}

const styles = StyleSheet.create({

    Box_tiutlo: {
        alignItems: 'center'
    },

    Fundo: {
        flex: 1
    },

    Container: {
        flex: 1,
        marginLeft: 35,
        marginRight: 35
    },

    Titulo: {
        color: 'white',
        fontWeight: 'bold',
        fontSize: 30,
        marginTop: 36,
        borderBottomColor: 'white',
        borderBottomWidth: 2
    },

    Box_Projeto: {
        alignItems: 'flex-end',
        // backgroundColor
        backgroundColor: '#494F8F'
    },

    ListarTitulo: {
        color: 'white',
        fontWeight: 'bold',
        fontSize: 18,
        marginRight: 8,
        margin: 3
    },

    ListarConteudo: {
        color: 'white',
        fontSize: 15,
        marginLeft: 8,
        marginTop: 8
    },

    ConteudoListar: {
        flexDirection: 'row'
    },

    TituloListar: {
        color: 'white',
        fontWeight: 'bold',
        fontSize: 25
    },

    Consulta: {
        marginTop: 20,
        marginBottom: 20,
        marginLeft: 15
    },

    Medico: {
        marginBottom: 20,
        marginLeft: 15
    },

    Descricao: {
        marginBottom: 20,
        marginLeft: 15,
         fontSize: 25
    },

    ListarDiv: {
        borderColor: 'white',
        borderWidth: 2,
        borderRadius: 10,
        marginTop: 30,
        // flexDirection: 'row'
        // alignItems: 'flex-end'
    }
})