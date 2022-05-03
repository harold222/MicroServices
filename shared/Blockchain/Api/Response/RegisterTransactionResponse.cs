namespace shared.Blockchain.Api.Response
{
    using shared.Blockchain.Model;
    using System.Collections.Generic;

    public class RegisterTransactionResponse
    {
        public List<BlockchainModel> Blocks { get; set; }
    }
}
