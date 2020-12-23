using Domain;
using Domain.Models;
using System;

namespace Service
{
    public interface IOperacaoService
    {
        Venda ObtemVenda(Guid idVenda);

        bool AtualizaStatusVenda(StatusVenda statusVenda, Guid idVenda);

        Guid RegistraVenda(Venda venda);
    }
}
