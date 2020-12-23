using System;
using System.Collections.Generic;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class VendaPost
    {
        public int Id { get; set; }

        /// <summary>
        /// 1-Aguardando Pagamento
        /// 2-PagamentoAprovado
        /// 3-Cancelada
        /// 4-Enviado Transportadora
        /// 5-Entregue
        /// </summary>
        public StatusVendaDto Status { get; set; }

        public VendedorDto Vendedor { get; set; }

        public DateTime DataVenda { get; set; }

        public IEnumerable<ItemVendaDto> ItensVenda { get; set; }
    }
}