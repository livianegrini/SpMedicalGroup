using Microsoft.EntityFrameworkCore;
using senai.SpMedicalGroup.webApi.Context;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();

        public void Atualizar(int Id, Medico MedicoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPoId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Medico MedicoNovo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Medico> ListarTodos()
        {
            return Ctx.Medicos
                .Include("IdClinicaNavigation")
                .Include("IdEspecialidadeNavigation")
                .Include("IdUsuarioNavigation")
                .ToList();
        }
    }
}
