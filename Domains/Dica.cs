using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class Dica : BaseDomain
    {
        
        [Column(TypeName = "varchar(255)")]
        public string Texto { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Imagem { get; set; }

        public Dica()
        {
            Id = Guid.NewGuid();
        }

        //IdUsuario : FK
        public Guid IdUsuario { get; set; }
        [ForeignKey("Id")]
        public Usuario Usuario { get; set; }

        public List<Curtida> Curtidas { get; set; }
    }
}
