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
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// Objeto _PacienteRepository que irá receber todos os métodos definidos na interface IPacienteRepository
        /// </summary>
        private IPacienteRepository _PacienteRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _PacienteRepository para que haja referência às implementações feitas no repositório PacienteRepository
        /// </summary>
        public PacientesController()
        {
            _PacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os Pacientes
        /// </summary>
        /// <returns>Uma lita de Pacientes com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_PacienteRepository.ListarTodos());
        }

        /// <summary>
        /// Busca um Paciente pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Paciente que será buscado</param>
        /// <returns>Um Paciente encontrado com o status code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Paciente PacienteBuscado = _PacienteRepository.BuscarPoId(Id);

            if (PacienteBuscado == null)
            {
                return NotFound("Nenhum Paciente encontrado!");
            }
            return Ok(PacienteBuscado);
        }

        /// <summary>
        /// Atualiza um Paciente existente
        /// </summary>
        /// <param name="Id">Id da Paciente que será atualizado</param>
        /// <param name="PacienteAtualizado">>Objeto PacienteAtualizado com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Paciente PacienteAtualizado)
        {
            try
            {
                if (PacienteAtualizado.DataNascimento < DateTime.Now)
                {

                    Paciente PacienteBuscado = _PacienteRepository.BuscarPoId(Id);


                    if (PacienteBuscado != null)
                    {
                        if (PacienteAtualizado != null)
                            _PacienteRepository.Atualizar(Id, PacienteAtualizado);

                    }
                    else
                    {
                        return BadRequest(new { mensagem = "Paciente informado não encontrado" });
                    }

                    return Ok();
                }
                else
                {
                    return BadRequest(new { mensagem = "A data de nascimento informada é inválida" });
                }  
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um Paciente
        /// </summary>
        /// <param name="PacienteNovo">>Objeto PacienteNovo com as informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(Paciente PacienteNovo)
        {
            _PacienteRepository.Cadastrar(PacienteNovo);

            return Ok();
        }

        /// <summary>
        /// Deleta um Paciente existente
        /// </summary>
        /// <param name="Id">Id da Paciente que será deletado</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _PacienteRepository.Deletar(Id);
            return Ok();
        }
    }
}
