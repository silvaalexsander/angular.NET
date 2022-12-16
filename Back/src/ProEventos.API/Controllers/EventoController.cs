using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    
    private readonly DataContext _context;
    public EventoController(DataContext context)
    {
        _context = context;
    }

  

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos.OrderByDescending(e => e.EventoID);
    }

    [HttpGet("{id}")]
    public Evento GetByID(int id)
    {
        return _context.Eventos.SingleOrDefault(e => e.EventoID == id);
    }

    [HttpPost]
    public Evento Post([FromBody] Evento evento)
    {
        _context.Add(evento);
        _context.SaveChanges();
        return evento;
    }


}
