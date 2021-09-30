using senai.SpMedicalGroup.webApi.Context;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();
        public void Atualizar(int Id, TipoUsuario TipoUsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPoId(int Id)
        {
            return Ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoUsuario == Id);
        }

        public void Cadastrar(TipoUsuario TipoUsuarioNovo)
        {
            Ctx.TipoUsuarios.Add(TipoUsuarioNovo);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            TipoUsuario TipoUsuarioBuscado = BuscarPoId(Id);

            Ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            Ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return Ctx.TipoUsuarios.ToList();
        }
    }
}
