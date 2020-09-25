using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface IPerfilRepository
    {
        //Listar por perfis
        List<Perfil> Listar();
        //Faz a busca pelos ID
        Perfil BuscarPorId(Guid Id);
        //Lista Por nomes dos perfis
        List<Perfil> BuscarPorNome(string Nome);
        //Adiciona um Perfil 
        void Adicionar(Perfil perfil);
        //Edita o Perfil
        void Editar(Perfil perfil);
        //Remove o perfil deste ID
        void Remover(Guid Id);
    }
}
