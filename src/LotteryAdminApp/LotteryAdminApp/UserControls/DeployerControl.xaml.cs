using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using LotteryAdminApp.Common;
using LotteryAdminApp.Controllers;
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
    }
}
