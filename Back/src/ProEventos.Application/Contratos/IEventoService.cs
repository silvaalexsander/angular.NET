using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(Evento model, int eventoId);
        Task<bool> DeleteEventos(int eventoId);
        Task<List<Evento>> GetAllEventosAsync( bool includePalestrantes = false);
        Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}