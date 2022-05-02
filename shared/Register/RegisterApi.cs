namespace shared.Register
{
    using Microsoft.AspNetCore.Mvc;
    using shared.Common;
    using shared.Wallet.Api.Request;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class RegisterApi
    {
        private static readonly Constants Constant = new Constants();

        public static async Task<ActionResult> RegisterTransaction(RegisterNewTransaction request) =>
            await Http.Post<ActionResult>($"{Constant.RegisterEndpoint}RegisterTransaction", request);
    }
}
