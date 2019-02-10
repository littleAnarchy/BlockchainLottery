using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Navigation;
using LotteryAdminApp.ViewModels;

namespace LotteryAdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly AdminAppViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new AdminAppViewModel();
            DataContext = _viewModel;
            Background = Brushes.DimGray;
            WindowTitleBrush = Brushes.SlateBlue;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
