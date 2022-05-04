using Microsoft.AspNetCore.Mvc;
using shared.Blockchain;
using shared.Blockchain.Api.Response;
using shared.Common;
using shared.Register;
using shared.Wallet.Api.Request;
using System;
using System.Net;
using System.Threading.Tasks;

namespace wallet.Controllers
{
    public class WalletController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult> ConsultFunds(string direction)
        {
            ConsultFundsResponse response = await BlockchainApi.ConsultFunds(direction);

            if (response.TotalAmount != -1)
            {
                return Ok(new
                {
                    Total = $"El saldo total de esta direccion es: {response.TotalAmount}"
                });
            }
            else
            {
                return new ObjectResult(new { error = "No se encontro esta direccion." })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterTransaction(RegisterNewTransaction request)
        {
            if (!string.IsNullOrEmpty(request.Dir1) && !string.IsNullOrEmpty(request.Dir2) && request.Amount > 0)
            {
                RegisterTransactionResponse registerResponse = await RegisterApi.RegisterTransaction(request);

                if (string.IsNullOrEmpty(registerResponse.Error))
                {
                    return Ok(new { Blocks = registerResponse.Blocks });
                }
                else
                {
                    return new ObjectResult(new { error = registerResponse.Error })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                }
            }

            return new ObjectResult(new { error = "Faltan direcciones" })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
