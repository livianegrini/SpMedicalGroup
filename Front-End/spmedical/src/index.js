//Components
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';
import {
  Route,
  BrowserRouter as Router,
  // Redirect,
  Switch,
} from 'react-router-dom';

//fazer services
// import { ParseJwt, UsuarioAutenticado } from './services/auth';

// Pages
// import App from './App';
import Login from './pages/Login/login';
import ListarMinhas from './pages/ListarMinhas/ListarMinhas.jsx';
import ListarTodas from './pages/ListarTodas/ListarTodas';
import CadastrarConsulta from './pages/CadastrarConsulta/CadastrarConsulta';

// const PermissaoAdm = ({ component: Component }) => (
//   <Route
//     render={(Props) =>
//       //If ternário para verificar o tipo de usuário e suas permissoes
//       UsuarioAutenticado() && ParseJwt().role === '1' ? (
//         //estamos copiando todas  as propriedades da tela anterior
//         <Component {...Props} />
//       ) : (
//         <Redirect to="/CadastrarConsulta" />
//       )
//     }
//   />
// );

// const PermissaoMedico = ({ component: Component }) => (
//   <Route
//     render={(Props) =>
//       UsuarioAutenticado() && ParseJwt().role === '2' ? (
//         // operador spread
//         <Component {...Props} />
//       ) : (
//         <Redirect to="Login" />
//       )
//     }
//   />
// );

// const PermissaoPaciente = ({ component: Component }) => (
//   <Route
//     render={(Props) =>
//       UsuarioAutenticado() && ParseJwt().role === '3' ? (
//         // operador spread
//         <Component {...Props} />
//       ) : (
//         <Redirect to="Login" />
//       )
//     }
//   />
// );

const routing = (
<Router>
  <div>
   <Switch>
       <Route exact path="/" component={Login} /> 
       <Route path="/MinhasConsultas" component={ListarMinhas} /> 
       <Route path="/Consultas" component={ListarTodas} /> 
       <Route path="/CadastrarConsulta" component={CadastrarConsulta} /> 

       {/* //Ir fazneod conforme faz as paginas */}
   </Switch>
  </div>
</Router>
);

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
