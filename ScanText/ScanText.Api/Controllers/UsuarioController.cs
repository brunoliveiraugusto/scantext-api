using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using System.Threading.Tasks;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// API responsável por criar um novo usuário
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPost()]
        public async Task<IActionResult> Criar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            await _usuarioAppService.InserirAsync(usuarioViewModel);
            return Ok();
        }
    }
}
