using Microsoft.AspNetCore.Mvc;
using shared.Common;

namespace wallet.Controllers
{
    public class WalletController : BaseController
    {
        [HttpGet]
        public ActionResult ConsultFunds()
        {
            return Ok(new { Name = "Consultando Fondos" });
        }

        [HttpGet]
        public ActionResult RegisterTransaction()
        {
            return Ok(new { Name = "Registrando Transaccion" });
        }
    }
}
