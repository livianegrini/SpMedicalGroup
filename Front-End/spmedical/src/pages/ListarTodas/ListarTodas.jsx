import { useState, useEffect } from "react";
import { Link } from 'react-router-dom';

export default function MinhasConsultas(){
    const [ ListaMinhasConsultas, SetListaMinhasConsultas] = useState( [] );

    function BuscarMinhasConsultas(){
        axios('http://localhost:5000/api/Consultas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('Usuario-Login')
            }
        })
        .then(Resposta => {
            if (Resposta.status === 200) {
                // console.log(resposta.data)
                SetListaMinhasConsultas( Resposta.data )
            };
        })
        .catch( Erro => console.log(Erro) );
    };

    useEffect( BuscarMinhasConsultas, [] );

    return(
        <div>

            <main>
                <section>
                    <h2>Minhas Consultas</h2>

                    <table>

                        <thead>
                            <tr>
                                {/* <th>idPresença</th> */}
                                <th>Data Consulta</th>
                                <th>Hora</th>
                                <th></th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>

                        <tbody>

                            {
                                ListaMinhasConsultas.map( (MinhaConsulta) => {
                                    return(
                                        <tr key={MinhaConsulta.idPresenca}>
                                            <td>{MinhaConsulta.idInstituicaoNavigation}</td>
                                            <td>{ Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'short', day: 'numeric',
                                                hour: 'numeric', minute: 'numeric',
                                                hour12: true                                                
                                            }).format(new Date(minhaPresenca.idEventoNavigation.dataEvento)) }</td>
                                            <td>{minhaPresenca.idEventoNavigation.acessoLivre ? 'Livre' : 'Restrito'}</td>
                                            <td>{minhaPresenca.idSituacaoNavigation.descricao}</td>
                                            <td>{minhaPresenca.idEventoNavigation.idTipoEventoNavigation.tituloTipoEvento}</td>
                                            <td>{minhaPresenca.idEventoNavigation.idInstituicaoNavigation.endereco}</td>
                                        </tr>
                                    )
                                } )
                            }
                            
                        </tbody>

                    </table>
                </section>
            </main>

        </div>
    )
};