using System.Collections.Generic;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace LoteryLogic.ContractFunctions
{
    [Function("tickets", typeof(string[]))]
    public class GetTicketMapFunction : FunctionMessage
    {

    }
}
