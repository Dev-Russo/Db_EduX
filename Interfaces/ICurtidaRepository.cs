using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface ICurtidaRepository
    {
        //Listar curtidas
        List<Curtida> Listar();
        //Faz a busca pelos ID
        Curtida BuscarPorId(Guid Id);
        //Listar as curtidas por usuário
        List<Curtida> ListarPorUsuario(Guid Id);
        //Adiciona uma curtida
        void Adicionar(Curtida curtida);
        //Remove a curtida deste ID
        void Remover(Guid Id);
    }
}
