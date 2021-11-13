using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_ProjDIO.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        // Obter a lista de jogos completo
        [HttpGet]
        public async Task<ActionResult<List<object>>> Obter()
        {
            return Ok();
        }

        // Obter a lista recebendo um id do jogo com parametro
        [HttpGet("(idJogo:guid)")]
        public async Task<ActionResult<object>> Obter(Guid idJogo)
        {
            return Ok();
        }

        // Inserir um jogo dentro da listagem
        [HttpPost]
        public async Task<ActionResult<object>> InserirJogo(object jogo)
        {
            return Ok();
        }

        // Atualizar algum jogo passando o id do jogo
        [HttpPut("(idJogo:guid)")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, object jogo)
        {
            return Ok();
        }

        // Atualizar o preço do jogo pelo id
        [HttpPatch("(idJogo:guid)/preco/(preco:double)")]
        public async Task<ActionResult> AtualizarPreco(Guid idJogo, double preco)
        {
            return Ok();
        }

        // Apagar um jogo da listagem
        [HttpDelete("(idJogo:guid)")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }
    }
}
