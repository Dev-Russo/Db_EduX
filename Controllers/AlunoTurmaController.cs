using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduX_API.Domains;
using EduX_API.Interfaces;
using EduX_API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurmaRepository _AlunoTurmaRepository;

        public AlunoTurmaController()
        {
            _AlunoTurmaRepository = new AlunoTurmaRepository();
        }

        // GET: api/<AlunoTurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os alunos
                var alunoTurma = _AlunoTurmaRepository.Listar();

                //Verifica se o aluno exista (ou não)
                if (alunoTurma.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e os alunos
                return Ok(new
                {
                    totalCount = alunoTurma.Count,
                    data = alunoTurma
                });
            }
            catch
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Não encontrado
                return BadRequest(new
                {
                    StatusCode = 400,
                    error = "Não foi encontrado, informe o erro para equipeEduX@email.com"
                });
            }
        }


        // GET api/<AlunoTurmaController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar aluno no repositório
                AlunoTurma alunoTurma = _AlunoTurmaRepository.BuscarPorId(Id);

                //Verifica se o aluno existe
                if (alunoTurma == null)
                    return NotFound();

                //Caso o aluno exista
                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AlunoTurmaController>
        [HttpPost]
        public IActionResult Post([FromForm] AlunoTurma alunoTurma)
        {
            try
            {
                //Adicionar um aluno
                _AlunoTurmaRepository.Adicionar(alunoTurma);

                //Retorna OK e os usuários
                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlunoTurmaController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, AlunoTurma alunoTurma)
        {
            try
            {
                var AlunoTemp = _AlunoTurmaRepository.BuscarPorId(Id);

                if (AlunoTemp == null)
                    return NotFound();

                alunoTurma.Id = Id;
                _AlunoTurmaRepository.Editar(alunoTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlunoTurmaController>/
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _AlunoTurmaRepository.Remover(Id);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }
    }
}
