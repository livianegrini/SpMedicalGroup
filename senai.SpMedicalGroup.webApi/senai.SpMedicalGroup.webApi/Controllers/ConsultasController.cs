using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using senai.SpMedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        /// <summary>
        /// Objeto _ConsultaRepository que irá receber todos os métodos definidos na interface IConsultaRepository
        /// </summary>
        IConsultaRepository _ConsultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _ConsultaRepository para que haja referência às implementações feitas no repositório ConsultaRepository
        /// </summary>
        public ConsultasController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Altera a situacao da consulta
        /// </summary>
        /// <param name="Id">Id da Consulta que será aprovada ou recusada</param>
        /// <param name="Situacao">Situacao que a consulta irá receber</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPatch("{Id}")]
        public IActionResult AprovarRecusar(int Id, Consultum Situacao)
        {
            try
            {
                _ConsultaRepository.AprovarRecusar(Id, Situacao.IdSituacao.ToString());
                return Ok();
            }
            catch (Exception Error)
            {
                return BadRequest(Error);
            }
        }

        /// <summary>
        /// Lista todas as Consultas
        /// </summary>
        /// <returns>Uma lita de Consultas com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_ConsultaRepository.ListarTodos());
        }


        /// <summary>
        /// Busca uma Consulta pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Consulta que será buscada</param>
        /// <returns>Uma Consulta encontrada com o status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public  IActionResult BuscarPorId(int Id)
        {
            Consultum ConsultaBuscada = _ConsultaRepository.BuscarPoId(Id);

            if (ConsultaBuscada == null)
            {
                return NotFound("Nenhuma consulta encontrada!");
            }

            return Ok(ConsultaBuscada);
        }

        /// <summary>
        /// Atualiza uma Consulta existente
        /// </summary>
        /// <param name="Id">Id da Consulta que será atualizada</param>
        /// <param name="ConsultaAtualizada">>Objeto ConsultaAtualizada com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Consultum ConsultaAtualizada)
        {
            _ConsultaRepository.Atualizar(Id, ConsultaAtualizada);

            return Ok();
        }

        /// <summary>
        /// Cadastra uma Consulta
        /// </summary>
        /// <param name="ConsultaNova">>Objeto ConsultaNova com as informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(Consultum ConsultaNova)
        {
            _ConsultaRepository.Cadastrar(ConsultaNova);

            return Ok();
        }

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="Id">Id da Consulta que será deletada</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _ConsultaRepository.Deletar(Id);
            return Ok();
        }

        /// <summary>
        /// Lista todas as Consultas de um determinado usuário 
        /// </summary>
        /// <returns>Uma lista de Consultas</returns>
        [HttpGet("Minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_ConsultaRepository.ListarMinhas(IdUsuario));
            }
            catch (Exception Error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    Error

                });
            }
        }

    }
}

