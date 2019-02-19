using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("loteryEnd", "uint256")]
    public class GetLoteryEndFunction : FunctionMessage
    {
    }
}
