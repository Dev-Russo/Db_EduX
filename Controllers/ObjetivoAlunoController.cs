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
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAlunoRepository _ObjetivoAlunoRepository;

        public ObjetivoAlunoController()
        {
            _ObjetivoAlunoRepository = new ObjetivoAlunoRepository();
        }

        // GET: api/<ObjetivoAlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os Objetivos
                var objetivoAluno = _ObjetivoAlunoRepository.Listar();

                //Verifica se o objetivo existe (ou não)
                if (objetivoAluno.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e os objetivos
                return Ok(new
                {
                    totalCount = objetivoAluno.Count,
                    data = objetivoAluno
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


        // GET api/<ObjetivoAlunoController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar objetivo no repositório
                ObjetivoAluno objetivoAluno = _ObjetivoAlunoRepository.BuscarPorId(Id);

                //Verifica se o objetivo existe
                if (objetivoAluno == null)
                    return NotFound();

                //Caso o objetivo exista
                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ObjetivoAlunoController>
        [HttpPost]
        public IActionResult Post([FromForm] ObjetivoAluno objetivoAluno)
        {
            try
            {
                //Adicionar um objetivo
                _ObjetivoAlunoRepository.Adicionar(objetivoAluno);

                //Retorna OK e os objetivos
                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ObjetivoAlunoController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, ObjetivoAluno objetivoAluno)
        {
            try
            {
                var ObjAluTemp = _ObjetivoAlunoRepository.BuscarPorId(Id);

                if (ObjAluTemp == null)
                    return NotFound();

                objetivoAluno.Id = Id;
                _ObjetivoAlunoRepository.Editar(objetivoAluno);

                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ObjetivoAlunoController>/
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _ObjetivoAlunoRepository.Remover(Id);
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