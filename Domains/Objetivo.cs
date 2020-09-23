using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduX_API.Domains
{
    /// <summary>
    /// Define a classe Objetivo 
    /// </summary>

    public class Objetivo

    {
        [Key]
        public Guid IdObjetivo { get; set; }
        public string Descricao { get; set; }

        /// <summary>
        /// Define a classe objetivo
        /// </summary>
        public Objetivo()
        {
            IdObjetivo = Guid.NewGuid();
        }

        //FK em Categoria 
        public Guid IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }

}