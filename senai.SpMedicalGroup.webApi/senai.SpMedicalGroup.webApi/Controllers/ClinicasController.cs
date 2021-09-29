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
    public class ClinicasController : ControllerBase
    {

        /// <summary>
        /// Objeto _ClinicaRepository que irá receber todos os métodos definidos na interface IClinicaRepository
        /// </summary>
        private IClinicaRepository _ClinicaRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _ClinicaRepository para que haja referência às implementações feitas no repositório ClinicaRepository
        /// </summary>
        public ClinicasController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todas as Clinicas
        /// </summary>
        /// <returns>Uma lita de Clinicas com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_ClinicaRepository.ListarTodos());
        }

        /// <summary>
        /// Busca uma Clinica pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Clinica que será buscada</param>
        /// <returns>Uma Clinica encontrada com o status code 200 - O</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Clinica ClinicaBuscada = _ClinicaRepository.BuscarPoId(Id);

            if (ClinicaBuscada == null)
            {
                return NotFound("Nenhuma clinica encontrada!");
            }
            return Ok(ClinicaBuscada);
        }

        /// <summary>
        /// Atualiza uma Clinica existente
        /// </summary>
        /// <param name="Id">Id da Clinica que será atualizada</param>
        /// <param name="ClinicaAtualizada">>Objeto ClinicaAtualizada com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Clinica ClinicaAtualizada)
        {
            _ClinicaRepository.Atualizar(Id, ClinicaAtualizada);

            return Ok();
        }

        /// <summary>
        /// Cadastra uma Clinica
        /// </summary>
        /// <param name="ClinicaNova">>Objeto ClinicaNova com as informações</param>
        /// <returns>Um status code 200 - Ok </returns>
        [HttpPost]
        public IActionResult Cadastrar(Clinica ClinicaNova)
        {
            _ClinicaRepository.Cadastrar(ClinicaNova);

            return Ok();
        }

        /// <summary>
        /// Deleta uma Clinica existente
        /// </summary>
        /// <param name="Id">Id da Clinica que será deletada</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _ClinicaRepository.Deletar(Id);
            return Ok();
        }
        
    }
}
