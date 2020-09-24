using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class ProfessorTurma
    {
        [Key]
        //PK : ID PROFESSOR E DESCRIÇÃO
        public Guid IdProfessorTurma { get; set; }
        public string Descricao { get; set; }

        //CRIAR NOVOS ID AUTOMATICAMENTE
        public ProfessorTurma()
        {
            IdProfessorTurma = Guid.NewGuid();
        }

        //FK : ID USUARIO E ID TURMA
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public Guid IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; } 
    }
}
