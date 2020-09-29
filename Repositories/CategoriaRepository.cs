using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly EduXContext _ctx;

        public CategoriaRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Categoria categoria)
        {
            try
            {
                _ctx.Categoria.Add(categoria);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Categoria BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Categoria.Find(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Categoria categoria)
        {
            try
            {
                Categoria categoria1 = _ctx.Categoria.Find(categoria.Id);
                if (categoria1 == null)
                    throw new Exception("Categoria  não encontrada");

                categoria1.Tipo = categoria.Tipo;

                _ctx.Categoria.Update(categoria1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Categoria> Listar()
        {
            try
            {
                return _ctx.Categoria.ToList();
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
                Categoria categoria1 = _ctx.Categoria.Find(Id);
                if (categoria1 == null)
                    throw new Exception("Categoria excluida com sucesso");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}