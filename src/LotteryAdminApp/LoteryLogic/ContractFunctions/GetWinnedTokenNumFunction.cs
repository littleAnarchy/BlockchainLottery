using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("winedTokenNum", "uint256")]
    public class GetWinnedTokenNumFunction : FunctionMessage
    {
    }
}
