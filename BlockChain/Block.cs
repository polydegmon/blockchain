using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace BlockChain
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Block<T> : IBlock where T : Transaction, new()
    {
        #region Properties

        /// <summary>
        /// The index of the block, representing the number of blocks in the chain
        /// </summary>
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        [DataMember]
        private readonly long _index;

        /// <summary>
        /// The initial creation time of the block
        /// </summary>
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        [DataMember]
        private readonly DateTime _creationTime;

        /// <summary>
        /// The information that is to be added to the block
        /// </summary>
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        [DataMember]
        private readonly IList<T> _data;

        /// <summary>
        /// The random string used to solve the hashing problem
        /// </summary>
        /// <remarks>
        /// The hashing problem, is to get a number of zero's at the start of the hash by changing the nonce value
        /// This is made more difficulty by the difficulty value setting, which specifices the number of zero's required
        /// </remarks>
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        [DataMember]
        private int _nonce;

        /// <summary>
        /// The hash of the previous block
        /// </summary>
        [DataMember]
        public string PreviousHash { get; set; }

        /// <summary>
        /// The hash for this block.
        /// </summary>
        /// <remarks>
        /// This has to fit the difficulty parameters
        /// </remarks>
        [IgnoreDataMember]
        public string Hash { get; private set; }

        #endregion

        /// <summary>
        /// We add all the data to a block and create the hash
        /// </summary>
        /// <param name="index">The index of the block, representing the number of blocks in the chain</param>
        /// <param name="creationTime">The initial creation time of the block</param>
        /// <param name="data">The data to be added to the block</param>
        /// <param name="nonce">The random string used to solve the hashing problem</param>
        public Block(long index, DateTime creationTime, IList<T> data, int nonce)
        {
            _index = index;
            _creationTime = creationTime;
            _nonce = nonce;
            _data = data;

            PreviousHash = string.Empty;

            Hash = ComputeHash();
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a hash of the block using <see cref="T:System.Security.Cryptography.SHA512" /> and returns it as a string
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// All the properties of the block are used to create the hash
        /// </remarks>
        public string ComputeHash()
        {
            var bf = new DataContractSerializer(typeof(Block<Transaction>));

            using (var ms = new MemoryStream())
            {
                bf.WriteObject(ms, this);
                ShaHash.Sha.ComputeHash(ms.ToArray());
            }

            var hash = ShaHash.Sha.Hash;

            var hashString = BitConverter.ToString(hash).Replace("-", string.Empty);

            return hashString;
        }

        /// <inheritdoc />
        /// <summary>
        /// This is the puzzle to solve driven by the difficulty variable.
        /// The difficulty is generating a number of zero's at the start of the hash
        /// </summary>
        public void MineBlock(int difficulty)
        {
            do
            {
                _nonce++;
                Hash = ComputeHash();
            } while (difficulty != 0 && Hash.Take(difficulty).ToString() != new string('0', difficulty));
        }
    }
}