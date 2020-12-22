using Domain;
using Domain.Models;
using Infra.Interfaces;

namespace Service
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }
        public void AtualizaStatusVenda(StatusVenda statusVenda, int idVenda)
        {
            _operacaoRepository.AtualizaVenda(statusVenda, idVenda);
        }

        public Venda ObtemVenda(int idVenda)
        {
            return _operacaoRepository.ObtemVenda(idVenda);
        }

        public void RegistraVenda(Venda venda)
        {
            _operacaoRepository.RegistraVenda(venda);
        }
    }
}
