using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using EduX_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Dados
{
    public class PopularTable
    {
        private readonly EduXContext contexto;
        public PopularTable()
        {
            contexto = new EduXContext();
            Popular();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Popular()
        {
            Perfil perfil = null;
            Perfil perfil2 = null;
            Usuario usuario = null;
            if (!contexto.Perfil.Any())
            {
                perfil = new Perfil
                {
                    Permissao = "Usuario"
                };
                perfil2 = new Perfil
                {
                    Permissao = "Visitante"
                };
                
                contexto.Perfil.Add(perfil);
                contexto.Perfil.Add(perfil2);
                contexto.SaveChanges();
            }

            //if(!contexto.Usuario.Any())
            //{
            //    usuario = new Usuario
            //    {
            //        DataCadastro = DateTime.Now,
            //        Email = "email@email.com",
            //        DataUltimoAcesso = DateTime.Now,
            //        IdPerfil = perfil.Id,
            //        Nome = "Nome de usuário",
            //        Senha = "password"
            //    };
            //    contexto.Usuario.Add(usuario);
            //    contexto.SaveChanges();
            //}

            //if(!contexto.Dica.Any())
            //{

            //    contexto.Dica.Add(new Dica
            //    {
            //        IdUsuario = usuario.Id,
            //        Imagem = "caminhoDaImagem_1",
            //        Texto = "Este texto refere-se a uma dica_1",
            //    });

            //    contexto.dicas.add(new dica
            //    {
            //        usuario = usuario,
            //        imagem = "caminhodaimagem_2",
            //        texto = "este texto refere-se a uma dica_2",
            //    });

            //    contexto.dicas.add(new dica
            //    {
            //        usuario = usuario,
            //        imagem = "caminhodaimagem_3",
            //        texto = "este texto refere-se a uma dica_3",
            //    });

            //    contexto.dicas.add(new dica
            //    {
            //        usuario = usuario,
            //        imagem = "caminhodaimagem_4",
            //        texto = "este texto refere-se a uma dica_4",
            //    });
            //    contexto.dicas.add(new dica
            //    {
            //        usuario = usuario,
            //        imagem = "caminhodaimagem_5",
            //        texto = "este texto refere-se a uma dica_5",
            //    });
            //    contexto.SaveChanges();
            //}
        }
    }
}
