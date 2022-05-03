namespace shared.Blockchain.Model
{
    public class BlockchainModel
    {
        public string id { get; set; }

        public int nonce { get; set; }

        public string data { get; set; }

        public string previousHash { get; set; }

        public string hash { get; set; }
    }
}
