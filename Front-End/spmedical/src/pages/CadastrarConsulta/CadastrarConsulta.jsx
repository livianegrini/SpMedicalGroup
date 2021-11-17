// import { Component } from 'react';
// import { Link } from 'react-router-dom';

import { React, Component } from 'react';
import axios from 'axios';

export default class CadastrarConsulta extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idPaciente: 0,
            idMedico: 0,
            idSituacao: 0,
            dataCon: new Date(),
            hora: new Date(),
            descricao: '',
            titulosecao: 'Lista Tipos Eventos',
            IsLoading: false,
        }
    };

    // BuscaConsultas = () => {
    //     //o método por padrão será o GET.
    //     axios('http://localhost:5000/api/Consultas', {
    //         headers: {
    //             //comunicação JWT, o padrao da api Bearer + token.
    //             Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
    //         },
    //     })
    //         .then((resposta) => {
    //             // caso a requisição retorno um status code 200
    //             if (resposta.status === 200) {
    //                 //atualiza o status listaTiposEventos como os dados obtidos.
    //                 this.setState({ lista: resposta.data });
    //                 console.log(this.state.lista);
    //             }
    //         })
    //         //caso ocorroa algum erro, mostra no console do navegador.
    //         .catch((Erro) => console.log(Erro));
    // };

    cadastrarEvento = (Event) => {
        //Ignora o comportamento padrao do navegador.
        Event.preventDefault();
        //define que a requisicao esta em andamento.
        this.setState({ IsLoading: true });

        let Consulta = {
            DataConsulta: new Daate(this.state.dataCon),
            Hora: new Date(this.state.hora),
            IdPaciente: this.state.idPaciente,
            IdMedico: this.state.idMedico,
            IdSituacao: this.state.idSituacao
        };


        axios.post('http://localhost:5000/api/Consultas', Consulta, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
            },
        })
            .then((Resposta) => {
                if (Resposta.status === 201) {
                    console.log('Consulta cadastrada!');
                    this.setState({ IsLoading: false });
                }
            })
            .catch((Erro) => {
                console.log(erro);
                this.setState({ isLoading: false });
            })
            .then(this.BuscarConsulta);
    };
}

