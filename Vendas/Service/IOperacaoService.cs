using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IOperacaoService
    {
        Venda ObtemVenda(int idVenda);

        void AtualizaStatusVenda(StatusVenda statusVenda);

        void RegistraVenda(Venda venda);
    }
}
