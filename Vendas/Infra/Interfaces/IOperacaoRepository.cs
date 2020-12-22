using Domain;
using Domain.Models;

namespace Infra.Interfaces
{
    public interface IOperacaoRepository
    {
        Venda ObtemVenda(int idVenda);
        void RegistraVenda(Venda venda);
        void AtualizaVenda(StatusVenda statusVenda, int idVenda);
    }
}
