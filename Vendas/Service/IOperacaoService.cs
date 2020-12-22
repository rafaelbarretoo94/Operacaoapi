using Domain;
using Domain.Models;

namespace Service
{
    public interface IOperacaoService
    {
        Venda ObtemVenda(int idVenda);

        void AtualizaStatusVenda(StatusVenda statusVenda, int idVenda);

        void RegistraVenda(Venda venda);
    }
}
