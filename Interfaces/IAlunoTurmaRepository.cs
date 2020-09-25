using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface IAlunoTurmaRepository
    {
        List<AlunoTurma> Listar();
        AlunoTurma BuscarPorId(Guid Id);
        void Adicionar(AlunoTurma alunoturma);
        void Editar(AlunoTurma alunoturma);
        void Remover(Guid Id);
    }
}
