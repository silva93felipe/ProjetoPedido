
using Microsoft.AspNetCore.Mvc;

namespace Financeiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceiroController : ControllerBase
    {   

        [HttpGet]
        [Route("StatusPagamento")]
        public IActionResult StatusPagamento( )
        {
            return Ok("Olá");

        }

    }
}