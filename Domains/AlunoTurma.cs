using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class AlunoTurma
    {
        //PK
        [Key]
        public Guid IdAlunoTurma { get; set; }
        [Required]
        public string Matricula { get; set; }

        /// <summary>
        /// Define a classe aluno turma
        /// </summary>
        public AlunoTurma()
        {
            IdAlunoTurma = Guid.NewGuid();
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