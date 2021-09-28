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

        [HttpPost]
        public IActionResult Cadastrar(Consultum ConsultaNova)
        {
            _ConsultaRepository.Cadastrar(ConsultaNova);

            return Ok();
        }
    }
}
