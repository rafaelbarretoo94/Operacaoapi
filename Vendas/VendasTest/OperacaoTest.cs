using Domain.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace VendasTest
{
    [TestClass]
    public class OperacaoTest
    {
        private readonly IOperacaoService _operacaoService;
        public OperacaoTest(IOperacaoService operacaoService)
        {
            _operacaoService = operacaoService;
        }

        [TestMethod]
        [Trait(nameof(IOperacaoService.RegistraVenda), "Sucesso")]
        public void RegistraVendaSucesso()
        {
            var venda = new Venda()
            {
                Id = 1,
                Status = StatusVenda.AguardandoPagamento,
                DataVenda = DateTime.Now,
                ItensVenda = new List<ItemVenda>() { new ItemVenda()
                {
                    Id = 13,
                    NomeProduto = "Cartão"
                }},

                Vendedor = new Vendedor()
                {
                    Cpf = "12332185613",
                    Email = "cliente@teste.com.br",
                    Id = 1313,
                    Nome = "Rafael",
                    Telefone = "31311313"
                }
            };
            _operacaoService.RegistraVenda(venda);
        }
    }
}
