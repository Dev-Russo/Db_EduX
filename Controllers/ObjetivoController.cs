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
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoRepository _objetivoRepository;

        public ObjetivoController()
        {
            _objetivoRepository = new ObjetivoRepository();
        }

        // GET: api/<ObjetivoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os objetivo
                var objetivo = _objetivoRepository.Listar();

                //Verifica se o objetive existe (ou não)
                if (objetivo.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e os objetivos
                return Ok(new
                {
                    totalCount = objetivo.Count,
                    data = objetivo
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


        // GET api/<ObjetivoController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar objetivo no repositório
                Objetivo objetivo = _objetivoRepository.BuscarPorId(Id);

                //Verifica se o objetivo existe
                if (objetivo == null)
                    return NotFound();

                //Caso o objetivo exista
                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ObjetivoController>
        [HttpPost]
        public IActionResult Post([FromForm] Objetivo objetivo)
        {
            try
            {
                //Adicionar um objetivo
                _objetivoRepository.Adicionar(objetivo);

                //Retorna OK e os objetivos
                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ObjetivoController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, Objetivo objetivo)
        {
            try
            {
                var objetivo1 = _objetivoRepository.BuscarPorId(Id);

                if (objetivo1 == null)
                    return NotFound();

                objetivo1.Id = Id;
                _objetivoRepository.Editar(objetivo1);

                return Ok(objetivo1);
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
                _objetivoRepository.Remover(Id);
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
