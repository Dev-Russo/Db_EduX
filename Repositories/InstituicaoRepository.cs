using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EduXContext _ctx;
        public InstituicaoRepository()
        {
            //Atribuição por instaciação variavel = new objeto
            _ctx = new EduXContext();
        }
        public void Adicionar(Instituicao instituicao)
        {
            try
            {
                _ctx.Instituicao.Add(instituicao);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Instituicao BuscarPorId(Guid Id)
        {
            try
            {
                //Ultilização de clausula where com expressão lambida.
                return _ctx.Instituicao.Where(i => i.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Instituicao> BuscarPorNome(string Nome)
        {
            try
            {
                return _ctx.Instituicao.Where(i => i.Nome == Nome).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Instituicao instituicao)
        {
            try
            {
                //Atribuição por Objeto
                Instituicao InstituicaoContexto = BuscarPorId(instituicao.Id);
                if (InstituicaoContexto == null)
                {
                    throw new Exception("Essa instituição não existe");
                }
                InstituicaoContexto.Bairro = instituicao.Bairro;
                InstituicaoContexto.CEP = instituicao.CEP;
                InstituicaoContexto.Cidade = instituicao.Cidade;
                InstituicaoContexto.Complemento = instituicao.Complemento;
                InstituicaoContexto.Logradouro = instituicao.Logradouro;
                InstituicaoContexto.Nome = instituicao.Nome;
                InstituicaoContexto.Número = instituicao.Número;
                InstituicaoContexto.UF = instituicao.UF;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Instituicao> Listar()
        {
            try
            {
                return _ctx.Instituicao.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid Id)
        {
            try
            {
                Instituicao instituicao = BuscarPorId(Id);
                if (instituicao == null)
                {
                    throw new Exception("Essa instituição não existe");
                }
                _ctx.Instituicao.Remove(instituicao);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}