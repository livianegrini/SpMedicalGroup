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

            var HorarioMinimo = new TimeSpan(5, 0, 0);
            var HorarioMaximo = new TimeSpan(22, 0, 0);

            if (ConsultaAtualizada.IdPaciente > 0)
            {
                ConsultaBuscada.IdPaciente = ConsultaAtualizada.IdPaciente;
            }
            if (ConsultaAtualizada.IdMedico > 0)
            {
                ConsultaBuscada.IdMedico = ConsultaAtualizada.IdMedico;
            }
            if (ConsultaAtualizada.DataCon != DateTime.Now)
            {
                ConsultaBuscada.DataCon = ConsultaAtualizada.DataCon;
            }
            if (ConsultaAtualizada.Hora > HorarioMinimo && ConsultaAtualizada.Hora < HorarioMaximo)
            {
                ConsultaBuscada.Hora = ConsultaAtualizada.Hora;
            }
            
        }

        public Consultum BuscarPoId(int Id)
        {
            return Ctx.Consulta.FirstOrDefault(c => c.IdConsulta == Id);
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
                .Where(c => c.IdMedicoNavigation.IdUsuario == IdUsuario || c.IdPacienteNavigation.IdUsuario == IdUsuario)
                .ToList();
        }

        //public List<Presenca> ListarMinhas(int idUsuario)
        //{
        //    // Retorna uma lista com todas as informações das presenças
        //    return ctx.Presencas
        //        .Include(p => p.IdUsuarioNavigation)
        //        .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
        //        .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
        //        .Include("IdSituacaoNavigation")
        //        // Estabele como parâmetro de consulta o ID do usuário recebido
        //        .Where(p => p.IdUsuario == idUsuario)
        //        .ToList();
        //}

        public List<Consultum> ListarTodos()
        {
            return Ctx.Consulta.ToList();
        }
    }
}

 //               .Include(c => c.IdMedicoNavigation)
 //               .Include(c => c.IdPacienteNavigation)
 //               .Include(c => c.IdSituacaoNavigation)