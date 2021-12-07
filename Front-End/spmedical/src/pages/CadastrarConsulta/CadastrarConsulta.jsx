// import { Component } from 'react';
// import { Link } from 'react-router-dom';

import { useState, useEffect } from "react";
import api from "../../services/api";

import Logo from '../assets/Imagens/logo.png'

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
    api.get('/Paciente', {
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
    api.get('/Medico', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        if (Resposta.status === 200) {
          setListaMedicos(Resposta.data);
          console.log(Resposta.data);
        }
      })
      .catch((Erro) => console.log(Erro));
  };

  useEffect(BuscarMedico, [])


  function BuscarClinica() {
    api.get('/Clinica', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        if (Resposta.status === 200) {
          setListaClinicas(Resposta.data);
          console.log(Resposta.data);
        }
      })
      .catch((Erro) => console.log(Erro));
  };
  useEffect(BuscarClinica, [])

  function BuscarSituacao() {
    api.get('/Situacao', {
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

  function BuscarConsulta() {
    api.get('/Consultas', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        if (Resposta.status === 200) {
          setListaConsultas(Resposta.data);
          console.log(Resposta.data);
        }
      })
      .catch((Erro) => console.log(Erro));
  };

  useEffect(BuscarConsulta, [])

  // AtualizaStateCampo = (Campo) => {
  //   this.setState({ [Campo.target.name]: Campo.target.value });
  // };

  function CadastrarConsulta(Evento) {
    Evento.preventDefault();
    api.post('/Consulta', {
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
          console.log('Consulta Cadastrada');
          BuscarConsulta();
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

      <header>
        <div className="Header">
          <img className="ImagemLogo" src={Logo} alt="Imagem do logo"/>
        </div>
      </header>


        <main className="FundoCadastrar">
          <section className="ListarDiv">
            <div className="TituloCadastro">
              <h2>Cadastrar Consulta</h2>
            </div>

            <div className="DivsListar">
              <input className="BottomMenor" type="date" placeholder="Data" />
              <input type="time" placeholder="Hora" />
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




