using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("endLotery")]
    public class EndLoteryFunction : FunctionMessage
    {
    }
}
