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

            var HorarioMinimo = new TimeSpan(8, 0, 0);
            var HorarioMaximo = new TimeSpan(19, 0, 0);

            if (ClinicaAtualizada.HorarioInicio > HorarioMinimo && ClinicaAtualizada.HorarioFim < HorarioMaximo && ClinicaAtualizada.Cnpj != null && ClinicaAtualizada.NomeFantasia != null && ClinicaAtualizada.RazaoSocial != null)
            {
                ClinicaBuscada.HorarioInicio = ClinicaAtualizada.HorarioInicio;
                ClinicaBuscada.HorarioFim = ClinicaAtualizada.HorarioFim;
                ClinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
                ClinicaBuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
                ClinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;

                Ctx.Clinicas.Update(ClinicaBuscada);

                Ctx.SaveChanges();
            }
        }

        public Clinica BuscarPoId(int Id)
        {
           return Ctx.Clinicas
                .Include("IdEnderecoNavigation")
                .FirstOrDefault(c => c.IdClinica == Id);
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
