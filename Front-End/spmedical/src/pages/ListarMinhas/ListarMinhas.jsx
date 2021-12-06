import { useState, useEffect } from "react";
import axios from "axios";
// import { Link } from 'react-router-dom';

export default function MinhasConsultas() {

    const [ListaMinhasConsultas, SetListaMinhasConsultas] = useState([]);

    function BuscarMinhasConsultas() {
        axios('http://192.168.0.15:5000/api/Consultas/Minhas', {
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

            <main>
                <section>

                    <article>

                        <h2>Minhas Consultas</h2>

                        <div>

                            {
                                ListaMinhasConsultas.map((MinhaConsulta) => {
                                    return (
                                        <div key={MinhaConsulta.idConsulta}>
                                            <p>Data Consulta</p>
                                            <p>{Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'short', day: 'numeric'                                                
                                            }).format(new Date(MinhaConsulta.dataCon))}</p>

                                            <p>Hora</p>
                                            <p>{MinhaConsulta.hora}</p>

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