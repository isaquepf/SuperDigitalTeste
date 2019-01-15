using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.InternetBanking.Core.application;
using SuperDigital.InternetBanking.application.Resources;

namespace SuperDigital.InternetBanking.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContaController : Controller
    {
        private readonly OperacaoApplicationService _app;

        public ContaController()
            => _app = new OperacaoApplicationService();
        
        [HttpPost]        
        public async Task<IActionResult> Post([FromBody]OperacaoResource operacao)
        {
            try
            {
                await _app.RealizarOperacao(operacao);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);                
            }
        }

   }
}
