using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScanController : ControllerBase
    {
        private readonly IScanAppService _scanAppService;

        public ScanController(IScanAppService scanAppService)
        {
            _scanAppService = scanAppService;
        }

        /// <summary>
        /// API responsável por ler uma imagem e retornar o texto contido na mesma.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPost()]
        [AllowAnonymous]
        public IActionResult LerTextoImagem([FromBody] ImagemViewModel imagemVM)
        {
            var response = _scanAppService.LerTextoImagem(imagemVM);
            return Ok(response);
        }
    }
}
