using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SpMedicalGroup.webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }
        public DateTime DataCon { get; set; }
        public TimeSpan Hora { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
