using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduX_API.Domains
{
    /// <summary>
    /// Definição da classe Categoria
    /// </summary>
    public class Categoria
    {
        //PK
        [Key]
        public Guid IdCategoria { get; set; }
        [Required]
        public string Tipo { get; set; }

        /// <summary>
        /// Criação de Id
        /// </summary>

        public Categoria()
        {
            IdCategoria = Guid.NewGuid();
        }
    }
}