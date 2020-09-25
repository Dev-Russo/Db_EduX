using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface ICursoRepository
    {
  
        List<Curso> Listar();
        Curso BuscarPorId(Guid Id);
        void Adicionar(Curso curso);
        void Editar(Curso curso);
        void Remover(Guid Id);
    }
}
