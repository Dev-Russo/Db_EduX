using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduX_API.Domains;
using EduX_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoRepository _instituicaoRepository;
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }
        //listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var instituicoes = _instituicaoRepository.Listar();
                if (instituicoes.Count == 0)
                {
                    return NoContent();
                }
                return Ok(new
                {
                    totalCount = instituicoes.Count,
                    data = instituicoes
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    error = ex.Message
                });
            }
        }
        //Buscar por ID
        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            try
            {
                Instituicao instituicao = _instituicaoRepository.BuscarPorId(Id);
                if (instituicao == null)
                {
                    return NoContent();
                }
                return Ok(new
                {
                    data = instituicao
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    error = ex.Message
                });
            }
        }
        //Buscar por nome :)
        [HttpGet]
        public IActionResult GetByNome(Guid Id)
        {
            try
            {
                List<Instituicao> instituicao = _instituicaoRepository.BuscarPorNome("Nome");
                if (instituicao == null)
                {
                    return NoContent();
                }
                return Ok(new
                {
                    data = instituicao
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    error = ex.Message
                });
            }
        }
        [HttpPut]
        public IActionResult Put(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Adicionar(instituicao);
                return Ok(instituicao);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _instituicaoRepository.Remover(Id);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, Instituicao instituicao)
        {
            try
            {
                var instituicaoContexto = _instituicaoRepository.BuscarPorId(Id);
                if (instituicaoContexto == null)
                {
                    return NotFound();
                }
                instituicao.IdInstituicao = Id;
                _instituicaoRepository.Editar(instituicao);
                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}