using senai.SpMedicalGroup.webApi.Context;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        SpMedicalGroupContext Ctx = new SpMedicalGroupContext();
        public void Atualizar(int Id, Endereco EnderecoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Endereco BuscarPoId(int Id)
        {
            return Ctx.Enderecos.FirstOrDefault(c => c.IdEndereco == Id);
        }

        public void Cadastrar(Endereco EnderecoNovo)
        {
            Ctx.Enderecos.Add(EnderecoNovo);
            Ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Endereco EnderecoBuscado = BuscarPoId(Id);

            Ctx.Enderecos.Remove(EnderecoBuscado);

            Ctx.SaveChanges();
        }

        public List<Endereco> ListarTodos()
        {
            return Ctx.Enderecos.ToList();
        }
    }
}
