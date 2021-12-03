import { Component } from "react";
import { AsyncStorage } from '@react-native-async-storage/async-storage';
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

            const Token = await AsyncStorage.getItem('Usuario-Token')

            // Definindo uma constante pra receber a resposta da requisição.
            const Resposta = await api.get('/Consultas', {
                headers: {
                    Authorization: 'Bearer ' + Token
                }
            });

            if (Resposta.status === 200) {

                // Com a função console.warn() é possível mostrar alertas na tela do dispositivo mobile
                // Console.warn(resposta.data[0])
                // Recebe o corpo da resposta.
                const DadosApi = Resposta.data;


                // Atualiza o state listaEventos com este corpo da requisição.
                this.setState({ ListarConsultas: DadosApi });
            }

        } catch (error) {
            console.warn(error);
        }

    };


    // quando o componente é renderizado
    componentDidMount() {

        // invoca a função abaixo
        this.BuscarConsultas();

    }

    render() {
        return(
            <View>
                <Text>Teste</Text>
            </View>
        )
    }
}