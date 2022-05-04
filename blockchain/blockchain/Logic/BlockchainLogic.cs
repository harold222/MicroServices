using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shared.Blockchain.Model;
using shared.Opencloser;

namespace blockchain.Logic
{
    public class BlockchainLogic
    {
        private static List<BlockchainModel> Blocks = new List<BlockchainModel>();
        private static int currentEditBlock = 0;

        public async Task RegistrarTx(string dir1, string dir2, float amount)
        {

            if (Blocks.Count == 0)
                await CreateNewBlock().ConfigureAwait(false);
            else
            {
                if (!string.IsNullOrEmpty(Blocks.LastOrDefault().hash))
                    await CreateNewBlock().ConfigureAwait(false);  
            }

            string transaction = $"{dir1}-{dir2}:{amount}";
            // save the transaction
            Blocks[currentEditBlock].data =
                Blocks[currentEditBlock].data == "" ?
                    transaction :
                    $"{Blocks[currentEditBlock].data},{transaction}";

            // verify count of transactions
            string[] allTransactions = Blocks[currentEditBlock].data.Split(',');
            if (allTransactions.Count() >= 3)
            {
                Blocks[currentEditBlock] = (await OpencloserApi.CloseBlock(Blocks[currentEditBlock])).NewBlock;
            }
        }

        public List<BlockchainModel> PrintAllBlocks()
        {
            List<BlockchainModel> model = new List<BlockchainModel>();

            Blocks.ForEach(block =>
                model.Add(new BlockchainModel
                {
                    id = block.id,
                    nonce = block.nonce,
                    data = block.data,
                    previousHash = block.previousHash,
                    hash = block.hash
                })
            );

            return model;
        }

        public float ConsultFunds(string dir)
        {
            float amount = -1;

            Blocks.ForEach(block =>
            {
                string[] allTransactions = block.data.Split(',');

                foreach (string transaction in allTransactions)
                {
                    string[] directions = transaction.Split('-');
                    if (directions.Length == 2)
                    {
                        string[] values = directions[1].Split(':');

                        if (directions[0] == dir)
                        {
                            if (amount == -1) amount = 0;
                            amount = amount - float.Parse(values[1]);
                        }
                        else if (values[0] == dir)
                        {
                            if (amount == -1) amount = 0;
                            amount = float.Parse(values[1]) + amount;
                        }
                    }
                }
            });

            return amount;
        }

        public int GetTotalBlocks() => Blocks.Count;

        public bool BlockOneHaveHash() =>
            GetTotalBlocks() > 0 ? !string.IsNullOrEmpty(Blocks[0].hash) : false;

        public bool VerifyAmountInDirection(string direction, float amount)
        {
            bool success = false;
            float result = ConsultFunds(direction);

            if (result != -1)
            {
                if (amount != 0) // primera direccion quien envia, comprobar saldo
                {
                    if (result >= amount) success = true;
                }
                else // segunda direccion quien recibe, solo comprobar que exista
                    success = true;
            }

            return success;
        }

        private async Task CreateNewBlock()
        {
            currentEditBlock = GetTotalBlocks();
            var response = (await OpencloserApi.OpenBlock(
                $"{currentEditBlock}",
                currentEditBlock == 0 ? "00000" : Blocks.LastOrDefault().hash
            )).NewBlock;
            Blocks.Add(response);
        }
    }
}
