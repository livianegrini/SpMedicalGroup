// import { Component } from 'react';
// import { Link } from 'react-router-dom';

import { useState, useEffect } from "react";
import api from "../../services/api";

import Logo from '../assets/Imagens/logo.png'
import Calendario from '../assets/Imagens/calendario.png'

export default function CadastrarConsulta() {

  const [hora, sethora] = useState(new Date());
  const [dataCon, setdataCon] = useState(new Date());
  const [idMedico, setidMedico] = useState(0);
  const [idSituacao, setidSituacao] = useState(0);
  const [idPaciente, setidPaciente] = useState(0);
  // const [mensagem, setmensagem] = useState('');
  const [sucesso, setsucesso] = useState(false);

  const [ListaConsultas, setListaConsultas] = useState([]);
  const [ListaPacientes, setListaPacientes] = useState([]);
  const [ListaMedicos, setListaMedicos] = useState([]);
  const [ListaSituacao, setListaSituacao] = useState([]);
  const [IsLoading, setIsLoading] = useState(false);



  function BuscarPaciente() {
    api.get('/Pacientes', {
      headers: {
        //comunicação JWT, o padrao da api Bearer + token.
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        if (Resposta.status === 200) {
          setListaPacientes(Resposta.data);
          console.log(Resposta.data);
        }
      })
      .catch((Erro) => console.log(Erro));
  };

  useEffect(BuscarPaciente, [])



  function BuscarMedico() {
    api.get('/Medicos', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        if (Resposta.status === 200) {
          setListaMedicos(Resposta.data);
          console.log('qualquer coisa');
          console.log(Resposta.data);
        }
      })
      .catch((Erro) => console.log(Erro));
  };

  useEffect(BuscarMedico, [])



  function BuscarSituacao() {
    api.get('/Situacoes', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        if (Resposta.status === 200) {
          setListaSituacao(Resposta.data);
          console.log(Resposta.data);
        }
      })
      .catch((Erro) => console.log(Erro));
  };
  useEffect(BuscarSituacao, [])


  function CadastrarConsulta(Evento) {
    console.log(idPaciente);
    console.log(idMedico);
    console.log(idSituacao);
    console.log(dataCon);
    console.log(hora);
    Evento.preventDefault();
    api.post('/Consultas', {
      idPaciente: idPaciente,
      idMedico: idMedico,
      idSituacao: idSituacao,
      dataCon: new Date(dataCon),
      hora: hora
    }, {
      headers: {
        'Authorization': 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then(Resposta => {
        if (Resposta.status === 200) {
          console.log("Consulta Cadastrada");
          setidPaciente(0);
          setidMedico(0);
          setidSituacao(0);
          setdataCon("");
          sethora("");
          setsucesso(true);
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

      <header>
        <div className="Header">
          <img className="ImagemLogo" src={Logo} alt="Imagem do logo" />
        </div>
      </header>


      <main className="FundoCadastrar">
        <section className="AlinhamentoCadastrar">
          <div className="BordaCadastrar">
            <div className="TituloCadastro">
              <h2>Cadastrar Consulta</h2>
              <img className="ImagemCalendario" src={Calendario} alt="Imagem do calendário" />
            </div>

            <form className="ConteudoDivCadastrar" onSubmit={CadastrarConsulta}>
              <div className="DivsListar">

                <input className="BottomMenor" type="date" placeholder="Data" value={dataCon} onChange={(Campo) => setdataCon(Campo.target.value)} />

                <input type="time" placeholder="Hora" value={hora} onChange={(Campo) => sethora(Campo.target.value)} />

                <select name="Paciente" id="Paciente" value={idPaciente} defaultValue={0} onChange={(Campo) => setidPaciente(Campo.target.value)}>
                  <option value="0" disabled>Paciente</option>
                  {
                    ListaPacientes.map((Paciente) => {
                      return (
                        <option key={Paciente.idPaciente} value={Paciente.idPaciente}>
                          {Paciente.nome}
                        </option>
                      )
                    })
                  }
                </select>


                <select name="Medico" id="Medico" value={idMedico} defaultValue={0} onChange={(Campo) => setidMedico(Campo.target.value)}>
                  <option value="0" disabled>Médico</option>
                  {
                    ListaMedicos.map((Medico) => {
                      return (
                        <option key={Medico.idMedico} value={Medico.idMedico}>
                          {Medico.nome}
                        </option>
                      )
                    })
                  }
                </select>

                <select name="Situação" id="Situação" value={idSituacao} defaultValue={0} onChange={(Campo) => setidSituacao(Campo.target.value)}>
                  <option value="0" disabled>Situação</option>
                  {
                    ListaSituacao.map((Situacao) => {
                      return (
                        <option key={Situacao.Situacao} value={Situacao.idSituacao}>
                          {Situacao.tipoSituacao}
                        </option>
                      )
                    })
                  }
                </select>
              </div>

              {IsLoading === false && (
                <button className="BotaoCadastrar" type="submit">
                  Cadastrar
                </button>
              )}

              {IsLoading === true && (
                <button type="submit">
                  Loading...
                </button>
              )}

            </form>

            {
              sucesso === true && (
                <p>
                  Consulta cadastrada com sucesso!
                </p>
              )
            }

          </div>
        </section>
      </main>
    </div>
  );

};




