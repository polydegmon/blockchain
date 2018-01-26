using System;
using System.Collections.Generic;
using BlockChain.Interfaces;

namespace BlockChain
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class BlockChain<T> : IBlockChain<T>
        where T : Transaction, new()
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Block<T>> _chain;

        /// <summary>
        /// 
        /// </summary>
        private int _difficulty = 2;

        /// <summary>
        /// Ensure we only create the block chain a single time and add a genesis block to it
        /// </summary>
        public BlockChain()
        {
            _chain = new List<Block<T>>
            {
                CreateGenesisBlock()
            };
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a genesis block to be used as the start of the block chain
        /// </summary>
        /// <returns></returns>
        public Block<T> CreateGenesisBlock()
        {
            var data = new List<T> { new T { Name = "Genesis Block" } };
            return new Block<T>(0, DateTime.Now, data, 0);
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the current <see cref="T:BlockChain.BlockChain`1" />
        /// </summary>
        /// <returns></returns>
        public List<Block<T>> GetChain() => _chain;

        /// <inheritdoc />
        /// <summary>
        /// Get the latest <see cref="T:BlockChain.Block`1" /> in the <see cref="T:BlockChain.BlockChain`1" />
        /// </summary>
        /// <returns></returns>
        public Block<T> GetLatestBlock() => _chain[_chain.Count - 1];

        /// <inheritdoc />
        /// <summary>
        /// Add a new <see cref="T:BlockChain.Block`1" /> to the <see cref="T:BlockChain.BlockChain`1" />
        /// </summary>
        public void AddBlock(Block<T> newBlock)
        {
            // Point to the hash of the previous block
            newBlock.PreviousHash = GetLatestBlock().Hash;

            // Compute the new hash for the block
            newBlock.MineBlock(_difficulty);

            // Add the block to the chain
            _chain.Add(newBlock);
        }

        /// <inheritdoc />
        /// <summary>
        /// Validates the chain is valid by checking the head <see cref="T:BlockChain.Block`1" /> with the previous <see cref="T:BlockChain.Block`1" /> in the <see cref="T:BlockChain.BlockChain`1" />
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The current blocks compute hash function is run and compared against the saved value of the hash for the data
        /// The current blocks previous hash value is compared to the hash value of the previous block
        /// </remarks>
        public bool IsChainValid()
        {
            for (var index = 0; index < _chain.Count; index++)
            {
                var currentBlock = _chain[index];

                if (currentBlock.Hash != currentBlock.ComputeHash())
                    return false;

                if (index == 0) continue;

                var previousBlock = _chain[index - 1];

                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }

            return true;
        }
    }
}