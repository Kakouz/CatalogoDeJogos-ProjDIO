using CatalogoDeJogos_ProjDIO.InputModels;
using CatalogoDeJogos_ProjDIO.Services;
using CatalogoDeJogos_ProjDIO.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_ProjDIO.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;
        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }
        // Obter a lista de jogos completo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        // Obter a lista recebendo um id do jogo com parametro
        [HttpGet("(idJogo:guid)")]
        public async Task<ActionResult<JogoViewModel>> Obter(Guid idJogo)
        {
            return Ok();
        }

        // Inserir um jogo dentro da listagem
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo(JogoInputModel jogo)
        {
            return Ok();
        }

        // Atualizar algum jogo passando o id do jogo
        [HttpPut("(idJogo:guid)")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, JogoInputModel jogo)
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
