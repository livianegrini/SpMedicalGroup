using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SpMedicalGroup.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public int? IdEndereco { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFim { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
