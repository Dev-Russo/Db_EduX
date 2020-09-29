using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly EduXContext _ctx;
        public PerfilRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Perfil perfil)
        {
            try
            {
                _ctx.Perfil.Add(perfil);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Perfil BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Perfil.Find(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Perfil> BuscarPorNome(string Nome)
        {
            try
            {
                return _ctx.Perfil.Where(p => p.Permissao == Nome).ToList();
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Perfil perfil)
        {
            try
            {
                Perfil perfilContexto = _ctx.Perfil.Find(perfil.Id);
                if(perfilContexto != null)
                {
                    perfilContexto.Permissao = perfil.Permissao;
                    _ctx.Perfil.Update(perfilContexto);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perfil> Listar()
        {
            try
            {
                return _ctx.Perfil.ToList();
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
                Perfil perfil = BuscarPorId(Id);
                if (perfil != null)
                {
                    _ctx.Perfil.Remove(perfil);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
