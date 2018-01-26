using System.Security.Cryptography;

namespace BlockChain.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBlock
    {
        /// <summary>
        /// Create a hash of the block using <see cref="SHA512"/> and returns it as a string
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// All the properties of the block are used to create the hash
        /// </remarks>
        string ComputeHash();

        /// <summary>
        /// This is the puzzle to solve driven by the difficulty variable.
        /// The difficulty is generating a number of zero's at the start of the hash
        /// </summary>
        void MineBlock(int difficulty);
    }
}