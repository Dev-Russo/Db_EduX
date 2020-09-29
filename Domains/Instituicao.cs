using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class Instituicao : BaseDomain
    {
        
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
    }
}
