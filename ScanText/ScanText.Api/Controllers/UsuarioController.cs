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
        /// <response code="200">Usuário criado com sucesso.</response>
        [HttpPost()]
        public async Task<bool> Criar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            return await _usuarioAppService.InserirAsync(usuarioViewModel);
        }

        /// <summary>
        /// API responsável por verificar se o usuário informado já existe cadastrado
        /// </summary>
        /// <response code="200">Usuário existente.</response>
        [HttpGet()]
        [Route("verificar-usuario-existente")]
        public async Task<IActionResult> VerificarUsuarioExistente(string username)
        {
            var result = await _usuarioAppService.IndicaUsuarioExistenteAsync(username);
            return Ok(result);
        }
    }
}
