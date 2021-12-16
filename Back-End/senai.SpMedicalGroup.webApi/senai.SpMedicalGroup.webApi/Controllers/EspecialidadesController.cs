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
    public class EspecialidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _EspecialidadeRepository que irá receber todos os métodos definidos na interface IEspecialidadeRepository
        /// </summary>
        private IEspecialidadeRepository _EspecialidadeRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _EspecialidadeRepository para que haja referência às implementações feitas no repositório EspecialidadeRepository
        /// </summary>
        public EspecialidadesController()
        {
            _EspecialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todas as Especialidades
        /// </summary>
        /// <returns>Uma lita de Especialidade com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_EspecialidadeRepository.ListarTodos());
        }

        /// <summary>
        /// Busca uma Especialidade pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Especialidade que será buscada</param>
        /// <returns>Uma Especialidade encontrada com o status code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Especialidade EspecialidadeBuscada = _EspecialidadeRepository.BuscarPoId(Id);

            if (EspecialidadeBuscada == null)
            {
                return NotFound("Nenhuma Especialidade encontrada!");
            }
            return Ok(EspecialidadeBuscada);
        }

        /// <summary>
        /// Atualiza uma Especialidade existente
        /// </summary>
        /// <param name="Id">Id da Especialidade que será atualizada</param>
        /// <param name="EspecialidadeAtualizada">>Objeto EspecialidadeAtualizada com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Especialidade EspecialidadeAtualizada)
        {
            try
            {
                Especialidade EspecialidadeBuscada = _EspecialidadeRepository.BuscarPoId(Id);

                if (EspecialidadeBuscada != null)
                {
                    if (EspecialidadeAtualizada != null)
                        _EspecialidadeRepository.Atualizar(Id, EspecialidadeAtualizada);
                }
                else
                {
                    return BadRequest(new { mensagem = "Especialidade informada não encontrada" });
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        /// <summary>
        /// Cadastra uma Especialidade
        /// </summary>
        /// <param name="EspecialidadeNova">>Objeto EspecialidadeNova com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Especialidade EspecialidadeNova)
        {
            _EspecialidadeRepository.Cadastrar(EspecialidadeNova);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="Id">Id da Especialidade que será deletada</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            if (Id > 0)
            {
                _EspecialidadeRepository.Deletar(Id);
                return Ok();
            }
            
            return BadRequest(new { mensagem = "O Id informado não existe" });
        }
    }
}
