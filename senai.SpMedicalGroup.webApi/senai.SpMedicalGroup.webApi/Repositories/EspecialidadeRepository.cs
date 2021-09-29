using senai.SpMedicalGroup.webApi.Context;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();

        public void Atualizar(int Id, Especialidade EspecialidadeAtualizada)
        {
            Especialidade EspecialidadeBuscada = BuscarPoId(Id);

            if (EspecialidadeAtualizada.Especialidade1 != null)
            {
                EspecialidadeBuscada.Especialidade1 = EspecialidadeAtualizada.Especialidade1;
            }

            Ctx.Especialidades.Update(EspecialidadeBuscada);

            Ctx.SaveChanges();
        }

        public Especialidade BuscarPoId(int Id)
        {
            return Ctx.Especialidades.FirstOrDefault(c => c.IdEspecialidade == Id);
        }

        public void Cadastrar(Especialidade EspecialidadeNova)
        {
            Ctx.Especialidades.Add(EspecialidadeNova);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Especialidade EspecialidadeBuscada = BuscarPoId(Id);

            Ctx.Especialidades.Remove(EspecialidadeBuscada);

            Ctx.SaveChanges();
        }

        public List<Especialidade> ListarTodos()
        {
            return Ctx.Especialidades.ToList();
        }
    }
}
