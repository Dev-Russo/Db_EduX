using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly EduXContext _ctx;

        public TurmaRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Turma turma)
        {
            try
            {
                _ctx.Turma.Add(turma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Turma BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Turma.Find(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Turma turma)
        {
            try
            {
                Turma turma1 = _ctx.Turma.Find(turma.IdTurma);
                if (turma1 == null)
                    throw new Exception("Turma não encontrada");

                turma1.Descricao = turma.Descricao;

                _ctx.Turma.Update(turma1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Turma> Listar()
        {
            try
            {
                return _ctx.Turma.ToList();
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
                Turma turma1 = _ctx.Turma.Find(Id);
                if (turma1 == null)
                    throw new Exception("Produto removido com sucesso");
                _ctx.Turma.Remove(turma1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}