using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("winner", "address")]
    public class GetWinnerFunction : FunctionMessage
    {
    }
}
