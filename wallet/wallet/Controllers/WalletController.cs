using Microsoft.AspNetCore.Mvc;
using shared.Common;
using shared.Register;
using shared.Wallet.Api.Request;
using System.Net;
using System.Threading.Tasks;

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
        public async Task<ActionResult> RegisterTransaction(RegisterNewTransaction request)
        {
            if (!string.IsNullOrEmpty(request.Dir1) && !string.IsNullOrEmpty(request.Dir2))
            {
                var registerResponse = await RegisterApi.RegisterTransaction(request).ConfigureAwait(false);
                return Ok(new { Name = "Registrando Transaccion" });
            }

            return new ObjectResult(new { error = "Faltan direcciones" })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
