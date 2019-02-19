using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

namespace LoteryLogic.ContractFunctions
{
    [Function("tokens", "address")]
    public class GetTokenFunction : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public BigInteger Index { get; set; }
    }
}
