namespace shared.Opencloser
{
    using Microsoft.AspNetCore.Mvc;
    using shared.Blockchain.Model;
    using shared.Common;
    using shared.Opencloser.Api.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OpencloserApi
    {
        private static readonly Constants Constant = new Constants();

        public static async Task<CloseBlockResponse> CloseBlock(BlockchainModel request) =>
            await Http.Post<CloseBlockResponse>($"{Constant.OpencloserEndpoint}CloseBlock", request);

        public static async Task<CloseBlockResponse> OpenBlock(string totalBlocks, string lastHash) =>
            await Http.Get<CloseBlockResponse>(
                $"{Constant.OpencloserEndpoint}OpenBlock",
                new Dictionary<string, string> {
                    { "totalBlocks", totalBlocks },
                    { "lastHash", lastHash },
                }
            );
    }
}
