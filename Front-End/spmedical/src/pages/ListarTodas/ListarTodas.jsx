import { useState, useEffect } from "react";
import axios from "axios";
// import { Link } from 'react-router-dom';
import Logo from '../assets/Imagens/logo.png'

export default function MinhasConsultas() {

    const [ListaMinhasConsultas, SetListaMinhasConsultas] = useState([]);

    function BuscarMinhasConsultas() {

        axios('http://192.168.7.133:5000/api/Consultas', {
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

    useEffect(BuscarMinhasConsultas, []);



    return (
        <div>

            <header>
                <div className="Header">
                    <img className="ImagemLogo" src={Logo} alt="Imagem do logo" />
                </div>
            </header>

            <main className="FundoListarTodos">

                <article className="AlinhamentoDivs">

                    <div className="ContainerCards">
                        {
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
                                                <p className="TituloListarMinhas">Medico</p>

                                                <div className="ConteudoListarConsulta">

                                                    <div className="ConteudoLinhas">
                                                        <p className="ChaveListar">
                                                            Nome:
                                                        </p>

                                                        <div className="valorListar">
                                                            {MinhasConsultas.idMedicoNavigation.nome}
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

                                                <div className="ConteudoListarConsulta Descricao">

                                                    <div className="ConteudoLinhas">
                                                        <div className="valorListar" id={"desc" + MinhasConsultas.idConsulta} style={{ display: " " }}>
                                                            {MinhasConsultas.descricao}
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </article>
                                    </div>
                                )
                            })

                        }

                    </div>
                </article>
            </main>

        </div>
    )
};