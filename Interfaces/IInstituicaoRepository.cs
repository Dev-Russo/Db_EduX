using EduX_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Interfaces
{
    public interface IInstituicaoRepository
    {
        //Listar por Instituições
        List<Instituicao> Listar();
        //Faz a busca pelos ID
        Instituicao BuscarPorId(Guid Id);
        //Lista Por nomes das instituições
        List<Instituicao> BuscarPorNome(string Nome);
        //Adiciona uma instituiçao
        void Adicionar(Instituicao instituicao);
        //Edita a Instituiçao
        void Editar(Instituicao instituicao);
        //Remove a instituição deste ID
        void Remover(Guid Id);
    }
}
