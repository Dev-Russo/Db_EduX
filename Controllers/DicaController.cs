using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class DicaController : ControllerBase
    {
        private readonly DicaRepository _dicaRepository;
        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dicas = _dicaRepository.Listar();
                if (dicas.Count == 0)
                {
                    return NoContent();
                }
                return Ok(new
                {
                    totalCount = dicas.Count(),
                    data = dicas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statuscode = 400,
                    error = ex.Message
                });
            }
        }
        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            try
            {
                Dica dica = _dicaRepository.BuscarPorId(Id);
                if (dica == null)
                {
                    return NoContent();
                }
                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Dica dica)
        {
            try
            {
                _dicaRepository.Adicionar(dica);
                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{Id}")]
        public IActionResult Uptade(Guid Id, Dica dica)
        {
            try
            {
                var dicaContexto = _dicaRepository.BuscarPorId(Id);
                if (dicaContexto == null)
                {
                    return NoContent();
                }
                dica.Id = Id;
                _dicaRepository.Editar(dica);
                return Ok(dica);
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
                _dicaRepository.Remover(Id);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}