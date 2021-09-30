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
    public class UsuariosController : ControllerBase
    {

        /// <summary>
        /// Objeto _UsuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _UsuarioRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _UsuarioRepository para que haja referência às implementações feitas no repositório UsuarioRepository
        /// </summary>
        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lita de Usuarios com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_UsuarioRepository.ListarTodos());
        }

        /// <summary>
        /// Busca um Usuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Usuario que será buscado</param>
        /// <returns>Um Usuario encontrado com o status code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.BuscarPoId(Id);

            if (UsuarioBuscado == null)
            {
                return NotFound("Nenhum Usuario encontrado!");
            }
            return Ok(UsuarioBuscado);
        }

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="Id">Id do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">>Objeto UsuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Usuario UsuarioAtualizado)
        {
            _UsuarioRepository.Atualizar(Id, UsuarioAtualizado);

            return Ok();
        }

        /// <summary>
        /// Cadastra um Usuario
        /// </summary>
        /// <param name="UsuarioNovo">>Objeto UsuarioNovo com as informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario UsuarioNovo)
        {
            _UsuarioRepository.Cadastrar(UsuarioNovo);

            return Ok();
        }

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="Id">Id do Usuario que será deletado</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _UsuarioRepository.Deletar(Id);
            return Ok();
        }

    }
}
