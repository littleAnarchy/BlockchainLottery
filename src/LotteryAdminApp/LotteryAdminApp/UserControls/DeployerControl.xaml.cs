using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;
using LotteryAdminApp.ViewModels;

namespace LotteryAdminApp.UserControls
{
    /// <summary>
    /// Interaction logic for DeployerControl.xaml
    /// </summary>
    public partial class DeployerControl : UserControl
    {
        public DeployerControl()
        {
            InitializeComponent();
            DataContext = new DeployerViewModel();
        }


        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
