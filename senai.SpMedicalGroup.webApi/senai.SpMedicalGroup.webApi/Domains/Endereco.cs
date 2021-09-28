using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SpMedicalGroup.webApi.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clinicas = new HashSet<Clinica>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdEndereco { get; set; }
        public string Logadouro { get; set; }
        public short Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }

        public virtual ICollection<Clinica> Clinicas { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
