using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /// Lista todas os Medicos
        /// </summary>
        /// <returns>Uma lita de Medicos com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_MedicoRepository.ListarTodos());
        }
    }
}
