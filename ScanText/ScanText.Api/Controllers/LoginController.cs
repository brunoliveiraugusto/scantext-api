using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using System.Threading.Tasks;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        /// <summary>
        /// API responsável por criar um novo usuário
        /// </summary>
        /// <response code="200">Login realizado com sucesso.</response>
        [HttpPost()]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var result = await _loginAppService.LoginAsync(loginViewModel);
            return Ok(result);
        }
    }
}
