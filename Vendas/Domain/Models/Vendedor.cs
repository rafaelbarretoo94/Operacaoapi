using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required]        
        [MaxLength(11)]
        public string Cpf { get; set; }
                
        public string Nome { get; set; }

        public string  Email { get; set; }

        public string Telefone { get; set; }     
    }
}
