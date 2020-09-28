using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduX_API.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        //Trazemos nosso contexto
        private readonly EduXContext _ctx;

        public AlunoTurmaRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Adicionar um novo aluno
        /// </summary>
        /// <param name="alunoturma">Novo aluno</param>
        public void Adicionar(AlunoTurma alunoturma)
        {
            try
            {
                //Adicionar um aluno
                _ctx.AlunoTurma.Add(alunoturma);
                //Salvar alterações
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Encontrar um aluno pelo seu ID
        /// </summary>
        /// <param name="Id">Id do aluno</param>
        /// <returns>Aluno encontrado</returns>
        public AlunoTurma BuscarPorId(Guid Id)
        {
            try
            {
               // Achar o aluno pelo Id
                return _ctx.AlunoTurma.Find(Id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Fazer uma alteração no cadastro do aluno
        /// </summary>
        /// <param name="alunoturma">Aluno alterado</param>
        public void Editar(AlunoTurma alunoturma)
        {
            try
            {
                //Busca o Id do aluno
                AlunoTurma alunoTurma1 = BuscarPorId(alunoturma.Id);

                //Verificar se o aluno existe (ou não)
                if (alunoTurma1 == null)
                    throw new Exception("Aluno não encontrado");

                //Dados do aluno que podem ser alterados
                alunoTurma1.Matricula = alunoturma.Matricula;
                alunoTurma1.Turma = alunoturma.Turma;
                alunoTurma1.Usuario = alunoturma.Usuario;

                //Alterar
                _ctx.AlunoTurma.Update(alunoTurma1);
                //Salvar
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Listar os alunos cadatrados
        /// </summary>
        /// <returns>Lista de alunos</returns>
        public List<AlunoTurma> Listar()
        {
            try 
            {
                //Retornar minha lista de alunos
                return _ctx.AlunoTurma.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remover um aluno
        /// </summary>
        /// <param name="Id">Id do aluno excluído</param>
        public void Remover(Guid Id)
        {
            try
            {
                //Busca o Id do aluno
                AlunoTurma alunoTurma1 = BuscarPorId(Id);

                //Verificar se o aluno existe (ou não)
                if (alunoTurma1 == null)
                    throw new Exception("Aluno não encontrado");

                //Remove o aluno
                _ctx.AlunoTurma.Remove(alunoTurma1);
                //Salva Alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
