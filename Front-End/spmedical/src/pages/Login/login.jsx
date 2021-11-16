import { Component } from "react";
import axios from "axios";
import { parseJwt } from ''
constructor(props){
    super(props)
    this.state = {
        Email: '',
        Senha: '',
        ErrorMessage: '',
        IsLoading: false
    };
};

FazLogin = (Event) => {

    // ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
    Event.preventDefault();

    //setando o state
    this.setState({ ErrorMessage: '', IsLoading: true });

    //fazendo a parte de requisições para a API
    axios.post('', {

        //onchange : dizendo que o email que vai ser pedido na requisição é o que está no state, estamos pegando o que usuário 
        //estamos apenas chamando o email
        Email: this.state.Email,
        //estamos apenas chamando a senha
        Senha: this.state.Senha
    })

        // recebendo todo o conteúdo da resposta da requisição na variável resposta
        .then(Resposta => {

            //estamos validando se o status da resposta for igual ao status code 200(Ok)
            if (Resposta === 200) {

                // se sim, exibe no console do navegador o token do usuário logado,
                // console.log('Meu token é: ' + resposta.data.token);
                // salva o valor do token no localStorage

                localStorage.setItem('Usuario-Login', Resposta)

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


                switch (parseJwt().role) {
                    case '1':
                        //redireciona para a página de cadastro de consulta
                        this.props.history.push('/CadastroConsulta');
                        console.log('estou logado: ' + usuarioAutenticado())
                        break;

                    case '2':
                        //redireciona para a página de listagem de consultas de médico
                        this.props.history.push('/MinhasConsultas');
                        console.log('estou logado: ' + usuarioAutenticado())
                        break;

                    case '3':
                        //redireciona para a página de cadastro de consulta
                        this.props.history.push('/MinhasConsultasPaciente');
                        console.log('estou logado: ' + usuarioAutenticado())
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
    this.setState({ [Campo.target.name]: [Campo.target.value] })
};

render(){
    return (
        <div>
            <header>
                <div class="Header">
                    <img class="ImagemLogo" src="./Imagens/logo.png" alt="Imagem do logo" />
                </div>
            </header>

            <main class="LinearGradient">
                <div class="FundoLogin">
                    <section class="container">
                        <div class="Div_Login">
                            <h1>Login</h1>
                            <div class="Espacamento">
                                <div class="box_form">
                                    <input
                                        class=""
                                        name="Email"
                                        type="text"
                                        value={this.state.Email}
                                        onChange={this.AtualizarStateCampo}
                                        placeholder="Email"
                                    />

                                    <input
                                        type="text"
                                        name="Senha"
                                        value={this.state.Senha}
                                        onChange={this.AtualizarStateCampo}
                                        placeholder="Senha"
                                    />

                                    <button class="botao">Entrar</button>
                                </div>

                                <div>
                                        {
                                            // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                            this.state.isLoading === true &&
                                            <button type="submit" disabled id="btn__login">
                                                Loading...
                                            </button>
                                        }

                                    {
                                        this.state.isLoading === false &&
                                        <button disabled={this.state.Email === '' || this.state.Senha === '' ? 'none' : ''}>
                                            Entrar
                                        </button>
                                    }
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