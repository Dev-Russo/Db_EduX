﻿using System;
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
    public class Usuario : BaseDomain
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimoAcesso { get; set; }


        //FK : ID PERFIL
        public Guid IdPerfil { get; set; }
        [ForeignKey("Id")]
        public Perfil Perfil { get; set; }

       // public List<Curtida> Curtidas { get; set; }
    }
}
