using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid Id);
        List<Usuario> BuscarPorNome(string Nome);
        void Adicionar(Usuario usuario);
        void Editar(Usuario usuario);
        void Remover(Guid Id);
    }
}
