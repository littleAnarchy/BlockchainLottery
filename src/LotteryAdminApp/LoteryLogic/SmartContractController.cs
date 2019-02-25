using System.Numerics;
using System.Threading.Tasks;
using LoteryLogic.ContractFunctions;
using LoteryLogic.Models;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;

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

        public async Task<TransactionReceipt> BuyTokens(TransactionParamentrsModel model)
        {
            var transfer = new BuyTokenFunction();

            if (model != null)
            {
                transfer.AmountToSend = model.AmountToSend;
                transfer.GasPrice = model.GasPrice;
                transfer.Gas = model.Gas;
            }
            
            var transferHandler = _web3.Eth.GetContractTransactionHandler<BuyTokenFunction>();
            return await transferHandler.SendRequestAndWaitForReceiptAsync(_contractAddress, transfer);
        }

        public async Task<TransactionReceipt> EndLotery(TransactionParamentrsModel model)
        {
            var transfer = new EndLoteryFunction();

            if (model != null)
            {
                transfer.AmountToSend = model.AmountToSend;
                transfer.GasPrice = model.GasPrice;
                transfer.Gas = model.Gas;
            }

            var transferHandler = _web3.Eth.GetContractTransactionHandler<EndLoteryFunction>();
            return await transferHandler.SendRequestAndWaitForReceiptAsync(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetCommisionBank()
        {
            var transfer = new GetCommisionBankFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetCommisionBankFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetCommision()
        {
            var transfer = new GetCommisionFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetCommisionFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetLoteryEnd()
        {
            var transfer = new GetLoteryEndFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetLoteryEndFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetPrizeValue()
        {
            var transfer = new GetPrizeValueFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetPrizeValueFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetTimeToEnd()
        {
            var transfer = new GetTimeToEndFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetTimeToEndFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetTokenCount()
        {
            var transfer = new GetTokenCountFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetTokenCountFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<string> GetToken(BigInteger index)
        {
            var transfer = new GetTokenFunction();

            transfer.Index = index;

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetTokenFunction>();
            return await transferHandler.QueryAsync<string>(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetTokenPrice()
        {
            var transfer = new GetTokenPriceFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetTokenPriceFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<BigInteger> GetWinnedTokenNum()
        {
            var transfer = new GetWinnedTokenNumFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetWinnedTokenNumFunction>();
            return await transferHandler.QueryAsync<BigInteger>(_contractAddress, transfer);
        }

        public async Task<string> GetWinner()
        {
            var transfer = new GetWinnerFunction();

            var transferHandler = _web3.Eth.GetContractQueryHandler<GetWinnerFunction>();
            return await transferHandler.QueryAsync<string>(_contractAddress, transfer);
        }
    }
}
