// import { Component } from 'react';
// import { Link } from 'react-router-dom';

import axios from 'axios';
import { useState, useEffect } from "react";

export default function CadastrarConsulta() {

  const [hora, sethora] = useState(new Date());
  const [dataCon, setdataCon] = useState(new Date());
  const [descricao, setdescricao] = useState("");
  const [idMedico, setidMedico] = useState(0);
  const [idSituacao, setidSituacao] = useState(0);
  const [idPaciente, setidPaciente] = useState(0);



  const [ListaConsultas, setListaConsultas] = useState([]);
  const [ListaPacientes, setListaPacientes] = useState([]);
  const [ListaMedicos, setListaMedicos] = useState([]);
  const [ListaClinicas, setListaClinicas] = useState([]);
  const [ListaSituacao, setListaSituacao] = useState([]);
  const [IsLoading, setIsLoading] = useState(false);



  function BuscarPaciente() {
    //o método por padrão será o GET.
    axios('http://localhost:5000/api/Paciente', {
      headers: {
        //comunicação JWT, o padrao da api Bearer + token.
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        // caso a requisição retorno um status code 200
        if (Resposta.status === 200) {
          setListaPacientes(Resposta.data);
          console.log(Resposta.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };

  useEffect(BuscarPaciente, [])

  function BuscarMedico() {
    //o método por padrão será o GET.
    axios('http://localhost:5000/api/Medico', {
      headers: {
        //comunicação JWT, o padrao da api Bearer + token.
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        // caso a requisição retorno um status code 200
        if (Resposta.status === 200) {
          //atualiza o status listaTiposEventos como os dados obtidos.
          setListaMedicos(Resposta.data);
          console.log(Resposta.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };

  useEffect(BuscarMedico, [])


  function BuscarClinica () {
    //o método por padrão será o GET.
    axios('http://localhost:5000/api/Clinica', {
      headers: {
        //comunicação JWT, o padrao da api Bearer + token.
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        // caso a requisição retorno um status code 200
        if (Resposta.status === 200) {
          //atualiza o status listaTiposEventos como os dados obtidos.
          setListaClinicas(Resposta.data);
          console.log(Resposta.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };
  useEffect(BuscarClinica, [])

  function BuscarSituacao () {
    //o método por padrão será o GET.
    axios('http://localhost:5000/api/Situacao', {
      headers: {
        //comunicação JWT, o padrao da api Bearer + token.
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        // caso a requisição retorno um status code 200
        if (Resposta.status === 200) {
          //atualiza o status listaTiposEventos como os dados obtidos.
          setListaSituacao(Resposta.data);
          console.log(Resposta.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };

  useEffect(BuscarSituacao, [])

  // AtualizaStateCampo = (Campo) => {
  //   this.setState({ [Campo.target.name]: Campo.target.value });
  // };

  function CadastrarConsulta(Evento) {
    Evento.preventDefault();
    axios.post('http://localhost:5000/api/Consulta', {
      idPaciente: idPaciente,
      idMedico: idMedico,
      idSituacao: idSituacao,
      dataCon: dataCon,
      descricao: descricao
    }, {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then(Resposta => {
        if (Resposta.status === 201) {
          console.log('Consulta Cadastrada')
          setidPaciente(0);
          setidMedico(0);
          setidSituacao(0);
          setdataCon("");
          setdescricao("");


        }
      })
      .catch((Erro) => {
        if (Erro.toJSON().status === 401) {
          this.props.Props.history.push('/Login')
        }
        else console.log(Erro)
      })
  }



  return (
    <div>
      <main class="FundoCadastrar">
        <section class="ListarDiv">
          <div class="DivsListar">
            <h2>Consulta</h2>
            <input class="BottomMenor" type="date" placeholder="Data" />
            <input type="time" placeholder="Hora" />
            <select>
              <option value="">Situação</option>
            </select>
          </div>

          <div DivsListar>
            <h2>Médico</h2>
            <input type="text" placeholder="Nome" />
            <select>
              <option value="">Especialidade</option>
            </select>
            <select>
              <option value="">Situação</option>
            </select>
          </div>

          <div>
            Descrição
          </div>
        </section>
      </main>
    </div>
  );


};



