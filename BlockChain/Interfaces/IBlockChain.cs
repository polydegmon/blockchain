using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BlockChain.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IBlockChain<T> where T : Transaction, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Block<T> CreateGenesisBlock();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Block<T>> GetChain();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Block<T> GetLatestBlock();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newBlock"></param>
        void AddBlock(Block<T> newBlock);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsChainValid();
    }
}