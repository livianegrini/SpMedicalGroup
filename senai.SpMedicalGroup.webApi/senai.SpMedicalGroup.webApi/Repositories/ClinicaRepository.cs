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
    public class ClinicaRepository : IClinicaRepository
    {

        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();

        public void Atualizar(int Id, Clinica ClinicaAtualizada)
        {
            Clinica ClinicaBuscada = BuscarPoId(Id);

            if (ClinicaAtualizada.HorarioInicio != null)
            {
                ClinicaBuscada.HorarioInicio = ClinicaAtualizada.HorarioInicio;
            }
            if (ClinicaAtualizada.HorarioFim != null)
            {
                ClinicaBuscada.HorarioFim = ClinicaAtualizada.HorarioFim;
            }
            if (ClinicaAtualizada.Cnpj != null)
            {
                ClinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
            }
            if (ClinicaAtualizada.NomeFantasia != null)
            {
                ClinicaBuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
            }
            if (ClinicaAtualizada.RazaoSocial != null)
            {
                ClinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
            }

            Ctx.Clinicas.Update(ClinicaBuscada);

            Ctx.SaveChanges();
        }

        public Clinica BuscarPoId(int Id)
        {
           return Ctx.Clinicas.FirstOrDefault(c => c.IdClinica == Id);
        }

        public void Cadastrar(Clinica ClinicaNova)
        {
            Ctx.Clinicas.Add(ClinicaNova);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Clinica ClinicaBuscada = BuscarPoId(Id);

            Ctx.Clinicas.Remove(ClinicaBuscada);

            Ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return Ctx.Clinicas.Include(c => c.IdEnderecoNavigation).ToList();
        }

    }
}
