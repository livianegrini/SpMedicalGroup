using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SpMedicalGroup.webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "O campo Medico é obrigatório!")]
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }

        [Required(ErrorMessage = "O campo Data da Consulta é obrigatório!")]
        public DateTime DataCon { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
