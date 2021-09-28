using senai.SpMedicalGroup.webApi.Context;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();
        public Usuario Login(string Email, string Senha)
        {
            return Ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }
    }
}
