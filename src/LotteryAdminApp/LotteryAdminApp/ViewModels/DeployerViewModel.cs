using System.Windows;
using LoteryLogic;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace LotteryAdminApp.ViewModels
{
    public class DeployerViewModel : ReactiveObject
    {
        #region Commands

        public ICommand DeployCommand { get; set; }

        #endregion

        #region Binding Fields

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                this.RaisePropertyChanged(nameof(IsBusy));
                this.RaisePropertyChanged(nameof(ProgressBarVisibility));
            }
        }

        [Reactive] public string ContractCode { get; set; }

        [Reactive] public string NodeUrl { get; set; } = "https://ropsten.infura.io";

        [Reactive] public string PrivateKey { get; set; }

        [Reactive] public string ContractAddress { get; set; } = "Not deployed";

        [Reactive]
        public string ContractUrl { get; set; } = "";

        public Visibility ProgressBarVisibility
        {
            get
            {
                if (IsBusy)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        #endregion

        public DeployerViewModel()
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
