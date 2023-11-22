using caixa_eletronico.Business;
using caixa_eletronico.Models;
using Microsoft.AspNetCore.Mvc;

namespace caixa_eletronico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaixaController : ControllerBase
    {


        private readonly ILogger<CaixaController> _logger;

        public CaixaController(ILogger<CaixaController> logger)
        {
            _logger = logger;
        }

        [HttpPost("saque")]
        public IActionResult Access([FromBody] Pedido info)
        {
            try
            {

                CaixaBusiness Business = new CaixaBusiness();
                var saque = Business.GetValores(info);
                return Ok(saque);

                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
    }
}