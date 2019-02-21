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
            _viewModel.OnLogin += OnLogin;
            DataContext = _viewModel;

            Background = new SolidColorBrush(Color.FromRgb(18, 37, 81));
            WindowTitleBrush = Brushes.SlateBlue;
        }

        private void OnLogin(object sender, EventArgs args)
        {
            LoginBadge.Badge = null;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Uri.OriginalString)) return;
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
