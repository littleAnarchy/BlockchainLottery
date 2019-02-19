using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("commision", "uint256")]
    public class GetCommisionFunction : FunctionMessage
    {
    }
}
