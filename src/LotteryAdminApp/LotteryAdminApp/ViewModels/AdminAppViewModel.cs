using System;
using System.Globalization;
using System.Timers;
using System.Windows.Input;
using LotteryAdminApp.Controllers;
using LotteryAdminApp.UserControls;
using MaterialDesignThemes.Wpf;
using Nethereum.Web3;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace LotteryAdminApp.ViewModels
{
    public class AdminAppViewModel : ReactiveObject
    {
        public event EventHandler OnLogin;

        private Timer _timer;

        public string LoginAddress => LoginController.IsLogin ? Web3.GetAddressFromPrivateKey(LoginController.PrivateKey) : "Is not login";
        [Reactive] public string AddressUrl { get; set; } = "";

        [Reactive] public string Balance { get; set; } = "Is not login";

        public bool IsNotLogin => !LoginController.IsLogin;

        public ICommand RunLoginDialogCommand { get; }

        public AdminAppViewModel()
        {
            RunLoginDialogCommand = new CommandHandler(o => true, RunLoginDialog);
        }

        private async void RunLoginDialog(object state)
        {
            var view = new LoginDialog
            {
                DataContext = new LoginDialogViewModel()
            };

            var result = await DialogHost.Show(view, "LoginDialog");

            UpdateViewModel();
            OnLogin?.Invoke(this, null);
            InitBalanceTimer();
        }

        private void InitBalanceTimer()
        {
            _timer = new Timer
            {
                Enabled = true,
                Interval = 1000 //1 second
            };
            _timer.Elapsed += UpdateBalance;
        }

        private void UpdateViewModel()
        {
            AddressUrl = "https://ropsten.etherscan.io/address/" + LoginAddress;

            this.RaisePropertyChanged(nameof(LoginAddress));
            this.RaisePropertyChanged(nameof(IsNotLogin));
            this.RaisePropertyChanged(nameof(AddressUrl));
        }

        private async void UpdateBalance(object sender, EventArgs args)
        {
            try
            {
                if (!LoginController.IsLogin) return;
                var balance = await LoginController.Web3.Eth.GetBalance.SendRequestAsync(LoginAddress);
                var newBalance = Web3.Convert.FromWei(balance).ToString(CultureInfo.InvariantCulture) + " Eth";
                if (newBalance != Balance)
                    NotificationConsoleController.GetInstance().AppendInfoMessage($"Balance updated: {newBalance}");
                Balance = newBalance;
            }
            catch (Exception e)
            {

                NotificationConsoleController.GetInstance().AppendErrorMessage(e.Message);
            }
        }
    }
}
