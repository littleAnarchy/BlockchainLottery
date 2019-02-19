using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("prize", "uint256")]
    public class GetPrizeValueFunction : FunctionMessage
    {
    }
}
