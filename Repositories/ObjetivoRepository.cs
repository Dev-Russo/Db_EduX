using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class ObjetivoRepository : IObjetivoRepository
    {
        private readonly EduXContext _ctx;

        public ObjetivoRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                _ctx.Objetivo.Add(objetivo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Objetivo BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Objetivo.Find(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Objetivo objetivo)
        {
            try
            {
                Objetivo objetivo1 = _ctx.Objetivo.Find(objetivo.IdObjetivo);
                if (objetivo1 == null)
                    throw new Exception("Objetivo não encontrado.");

                objetivo1.Descricao = objetivo.Descricao;

                _ctx.Objetivo.Update(objetivo1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Objetivo> Listar()
        {
            try
            {
                return _ctx.Objetivo.ToList();
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
                Objetivo objetivo1 = _ctx.Objetivo.Find(Id);
                if (objetivo1 == null)
                    throw new Exception("Objetivo excluido com sucesso!");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}