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

        [HttpGet]
        public ActionResult CreateBlock()
        {
            return Ok(new { Name = "Creando bloque" });
        }

        [HttpGet]
        public ActionResult RegisterData()
        {
            return Ok(new { Name = "registrando data" });
        }

        [HttpGet]
        public ActionResult ConsultDir()
        {
            return Ok(new { Name = "Consultando direccion" });
        }

        [HttpPost]
        public async Task<RegisterTransactionResponse> RegisterTransaction(RegisterNewTransaction request)
        {
            RegisterTransactionResponse response = new RegisterTransactionResponse();

            logic.RegistrarTx(request.Dir1, request.Dir2, request.Amount);
            response.Blocks = logic.PrintAllBlocks();

            return response;
        }
    }
}
