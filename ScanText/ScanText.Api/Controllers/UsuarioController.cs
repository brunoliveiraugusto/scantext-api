using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanText.Api.Configuration;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using System;
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
        public async Task<UsuarioViewModel> Criar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            return await _usuarioAppService.Inserir(usuarioViewModel);
        }

        /// <summary>
        /// API responsável por verificar se o usuário informado já existe cadastrado
        /// </summary>
        /// <response code="200">Usuário existente.</response>
        [HttpGet()]
        [Route("verificar-usuario-existente")]
        public async Task<IActionResult> VerificarUsuarioExistente(string username, Guid? idUsuario = null)
        {
            var result = await _usuarioAppService.IndicaUsuarioExistente(username, idUsuario);
            return Ok(result);
        }

        /// <summary>
        /// API responsável buscar o e-mail do usuário logado.
        /// </summary>
        /// <response code="200">E-mail obtido.</response>
        [HttpGet()]
        [Route("obter-email-usuario-logado")]
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<IActionResult> ObterEmailUsuarioLogado()
        {
            var result = await _usuarioAppService.ObterEmailUsuarioLogado();
            return Ok(result);
        }

        /// <summary>
        /// API responsável por buscar dados de cadastro do usuário.
        /// </summary>
        /// <response code="200">Dados de cadastro obtido.</response>
        [HttpGet()]
        [Route("obter-dados-cadastro-usuario")]
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<IActionResult> ObterDadosCadastroUsuario()
        {
            var result = await _usuarioAppService.CarregarDadosCadastroUsuario();
            return Ok(result);
        }

        /// <summary>
        /// API responsável por atualizar dados de cadastro do usuário.
        /// </summary>
        /// <response code="200">Dados atualizado.</response>
        [HttpPut()]
        [Route("atualizar-dados-cadastro-usuario/{idUsuario:guid}")]
        [Authorize(Roles = AuthorizationService.Todos)]
        public async Task<IActionResult> AtualizarDadosCadastroUsuario([FromBody] UsuarioViewModel usuarioViewModel, Guid idUsuario)
        {
            var result = await _usuarioAppService.AtualizarDadosCadastroUsuario(usuarioViewModel, idUsuario);
            return Ok(result);
        }
    }
}
