using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    { 
        private readonly EduXContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Adicionar um novo usuário
        /// </summary>
        /// <param name="usuario">Usuário</param>
        public void Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buscar o usuário pelo seu ID
        /// </summary>
        /// <param name="Id">Id do usuário a ser procurado</param>
        /// <returns>Usuário encontrado</returns>
        public Usuario BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buscar o usuário pelo seu Nome
        /// </summary>
        /// <param name="Nome">Nome do usuário a ser procurado</param>
        /// <returns>Usuário encontrado</returns>
        public List<Usuario> BuscarPorNome(string Nome)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fazer mudanças no usuário
        /// </summary>
        /// <param name="usuario">Usuário</param>
        public void Editar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listar os usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários cadastrados</returns>
        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Excluir um usuário cadastrado
        /// </summary>
        /// <param name="Id">Id do usuário excluído</param>
        public void Remover(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
