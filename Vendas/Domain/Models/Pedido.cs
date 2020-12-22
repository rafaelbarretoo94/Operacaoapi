using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataPedido { get; set; }

        public IEnumerable<ItemVenda> ItemVendas { get; set; }

        public StatusVenda StatusVenda { get; set; }
    }
}
