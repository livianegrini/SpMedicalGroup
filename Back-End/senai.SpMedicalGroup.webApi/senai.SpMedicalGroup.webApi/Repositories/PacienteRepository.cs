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
            Paciente PacienteBuscado = BuscarPoId(Id);


            if (PacienteAtualizado.IdUsuario > 0)
            {
                PacienteBuscado.IdUsuario = PacienteAtualizado.IdUsuario;
            }
            if (PacienteAtualizado.IdEndereco > 0)
            {
                PacienteBuscado.IdEndereco = PacienteAtualizado.IdEndereco;
            }
            if (PacienteAtualizado.Nome != null)
            {
                PacienteBuscado.Nome = PacienteAtualizado.Nome;
            }
            if (PacienteAtualizado.DataNascimento < DateTime.Now)
            {
                PacienteBuscado.DataNascimento = PacienteAtualizado.DataNascimento;
            }
            if (PacienteAtualizado.Telefone != null)
            {
                PacienteBuscado.Telefone = PacienteAtualizado.Telefone;
            }
            if (PacienteAtualizado.Rg > 0)
            {
                PacienteBuscado.Rg = PacienteAtualizado.Rg;
            }
            if (PacienteAtualizado.Cpf != null)
            {
                PacienteBuscado.Cpf = PacienteAtualizado.Cpf;
            }

            Ctx.Pacientes.Update(PacienteBuscado);

            Ctx.SaveChanges();
        }

        public Paciente BuscarPoId(int Id)
        {
            return Ctx.Pacientes
                .Include("IdEnderecoNavigation")
                .Include("IdUsuarioNavigation")
                .FirstOrDefault(c => c.IdPaciente == Id);
                
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
                .Select(c => new Paciente
                {
                    IdPaciente = c.IdPaciente,
                    Nome = c.Nome,
                    DataNascimento = c.DataNascimento,
                    Telefone = c.Telefone,
                    Rg = c.Rg,
                    Cpf = c.Cpf,
                    IdEnderecoNavigation = new Endereco
                    {
                        IdEndereco = c.IdEnderecoNavigation.IdEndereco,
                        Logadouro = c.IdEnderecoNavigation.Logadouro,
                        Numero = c.IdEnderecoNavigation.Numero,
                        Bairro = c.IdEnderecoNavigation.Bairro,
                        Municipio = c.IdEnderecoNavigation.Municipio,
                        Estado = c.IdEnderecoNavigation.Estado,
                        Cep = c.IdEnderecoNavigation.Cep,

                    },
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = c.IdUsuarioNavigation.IdUsuario,
                        IdTipoUsuario =c.IdUsuarioNavigation.IdTipoUsuario,
                        Email = c.IdUsuarioNavigation.Email,
                        Senha = c.IdUsuarioNavigation.Senha
                       
                    }
                }).ToList();
        }
    }
}
