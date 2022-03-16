using Microsoft.AspNetCore.Mvc;
using shared.Common;

namespace blockchain.Controllers
{
    public class BlockChainController : BaseController
    {

        [HttpGet]
        public ActionResult GetProjectName()
        {
            return Ok(new { Project = "BlockChain" });
        }
    }
}
