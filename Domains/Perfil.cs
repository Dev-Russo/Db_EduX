using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    public class Perfil
    {
        //PK
        [Key]
        public Guid IdPerfil { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Permissao { get; set; }

        public Perfil()
        {
            IdPerfil = Guid.NewGuid();
        }
    }
}
