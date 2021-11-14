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
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok();
        }

        // Inserir um jogo dentro da listagem
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody]JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);
                return Ok();
            }
           // catch (JogoJaCadastradoException ex)
              catch (Exception ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        // Atualizar algum jogo passando o id do jogo
        [HttpPut("(idJogo:guid)")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);
                return Ok();
            }
            // catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
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
