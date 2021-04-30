using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanText.Api.Configuration;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Domain.Utils.Interfaces;

namespace ScanText.Api.Controllers
{
    public class ScanController : BaseController
    {
        private readonly IScanAppService _scanAppService;

        public ScanController(IScanAppService scanAppService, INotificationService notificationService) : base(notificationService)
        {
            _scanAppService = scanAppService;
        }

        /// <summary>
        /// API responsável por ler uma imagem e retornar o texto contido na mesma.
        /// </summary>
        /// <response code="200">Imagem Processada.</response>
        [HttpPost()]
        [Authorize(Roles = AuthorizationService.Todos)]
        public IActionResult LerTextoImagem([FromBody] ImagemViewModel imagemVM)
        {
            var response = _scanAppService.LerTextoImagem(imagemVM);
            return Ok(response);
        }

        /// <summary>
        /// API responsável por gerar um QrCode.
        /// </summary>
        /// <response code="200">QrCode gerado.</response>
        [HttpPost()]
        [Route("obter-qr-code")]
        [Authorize(Roles = AuthorizationService.Todos)]
        public IActionResult ObterQrCodeImagem([FromBody] QrCodeViewModel qrCode)
        {
            var response = _scanAppService.ObterQrCodeImagem(qrCode.Text);
            return Ok(response);
        }
    }
}
