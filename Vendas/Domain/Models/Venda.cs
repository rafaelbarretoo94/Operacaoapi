using Domain.Models;
using System;

namespace Domain
{
    public class Venda
    {
        public int Id { get; set; }

        public StatusVenda  Status { get; set; }

        public Vendedor Vendedor { get; set; }

        public DateTime DataVenda { get; set; }




        //Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos.

    }
}
