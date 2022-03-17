using Microsoft.AspNetCore.Mvc;
using shared.Common;

namespace blockchain.Controllers
{
    public class BlockChainController : BaseController
    {
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
    }
}
