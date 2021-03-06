namespace shared.Register
{
    using shared.Blockchain.Api.Response;
    using shared.Common;
    using shared.Wallet.Api.Request;
    using System.Threading.Tasks;

    public static class RegisterApi
    {
        private static readonly Constants Constant = new Constants();

        public static async Task<RegisterTransactionResponse> RegisterTransaction(RegisterNewTransaction request) =>
            await Http.Post<RegisterTransactionResponse>($"{Constant.RegisterEndpoint}RegisterTransaction", request);
    }
}
