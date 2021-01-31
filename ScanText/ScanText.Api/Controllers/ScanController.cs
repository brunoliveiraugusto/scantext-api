using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;

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
        [HttpGet("{urlImg}")]
        public IActionResult LerTextoImagem(string base64)
        {
            var response = _scanAppService.LerTextoImagem(base64);
            return Ok(response);
        }
    }
}
