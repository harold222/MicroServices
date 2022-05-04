using blockchain.Logic;
using Microsoft.AspNetCore.Mvc;
using shared.Blockchain.Api.Response;
using shared.Common;
using shared.Wallet.Api.Request;
using System;
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
        [HttpGet]
        public GetTotalBlocksResponse BlockOneHaveHash()
        {
            GetTotalBlocksResponse response = new GetTotalBlocksResponse();
            response.exist = logic.BlockOneHaveHash();
            return response;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public VerifyAmountInDirectionResponse VerifyAmountInDirection(string direction, string amount)
        {
            VerifyAmountInDirectionResponse response = new VerifyAmountInDirectionResponse();
            response.success = logic.VerifyAmountInDirection(direction, float.Parse(amount));
            return response;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public async Task<RegisterTransactionResponse> RegisterTransaction(RegisterNewTransaction request)
        {
            RegisterTransactionResponse response = new RegisterTransactionResponse();

            await logic.RegistrarTx(request.Dir1, request.Dir2, request.Amount).ConfigureAwait(false);
            response.Blocks = logic.PrintAllBlocks();
            return response;
        }
    }
}
