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
        public bool AtualizaVenda(StatusVenda statusVenda, Guid idVenda)
        {
            var venda = _context.Venda.FirstOrDefault(v => v.Id == idVenda);

            return AtribuiStatusVenda(statusVenda, venda);
        }

        private bool AtribuiStatusVenda(StatusVenda statusVenda, Venda venda)
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
                            return false;
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
                            return false;
                        }
                        break;

                    case StatusVenda.EnviadoTransportadora:
                        if (statusVenda == StatusVenda.Entregue)
                        {
                            venda.Status = StatusVenda.Entregue;
                        }
                        else
                        {
                            return false;
                        }
                        break;

                    case StatusVenda.Entregue:
                        return false;

                };
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Não existe venda para o identificador informado.");
            }

            return true;
        }

        public Venda ObtemVenda(Guid idVenda)
        {
            return _context.Venda.Include(v => v.ItensVenda)
                .Include(v => v.Vendedor).
                FirstOrDefault(v => v.Id == idVenda);
        }

        public Guid RegistraVenda(Venda venda)
        {
            if (!VerificaExistenciaVenda(venda.Id))
            {
                if (venda.ItensVenda.Any() || venda.ItensVenda.Any(v => v.Id > 0))
                {
                    venda.DataVenda = DateTime.Now;
                    venda.Id = Guid.NewGuid();
                    venda.Status = StatusVenda.AguardandoPagamento;
                    _context.Venda.Add(venda);
                    Random rnd = new Random();
                    venda.Vendedor.Id = rnd.Next(1, 10000);
                    _context.Vendedor.Add(venda.Vendedor);
                    _context.ItensVenda.AddRangeAsync(venda.ItensVenda);
                    _context.SaveChanges();

                    return venda.Id;
                }
                else
                {
                    throw new ArgumentNullException("Não foram incluídos items para esta venda.");
                }
            }
            else
                return Guid.Empty;
        }

        private bool VerificaExistenciaVenda(Guid id)
        {
            return _context.Venda.Any(v => v.Id == id);
        }
    }
}
