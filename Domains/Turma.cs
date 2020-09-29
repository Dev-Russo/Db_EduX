using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduX_API.Domains
{
    public class Turma : BaseDomain
    {


        public string Descricao { get; set; }

        //FK : ID CURSO
        public Guid IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }


    }
}