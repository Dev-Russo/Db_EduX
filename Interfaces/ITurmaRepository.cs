using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduX_API.Interface
{
    public interface ITurmaRepository
    {

            List<Turma> Listar();
            Turma BuscarPorId(Guid Id);
            void Adicionar(Turma turma);
            void Editar(Turma turma);
            void Remover(Guid Id);
        }
    }
}