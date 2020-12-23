using Domain.Models;
using Infra.Interfaces;
using System;

namespace Service
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }
        public bool AtualizaStatusVenda(StatusVenda statusVenda, Guid idVenda)
        {
            return _operacaoRepository.AtualizaVenda(statusVenda, idVenda);
        }

        public Venda ObtemVenda(Guid idVenda)
        {
            return _operacaoRepository.ObtemVenda(idVenda);
        }

        public Guid RegistraVenda(Venda venda)
        {
            return _operacaoRepository.RegistraVenda(venda);
        }
    }
}
