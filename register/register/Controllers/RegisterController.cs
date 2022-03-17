using Microsoft.AspNetCore.Mvc;
using shared.Common;

namespace register.Controllers
{
    public class RegisterController : BaseController
    {
        [HttpGet]
        public ActionResult RegisterTransaction()
        {
            return Ok(new { Name = "Registrar Transaccion" });
        }
    }
}
