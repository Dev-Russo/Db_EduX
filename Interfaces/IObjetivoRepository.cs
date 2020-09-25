using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface IObjetivoRepository
    {
        List<Objetivo> Listar();
        Objetivo BuscarPorId(Guid Id);
        void Adicionar(Objetivo objetivo);
        void Editar(Objetivo objetivo);
        void Remover(Guid Id);
    }
}
