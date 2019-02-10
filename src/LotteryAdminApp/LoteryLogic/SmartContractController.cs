using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoteryLogic.ContractFunctions;
using Nethereum.Web3;
using Org.BouncyCastle.Math;

namespace LoteryLogic
{
    public class SmartContractController
    {
        private readonly string _contractAddress;
        private readonly Web3 _web3;

        public SmartContractController(string contractAddress, Web3 web3)
        {
            _contractAddress = contractAddress;
            _web3 = web3;
        }

        public async Task<int> GetData()
        {
            var getFunctionMessage = new GetFunction();
            var dataHandler = _web3.Eth.GetContractQueryHandler<GetFunction>();
            var data = await dataHandler.QueryAsync<int>(_contractAddress, getFunctionMessage);
            return data;
        }

        public async Task SetData(int x)
        {
            var transfer = new SetFunction{X = x};
            var transferHandler = _web3.Eth.GetContractTransactionHandler<SetFunction>();
            var transactionReceipt =
                await transferHandler.SendRequestAndWaitForReceiptAsync(_contractAddress, transfer);
        }

        public async Task<string[]> GetTicketMap()
        {
            var tickets = new GetTicketMapFunction();
            var dataHandler = _web3.Eth.GetContractQueryHandler<GetTicketMapFunction>();
            var data = await dataHandler.QueryAsync<string[]>(_contractAddress, tickets);
            return data;
        }
    }
}
