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
    public class LocalizacoesController : ControllerBase
    {
        private ILocalizacaoRepository _LocalizacaoRepository { get; set; }

        public LocalizacoesController()
        {
            _LocalizacaoRepository = new LocalizacaoRepository();
        }

        /// <summary>
        /// Lista todas as Localizações
        /// </summary>
        /// <returns>Uma lita de Localizações com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_LocalizacaoRepository.ListarTodas());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        /// <summary>
        /// Cadastra uma Localização
        /// </summary>
        /// <param name="NovaLocalizacao">>Objeto NovaLocalização com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Localizacao NovaLocalizacao)
        {
            try
            {
                _LocalizacaoRepository.Cadastrar(NovaLocalizacao);

                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }
    }
}
