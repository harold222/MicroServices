using Microsoft.AspNetCore.Mvc;
using shared.Blockchain;
using shared.Blockchain.Api.Response;
using shared.Common;
using shared.Wallet.Api.Request;
using System.Threading.Tasks;

namespace register.Controllers
{
    public class RegisterController : BaseController
    {
        [HttpPost]
        public async Task<RegisterTransactionResponse> RegisterTransaction(RegisterNewTransaction request)
        {
            RegisterTransactionResponse response = await BlockchainApi.RegisterTransaction(request);
            return response;
        }
    }
}
