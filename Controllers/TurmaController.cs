using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduX_API.Domains;
using EduX_API.Interface;
using EduX_API.Interfaces;
using EduX_API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaController()
        {
            _turmaRepository = new TurmaRepository();
        }

        // GET: api/<TurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar as turmas
                var turma = _turmaRepository.Listar();

                //Verifica se a turma existe (ou não)
                if (turma.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e as turmas
                return Ok(new
                {
                    totalCount = turma.Count,
                    data = turma
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


        // GET api/<TurmaController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar turma no repositório
                Turma turma = _turmaRepository.BuscarPorId(Id);

                //Verifica se a turma existe existe
                if (turma == null)
                    return NotFound();

                //Caso a turma exista
                return Ok(turma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TurmaController>
        [HttpPost]
        public IActionResult Post([FromForm] Turma turma)
        {
            try
            {
                //Adicionar uma turma
                _turmaRepository.Adicionar(turma);

                //Retorna OK e as turmas
                return Ok(turma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TurmaController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, Turma turma)
        {
            try
            {
                var turmaTemp = _turmaRepository.BuscarPorId(Id);

                if (turmaTemp == null)
                    return NotFound();

                turmaTemp.Id = Id;
                _turmaRepository.Editar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _turmaRepository.Remover(Id);
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
