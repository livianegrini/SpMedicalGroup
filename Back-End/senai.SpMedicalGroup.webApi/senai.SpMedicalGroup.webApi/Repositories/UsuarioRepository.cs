using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using senai.SpMedicalGroup.webApi.Context;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();

        public void Atualizar(int Id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = BuscarPoId(Id);

            if (UsuarioAtualizado.IdTipoUsuario > 0 && UsuarioAtualizado.Email != null && UsuarioAtualizado.Senha != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;

                Ctx.Usuarios.Update(UsuarioBuscado);

                Ctx.SaveChanges();
            }
        }

        public Usuario BuscarPoId(int Id)
        {
            return Ctx.Usuarios
                .Include("IdTipoUsuarioNavigation")
                .FirstOrDefault(c => c.IdUsuario == Id);
        }

        public void Cadastrar(Usuario UsuarioNovo)
        {
            Ctx.Usuarios.Add(UsuarioNovo);
            Ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int IdUsuario)
        {
            string NomeNovo = IdUsuario.ToString() + ".png";
            string Caminho = Path.Combine("Perfil", NomeNovo);

            if (File.Exists(Caminho))
            {
                byte[] BytesArquivo = File.ReadAllBytes(Caminho);
                return Convert.ToBase64String(BytesArquivo);
            }

            return null;
        }

        public void Deletar(int Id)
        {
            Usuario UsuarioBuscado = BuscarPoId(Id);

            Ctx.Usuarios.Remove(UsuarioBuscado); 

            Ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
          return Ctx.Usuarios
                .Select(c => new Usuario
                {
                    IdUsuario = c.IdUsuario,
                    Email = c.Email,
                    Senha = c.Senha,
                    IdTipoUsuarioNavigation = new TipoUsuario
                    {
                        IdTipoUsuario = c.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TipoUsuario1 = c.IdTipoUsuarioNavigation.TipoUsuario1
                    }
                }).ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            return Ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }

        public void SalvarPerfilDir(IFormFile Foto, int IdUsuario)
        {
            string NomeNovo = IdUsuario.ToString() + ".png";

            using (var Strem = new FileStream(Path.Combine("Perfil", NomeNovo), FileMode.Create))
            {
                Foto.CopyTo(Strem);
            }
        }
    }
}
