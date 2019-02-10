using System.Windows.Input;
using LoteryLogic;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace LotteryAdminApp.ViewModels
{
    public class AdminAppViewModel : ReactiveObject
    {
        #region Commands

        public ICommand DeployCommand { get; set; }

        #endregion

        #region Binding Fields

        [Reactive] public bool IsBusy { get; set; }

        [Reactive] public string ContractCode { get; set; }

        [Reactive] public string NodeUrl { get; set; } = "https://ropsten.infura.io";

        [Reactive] public string PrivateKey { get; set; }

        [Reactive] public string ContractAddress { get; set; } = "Not deployed";

        [Reactive]
        public string ContractUrl { get; set; } = "";

        #endregion

        public AdminAppViewModel()
        {
            DeployCommand = new CommandHandler(IsContractDeployable, DeployContract);
        }

        private bool IsContractDeployable(object parametr)
        {
            return !(string.IsNullOrEmpty(ContractCode) ||
                     string.IsNullOrEmpty(NodeUrl) ||
                     string.IsNullOrEmpty(PrivateKey));
        }

        private async void DeployContract(object parametr)
        {
            IsBusy = true;

            var account = new Account(PrivateKey);
            var web3 = new Web3(account, NodeUrl);

            var deployer = new SmartContractDeployer(web3);
            ContractAddress = await deployer.Deploy(ContractCode);
            ContractUrl = "https://ropsten.etherscan.io/address/" + ContractAddress;
            IsBusy = false;
        }
    }
}
