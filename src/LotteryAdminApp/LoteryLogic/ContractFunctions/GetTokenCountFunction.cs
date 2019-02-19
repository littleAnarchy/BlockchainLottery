using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("getCount", "uint256")]
    public class GetTokenCountFunction : FunctionMessage
    {
    }
}
