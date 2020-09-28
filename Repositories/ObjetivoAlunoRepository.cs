using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAlunoRepository
    {
        //Trazemos nosso contexto
        private readonly EduXContext _ctx;

        public ObjetivoAlunoRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Adicionar um novo ObjetivoAluno
        /// </summary>
        /// <param name="objetivoaluno">Novo ObjetivoAluno</param>
        public void Adicionar(ObjetivoAluno objetivoaluno)
        {
            try
            {
                //Adiciona um ObjetivoAluno
                _ctx.ObjetivoAluno.Add(objetivoaluno);
                //Salvar mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Buscar ObjetivoAluno por Id
        /// </summary>
        /// <param name="Id">Id procurado</param>
        /// <returns>O ObjetivoAluno encontrado</returns>
        public ObjetivoAluno BuscarPorId(Guid Id)
        {
            try
            {
                //Achar o objetivo aluno pelo Id
                return _ctx.ObjetivoAluno.Find(Id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Alterar ObjetivoAluno
        /// </summary>
        /// <param name="objetivoaluno">ObjetivoAluno alterado</param>
        public void Editar(ObjetivoAluno objetivoaluno)
        {
            try
            {
                //Buscar objetivo aluno pelo Id
                ObjetivoAluno objetivoaluno1 = BuscarPorId(objetivoaluno.Id);

                //Verifica se existe (ou não)
                if (objetivoaluno1 == null)
                    throw new Exception("ObjetivoAluno não encontrado");

                //Dados que podem ser alterados
                objetivoaluno1.Nota = objetivoaluno.Nota;
                objetivoaluno1.Turma = objetivoaluno.Turma;
                objetivoaluno1.DataAlcancado = objetivoaluno.DataAlcancado;

                //Alterar
                _ctx.ObjetivoAluno.Update(objetivoaluno1);

                //Salvar
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Listar os ObjetivosAluno
        /// </summary>
        /// <returns>Lista de objetivos</returns>
        public List<ObjetivoAluno> Listar()
        {
            try
            {
                //Retornar minha lista de ObjetivoAluno
                return _ctx.ObjetivoAluno.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remover um ObjetivoAluno
        /// </summary>
        /// <param name="Id">Id do ObjetivoAluno excluído</param>
        public void Remover(Guid Id)
        {
            try {
                //Busca o Id do objetivo aluno
                ObjetivoAluno objetivoaluno1 = BuscarPorId(Id);

                //Verifica se o objetivoAluno existe (ou não)
                if (objetivoaluno1 == null)
                    throw new Exception("Objetivo Aluno não encontrado");

                //Remover objetivo aluno
                _ctx.ObjetivoAluno.Remove(objetivoaluno1);
                //Salva alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }
    }
}
