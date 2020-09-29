using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduX_API.Domains;
using EduX_API.Interfaces;
using EduX_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaRepository _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var curtidas = _curtidaRepository.Listar();
                if (curtidas.Count == 0)
                {
                    return NoContent();
                }
                return Ok(new
                {
                    totalCount = curtidas.Count,
                    data = curtidas
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
        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            try
            {
                Curtida curtida = _curtidaRepository.BuscarPorId(Id);
                if (curtida == null)
                {
                    return NoContent();
                }
                return Ok(new
                {
                    data = curtida
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
        [HttpGet]
        public IActionResult GetByUsuario(Guid Id)
        {
            try
            {
                List<Curtida> curtidas = _curtidaRepository.ListarPorUsuario(Id);
                if (curtidas.Count == 0)
                {
                    return NoContent();
                }
                return Ok(new
                {
                    totalCount = curtidas.Count(),
                    data = curtidas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = ex.Message
                });
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _curtidaRepository.Remover(Id);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Curtida curtida)
        {
            try
            {
                _curtidaRepository.Adicionar(curtida);
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}