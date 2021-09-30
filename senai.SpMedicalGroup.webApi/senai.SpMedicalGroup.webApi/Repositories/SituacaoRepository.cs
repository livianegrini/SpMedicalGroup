using senai.SpMedicalGroup.webApi.Context;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();

        public void Atualizar(int Id, Situacao SituacaoAtualizada)
        {
            throw new NotImplementedException();
        }

        public Situacao BuscarPoId(int Id)
        {
            return Ctx.Situacaos.FirstOrDefault(c => c.IdSituacao == Id);
        }

        public void Cadastrar(Situacao SituacaoNova)
        {
            Ctx.Situacaos.Add(SituacaoNova);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Situacao SituacaoBuscada = BuscarPoId(Id);

            Ctx.Situacaos.Remove(SituacaoBuscada);

            Ctx.SaveChanges();
        }

        public List<Situacao> ListarTodos()
        {
            return Ctx.Situacaos.ToList();
        }
    }
}
