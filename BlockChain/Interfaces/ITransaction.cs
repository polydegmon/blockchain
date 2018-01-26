namespace BlockChain.Interfaces
{
    /// <summary>
    /// Describes the smallest data level of the block in the blockchain.
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// The name of the transaction
        /// </summary>
        string Name { get; set; }
    }
}