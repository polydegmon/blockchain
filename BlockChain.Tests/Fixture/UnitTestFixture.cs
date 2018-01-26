using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BlockChain.Tests.Fixture
{
    /// <inheritdoc />
    /// <summary>
    /// This class sets up all the fixture information required to run the unit tests
    /// </summary>
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public sealed class UnitTestFixture : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public BlockChain<Transaction> BlockChain;

        public UnitTestFixture()
        {
            BlockChain = new BlockChain<Transaction>();

            const int blocksToAdd = 2;

            for (var i = 0; i < blocksToAdd; i++)
                BlockChain.AddBlock(GetBlock());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public Block<Transaction> GetBlock()
        {
            var index = BlockChain.GetChain().Count;
            var creationTime = DateTime.Now;

            const int nonce = 0;
            var data = GetData();

            return new Block<Transaction>(index, creationTime, data, nonce);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public IList<Transaction> GetData()
        {
            return new List<Transaction>
            {
                new Transaction
                {
                    Name = "Test Block 1"
                },
                new Transaction
                {
                    Name = "Test Block 2"
                },
                new Transaction
                {
                    Name = "Test Block 3"
                }
            };
        }

        public void Dispose()
        {
        }
    }
}