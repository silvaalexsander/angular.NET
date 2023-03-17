using ProEventos.Domain;
    public interface IEventoPersist
    {
        // EVENTOS;

        Task<List<Evento>> GetAllEventosAsync( bool includePalestrantes = false);
        Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false);
        
       
    }
