using System.ComponentModel.DataAnnotations;

namespace Vendas.Models
{
    public class VendedorDto
    {
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
