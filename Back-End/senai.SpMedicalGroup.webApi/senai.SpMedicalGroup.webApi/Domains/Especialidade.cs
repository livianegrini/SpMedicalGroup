using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SpMedicalGroup.webApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }
        public string Especialidade1 { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
