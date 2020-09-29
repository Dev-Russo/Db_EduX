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
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly IProfessorTurmaRepository _ProfessorTurmaRepository;

        public ProfessorTurmaController()
        {
            _ProfessorTurmaRepository = new ProfessorTurmaRepository();
        }

        // GET: api/<ProfessorTurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os professores
                var professorTurma = _ProfessorTurmaRepository.Listar();

                //Verifica se o professor existe (ou não)
                if (professorTurma.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e os objetivos
                return Ok(new
                {
                    totalCount = professorTurma.Count,
                    data = professorTurma
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


        // GET api/<ProfessorTurmaController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar professor no repositório
                ProfessorTurma professorTurma = _ProfessorTurmaRepository.BuscarPorId(Id);

                //Verifica se o objetivo existe
                if (professorTurma == null)
                    return NotFound();

                //Caso o objetivo exista
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProfessorTurmaController>
        [HttpPost]
        public IActionResult Post([FromForm] ProfessorTurma professorTurma)
        {
            try
            {
                //Adicionar um professor
                _ProfessorTurmaRepository.Adicionar(professorTurma);

                //Retorna OK e os objetivos
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProfessorTurmaController>/
        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, ProfessorTurma professorTurma)
        {
            try
            {
                var ProfTurma = _ProfessorTurmaRepository.BuscarPorId(Id);

                if (ProfTurma == null)
                    return NotFound();

                ProfTurma.Id = Id;
                _ProfessorTurmaRepository.Editar(professorTurma);

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProfessorTurmaController>/
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _ProfessorTurmaRepository.Remover(Id);
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