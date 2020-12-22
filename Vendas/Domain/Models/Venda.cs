using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Venda
    {
        
        public int Id { get; set; }

        public StatusVenda Status { get; set; }

        public Vendedor Vendedor { get; set; }

        public DateTime DataVenda { get; set; }

        public IEnumerable<ItemVenda> ItensVenda { get; set; }
    }
}
