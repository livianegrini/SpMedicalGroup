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
    public class MedicosController : ControllerBase
    {
        /// <summary>
        /// Objeto _MedicoRepository que irá receber todos os métodos definidos na interface IMedicoRepository
        /// </summary>
        private IMedicoRepository _MedicoRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _MedicoRepository para que haja referência às implementações feitas no repositório MedicoRepository
        /// </summary>
        public MedicosController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os Medicos
        /// </summary>
        /// <returns>Uma lita de Medicos com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_MedicoRepository.ListarTodos());
        }

        /// <summary>
        /// Busca um Medico pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Medico que será buscado</param>
        /// <returns>Um Medico encontrado com o status code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Medico MedicoBuscado = _MedicoRepository.BuscarPoId(Id);

            if (MedicoBuscado == null)
            {
                return NotFound("Nenhum Medico encontrado!");
            }
            return Ok(MedicoBuscado);
        }

        /// <summary>
        /// Atualiza um Medico existente
        /// </summary>
        /// <param name="Id">Id da Medico que será atualizado</param>
        /// <param name="MedicoAtualizado">>Objeto MedicoAtualizado com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Medico MedicoAtualizado)
        {
            try
            {
                Medico MedicoBuscado = _MedicoRepository.BuscarPoId(Id);

                if (MedicoBuscado != null)
                {
                    if (MedicoAtualizado != null)
                        _MedicoRepository.Atualizar(Id, MedicoAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "Medico informado não encontrado" });
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um Medico
        /// </summary>
        /// <param name="MedicoNovo">>Objeto MedicoNovo com as informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(Medico MedicoNovo)
        {
            _MedicoRepository.Cadastrar(MedicoNovo);

            return Ok();
        }

        /// <summary>
        /// Deleta um Medico existente
        /// </summary>
        /// <param name="Id">Id do Medico que será deletado</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _MedicoRepository.Deletar(Id);
            return Ok();
        }
    }
}
