using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduX_API.Domains
{
    /// <summary>
    /// Definição da classe Categoria
    /// </summary>
    public class Categoria : BaseDomain
    {
     
        [Required]
        public string Tipo { get; set; }

    }
}