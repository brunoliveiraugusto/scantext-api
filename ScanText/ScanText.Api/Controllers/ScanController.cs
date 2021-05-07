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
        public IActionResult LerTextoImagem([FromBody] ImagemTesseractViewModel imagemVM)
        {
            var response = _scanAppService.LerTextoImagem(imagemVM);
            return ResponseRequest(response);
        }

        /// <summary>
        /// API responsável por gerar um QrCode.
        /// </summary>
        /// <response code="200">QrCode gerado.</response>
        [HttpPost()]
        [Route("gerar-qr-code")]
        [Authorize(Roles = AuthorizationService.Todos)]
        public IActionResult GerarQrCodeImagem([FromBody] QrCodeViewModel qrCode)
        {
            var response = _scanAppService.GerarQrCodeImagem(qrCode.Text);
            return ResponseRequest(response);
        }
    }
}
