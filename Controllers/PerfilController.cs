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
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        // GET: api/<PerfilController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os perfis
                var perfil = _perfilRepository.Listar();

                //Verifica se o perfil existe (ou não)
                if (perfil.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e os perfis
                return Ok(new
                {
                    totalCount = perfil.Count,
                    data = perfil
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


        // GET api/<PerfilController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar perfil no repositório
                Perfil perfil = _perfilRepository.BuscarPorId(Id);

                //Verifica se o perfil existe
                if (perfil == null)
                    return NotFound();

                //Caso o perfil exista
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PerfilController>
        [HttpPost]
        public IActionResult Post([FromForm] Perfil perfil)
        {
            try
            {
                //Adicionar um perfil
                _perfilRepository.Adicionar(perfil);

                //Retorna OK e os perfis
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PerfilController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, Perfil perfil)
        {
            try
            {
                var perfilTemp = _perfilRepository.BuscarPorId(Id);

                if (perfilTemp == null)
                    return NotFound();

                perfil.Id = Id;
                _perfilRepository.Editar(perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PerfilController>/
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _perfilRepository.Remover(Id);
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
