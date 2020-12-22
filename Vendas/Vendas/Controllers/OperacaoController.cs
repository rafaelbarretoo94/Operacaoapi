using AutoMapper;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

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
        public IActionResult BuscaVenda(int id)
        {
            var venda = _operacaoService.ObtemVenda(id);
            var retorno = _mapper.Map<VendaGet>(venda);

            return Ok(retorno);
        }

        [HttpPost]
        public void RegistrarVenda([FromBody] VendaPost vendaPost)
        {
            var dados = _mapper.Map<Venda>(vendaPost);
            _operacaoService.RegistraVenda(dados);
        }

        [HttpPatch]
        public void AtualizaVenda(StatusVendaPost statusVendaPost, int idVenda)
        {
            var status = _mapper.Map<StatusVenda>(statusVendaPost);
            _operacaoService.AtualizaStatusVenda(status, idVenda);
        }
    }
}
