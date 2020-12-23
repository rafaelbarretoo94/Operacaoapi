using Domain;
using Domain.Models;
using System;

namespace Infra.Interfaces
{
    public interface IOperacaoRepository
    {
        Venda ObtemVenda(Guid idVenda);
        Guid RegistraVenda(Venda venda);
        bool AtualizaVenda(StatusVenda statusVenda, Guid idVenda);
    }
}
