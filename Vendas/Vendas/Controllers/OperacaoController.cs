using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Net.Http;

namespace Vendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Serializable]
    public class OperacaoController : ControllerBase
    {
        private readonly IOperacaoService _operacaoService;
        private readonly IMapper _mapper;

        public OperacaoController(IOperacaoService operacaoService, IMapper mapper)
        {
            _operacaoService = operacaoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult BuscaVenda(Guid id)
        {
            var venda = _operacaoService.ObtemVenda(id);
            var retorno = _mapper.Map<VendaGet>(venda);

            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult RegistrarVenda([FromBody] VendaPost vendaPost)
        {
            var dados = _mapper.Map<Venda>(vendaPost);
            var retorno = _operacaoService.RegistraVenda(dados);

            if (retorno == Guid.Empty)
            {
                return BadRequest($"Já existe uma venda com esse identificador.");
            }
           
            return Ok(retorno);
        }

        [HttpPatch]
        public IActionResult AtualizaVenda(StatusVendaPost statusVendaPost, Guid idVenda)
        {
            var status = _mapper.Map<StatusVenda>(statusVendaPost);

            if (!_operacaoService.AtualizaStatusVenda(status, idVenda))
            {
                return BadRequest($"O Status {statusVendaPost} não  é permitido.");
            }
            return Ok();
        }
    }
}
