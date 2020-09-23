using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class Dica
    {
        //PK
        [Key]
        public Guid IdDica { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Texto { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Imagem { get; set; }

        public Dica()
        {
            IdDica = Guid.NewGuid();
        }

        //IdUsuario : FK
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
