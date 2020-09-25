using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface IProfessorTurmaRepository
    {
        List<ProfessorTurma> Listar();
        ProfessorTurma BuscarPorId(Guid Id);
        void Adicionar(ProfessorTurma professorturma);
        void Editar(ProfessorTurma professorturma);
        void Remover(Guid Id);
    }
}
