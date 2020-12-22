using System;
using System.Collections.Generic;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class VendaGet
    {
        public int Id { get; set; }

        public StatusVendaPost Status { get; set; }

        public VendedorPost Vendedor { get; set; }

        public DateTime DataVenda { get; set; }

        public IEnumerable<ItemVendaPost> ItensVenda { get; set; }
    }
}