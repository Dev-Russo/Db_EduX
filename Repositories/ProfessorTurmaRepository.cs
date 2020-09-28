using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurmaRepository
    {
        //Trazemos nosso contexto 
        private readonly EduXContext _ctx;

        public ProfessorTurmaRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Adicionar um novo professor
        /// </summary>
        /// <param name="professorturma">Novo professor</param>
        public void Adicionar(ProfessorTurma professorturma)
        {
            //Adiciona um professor
            _ctx.ProfessorTurma.Add(professorturma);
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Encontrar um professor pelo sua ID
        /// </summary>
        /// <param name="Id">Id do professor encontrado</param>
        /// <returns></returns>
        public ProfessorTurma BuscarPorId(Guid Id)
        {
            try
            {
                //Achar professor pelo Id
                return _ctx.ProfessorTurma.Find(Id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Alterar no cadastro do professor
        /// </summary>
        /// <param name="professorturma">Professor alterado</param>
        public void Editar(ProfessorTurma professorturma)
        {
            try
            {
                //Busca o Id do professor
                ProfessorTurma professorturma1 = BuscarPorId(professorturma.Id);

                //Verifica se o professor está no sistema (ou não)
                if (professorturma1 == null)
                    throw new Exception("Professor não encontrado");

                //Dados do professor que podem ser alterados
                professorturma1.Descricao = professorturma.Descricao;
                professorturma1.Turma = professorturma.Turma;
                professorturma1.Usuario = professorturma.Usuario;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ProfessorTurma> Listar()
        {
            try
            {
                //Retornar minha lista de professores
                return _ctx.ProfessorTurma.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remover um professor
        /// </summary>
        /// <param name="Id">Id do professor excluído</param>
        public void Remover(Guid Id)
        {
            try
            {
                //Buscar Id do Professor
                ProfessorTurma professorTurma = BuscarPorId(Id);

                //Verificar se o professor existe (ou não)
                if (professorTurma == null)
                    throw new Exception("Professor não encontrado");

                //Remove o professor 
                _ctx.ProfessorTurma.Remove(professorTurma);

                //Salva as mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
