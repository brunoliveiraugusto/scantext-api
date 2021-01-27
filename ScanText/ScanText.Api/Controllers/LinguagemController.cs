using Microsoft.AspNetCore.Mvc;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinguagemController : ControllerBase
    {
        private readonly ILinguagemAppService _linguagemAppService;

        public LinguagemController(ILinguagemAppService linguagemAppService)
        {
            _linguagemAppService = linguagemAppService;
        }

        /// <summary>
        /// API responsável por criar uma nova linguagem.
        /// </summary>
        /// <response code="200">Sucesso.</response>
        [HttpPost()]
        public async Task Criar([FromBody] LinguagemViewModel linguagemViewModel)
        {
            await _linguagemAppService.InserirLinguagemAsync(linguagemViewModel);
        }
    }
}
