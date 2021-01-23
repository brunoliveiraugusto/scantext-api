using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScanController : ControllerBase
    {
        /// <summary>
        /// API responsável por ler uma imagem e retornar o texto contido na mesma.
        /// </summary>
        /// <response code="200">Indica que a leitura da imagem foi realizada com sucesso.</response>
        [HttpGet("{base64}")]
        public async Task<IActionResult> LerTextoImagem(string base64)
        {
            return Ok("Texto qualquer.");
        }
    }
}
