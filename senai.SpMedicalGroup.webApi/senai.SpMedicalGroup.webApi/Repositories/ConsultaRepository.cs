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
            throw new NotImplementedException();
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
            //Ctx.Consulta.Remove();
        }

        public List<Consultum> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
