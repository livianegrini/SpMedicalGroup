import { useState, useEffect } from "react";
import axios from 'axios';

export default function Consultas() {
    const [ListaConsultas, SetListaConsultas] = useState([]);

    function BuscarConsultas() {
        axios('http://192.168.0.15:5000/api/Consultas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-Login')
            }
        })
            .then(Resposta => {
                if (Resposta.status === 200) {
                    // console.log(resposta.data)
                    SetListaConsultas(Resposta.data)
                };
            })
            .catch(Erro => console.log(Erro));
    };

    useEffect(BuscarConsultas, []);

    return (
        <div>

            <main>
                <section>
                    <article>

                        <h2>Consultas</h2>

                        <div>

                            {
                                ListaConsultas.map((Consulta) => {
                                    return (
                                        <div key={MinhaConsulta.idConsulta}>
                                            <p>Data Consulta</p>
                                            <p>{Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'short', day: 'numeric'
                                            }).format(new Date(MinhaConsulta.dataCon))}</p>

                                            <p>Hora</p>
                                            <p>{MinhaConsulta.hora}</p>

                                            <p>Situação</p>
                                            <p>{MinhaConsulta.situacao}</p>

                                            

                                            <p>Descrição</p>
                                            <p>{MinhaConsulta.descricao === undefined ? 'Sem descrição' : MinhaConsulta.descricao}</p>
                                        </div>
                                    )
                                })
                            }

                        </div>

                    </article>
                </section>
            </main>

        </div>
    )
};