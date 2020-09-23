using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduX_API.Domains
{
    public class Turma
    {

        //PK
        [Key]
        public Guid IdTurma { get; set; }
        public string Descricao { get; set; }

        /// <summary>
        /// Define a classe turma
        /// </summary>
        public Turma()
        {
            IdTurma = Guid.NewGuid();
        }

        //FK : ID CURSO
        public Guid IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }


    }
}