using Domain.Models;
using Infra.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using NUnit.Framework;
using Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace VendasTest
{
    public class OperacaoTest
    {
        private readonly IOperacaoService _operacaoService;
        private readonly Mock<IOperacaoRepository> operacaoRepositoryMock;
        public OperacaoTest(IOperacaoService operacaoService)
        {
            _operacaoService = operacaoService;
            operacaoRepositoryMock = new Mock<IOperacaoRepository>();
            _operacaoService = new OperacaoService(operacaoRepositoryMock.Object);
        }

        #region
        [Fact]
        [Trait(nameof(IOperacaoService.RegistraVenda), "Sucesso")]
        public void RegistraVendaSucesso()
        {
            var idEsperado = Guid.NewGuid();

            var venda = new Venda()
            {
                Id = idEsperado,
                Status = StatusVenda.AguardandoPagamento,
                DataVenda = DateTime.Now,
                ItensVenda = new List<ItemVenda>() { new ItemVenda()
                {
                    Id = 13,
                    NomeProduto = "Cart�o"
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

            operacaoRepositoryMock.Setup(o => o.RegistraVenda(It.IsAny<Venda>()))
                                  .Returns(venda.Id);

            var retorno = _operacaoService.RegistraVenda(venda);

            Assert.Equals(idEsperado, retorno);
        }

        #endregion
    }
}
