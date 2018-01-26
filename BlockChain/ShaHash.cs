using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace BlockChain
{
    /// <summary>
    /// 
    /// </summary>
    public static class ShaHash
    {
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
        public static readonly SHA512Managed Sha;

        static ShaHash()
        {
            Sha = new SHA512Managed();
            Sha.Initialize();
        }
    }
}