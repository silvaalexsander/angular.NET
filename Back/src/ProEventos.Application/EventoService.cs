using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetAllEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEventos(Evento model, int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);
                if(evento == null) return null;
                model.Id = eventoId;

                _geralPersist.Update(model);

                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetAllEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

       public async Task<bool> DeleteEventos(int eventoId)
        {
             try
            {
                var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento para deletar não foi encontrado");
                _geralPersist.Delete(evento);
                return await _geralPersist.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
           try
           {
                var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, includePalestrantes);
                if(evento == null) return null;
                return evento;
           }catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
        }

        public async Task<List<Evento>> GetAllEventosAsync(bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null) return null;
                return eventos;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
        
}