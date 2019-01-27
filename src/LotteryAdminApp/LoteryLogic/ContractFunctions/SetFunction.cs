using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("set")]
    public class SetFunction : FunctionMessage
    {
        [Parameter("uint256", "x")]
        public int X { get; set; }
    }
}
