using System.Numerics;
using System.Threading.Tasks;
using LoteryLogic.Models;
using Nethereum.Web3;

namespace LoteryLogic
{
    public class SmartContractDeployer
    {
        private readonly Web3 _web3;

        public SmartContractDeployer(Web3 web3)
        {
            _web3 = web3;
        }

        public async Task<string> Deploy(string byteCode)
        {

            var deploymentMessage = new StandardLoteryDeployment(byteCode);

            var deploymentHandler = _web3.Eth.GetContractDeploymentHandler<StandardLoteryDeployment>();

            //deploymentMessage.GasPrice = await deploymentHandler.EstimateGasAsync(deploymentMessage);

            var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            return transactionReceipt.ContractAddress;
        }

        public async Task<string> Deploy(string byteCode, ContractParametersModel model)
        {

            var deploymentMessage = new StandardLoteryDeployment(byteCode);

            deploymentMessage.Comission = model.Comission;
            deploymentMessage.LoteryEnd = model.LoteryEnd;
            deploymentMessage.TokenPrice = model.TokenPrice;

            var deploymentHandler = _web3.Eth.GetContractDeploymentHandler<StandardLoteryDeployment>();

            //deploymentMessage.GasPrice = await deploymentHandler.EstimateGasAsync(deploymentMessage);

            var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            return transactionReceipt.ContractAddress;
        }

        public async Task<string> Deploy(string byteCode, ContractParametersModel contractModel, TransactionParamentrsModel transactionParamenters)
        {

            var deploymentMessage = new StandardLoteryDeployment(byteCode)
            {
                Comission = contractModel.Comission,
                LoteryEnd = contractModel.LoteryEnd,
                TokenPrice = contractModel.TokenPrice
            };


            if (transactionParamenters.AmountToSend != BigInteger.Zero)
                deploymentMessage.AmountToSend = transactionParamenters.AmountToSend;
            if (transactionParamenters.GasPrice != BigInteger.Zero)
                deploymentMessage.GasPrice = transactionParamenters.GasPrice;
            if (transactionParamenters.Gas != BigInteger.Zero)
                deploymentMessage.Gas = transactionParamenters.Gas;

            var deploymentHandler = _web3.Eth.GetContractDeploymentHandler<StandardLoteryDeployment>();

            var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            return transactionReceipt.ContractAddress;
        }
    }
}
