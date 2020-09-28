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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os usuários
                var usuario = _usuarioRepository.Listar();

                //Verifica se o usuário exista (ou não)
                if (usuario.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e os usuários
                return Ok(new
                {
                    totalCount = usuario.Count,
                    data = usuario
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


        // GET api/<UsuarioController>/5
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar usuário no repositório
                Usuario usuario = _usuarioRepository.BuscarPorId(Id);

                //Verifica se o usuário existe
                if (usuario == null)
                    return NotFound();

                //Caso o usuário exista
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromForm] Usuario usuario)
        {
            try
            {
                //Adicionar um produto
                _usuarioRepository.Adicionar(usuario);

                //Retorna OK e os usuários
                return Ok(usuario);
            }
            catch(Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, Usuario usuario)
        {
            try
            {
                var usuarioTemp = _usuarioRepository.BuscarPorId(Id);

                if (usuarioTemp == null)
                    return NotFound();

                usuario.Id = Id;
                _usuarioRepository.Editar(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _usuarioRepository.Remover(Id);
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
