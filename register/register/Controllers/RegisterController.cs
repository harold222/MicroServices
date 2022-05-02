using Microsoft.AspNetCore.Mvc;
using shared.Common;
using shared.Wallet.Api.Request;

namespace register.Controllers
{
    public class RegisterController : BaseController
    {
        [HttpPost]
        public ActionResult RegisterTransaction(RegisterNewTransaction request)
        {
            return Ok(new { Name = "Registrar Transaccion", data = request.ToString() });
        }
    }
}
