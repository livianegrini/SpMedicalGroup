using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using senai.SpMedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _TipoUsuarioRepository que irá receber todos os métodos definidos na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _TipoUsuarioRepository para que haja referência às implementações feitas no repositório TipoUsuarioRepository
        /// </summary>
        public TiposUsuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Tipos de Usuarios
        /// </summary>
        /// <returns>Uma lita de Tipos de Usuarios com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_TipoUsuarioRepository.ListarTodos());
        }

        /// <summary>
        /// Busca um TipoUsuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Tipo Usuario que será buscado</param>
        /// <returns>Um Tipo Usuario encontrado com o status code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPoId(Id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum Tipo de Usuario encontrado!");
            }
            return Ok(TipoUsuarioBuscado);
        }

        /// <summary>
        /// Atualiza um Tipo Usuario existente
        /// </summary>
        /// <param name="Id">Id do Tipo Usuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">>Objeto TipoUsuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, TipoUsuario TipoUsuarioAtualizado)
        {
            _TipoUsuarioRepository.Atualizar(Id, TipoUsuarioAtualizado);

            return Ok();
        }

        /// <summary>
        /// Cadastra um Tipo Usuario
        /// </summary>
        /// <param name="TipoUsuarioNovo">>Objeto TipoUsuarioNovo com as informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario TipoUsuarioNovo)
        {
            _TipoUsuarioRepository.Cadastrar(TipoUsuarioNovo);

            return Ok();
        }

        /// <summary>
        /// Deleta um Tipo Usuario existente
        /// </summary>
        /// <param name="Id">Id da TipoUsuario que será deletado</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _TipoUsuarioRepository.Deletar(Id);
            return Ok();
        }
    }
}
