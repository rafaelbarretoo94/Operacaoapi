using System;
using System.Collections.Generic;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class VendaGet
    {
        public int Id { get; set; }

        public StatusVendaDto Status { get; set; }

        public VendedorDto Vendedor { get; set; }

        public DateTime DataVenda { get; set; }

        public IEnumerable<ItemVendaDto> ItensVenda { get; set; }
    }
}