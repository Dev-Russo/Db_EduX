using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class ProfessorTurma : BaseDomain
    {
        public string Descricao { get; set; }

        //FK : ID USUARIO E ID TURMA
        public Guid IdUsuario { get; set; }
        [ForeignKey("Id")]
        public Usuario Usuario { get; set; }

        public Guid IdTurma { get; set; }
        [ForeignKey("Id")]
        public Turma Turma { get; set; } 
    }
}
