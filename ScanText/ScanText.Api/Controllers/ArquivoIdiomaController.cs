using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanText.Api.Configuration;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Domain.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace ScanText.Api.Controllers
{
    public class ArquivoIdiomaController : BaseController
    {
        private readonly IArquivoIdiomaAppService _arquivoIdiomaAppService;

        public ArquivoIdiomaController(IArquivoIdiomaAppService arquivoIdiomaAppService, INotificationService notificationService) : base(notificationService)
        {
            _arquivoIdiomaAppService = arquivoIdiomaAppService;
        }

        /// <summary>
        /// API responsável por gravar um novo arquivo de idioma.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPost()]
        [RequestSizeLimit(100_000_000)]
        [Authorize(Roles = AuthorizationService.Administrador)]
        public async Task<IActionResult> Criar([FromBody] ArquivoIdiomaViewModel arquivoIdiomaViewModel)
        {
            var resp = await _arquivoIdiomaAppService.Inserir(arquivoIdiomaViewModel);
            return ResponseRequest(resp);
        }

        /// <summary>
        /// API responsável por remover um arquivo de idioma existente.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpDelete()]
        [Route("{id:guid}")]
        [Authorize(Roles = AuthorizationService.Administrador)]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var resp = await _arquivoIdiomaAppService.Remover(id);
            return ResponseRequest(resp);
        }

        /// <summary>
        /// API responsável por atualizar um arquivo de idioma existente.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPut()]
        [Route("{id:guid}")]
        [Authorize(Roles = AuthorizationService.Administrador)]
        public async Task<IActionResult> Atualizar([FromBody] ArquivoIdiomaViewModel arquivoIdiomaViewModel, Guid id)
        {
            var resp = await _arquivoIdiomaAppService.Atualizar(arquivoIdiomaViewModel, id);
            return ResponseRequest(resp);
        }

        /// <summary>
        /// API responsável por buscar um arquivo de idioma por id.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet()]
        [Route("{id:guid}")]
        [Authorize(Roles = AuthorizationService.Administrador)]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var resp = await _arquivoIdiomaAppService.ObterPorId(id);
            return ResponseRequest(resp);
        }

        /// <summary>
        /// API responsável por buscar todos os arquivos de idioma.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet()]
        [Authorize(Roles = AuthorizationService.Administrador)]
        public async Task<IActionResult> BuscarTodos()
        {
            var resp = await _arquivoIdiomaAppService.ObterTodos();
            return ResponseRequest(resp);
        }
    }
}
