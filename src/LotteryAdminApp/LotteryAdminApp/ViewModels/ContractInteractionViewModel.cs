using System;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LoteryLogic;
using LotteryAdminApp.Controllers;
using Nethereum.Web3;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace LotteryAdminApp.ViewModels
{
    public class ContractInteractionViewModel : ReactiveObject
    {
        private SmartContractController _contractController;

        [Reactive]
        public ICommand LoadContractCommand { get; set; }
        [Reactive]
        public ICommand CloseLoteryCommand { get; set; }

        #region Binding fields

        #region Contract fields

        [Reactive] public string InnerContractAddress { get; set; }
        [Reactive] public string ContractAddress { get; set; }
        [Reactive] public BigInteger CommisionBank { get; set; }
        [Reactive] public BigInteger Commision { get; set; }
        [Reactive] public BigInteger LoteryEnd { get; set; }
        [Reactive] public BigInteger PrizeValue { get; set; }
        [Reactive] public BigInteger TimeToEnd { get; set; }
        [Reactive] public BigInteger TokenCount { get; set; }
        [Reactive] public BigInteger TokenPrice { get; set; }
        [Reactive] public BigInteger WinnedTokenNum { get; set; }
        [Reactive] public string Winner { get; set; }

        #endregion

        #region View interaction fields

        [Reactive] public Visibility ContractInfoVisibility { get; set; } = Visibility.Hidden;

        [Reactive] public bool IsContractLoading { get; set; }

        #endregion

        #endregion


        public ContractInteractionViewModel()
        {
            LoadContractCommand = new CommandHandler(o => true, LoadContract);
            CloseLoteryCommand = new CommandHandler(o => true, CloseLotery);

            ModuleInteractionController.ContractDeployed += OnContractDeployed;
        }

        private async void LoadContract(object parametr)
        {
            try
            {
                IsContractLoading = true;

                _contractController = new SmartContractController(InnerContractAddress, new Web3("https://ropsten.infura.io"));
                await UpdateContractInfo();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                IsContractLoading = false;
            }
        }

        private void OnContractDeployed(object sender, EventArgs args)
        {
            InnerContractAddress = sender as string;
        }

        private async Task UpdateContractInfo()
        {
            ContractAddress = InnerContractAddress;
            CommisionBank = await _contractController.GetCommisionBank();
            Commision = await _contractController.GetCommision();
            LoteryEnd = await _contractController.GetLoteryEnd();
            PrizeValue = await _contractController.GetPrizeValue();
            TimeToEnd = await _contractController.GetTimeToEnd();
            TokenCount = await _contractController.GetTokenCount();
            TokenPrice = await _contractController.GetTokenPrice();
            WinnedTokenNum = await _contractController.GetWinnedTokenNum();
            Winner = await _contractController.GetWinner();

            ContractInfoVisibility = Visibility.Visible;
            IsContractLoading = false;
        }

        private async void CloseLotery(object state)
        {
            await _contractController.EndLotery(null);
        }
     }
}
