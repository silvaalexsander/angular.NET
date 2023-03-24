using ProEventos.Domain;
using ProEventos.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.API.Dtos
{
    public class EventoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), 
        StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
        public string? Local { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), DataType(DataType.DateTime)]
        public DateTime? DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), 
        StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
        public string? Tema { get; set; }

        public int QtdPessoa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),]
        [RegularExpression (@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida")]
        public string? ImagemURL { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), 
        Phone(ErrorMessage = "O campo {0} está inválido")]
        public string? Telefone { get; set; }

        [EmailAddress (ErrorMessage = "O campo {0} está em formato inválido"), 
        Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Email { get; set; }

        public IEnumerable<LoteDTO>? Lotes { get; set; }
        public IEnumerable<RedeSocialDTO>? RedesSociais { get; set; }
        public IEnumerable<PalestranteDTO>? PalestrantesEventos { get; set; }
    }
}
