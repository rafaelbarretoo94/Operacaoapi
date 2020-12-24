using Domain.Models;
using Infra.Interfaces;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace OperacaoTests
{
    public class OperacaoTests
    {
        private readonly IOperacaoService _operacaoService;
        private readonly Mock<IOperacaoRepository> operacaoRepositoryMock;

        public OperacaoTests(IOperacaoService operacaoService)
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

            operacaoRepositoryMock.Setup(o => o.RegistraVenda(It.IsAny<Venda>()))
                                  .Returns(venda.Id);

            var retorno = _operacaoService.RegistraVenda(venda);

            Assert.Equal(idEsperado, retorno);
        }

        #endregion
    }
}
