using AutoMapper;
using ProEventos.API.Dtos;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
            _mapper = mapper;
        }
        public async Task<EventoDTO> AddEventos(EventoDTO model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                _geralPersist.Add<Evento>(evento);
                if(await _geralPersist.SaveChangesAsync())
                {

                    var eventoRetorno = await _eventoPersist.GetAllEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDTO>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO> UpdateEventos(EventoDTO model, int eventoId)
        {
                   try
                        {   
                            
                            var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);
                            if (evento == null) return null;
                            model.Id = eventoId;
                            _mapper.Map(model, evento);
                            _geralPersist.Update<Evento>(evento);

                            if (await _geralPersist.SaveChangesAsync())
                            {
                                var eventoRetorno = await _eventoPersist.GetAllEventoByIdAsync(evento.Id, false);
                                return _mapper.Map<EventoDTO>(eventoRetorno);
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
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
           try
           {
                var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, includePalestrantes);

                if(evento == null) return null;

                var resultado = _mapper.Map<EventoDTO>(evento);

                return resultado;
           }catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
        }

        public async Task<List<EventoDTO>> GetAllEventosAsync(bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);

                if(eventos == null) return null;

                var resultado = _mapper.Map<List<EventoDTO>>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EventoDTO>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

                if(eventos == null) return null;

                var resultado = _mapper.Map<List<EventoDTO>>(eventos);

                return resultado;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

  
    }
        
}