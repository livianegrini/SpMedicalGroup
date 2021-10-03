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
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();

        public void AprovarRecusar(int IdConsulta, string Situacao)
        {
            Consultum ConsultaBuscada = Ctx.Consulta.FirstOrDefault(c => c.IdConsulta == IdConsulta);

            switch (Situacao)
            {
                case "1":
                    ConsultaBuscada.IdSituacao = 1;
                    break;

                case "2":
                    ConsultaBuscada.IdSituacao = 2;
                    break;

                case "3":
                    ConsultaBuscada.IdSituacao = 3;
                    break;

                default:
                    ConsultaBuscada.IdSituacao = ConsultaBuscada.IdSituacao;
                    break;
            }

            Ctx.Consulta.Update(ConsultaBuscada);

            Ctx.SaveChanges();
        }

        public void Atualizar(int Id, Consultum ConsultaAtualizada)
        {
            Consultum ConsultaBuscada = BuscarPoId(Id);

            var HorarioMinimo = new TimeSpan(8, 0, 0);
            var HorarioMaximo = new TimeSpan(19, 0, 0);

            if (ConsultaAtualizada.IdPaciente > 0 && ConsultaAtualizada.IdMedico > 0 && ConsultaAtualizada.IdSituacao > 0 && ConsultaAtualizada.DataCon != DateTime.Now && ConsultaAtualizada.Hora > HorarioMinimo && ConsultaAtualizada.Hora < HorarioMaximo && ConsultaAtualizada.Descricao != null)
            {
                ConsultaBuscada.IdPaciente = ConsultaAtualizada.IdPaciente;
                ConsultaBuscada.IdMedico = ConsultaAtualizada.IdMedico;
                ConsultaBuscada.IdSituacao = ConsultaAtualizada.IdSituacao;
                ConsultaBuscada.DataCon = ConsultaAtualizada.DataCon;
                ConsultaBuscada.Hora = ConsultaAtualizada.Hora;
                ConsultaBuscada.Descricao = ConsultaAtualizada.Descricao;

                Ctx.Consulta.Update(ConsultaBuscada);

                Ctx.SaveChanges();
            }  
        }


        public void AtualizarDescricao(int IdConsulta, string DescricaoAtualizada)
        {
            Consultum ConsultaBuscada = BuscarPoId(IdConsulta);

            if (DescricaoAtualizada != null && ConsultaBuscada != null)
            {
                   ConsultaBuscada.Descricao = DescricaoAtualizada;

                    Ctx.Consulta.Update(ConsultaBuscada);

                   Ctx.SaveChanges(); 
            }
         
        }

        public Consultum BuscarPoId(int Id)
        {
            return Ctx.Consulta
                .Include("IdPacienteNavigation")
                .Include("IdMedicoNavigation")
                .Include("IdSituacaoNavigation")
                .FirstOrDefault(c => c.IdConsulta == Id);
        }

        public void Cadastrar(Consultum ConsultaNova)
        {
            Ctx.Consulta.Add(ConsultaNova);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Consultum ConsultaBuscada = BuscarPoId(Id);

            Ctx.Consulta.Remove(ConsultaBuscada);

            Ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int IdUsuario)
        {
            return Ctx.Consulta
                .Select(c => new Consultum
                {
                    IdConsulta = c.IdConsulta,
                    DataCon = c.DataCon,
                    Hora = c.Hora,
                    Descricao = c.Descricao,
                    IdPacienteNavigation = new Paciente
                    {
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        Nome = c.IdPacienteNavigation.Nome,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        Rg = c.IdPacienteNavigation.Rg,
                        Cpf = c.IdPacienteNavigation.Cpf,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        Nome = c.IdMedicoNavigation.Nome,
                        Crm = c.IdMedicoNavigation.Crm,
                        IdEspecialidadeNavigation = new Especialidade
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                            Especialidade1 = c.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidade1
                        },
                    },
                    IdSituacaoNavigation = new Situacao
                    {
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        TipoSituacao = c.IdSituacaoNavigation.TipoSituacao
                    }
                })
                 .Where(c => c.IdMedicoNavigation.IdUsuario == IdUsuario || c.IdPacienteNavigation.IdUsuario == IdUsuario)
                 .ToList();
        }

   

        public List<Consultum> ListarTodos()
        {
            return Ctx.Consulta
                .Select(c => new Consultum
                {
                    IdConsulta = c.IdConsulta,
                    DataCon = c.DataCon,
                    Hora = c.Hora,
                    Descricao = c.Descricao,
                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        Nome = c.IdPacienteNavigation.Nome,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        Rg = c.IdPacienteNavigation.Rg,
                        Cpf = c.IdPacienteNavigation.Cpf,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        Nome = c.IdMedicoNavigation.Nome,
                        Crm = c.IdMedicoNavigation.Crm,
                        IdEspecialidadeNavigation = new Especialidade
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                            Especialidade1 = c.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidade1
                        },

                        IdClinicaNavigation = new Clinica
                        {
                            IdClinica = c.IdMedicoNavigation.IdClinicaNavigation.IdClinica,
                            HorarioInicio = c.IdMedicoNavigation.IdClinicaNavigation.HorarioInicio,
                            HorarioFim = c.IdMedicoNavigation.IdClinicaNavigation.HorarioFim,
                            Cnpj = c.IdMedicoNavigation.IdClinicaNavigation.Cnpj,
                            NomeFantasia = c.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                            RazaoSocial = c.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial
                        }
                    },
                    IdSituacaoNavigation = new Situacao
                    {
                       IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                       TipoSituacao = c.IdSituacaoNavigation.TipoSituacao
                    }
                }).ToList();
        }
    }
}
