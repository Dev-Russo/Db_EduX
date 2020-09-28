using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {
        private readonly EduXContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Curtida curtida)
        {
            try
            {
                _ctx.Curtida.Add(curtida);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Curtida BuscarPorId(Guid Id)
        {
            Curtida curtida = null;
            try
            {
                curtida = _ctx.Curtida.Find(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return curtida;
        }
        public List<Curtida> Listar()
        {
            try
            {
                return _ctx.Curtida.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curtida> ListarPorUsuario(Guid Id)
        {
            try
            {
                return _ctx.Curtida.Where(c => c.IdUsuario == Id).ToList();

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
                Curtida curtida = BuscarPorId(Id);
                if (curtida == null)
                {
                    throw new Exception("Curtida não encontrada");
                }
                _ctx.Remove(curtida);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}