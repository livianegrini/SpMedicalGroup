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
            Medico MedicoBuscado = BuscarPoId(Id);

            //if (MedicoAtualizado.Nome)
            //{
            //    ClinicaBuscada.HorarioInicio = ClinicaAtualizada.HorarioInicio;
            //}
        }

        public Medico BuscarPoId(int Id)
        {
            return Ctx.Medicos
                .Include("IdClinicaNavigation")
                .Include("IdEspecialidadeNavigation")
                .Include("IdUsuarioNavigation")
                .FirstOrDefault(c => c.IdMedico == Id);
        }

        public void Cadastrar(Medico MedicoNovo)
        {
            Ctx.Medicos.Add(MedicoNovo);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Medico MedicoBuscado = BuscarPoId(Id);

            Ctx.Medicos.Remove(MedicoBuscado);

            Ctx.SaveChanges();
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
