using blockchain.Logic;
using Microsoft.AspNetCore.Mvc;
using shared.Blockchain.Api.Response;
using shared.Common;
using shared.Wallet.Api.Request;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace blockchain.Controllers
{
    public class BlockChainController : BaseController
    {
        private readonly BlockchainLogic logic = new BlockchainLogic();

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public ConsultFundsResponse ConsultFunds(string direction)
        {
            ConsultFundsResponse response = new ConsultFundsResponse();
            response.TotalAmount = logic.ConsultFunds(direction);
            return response;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public RegisterTransactionResponse RegisterTransaction(RegisterNewTransaction request)
        {
            RegisterTransactionResponse response = new RegisterTransactionResponse();

            logic.RegistrarTx(request.Dir1, request.Dir2, request.Amount);
            response.Blocks = logic.PrintAllBlocks();

            return response;
        }
    }
}
