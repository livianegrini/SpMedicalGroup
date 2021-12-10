import { useState, useEffect } from "react";
import axios from "axios";
// import { Link } from 'react-router-dom';
import { ParseJwt, usuarioAutenticado } from '../../services/auth';
import Logo from '../assets/Imagens/logo.png'

export default function MinhasConsultas() {

    const [ListaMinhasConsultas, SetListaMinhasConsultas] = useState([]);
    const [TipoLogado, setTipoLogado] = useState(null);
    const [idConsultaAlterada, setidConsultaAlterada] = useState(0);
    const [NovaDescricao, setNovaDescricao] = useState('')

    function BuscarMinhasConsultas() {

        setTipoLogado(ParseJwt().role)

        axios('http://192.168.7.133:5000/api/Consultas/Minhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-Login')
            }
        })
            .then(Resposta => {
                if (Resposta.status === 200) {
                    console.log(Resposta.data)
                    SetListaMinhasConsultas(Resposta.data)
                };
            })
            .catch(Erro => console.log(Erro));
    };

    console.log(TipoLogado);

    function AlterarDescricao(Evento) {
        Evento.preventDefault();
        axios.patch('http://192.168.7.133:5000/api/Consultas/Descricao' + idConsultaAlterada, {
            Descricao: NovaDescricao
        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-Login')
            }
        })
            .then(Resposta => {
                if (Resposta.status === 200) {
                    console.log('Descrição alterada')
                }
            })
            .catch(Erro => console.log(Erro))
        BuscarMinhasConsultas();
    }

    useEffect(BuscarMinhasConsultas, []);



    return (
        <div>

            {/* {
                TipoLogado === '2' &&
                (
                    <p>Médico</p>
                )
            }

            {
                TipoLogado === '3' &&
                (
                    <p>Paciente</p>
                )
            } */}

            <header>
                <div className="Header">
                    <img className="ImagemLogo" src={Logo} alt="Imagem do logo" />
                </div>
            </header>

            <main className="FundoListarMedico">

                <article>

                    <div className="ContainerCards">

                        {/* medico */}

                        {TipoLogado === '2' && (

                            ListaMinhasConsultas.map((MinhasConsultas) => {
                                console.log(MinhasConsultas)
                                return (
                                    <div>
                                        <article className="ConteudoListar">

                                            <div className="ConteudoListarConsulta">

                                                <p className="TituloListarMinhas">Consulta</p>

                                                <div className="ConteudoListarDentro">

                                                    <div className="DataHora">
                                                        <div className="ConteudoLinhas">
                                                            <p className="ChaveListar">
                                                                Data:
                                                            </p>

                                                            <div className="valorListar">
                                                                {Intl.DateTimeFormat("pt-BR", {
                                                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                                                }).format(new Date(MinhasConsultas.dataCon))}
                                                            </div>
                                                        </div>

                                                        <div className="ConteudoLinhas ListarHora">
                                                            <p className="ChaveListar">
                                                                Hora:
                                                            </p>

                                                            <div className="valorListar">
                                                                {MinhasConsultas.hora}
                                                            </div>
                                                        </div>
                                                    </div>



                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Situação:
                                                        </p>

                                                        <div className="valorListar">
                                                            {MinhasConsultas.idSituacaoNavigation.tipoSituacao}
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>


                                            <div className="ConteudoEspacamento">
                                                <p className="TituloListarMinhas">Paciente</p>

                                                <div className="ConteudoListarConsulta">

                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Nome:
                                                        </p>

                                                        <div className="valorListar">
                                                            {MinhasConsultas.idPacienteNavigation.nome}
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                            <div className="ConteudoEspacamento">
                                                <p className="TituloListarMinhas">Descrição</p>

                                                <form onSubmit={AlterarDescricao}>
                                                    <div className="ConteudoDescricao">

                                                        <select name="paciente" id="" onChange={(Evento) => setidConsultaAlterada(Evento.target.value)}>
                                                            <option value="#">Escolha uma consulta</option>
                                                            {
                                                                ListaMinhasConsultas.map((Evento) => {

                                                                    return (

                                                                        <option key={Evento.idConsulta} value={Evento.idConsulta}>{Evento.idPacienteNavigation.nome + ', ' + Intl.DateTimeFormat("pt-BR", {
                                                                            year: 'numeric', month: 'short', day: 'numeric'
                                                                        }).format(new Date(Evento.dataCon))}</option>
                                                                    )
                                                                })
                                                            }
                                                        </select>
                                                        <input className="DivDescricao" type="text" name="" id="" placeholder="" onChange={(Evento) => setNovaDescricao(Evento.target.value)} />
                                                        <button
                                                            type="submit"
                                                            className="BotaoAtualizarDescricao"
                                                        >
                                                            Atualizar
                                                        </button>
                                                    </div>
                                                </form>




                                                <div className="ConteudoListarConsulta Descricao">

                                                    <div className="ConteudoLinhas">
                                                        <div className="valorListar">
                                                            {MinhasConsultas.descricao}
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </article>
                                    </div>
                                )
                            })
                        )}


                        {/* Paciente */}
                        {TipoLogado === '3' && (

                            ListaMinhasConsultas.map((MinhasConsultas) => {
                                console.log(MinhasConsultas)
                                return (
                                    <div>
                                        <article className="ConteudoListar">

                                            <div className="ConteudoListarConsulta">

                                                <p className="TituloListarMinhas">Consulta</p>

                                                <div className="ConteudoListarDentro">

                                                    <div className="DataHora">
                                                        <div className="ConteudoLinhas">
                                                            <p className="ChaveListar">
                                                                Data:
                                                            </p>

                                                            <div className="valorListar">
                                                                {Intl.DateTimeFormat("pt-BR", {
                                                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                                                }).format(new Date(MinhasConsultas.dataCon))}
                                                            </div>
                                                        </div>

                                                        <div className="ConteudoLinhas ListarHora">
                                                            <p className="ChaveListar">
                                                                Hora:
                                                            </p>

                                                            <div className="valorListar">
                                                                {MinhasConsultas.hora}
                                                            </div>
                                                        </div>
                                                    </div>



                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Situação:
                                                        </p>

                                                        <div className="valorListar">
                                                            {MinhasConsultas.idSituacaoNavigation.tipoSituacao}
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>


                                            <div>
                                                <p className="TituloListarMinhas">Médico</p>

                                                <div className="ConteudoListarConsulta">

                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Nome:
                                                        </p>

                                                        <div className="valorListar">
                                                            {MinhasConsultas.idMedicoNavigation.nome}
                                                        </div>
                                                    </div>

                                                    <p>
                                                        Especialidade: {MinhasConsultas.idEspecialidadeNavigation.especialidade1}
                                                    </p>

                                                </div>

                                            </div>

                                        </article>
                                    </div>
                                )
                            })

                        )}
                    </div>

                </article>
            </main>

        </div>
    )
};