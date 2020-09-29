using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly EduXContext _ctx;

        public CursoRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Curso.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curso BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Curso.Find(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Curso curso)
        {
            try
            {
                Curso curso1 = _ctx.Curso.Find(curso.Id);
                if (curso1 == null)
                    throw new Exception("Curso não encontrado");

                curso1.Titulo = curso.Titulo;

                _ctx.Curso.Update(curso1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Curso.ToList();
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
                Curso curso1 = _ctx.Curso.Find(Id);
                if (curso1 == null)
                    throw new Exception("Curso removido com sucesso>");
                _ctx.Curso.Remove(curso1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}