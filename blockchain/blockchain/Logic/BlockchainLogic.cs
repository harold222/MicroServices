﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Dynamic;
using shared.Blockchain.Model;

namespace blockchain.Logic
{
    public class BlockchainLogic
    {
        private static List<dynamic> Blocks = new List<dynamic>();
        private static int currentEditBlock = 0;

        public void RegistrarTx(string dir1, string dir2, float amount)
        {
            if (Blocks.Count > 0)
            {
                string[] allTransactions = Blocks.LastOrDefault().data.Split(',');

                if (allTransactions.Count() >= 3)
                {
                    // Close the block
                    string resultHash = "";
                    do
                    {
                        Blocks[currentEditBlock].nonce = Blocks[currentEditBlock].nonce + 1;
                        string allData =
                            $"{Blocks[currentEditBlock].id}+{Blocks[currentEditBlock].nonce}+{Blocks[currentEditBlock].data}+{Blocks[currentEditBlock].previousHash}";

                        resultHash = GenerateHash(allData);
                        // hash generate 000 at the beginning of the string
                    } while (resultHash.Substring(0, 3) != "000");

                    // save hash of block
                    Blocks[currentEditBlock].hash = resultHash;
                    // Create other block
                    CreateNewBlock();
                }
            }
            else CreateNewBlock();

            string transaction = $"{dir1}-{dir2}:{amount}";
            // save the transaction
            Blocks[currentEditBlock].data =
                Blocks[currentEditBlock].data == "" ?
                    transaction :
                    $"{Blocks[currentEditBlock].data},{transaction}";
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

        private string GenerateHash(string words)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string word = string.Format("{0}{1}", sha256, words);
                byte[] wordAsBytes = Encoding.UTF8.GetBytes(word);
                return Convert.ToBase64String(sha256.ComputeHash(wordAsBytes));
            }
        }

        private static void CreateNewBlock()
        {
            int totalBlocks = GetTotalBlocks();

            // previousHash if the first block save value defult
            // else save last generated hash
            dynamic newBlock = new ExpandoObject();
            newBlock.id = $"{totalBlocks}";
            newBlock.nonce = 0;
            newBlock.data = "";
            newBlock.previousHash = totalBlocks == 0 ? "00000" : Blocks.LastOrDefault().hash;
            newBlock.hash = "";

            Blocks.Add(newBlock);
            currentEditBlock = totalBlocks;
        }

        private static int GetTotalBlocks() => Blocks.Count;
    }
}