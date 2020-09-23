using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class ObjetivoAluno
    {
        //PK
        [Key]
        public Guid IdObjetivoAluno { get; set; }
        public float Nota { get; set; }
        public DateTime DataAlcancado { get; set; }

        /// <summary>
        /// Criar novos Id
        /// </summary>
        public ObjetivoAluno()
        {
            IdObjetivoAluno = Guid.NewGuid();
        }

        //FK : ID ALUNO TURMA E ID OBJETIVO

        public Guid IdAlunoTurma { get; set; }
        [ForeignKey("IdObjetivo")]
        public Objetivo Objetivo { get; set; }

        public Guid IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma{ get; set; }
    }
}