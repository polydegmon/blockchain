using System.Runtime.Serialization;
using BlockChain.Interfaces;

namespace BlockChain
{
    /// <inheritdoc />
    /// <summary>
    /// A sample transaction class to implement the blockchain.
    /// </summary>
    /// <remarks>
    /// This can be a complex as required to get the job done
    /// </remarks>
    [DataContract]
    public class Transaction : ITransaction
    {
        /// <inheritdoc />
        /// <summary>
        /// The name of the transaction
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}