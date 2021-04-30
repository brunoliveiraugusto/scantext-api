using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ScanText.Api.Configuration;

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
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<LinguagemViewModel> Criar([FromBody] LinguagemViewModel linguagemViewModel)
        {
            return await _linguagemAppService.Inserir(linguagemViewModel);
        }

        /// <summary>
        /// API responsável por buscar uma linguagem por id.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet("{id}")]
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<LinguagemViewModel> ObterPorId(Guid id)
        {
            var linguagem = await _linguagemAppService.ObterPorId(id);
            return linguagem;
        }

        /// <summary>
        /// API responsável por buscar uma lista de linguagens.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet()]
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<IEnumerable<LinguagemViewModel>> ObterTodos()
        {
            var linguagens = await _linguagemAppService.ObterTodos();
            return linguagens;
        }

        /// <summary>
        /// API responsável por atualizar uma linguagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPut()]
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<IActionResult> Atualizar([FromBody] LinguagemViewModel linguagem, Guid id)
        {
            await _linguagemAppService.Atualizar(linguagem, id);
            return Ok();
        }

        /// <summary>
        /// API responsável por deletar uma linguagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _linguagemAppService.Remover(id);
            return Ok();
        }
    }
}
