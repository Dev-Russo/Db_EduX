using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();
        Categoria BuscarPorId(Guid Id);
        void Adicionar(Categoria categoria);
        void Editar(Categoria categoria);
        void Remover(Guid Id);
    }
}
