using Microsoft.AspNetCore.Mvc;
using shared.Common;
using shared.Wallet.Api.Request;
using System.Net;

namespace wallet.Controllers
{
    public class WalletController : BaseController
    {
        [HttpGet]
        public ActionResult ConsultFunds()
        {
            return Ok(new { Name = "Consultando Fondos" });
        }

        [HttpPost]
        public ActionResult RegisterTransaction(RegisterNewTransaction request)
        {
            if (!string.IsNullOrEmpty(request.Dir1) && !string.IsNullOrEmpty(request.Dir2))
            {

                return Ok(new { Name = "Registrando Transaccion" });
            }

            return new ObjectResult(new { error = "Faltan direcciones" })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
