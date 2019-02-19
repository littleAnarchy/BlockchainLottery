using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("tokenPrice", "uint256")]
    public class GetTokenPriceFunction : FunctionMessage
    {
    }
}
