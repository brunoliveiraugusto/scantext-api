using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using System.Threading.Tasks;

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
        /// <response code="200">Indica que a leitura da imagem foi realizada com sucesso.</response>
        [HttpGet("{base64}")]
        public async Task<IActionResult> LerTextoImagem(string base64)
        {
            var response = await _scanAppService.LerTextoImagemAsync(base64);
            return Ok(response);
        }
    }
}
