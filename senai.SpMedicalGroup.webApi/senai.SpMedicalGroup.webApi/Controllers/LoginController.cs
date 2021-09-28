using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using senai.SpMedicalGroup.webApi.Repositories;
using senai.SpMedicalGroup.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="Login">Objeto Login que contém e-mail e senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel Login)
        {
            try
            {
                Usuario UsuarioBuscado = _UsuarioRepository.Login(Login.Email, Login.Senha);

                if (UsuarioBuscado == null)
                {
                    return BadRequest("Email ou senha inválidos!");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString())
                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMedicalGroup-chave-autenticacao"));

                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var Token = new JwtSecurityToken(
                        issuer: "SpMedicalGroup.webApi",
                        audience: "SpMedicalGroup.webApi",
                        claims: Claims,
                        expires: DateTime.Now.AddHours(5),
                        signingCredentials: Creds

                    );

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(Token)
                });
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }
    }
}
