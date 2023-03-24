using ProEventos.API.Dtos;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDTO> AddEventos(EventoDTO model);
        Task<EventoDTO> UpdateEventos(EventoDTO model, int eventoId);
        Task<bool> DeleteEventos(int eventoId);
        Task<List<EventoDTO>> GetAllEventosAsync( bool includePalestrantes = false);
        Task<List<EventoDTO>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDTO> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}