using Domain;
using Domain.Models;
using Infra.Interfaces;
using System;
using System.Linq;

namespace Infra
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private readonly ApiContext _context;

        public OperacaoRepository(ApiContext context)
        {
            _context = context;
        }
        public void AtualizaVenda(StatusVenda statusVenda, int idVenda)
        {
            var venda = _context.Venda.FirstOrDefault(v => v.Id == idVenda);

            if (venda != null)
            {
                switch (venda.Status)
                {
                    case StatusVenda.AguardandoPagamento:
                        venda.Status = statusVenda == StatusVenda.PagamentoAprovado
                            ? StatusVenda.PagamentoAprovado : StatusVenda.Cancelada;
                        break;

                    case StatusVenda.PagamentoAprovado:
                        venda.Status = statusVenda == StatusVenda.EnviadoTransportadora
                            ? StatusVenda.EnviadoTransportadora : StatusVenda.Cancelada;
                        break;

                    case StatusVenda.EnviadoTransportadora:
                        venda.Status = StatusVenda.Entregue;
                        break;
                };

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Não existe venda para o identificador informado.");
            }
        }

        public Venda ObtemVenda(int idVenda)
        {
            return _context.Venda.FirstOrDefault(v => v.Id == idVenda);
        }

        public void RegistraVenda(Venda venda)
        {
            if (!VerificaExistenciaVenda(venda.Id))
            {
                if (venda.ItensVenda != null)
                {
                    venda.DataVenda = DateTime.Now;
                    _context.Add(venda);
                }
                else
                {
                    throw new ArgumentNullException("Não foram incluídos items para esta venda.");
                }
            }
            _context.SaveChanges();
        }

        private bool VerificaExistenciaVenda(int id)
        {
            return _context.Venda.Any(v => v.Id == id);
        }
    }
}
