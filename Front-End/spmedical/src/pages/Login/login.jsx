import { Component } from "react";
import Logo from '../assets/Imagens/logo.png'
import '../assets/css/SpMedical.css'
import axios from "axios";
import { ParseJwt, UsuarioAutenticado } from '../../services/auth';
export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Email: 'adm@gmail.com',
            Senha: '123',
            ErrorMessage: '',
            IsLoading: false
        };
    };

    FazLogin = (Event) => {

        console.log(this.state.Email, this.state.Senha)
        console.log(ParseJwt())

        // ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
        Event.preventDefault();

        //setando o state
        this.setState({ ErrorMessage: '', IsLoading: true });

        //fazendo a parte de requisições para a API
        axios.post('http://localhost:5000/api/Login', {

            //onchange : dizendo que o email que vai ser pedido na requisição é o que está no state, estamos pegando o que usuário 
            //estamos apenas chamando o email
            Email: this.state.Email,
            //estamos apenas chamando a senha
            Senha: this.state.Senha
        })

            // recebendo todo o conteúdo da resposta da requisição na variável resposta
            .then(Resposta => {

                //estamos validando se o status da resposta for igual ao status code 200(Ok)
                if (Resposta.status === 200) {

                    // se sim, exibe no console do navegador o token do usuário logado,
                    // console.log('Meu token é: ' + resposta.data.token);
                    // salva o valor do token no localStorage

                    localStorage.setItem('Usuario-Login', Resposta.data.token)
                    console.log(Resposta.data.token)

                    // definindo que a requisição terminou
                    this.setState({ IsLoading: false });

                    // definindo a variável base64 que vai receber o payload do token
                    // estamos pegando o token, separando por . para conseguirmos pega a segunda propriedade do token, que é o JTI
                    let Base64 = localStorage.getItem('Usuario-Login').split('.')[1];
                    // exibe no console do navegador o valor em base64
                    console.log(Base64);

                    // exibe no console o valor decodificado de base64 para string
                    // console.log(window.atob(base64));

                    // exibe no console do navegador o valor da chave role
                    // console.log( JSON.parse( window.atob(base64) ) );

                    // console.log( parseJwt().role );

                    // exibe as propriedades da página
                    console.log(this.props)


                    switch (ParseJwt().role) {
                        case '1':
                            //redireciona para a página de cadastro de consulta
                            this.props.history.push('/CadastroConsulta');
                            console.log('Estou logado: ' + UsuarioAutenticado())
                            break;

                        case '2':
                            //redireciona para a página de listagem de consultas de médico
                            this.props.history.push('/MinhasConsultas');
                            console.log('Estou logado: ' + UsuarioAutenticado())
                            break;

                        case '3':
                            //redireciona para a página de cadastro de consulta
                            this.props.history.push('/MinhasConsultas');
                            console.log('Estou logado: ' + UsuarioAutenticado())
                            break;

                        default:
                            this.props.history.push('/')
                            break;
                    }
                }
            })

            // Caso haja um erro,
            .catch(() => {
                // define o valor do state erroMensagem com uma mensagem personalizada
                this.setState({ erroMensagem: 'E-mail e/ou senha inválidos!', isLoading: false })
            })
    }

    // Target = alvo
    AtualizarStateCampo = (Campo) => {
        //                  nomeState : novoValor
        // this.setState({ email : 'adm@adm' })
        this.setState({ [Campo.target.name]: Campo.target.value })
    };

    render() {
        return (
            <div>
                <header>
                    <div className="Header">
                        <img className="ImagemLogo" src={Logo} alt="Imagem do logo" />
                    </div>
                </header>

                <main className="LinearGradient">
                    <div className="FundoLogin">
                        <section className="container">
                            <div className="Div_Login">
                                <h1>Login</h1>
                                <div className="Espacamento">
                                    <div className="box_form">
                                        <form onSubmit={this.FazLogin}>
                                        <input
                                            className=""
                                            name="Email"
                                            type="text"
                                            value={this.state.Email}
                                            onChange={this.AtualizarStateCampo}
                                            placeholder="Email"
                                        />

                                        <input
                                            type="password"
                                            name="Senha"
                                            value={this.state.Senha}
                                            onChange={this.AtualizarStateCampo}
                                            placeholder="Senha"
                                        />

                                        {/* {
                                            // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                            this.state.IsLoading === true &&
                                            <button type="submit" disabled className="botao">
                                                Loading...
                                            </button>
                                        }

                                        {
                                            this.state.IsLoading === false &&
                                            <button className="botao" disabled={this.state.Email === '' || this.state.Senha === '' ? 'none' : ''}>
                                                Entrar
                                            </button>
                                        } */}

                                        <button type="submit" className="botao">Entrar</button>
                                        </form>
                                        
                                    </div>

                                    <div>
                                        
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </main>
            </div>
        )
    }

}
