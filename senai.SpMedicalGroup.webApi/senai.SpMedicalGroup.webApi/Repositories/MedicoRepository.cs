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

            if (MedicoAtualizado.IdUsuario > 0 && MedicoAtualizado.IdClinica > 0 && MedicoAtualizado.IdEspecialidade > 0 && MedicoAtualizado.Crm != null && MedicoAtualizado.Nome != null)
            {
                MedicoBuscado.IdUsuario = MedicoAtualizado.IdUsuario;
                MedicoBuscado.IdClinica = MedicoAtualizado.IdClinica;
                MedicoBuscado.IdEspecialidade = MedicoAtualizado.IdEspecialidade;
                MedicoBuscado.Crm = MedicoAtualizado.Crm;
                MedicoBuscado.Nome = MedicoAtualizado.Nome;

                Ctx.Medicos.Update(MedicoBuscado);

                Ctx.SaveChanges();
            }
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
                .Select(c => new Medico
                {
                    IdMedico= c.IdMedico,
                    Crm = c.Crm,
                    Nome = c.Nome,
                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = c.IdClinicaNavigation.IdClinica,
                        HorarioInicio = c.IdClinicaNavigation.HorarioInicio,
                        HorarioFim = c.IdClinicaNavigation.HorarioFim,
                        Cnpj = c.IdClinicaNavigation.Cnpj,
                        NomeFantasia = c.IdClinicaNavigation.NomeFantasia,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial
                    },
                    IdEspecialidadeNavigation = new Especialidade
                    {
                        IdEspecialidade = c.IdEspecialidadeNavigation.IdEspecialidade,
                        Especialidade1 = c.IdEspecialidadeNavigation.Especialidade1
                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = c.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuario,
                        Email = c.IdUsuarioNavigation.Email,
                        Senha = c.IdUsuarioNavigation.Senha
                    }
                }).ToList();
        }
    }
}
