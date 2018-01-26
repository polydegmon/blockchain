using BlockChain.Tests.Fixture;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace BlockChain.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [Collection("UnitTestFixture")]
    public class BlockChainTests
    {
        /// <summary>
        /// 
        /// </summary>
        public ITestOutputHelper Output;

        /// <summary>
        /// 
        /// </summary>
        private readonly UnitTestFixture _unitTestFixture;

        /// <summary>
        /// 
        /// </summary>
        public BlockChainTests(UnitTestFixture unitTestFixture, ITestOutputHelper output)
        {
            Output = output;

            _unitTestFixture = unitTestFixture;
        }

        [Fact]
        public void Test1()
        {
            Output.WriteLine(_unitTestFixture.BlockChain.IsChainValid()
                ? "Blockchain is valid..."
                : "Blockchain is invalid...");

            var chain =  _unitTestFixture.BlockChain.GetChain();

            Output.WriteLine(JsonConvert.SerializeObject(chain, Formatting.Indented));
        }
    }
}