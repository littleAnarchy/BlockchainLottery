using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("get", "uint256")]
    public class BuyTicketFunction : FunctionMessage
    {
    }
}
