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

      ListaPacientes: [],
      ListaMedicos: [],
      ListaClinicas: [],
      ListaSituacao: [],
      IsLoading: false,
    }
  };

  BuscarPaciente = () => {
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
          //atualiza o status listaTiposEventos como os dados obtidos.
          this.setState({ ListaPacientes: Resposta.data });
          console.log(this.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };

  BuscarMedico = () => {
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
          this.setState({ ListaMedicos: Resposta.data });
          console.log(this.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };


  BuscarClinica = () => {
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
          this.setState({ ListaClinicas: Resposta.data });
          console.log(this.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };

  BuscarSituacao = () => {
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
          this.setState({ ListaSituacao: Resposta.data });
          console.log(this.data);
        }
      })
      //caso ocorroa algum erro, mostra no console do navegador.
      .catch((Erro) => console.log(Erro));
  };


  AtualizaStateCampo = (Campo) => {
    this.setState({ [Campo.target.name]: Campo.target.value });
  };


  CadastrarEvento = (Event) => {
    //Ignora o comportamento padrao do navegador.
    Event.preventDefault();
    //define que a requisicao esta em andamento.
    this.setState({ IsLoading: true });

    let Consulta = {
      DataConsulta: new Date(this.state.dataCon),
      Hora: new Date(this.state.hora),
      IdPaciente: this.state.idPaciente,
      IdMedico: this.state.idMedico,
      IdSituacao: this.state.idSituacao,
      Descricao: this.state.descricao
    };


    axios.post('http://localhost:5000/api/Consultas', Consulta, {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('Usuario-Login'),
      },
    })
      .then((Resposta) => {
        if (Resposta.status === 201) {
          console.log('Consulta Cadastrada!');
          this.setState({ IsLoading: false });
          this.setState({
            DataConsulta: new Date(),
            Hora: new Date(),
            idPaciente: 0,
            IdPaciente: 0,
            IdMedico: 0,
            IdSituacao: 0,
            Descricao: ''
          })
        }
      })
      .catch((Erro) => {
        if (Erro.toJSON().status === 401) {
          this.props.history.push('/Login')
        }
        else console.log(Erro)
      })
  };

  componentDidMount() {
    this.BuscarPaciente();
    this.BuscarMedico();
    this.BuscarClinica();
    this.BuscarSituacao();
  }

  render() {
    return (
      <>
        <main>
          <section>
            {/* Lista de Eventos */}
            <h2>Lista de Consultas</h2>
            <table style={{ borderCollapse: 'separate', borderSpacing: 30 }}>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Data Consulta</th>
                  <th>Hora</th>
                  <th>Id Paciente</th>
                  <th>Id Medico</th>
                  <th>Id Situacao</th>
                </tr>
              </thead>

              <tbody>
                {/* Preenche o corpo da tabela utilizando a funcao map(). */}

                {/* <tr><td>teste de linha</td></tr>  */}
                {this.state.listaEventos.map((Consulta) => {
                  return (
                    <tr key={Consulta.idConsulta}>
                      <td>{Consulta.idConsulta}</td>
                      <td>{Consulta.dataCon}</td>
                      <td>{Consulta.hora}</td>
                      <td>{Consulta.IdPaciente}</td>
                      <td>{Consulta.IdMedico}</td>
                      <td>{Consulta.IdSituacao}</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </section>

          <section>
            <h2>Cadastro de Consultas</h2>
            <form onSubmit={this.CadastrarConsulta}>
              <div
                style={{
                  display: 'flex',
                  flexDirection: 'column',
                  width: '20vw',
                }}
              >
                <input
                  required
                  type="text"
                  name="titulo"
                  value={this.state.dataCon}
                  onChange={this.atualizaStateCampo}
                  placeholder="Titulo do Evento"
                />

                <input
                  required
                  type="text"
                  name="descricao"
                  value={this.state.hora}
                  onChange={this.atualizaStateCampo}
                  placeholder="Descrição do Evento"
                />

                <input
                  type="date"
                  name="dataEvento"
                  value={this.state.idPaciente}
                  onChange={this.atualizaStateCampo}
                />

                <select
                  name="idTipoEvento"
                  value={this.state.idMedico}
                  onChange={this.atualizaStateCampo}
                />

                <select
                  name="idInstituicao"
                  value={this.state.idInstituicao}
                  onChange={this.atualizaStateCampo}
                >
                  <option value="0" selected disabled>
                    Selecione a instituição
                  </option>

                  {/* utilizar a funcao map() */}

                  {this.state.listaInstituicao.map((tema) => {
                    return (
                      <option
                        key={tema.idInstituicao}
                        value={tema.idInstituicao}
                      >
                        {tema.nomeFantasia}
                      </option>
                    );
                  })}
                </select>

                <select
                  name="acessoLivre"
                  value={this.state.acessoLivre}
                  onChange={this.atualizaStateCampo}
                >
                  <option value="">Selecione o acesso</option>
                  <option value="1">Livre</option>
                  <option value="0">Restrito</option>
                </select>

                {this.state.isLoading === true && (
                  <button type="submit">Loading...</button>
                )}

                {this.state.isLoading === false && (
                  <button type="submit">Cadastrar</button>
                )}
              </div>
            </form>
          </section>
        </main>
      </>
    );
  }
}

