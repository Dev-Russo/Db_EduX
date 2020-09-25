using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class Instituicao 
    {
        //PK
        [Key]
      
        public Guid IdInstituicao { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Logradouro { get; set; }
        public int Número { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        /// <summary>
        /// Define a classe instituicao
        /// </summary>
        public Instituicao()
        {
            IdInstituicao = Guid.NewGuid();
        }
    }
}
