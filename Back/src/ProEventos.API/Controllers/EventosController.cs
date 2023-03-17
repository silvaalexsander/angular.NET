using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if(eventos == null)
                {
                    return NotFound("Nenhum evento encontrado!");
                }
                return Ok(eventos);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetById(int id)
        {
            try{
                var evento = await _eventoService.GetAllEventoByIdAsync(id, true);
                if(evento == null)
                {
                    return NotFound("Nenhum evento encontrado com o id informado");
                }
                return evento;
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<ActionResult> GetByTema(string tema)
        {
            try{
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if(evento == null)
                {
                    return NotFound("Nenhum evento encontrado com o tema informado");
                }
                return Ok(evento);
            }catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if(evento == null)
                {
                    return BadRequest("Erro ao tentar adicionar evento");
                }
                return Ok(evento);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
      
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEventos(model, id);
                if(evento == null)
                {
                    return BadRequest("Erro ao tentar atualizar evento");
                }
                return Ok(evento);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _eventoService.DeleteEventos(id);
                if(evento == false)
                {
                    return BadRequest("Erro ao tentar deletar evento");
                }
                return Ok("Evento deletado com sucesso");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}