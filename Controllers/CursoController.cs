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
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        // GET: api/<CursoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os cursos
                var curso = _cursoRepository.Listar();

                //Verifica se o curso existe (ou não)
                if (curso.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e os usuários
                return Ok(new
                {
                    totalCount = curso.Count,
                    data = curso
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


        // GET api/<CursoController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar cursi no repositório
                Curso curso = _cursoRepository.BuscarPorId(Id);

                //Verifica se o curso existe
                if (curso == null)
                    return NotFound();

                //Caso o curso exista
                return Ok(curso);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CursoController>
        [HttpPost]
        public IActionResult Post([FromForm] Curso curso)
        {
            try
            {
                //Adicionar um curso
                _cursoRepository.Adicionar(curso);

                //Retorna OK e os cursos
                return Ok(curso);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CursoController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, Curso curso)
        {
            try
            {
                var cursoTemp = _cursoRepository.BuscarPorId(Id);

                if (cursoTemp == null)
                    return NotFound();

                curso.Id = Id;
                _cursoRepository.Editar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CursoController>/
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _cursoRepository.Remover(Id);
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
