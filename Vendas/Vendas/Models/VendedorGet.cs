using System.ComponentModel.DataAnnotations;

namespace Vendas.Models
{
    public class VendedorGet
    {
        public int Id { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
