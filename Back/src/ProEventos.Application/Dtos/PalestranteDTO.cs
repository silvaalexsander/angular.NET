using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class PalestranteDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Minicurriculo { get; set; }
        public string? ImagemURL { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public IEnumerable<RedeSocialDTO>? RedesSociais { get; set; }
        public IEnumerable<PalestranteDTO>? PalestrantesEventos { get; set; }
    }
}