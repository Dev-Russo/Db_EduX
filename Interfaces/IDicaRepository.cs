using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface IDicaRepository
    {

        //Listar por Dicas
        List<Dica> Listar();
        //Faz a busca pelos ID
        Dica BuscarPorId(Guid Id);
        //Adiciona uma Dica
        void Adicionar(Dica dica);
        //Edita a Dica
        void Editar(Dica dica);
        //Remove a Dica deste ID
        void Remover(Guid Id);
    }
}
