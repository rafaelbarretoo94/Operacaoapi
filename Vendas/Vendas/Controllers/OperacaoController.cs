using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Vendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacaoController : ControllerBase
    {
        // GET api/<OperacaoController>/5
        [HttpGet("{id}")]
        public string BuscaVenda(int id)
        {
            return "value";
        }

        // POST api/<OperacaoController>
        [HttpPost]
        public void RegistrarVenda([FromBody] string value)
        {
        }

        [HttpPatch]
        public void AtualizaVenda(Venda venda)
        {
        }
    }
}
