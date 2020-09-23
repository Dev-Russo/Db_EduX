using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Domains
{
    /// <summary>
    /// Define a classe usuário
    /// </summary>
    public class Usuario
    {
        //PK
        [Key]
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimoAcesso { get; set; }

        /// <summary>
        /// Criar novos ID's
        /// </summary>
        public Usuario()
        {
            IdUsuario = Guid.NewGuid();
        }

        //FK : ID PERFIL
        public Guid IdPerfil { get; set; }
        [ForeignKey("IdPerfil")]
        public Perfil Perfil { get; set; }

        public List<Curtida> Curtidas;
        
    }
}
