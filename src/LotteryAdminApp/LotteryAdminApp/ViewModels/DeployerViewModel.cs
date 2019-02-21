using System;
using System.Numerics;
using System.Windows;
using LoteryLogic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;
using LoteryLogic.Models;
using LotteryAdminApp.Common;
using LotteryAdminApp.Controllers;

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

        [Reactive] public string ContractUrl { get; set; } = "";
        [Reactive] public DateTime LoteryEndDate { get; set; } = DateTime.Now;
        [Reactive] public DateTime LoteryEndTime { get; set; } = DateTime.Now;
        [Reactive] public string TokenPrice { get; set; }
        [Reactive] public string Commision { get; set; }

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
            return !string.IsNullOrEmpty(ContractCode) && LoginController.IsLogin;
        }

        private async void DeployContract(object parametr)
        {
            try
            {
                IsBusy = true;

                var model = FormContractParametersModel();

                NotificationConsoleController.GetInstance().AppendAllertMessage("Contract deploying...");

                var deployer = new SmartContractDeployer(LoginController.Web3);
                ContractAddress = await deployer.Deploy(ContractCode, model);
                ContractUrl = "https://ropsten.etherscan.io/address/" + ContractAddress;

                NotificationConsoleController.GetInstance().AppendAllertMessage("Contract deployed sucсessfully!");
                NotificationConsoleController.GetInstance().AppendUrlMessage(new CustomUrlMessage
                {
                    MessageText = "Contract address: ",
                    AdditionalMessageText = ContractAddress,
                    AdditionalMessageUrl = ContractUrl
                });

                ModuleInteractionController.RaiseContractDeployed(ContractAddress);

                IsBusy = false;
            }
            catch (Exception e)
            {
                IsBusy = false;
                NotificationConsoleController.GetInstance().AppendErrorMessage(e.Message);
            }
        }

        private ContractParametersModel FormContractParametersModel()
        {
            var endDateTime = new DateTimeOffset(LoteryEndDate.Date + LoteryEndTime.TimeOfDay).ToUnixTimeSeconds();
            return new ContractParametersModel
            {
                Comission = BigInteger.Parse(Commision),
                TokenPrice = BigInteger.Parse(TokenPrice),
                LoteryEnd = endDateTime
            };
        }


    }
}
