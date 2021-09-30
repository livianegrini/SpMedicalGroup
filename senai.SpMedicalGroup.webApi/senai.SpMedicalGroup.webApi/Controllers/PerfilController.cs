using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SpMedicalGroup.webApi.Interfaces;
using senai.SpMedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public PerfilController()
        {
            _UsuarioRepository = new UsuarioRepository();

        }

        [HttpPost("Imagem")]
        public IActionResult Post(IFormFile Arquivo)
        {
            try
            {
                if (Arquivo.Length > 5000000) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                string Extensao = Arquivo.FileName.Split('.').Last();


                if (Extensao != "png" || Extensao != "jpg")
                    return BadRequest(new { mensagem = "Apenas arquivos .png ou .jpg são obrigatórios." });

                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _UsuarioRepository.SalvarPerfilDir(Arquivo, IdUsuario);

                return Ok();

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpGet("Imagem")]
        public IActionResult Get()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string Base64 = _UsuarioRepository.ConsultarPerfilDir(IdUsuario);

                return Ok(Base64);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

   
}
