using Domain;
using Domain.Models;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
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

            AtribuiStatusVenda(statusVenda, venda);
        }

        private void AtribuiStatusVenda(StatusVenda statusVenda, Venda venda)
        {
            if (venda != null)
            {
                switch (venda.Status)
                {
                    case StatusVenda.AguardandoPagamento:
                        if (statusVenda == StatusVenda.PagamentoAprovado)
                        {
                            venda.Status = StatusVenda.PagamentoAprovado;
                        }
                        else if (statusVenda == StatusVenda.Cancelada)
                        {
                            venda.Status = StatusVenda.Cancelada;
                        }
                        else
                        {
                            RetornaMensagemStatus();
                            return;
                        }

                        break;

                    case StatusVenda.PagamentoAprovado:
                        if (statusVenda == StatusVenda.EnviadoTransportadora)
                        {
                            venda.Status = StatusVenda.EnviadoTransportadora;
                        }
                        else if (statusVenda == StatusVenda.Cancelada)
                        {
                            venda.Status = StatusVenda.Cancelada;
                        }
                        else
                        {
                            RetornaMensagemStatus();
                            return;
                        }

                        break;

                    case StatusVenda.EnviadoTransportadora:
                        if (statusVenda == StatusVenda.Entregue)
                        {
                            venda.Status = StatusVenda.Entregue;
                        }
                        else
                        {
                            RetornaMensagemStatus();
                            return;
                        }
                        break;
                };
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Não existe venda para o identificador informado.");
            }
        }

        private static void RetornaMensagemStatus()
        {
            throw new ArgumentException("Status não permitido.");
        }

        public Venda ObtemVenda(int idVenda)
        {
            return _context.Venda.Include(v => v.ItensVenda)
                .Include(v => v.Vendedor).
                FirstOrDefault(v => v.Id == idVenda);
        }

        public void RegistraVenda(Venda venda)
        {
            if (!VerificaExistenciaVenda(venda.Id))
            {
                if (venda.ItensVenda != null)
                {
                    venda.DataVenda = DateTime.Now;
                    _context.Venda.Add(venda);
                    _context.Vendedor.Add(venda.Vendedor);
                    _context.ItensVenda.AddRangeAsync(venda.ItensVenda);
                    _context.SaveChanges();

                    _context.Add(venda);
                }
                else
                {
                    throw new ArgumentNullException("Não foram incluídos items para esta venda.");
                }
            }
        }

        private bool VerificaExistenciaVenda(int id)
        {
            return _context.Venda.Any(v => v.Id == id);
        }
    }
}
