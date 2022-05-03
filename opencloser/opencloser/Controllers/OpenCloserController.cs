using Microsoft.AspNetCore.Mvc;
using shared.Blockchain.Model;
using shared.Common;
using shared.Opencloser.Api.Response;
using System;
using System.Security.Cryptography;
using System.Text;

namespace opencloser.Controllers
{
    public class OpenCloserController : BaseController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public CloseBlockResponse CloseBlock(BlockchainModel request)
        {
            CloseBlockResponse response = new CloseBlockResponse();
            string resultHash = "";
            do
            {
                request.nonce = request.nonce + 1;
                string allData =
                    $"{request.id}+{request.nonce}+{request.data}+{request.previousHash}";

                using (SHA256 sha256 = SHA256.Create())
                {
                    string word = string.Format("{0}{1}", sha256, allData);
                    byte[] wordAsBytes = Encoding.UTF8.GetBytes(word);
                    resultHash = Convert.ToBase64String(sha256.ComputeHash(wordAsBytes));
                }

                // hash generate 000 at the beginning of the string
            } while (resultHash.Substring(0, 3) != "000");

            request.hash = resultHash;
            response.NewBlock = request;
            return response;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public ActionResult OpenBlock()
        {
            return Ok(new { Name = "Abriendo bloque" });
        }
    }
}
