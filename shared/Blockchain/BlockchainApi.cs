namespace shared.Blockchain
{
    using Microsoft.AspNetCore.Mvc;
    using shared.Blockchain.Api.Response;
    using shared.Common;
    using shared.Wallet.Api.Request;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class BlockchainApi
    {
        private static readonly Constants Constant = new Constants();

        public static async Task<ConsultFundsResponse> ConsultFunds(string direction) =>
            await Http.Get<ConsultFundsResponse>($"{Constant.BlockchainEndpoint}ConsultFunds", new Dictionary<string, string> { { "direction", direction } });

        public static async Task<RegisterTransactionResponse> RegisterTransaction(RegisterNewTransaction request) =>
            await Http.Post<RegisterTransactionResponse>($"{Constant.BlockchainEndpoint}RegisterTransaction", request);
    }
}
