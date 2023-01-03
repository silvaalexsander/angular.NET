using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    
    public IEventoService _eventoService;
    
    public EventoController(IEventoService eventoService)
    {
            _eventoService = eventoService;
        
    }

    [HttpGet]
    public async Task<ActionResult<Evento>> Get()
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if(eventos == null) return NotFound("Nenhum conteudo encontrado");
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> GetByID(int id)
    {
        try
        {
            var evento = await _eventoService.GetAllEventoByIdAsync(id, true);
            if(evento == null) return NotFound($"Nenhum conteudo encontrado com o id {id}");
            return Ok(evento);
        }catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
        }
    }

    [HttpGet("tema/{tema}")]
    public async Task<ActionResult<Evento>> GetByTema(string tema)
    {
        try
        {
            var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if(evento == null) return NotFound($"Nenhum conteudo encontrado com o tema {tema}");
            return Ok(evento);
        }catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Evento>> Post(Evento model)
    {
        try
        {
            var evento = await _eventoService.AddEventos(model);
            if(evento == null) return BadRequest("Erro ao tentar adicionar evento");
            return Ok(evento);
        }catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Evento>> Put(int id, Evento model)
    {
        try
        {
            var evento = await _eventoService.UpdateEventos(model, id);
            if(evento == null) return BadRequest("Erro ao tentar atualizar evento");
            return Ok(evento);
        }catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar atualizar evento. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Evento>> Delete(int id)
    {
        try
        {
            if( await _eventoService.DeleteEventos(id))
                return Ok("Evento deletado com sucesso");
            else
                return BadRequest("Erro ao tentar deletar evento");
        }catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar deletar evento. Erro: {ex.Message}");
        }
    }


}
