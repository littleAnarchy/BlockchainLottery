using System.Windows;
using System.Windows.Controls;
using LotteryAdminApp.ViewModels;

namespace LotteryAdminApp.UserControls
{
    /// <summary>
    /// Interaction logic for ContractInteractionControl.xaml
    /// </summary>
    public partial class ContractInteractionControl
    {
        public ContractInteractionControl()
        {
            InitializeComponent();
            DataContext = new ContractInteractionViewModel();
        }
    }
}
