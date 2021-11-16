import { Component } from 'react';
import { Link } from 'react-router-dom';

export default class TiposEventos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaTiposEventos: [],
            titulo: '',
            idTipoEventoAlterado: 0,
            titulosecao: 'Lista Tipos Eventos',
        }
    };


};    
