using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduX_API.Domains
{

    public class Objetivo : BaseDomain

    {
        public string Descricao { get; set; }

        //FK em Categoria 
        public Guid IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }

}