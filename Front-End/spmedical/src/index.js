//Components
import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

//fazer services
import { ParseJwt, UsuarioAutenticado } from './services/auth';

// Pages
import App from './App';
import Login from './pages/Login/login';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(Props) =>
      //If ternário para verificar o tipo de usuário e suas permissoes
      UsuarioAutenticado() && ParseJwt().role === '1' ? (
        //estamos copiando todas  as propriedades da tela anterior
        <Component {...Props} />
      ) : (
        <Redirect to="Login" />
      )
    }
  />
);

const PermissaoMedico = ({ component: Component }) => (
  <Route
    render={(Props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        // operador spread
        <Component {...Props} />
      ) : (
        <Redirect to="Login" />
      )
    }
  />
);

const PermissaoPaciente = ({ component: Component }) => (
  <Route
    render={(Props) =>
      usuarioAutenticado() && parseJwt().role === '3' ? (
        // operador spread
        <Component {...Props} />
      ) : (
        <Redirect to="Login" />
      )
    }
  />
);

const routing = (
<Router>
  <div>
   <Switch>
       <Route exact path="/login" component={Login} /> 
       //Ir fazneod conforme faz as paginas
   </Switch>
  </div>
</Router>
);

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
