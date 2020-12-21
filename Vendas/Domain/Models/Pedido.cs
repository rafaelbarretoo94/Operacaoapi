using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime DataPedido { get; set; }

        //private IEnumerable<ItemVenda> itensVenda;

        //public IEnumerable<ItemVenda> GetItensVenda()
        //{
        //    return itensVenda;
        //}

        //public void SetItensVenda(IEnumerable<ItemVenda> value)
        //{
        //    itensVenda = value;
        //}
    }
}
