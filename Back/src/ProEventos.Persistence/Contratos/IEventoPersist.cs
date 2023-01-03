using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IEventoPersist
    {
        // EVENTOS;

        Task<List<Evento>> GetAllEventosAsync( bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false);
        
       
    }
}