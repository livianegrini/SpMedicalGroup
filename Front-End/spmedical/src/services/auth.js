// Definindo a constante UsuarioAutenticado para verificar se o usuário está logado
export const UsuarioAutenticado = () => localStorage.setItem('Usuario-Login') !== null;

// Definindo a constante parseJwt que retorn o payload do usuário logado convertido em JSON
export const ParseJwt = () => {

    // Defininfo a variável base64 que recebe o payload do token do usuário logado
    let Base64 = localStorage.getItem('Usuario-Login').split('.')[1];

    // Converte o valor de base64 para string e em seguida para JSON
    return JSON.parse( window.atob(Base64) );
};