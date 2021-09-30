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
            throw new NotImplementedException();
        }

        public Usuario BuscarPoId(int Id)
        {
            return Ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == Id);
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
            return Ctx.Usuarios.Include("IdTipoUsuarioNavigation").ToList();
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
