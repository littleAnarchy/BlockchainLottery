using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("commisionBank", "uint256")]
    public class GetCommisionBankFunction : FunctionMessage
    {
    }
}
