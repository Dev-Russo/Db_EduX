using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface ICurtidaRepository
    {
        //Listar por Instituições
        List<Curtida> Listar();
        //Faz a busca pelos ID
        Curtida BuscarPorId(Guid Id);
        //Adiciona uma instituiçao
        void Adicionar(Curtida curtida);
        //Edita a Instituiçao
        void Editar(Curtida curtida);
        //Remove a instituição deste ID
        void Remover(Guid Id);
    }
}
