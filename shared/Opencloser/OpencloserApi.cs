namespace shared.Opencloser
{
    using Microsoft.AspNetCore.Mvc;
    using shared.Blockchain.Model;
    using shared.Common;
    using shared.Opencloser.Api.Response;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OpencloserApi
    {
        private static readonly Constants Constant = new Constants();

        public static async Task<CloseBlockResponse> CloseBlock(BlockchainModel request) =>
            await Http.Post<CloseBlockResponse>($"{Constant.OpencloserEndpoint}CloseBlock", request);
    }
}
