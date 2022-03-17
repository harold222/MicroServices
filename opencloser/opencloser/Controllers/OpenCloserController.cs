using Microsoft.AspNetCore.Mvc;
using shared.Common;

namespace opencloser.Controllers
{
    public class OpenCloserController : BaseController
    {
        [HttpGet]
        public ActionResult CloseBlock()
        {
            return Ok(new { Name = "Cerrando bloque" });
        }
    }
}
