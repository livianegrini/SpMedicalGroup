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
    public class PacienteRepository : IPacienteRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();

        public void Atualizar(int Id, Paciente PacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public Paciente BuscarPoId(int Id)
        {
            return Ctx.Pacientes.FirstOrDefault(c => c.IdPaciente == Id);
        }

        public void Cadastrar(Paciente PacienteNovo)
        {
            Ctx.Pacientes.Add(PacienteNovo);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Paciente PacienteBuscado = BuscarPoId(Id);

            Ctx.Pacientes.Remove(PacienteBuscado);

            Ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return Ctx.Pacientes
                .Include("IdEnderecoNavigation")
                .Include("IdUsuarioNavigation")
                .ToList();
        }
    }
}
