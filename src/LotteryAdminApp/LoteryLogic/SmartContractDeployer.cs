using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace LoteryLogic
{
    public class SmartContractDeployer
    {
        private readonly Web3 _web3;

        public SmartContractDeployer(Web3 web3)
        {
            _web3 = web3;
        }

        public async Task<string> Deploy()
        {

            var deploymentMessage = new StandardLoteryDeployment();

            var deploymentHandler = _web3.Eth.GetContractDeploymentHandler<StandardLoteryDeployment>();
            var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            return transactionReceipt.ContractAddress;
        }
    }
}
