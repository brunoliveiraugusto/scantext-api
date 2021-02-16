using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagemController : ControllerBase
    {
        private readonly IImagemAppService _imagemAppService;

        public ImagemController(IImagemAppService imagemAppService)
        {
            _imagemAppService = imagemAppService;
        }

        /// <summary>
        /// API responsável por criar uma nova imagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPost()]
        public async Task<IActionResult> Criar([FromBody] ImagemViewModel imagemViewModel)
        {
            await _imagemAppService.InserirAsync(imagemViewModel);
            return Ok();
        }

        /// <summary>
        /// API responsável por buscar uma imagem por id.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet("{id}")]
        public async Task<ImagemViewModel> ObterPorId(Guid id)
        {
            var imagem = await _imagemAppService.ObterPorIdAsync(id);
            return imagem;
        }

        /// <summary>
        /// API responsável por buscar uma lista de imagens.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpGet()]
        [AllowAnonymous]
        public async Task<IEnumerable<ImagemViewModel>> ObterTodos()
        {
            var imagens = await _imagemAppService.ObterTodosAsync();
            return imagens;
        }

        /// <summary>
        /// API responsável por atualizar uma imagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPut()]
        [Route("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Atualizar([FromBody] ImagemViewModel imagemViewModel, Guid id)
        {
            await _imagemAppService.AtualizarAsync(imagemViewModel, id);
            return Ok();
        }

        /// <summary>
        /// API responsável por deletar uma imagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _imagemAppService.RemoverAsync(id);
            return Ok();
        }

        /// <summary>
        /// API responsável por obter imagens paginadas.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPost("obter-imagens-paginacao")]
        public IActionResult ObterImagensPaginacao([FromBody] PaginationFilterViewModel<ImagemViewModel> paginationFilterViewModel)
        {
            var response = _imagemAppService.ObterImagensPaginadas(paginationFilterViewModel);
            return Ok(response);
        }
    }
}
