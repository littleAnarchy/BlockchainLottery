using System;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using LotteryAdminApp.Controllers;
using MaterialDesignThemes.Wpf;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace LotteryAdminApp.ViewModels
{
    public class LoginDialogViewModel : ReactiveObject
    {
        [Reactive] public string UserPrivateKey { get; set; }

        public ICommand RunLoginationCommand { get; }

        public LoginDialogViewModel()
        {
            RunLoginationCommand = new CommandHandler(IsCanLogin, RunLogination);
        }

        private void RunLogination(object state)
        {
            try
            {
                LoginController.SetPrivateKey(UserPrivateKey);
                DialogHost.CloseDialogCommand.Execute(null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool IsCanLogin(object state)
        {
            return !string.IsNullOrEmpty(UserPrivateKey);
        }
    }
}
