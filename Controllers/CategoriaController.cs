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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar as categorias
                var categoria = _categoriaRepository.Listar();

                //Verifica se a categoria existe (ou não)
                if (categoria.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e as categorias
                return Ok(new
                {
                    totalCount = categoria.Count,
                    data = categoria
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


        // GET api/<CategoriaController>/
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar categoria no repositório
                Categoria categoria = _categoriaRepository.BuscarPorId(Id);

                //Verifica se  existe a categoria
                if (categoria == null)
                    return NotFound();

                //Caso a categoria exista
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromForm] Categoria categoria)
        {
            try
            {
                //Adicionar uma categoria
                _categoriaRepository.Adicionar(categoria);

                //Retorna OK e as categorias
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna uma mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriaController>/
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, Categoria categoria)
        {
            try
            {
                var categoriaTemp = _categoriaRepository.BuscarPorId(Id);

                if (categoriaTemp == null)
                    return NotFound();

                categoria.Id = Id;
                _categoriaRepository.Editar(categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriaController>/
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _categoriaRepository.Remover(Id);
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
