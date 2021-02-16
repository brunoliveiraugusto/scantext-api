using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinguagemController : ControllerBase
    {
        private readonly ILinguagemAppService _linguagemAppService;

        public LinguagemController(ILinguagemAppService linguagemAppService)
        {
            _linguagemAppService = linguagemAppService;
        }

        /// <summary>
        /// API responsável por criar uma nova linguagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPost()]
        public async Task<IActionResult> Criar([FromBody] LinguagemViewModel linguagemViewModel)
        {
            await _linguagemAppService.InserirAsync(linguagemViewModel);
            return Ok();
        }

        /// <summary>
        /// API responsável por buscar uma linguagem por id.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet("{id}")]
        public async Task<LinguagemViewModel> ObterPorId(Guid id)
        {
            var linguagem = await _linguagemAppService.ObterPorIdAsync(id);
            return linguagem;
        }

        /// <summary>
        /// API responsável por buscar uma lista de linguagens.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet()]
        [AllowAnonymous]
        public async Task<IEnumerable<LinguagemViewModel>> ObterTodos()
        {
            var linguagens = await _linguagemAppService.ObterTodosAsync();
            return linguagens;
        }

        /// <summary>
        /// API responsável por atualizar uma linguagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPut()]
        public async Task<IActionResult> Atualizar([FromBody] LinguagemViewModel linguagem, Guid id)
        {
            await _linguagemAppService.AtualizarAsync(linguagem, id);
            return Ok();
        }

        /// <summary>
        /// API responsável por deletar uma linguagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _linguagemAppService.RemoverAsync(id);
            return Ok();
        }
    }
}
