using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Dtos;
using ProEventos.Application.Contratos;

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
                    return NoContent();
                }
               
                return Ok(eventos);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDTO>> GetById(int id)
        {
            try{
                var evento = await _eventoService.GetAllEventoByIdAsync(id, true);
                if(evento == null)
                {
                    return NoContent();
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
                    return NoContent();
                }
                return Ok(evento);
            }catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDTO model)
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
      
        public async Task<IActionResult> Put(int id, EventoDTO model)
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
                return Ok(new { message = "Deletado" });
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}