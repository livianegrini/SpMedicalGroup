// faz a importação do pacote axios
import axios from 'axios';

// define a função para chamada das requisições
const api = axios.create({
  // define a URL base das requisições
  baseURL: 'http://192.168.7.133:5000/api',
  //sempre mudar o IP
});

// define o padrão de exportação
export default api;