using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IPalestrantePersist
    {

        
        // PALESTRANTES
        Task<Palestrante[]> GetAllEventosPalestranteByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync( bool includeEventos);
        Task<Palestrante> GetAllPalestrantesByIdAsync(int palestranteId, bool includeEventos);
    }
}