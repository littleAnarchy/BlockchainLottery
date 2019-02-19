using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("getTimeToEnd", "uint256")]
    public class GetTimeToEndFunction : FunctionMessage
    {
    }
}
