import { useState, useEffect } from "react";
import axios from "axios";
// import { Link } from 'react-router-dom';
import { ParseJwt, usuarioAutenticado } from '../../services/auth';
import Logo from '../assets/Imagens/logo.png'
import Lapis from '../assets/Imagens/lapis.png'

export default function MinhasConsultas() {

    const [ListaMinhasConsultas, SetListaMinhasConsultas] = useState([]);
    const [TipoLogado, setTipoLogado] = useState(null);
    const [idConsultaAlterada, setidConsultaAlterada] = useState(0);
    const [Descricao, setDescricao] = useState('')

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

    function AlterarDescricao(idConsultaAlterada) {
        axios.patch('http://192.168.7.133:5000/api/Consultas/Descricao/' + idConsultaAlterada, {
            descricao: Descricao
        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-Login')
            }
        })
            .then(Resposta => {
                if (Resposta.status === 200) {
                    console.log('Descrição alterada')
                    var btn = document.getElementById("btn" + idConsultaAlterada)
                    var p = document.getElementById("desc" + idConsultaAlterada);
                    var textarea = document.getElementById("descricao" + idConsultaAlterada)
                    btn.style.display = "none";
                    p.style.display = "";
                    textarea.style.display = "none";

                    BuscarMinhasConsultas();
                    setDescricao("")
                }
            })
            .catch(Erro => console.log(Erro))
        BuscarMinhasConsultas();
    }

    useEffect(BuscarMinhasConsultas, []);

    function PermitirTextArea(idConsultaAlterada) {

        // setDescricao(Descricao);
        // console.log(Descricao)
        // var textoDescricao = document.getElementById("descricao" + IdConsulta)
        // document.getElementById("descricao" + IdConsulta).value = Descricao

        // if (textoDescricao.value === null || textoDescricao.value === "") {
        //     textoDescricao.value = "Consulta sem descrição";

        // }
        var btn = document.getElementById("btn" + idConsultaAlterada);
        var p = document.getElementById("desc" + idConsultaAlterada);
        var textarea = document.getElementById("descricao" + idConsultaAlterada);

        if (btn.style.display === "none") {
            btn.style.display = "";
            p.style.display = "none";
            textarea.style.display = "";
        } else {


            p.style.display = "";
            textarea.style.display = "none";

            setDescricao("")
            btn.style.display = "none";
        }


    }




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

                <article className="AlinhamentoDivs">

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

                                                <button className="LapisIcon" onClick={() => PermitirTextArea(MinhasConsultas.idConsulta)}><img src={Lapis} alt="Imagem do lapis" /></button>

                                                <form onSubmit={AlterarDescricao}>
                                                    <div className="ConteudoDescricao">
                                                        <input className="DivDescricao" type="text" name="Descricao" style={{ display: "none" }} id={"descricao" + MinhasConsultas.idConsulta} placeholder="" onChange={(Evento) => setDescricao(Evento.target.value)} />
                                                        <button
                                                            type="submit"
                                                            className="BotaoAtualizarDescricao"
                                                            onClick={() => AlterarDescricao(MinhasConsultas.idConsulta)} style={{ display: "none" }}
                                                            id={"btn" + MinhasConsultas.idConsulta}
                                                        >
                                                            Atualizar
                                                        </button>
                                                    </div>
                                                </form>

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
                        )}


                        {/* Paciente */}
                        {TipoLogado === '3' && (

                            ListaMinhasConsultas.map((MinhasConsultas) => {
                                console.log(MinhasConsultas)
                                return (
                                    <div>
                                        {/* <article className="ConteudoListar">

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
                                                        Especialidade: {MinhasConsultas.idMedicoNavigation.idEspecialidadeNavigation.especialidade1}
                                                    </p>

                                                </div>

                                            </div>

                                        </article> */}

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

                        )}
                    </div>

                </article>
            </main>

        </div>
    )
};