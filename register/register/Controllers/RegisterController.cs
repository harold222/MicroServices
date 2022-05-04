using Microsoft.AspNetCore.Mvc;
using shared.Blockchain;
using shared.Blockchain.Api.Response;
using shared.Common;
using shared.Wallet.Api.Request;
using System;
using System.Net;
using System.Threading.Tasks;

namespace register.Controllers
{
    public class RegisterController : BaseController
    {

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public async Task<RegisterTransactionResponse> RegisterTransaction(RegisterNewTransaction request)
        {

            bool exist = (await BlockchainApi.BlockOneHaveHash().ConfigureAwait(false)).exist;
            RegisterTransactionResponse response = new RegisterTransactionResponse();

            bool makeRegister = false;

            if (!exist) makeRegister = true;
            else
            {
                makeRegister = (await BlockchainApi.VerifyAmountInDirection(request.Dir1, request.Amount.ToString()).ConfigureAwait(false)).success;

                if (makeRegister)
                {
                    makeRegister = (await BlockchainApi.VerifyAmountInDirection(request.Dir2, "0").ConfigureAwait(false)).success;

                    if (!makeRegister)
                        response.Error = $"La direccion {request.Dir2} no existe.";
                }
                else
                    response.Error = $"La direccion {request.Dir1} no existe o no posee ese saldo para enviar.";
            }

            if (makeRegister) response = await BlockchainApi.RegisterTransaction(request).ConfigureAwait(false);

            return response;
        }
    }
}
