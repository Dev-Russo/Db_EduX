using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduX_API.Domains
{
    public class Curso : BaseDomain
    {

        [Required]
        public string Titulo { get; set; }


        //FK: ID INSTITUIÇÃO
        public Guid IdInstituicao { get; set; }
        [ForeignKey("Id")]
        public Instituicao Instituicao { get; set; }
    }
}