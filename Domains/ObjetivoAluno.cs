using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class ObjetivoAluno : BaseDomain
    {
        public float Nota { get; set; }
        public DateTime DataAlcancado { get; set; }

        //FK : ID ALUNO TURMA E ID OBJETIVO

        public Guid IdAlunoTurma { get; set; }
        [ForeignKey("Id")]
        public AlunoTurma AlunoTurma { get; set; }

        public Guid IdTurma { get; set; }
        [ForeignKey("Id")]
        public Turma Turma{ get; set; }
    }
}