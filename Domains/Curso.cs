using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduX_API.Domains
{
    /// <summary>
    /// Definição da classe Curso 
    /// </summary>
    public class Curso
    //PK
    {
        [Key]
        public Guid IdCurso { get; set; }
        [Required]
        public string Titulo { get; set; }

        /// <summary>
        /// Criação do Id 
        /// </summary>
        public Curso()
        {
            IdCurso = Guid.NewGuid();
        }

        //FK: ID INSTITUIÇÃO
        public Guid IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]
        public Instituicao Instituicao { get; set; }
    }
}