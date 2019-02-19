using System.Windows.Input;
using LotteryAdminApp.Controllers;
using LotteryAdminApp.UserControls;
using MaterialDesignThemes.Wpf;
using ReactiveUI;

namespace LotteryAdminApp.ViewModels
{
    public class AdminAppViewModel : ReactiveObject
    {
        public ICommand RunLoginDialogCommand { get; }

        public AdminAppViewModel()
        {
            RunLoginDialogCommand = new CommandHandler(o => true, RunLoginDialog);
        }

        private async void RunLoginDialog(object state)
        {
            var view = new LoginDialog
            {
                DataContext = new LoginController()
            };

            var result = await DialogHost.Show(view, "LoginDialog");
        }
    }
}
