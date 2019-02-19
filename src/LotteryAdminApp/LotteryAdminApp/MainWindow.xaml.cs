using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using LotteryAdminApp.ViewModels;
using Xceed.Wpf.AvalonDock.Layout;

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
            Background = new SolidColorBrush(Color.FromRgb(18, 37, 81));
            WindowTitleBrush = Brushes.SlateBlue;
        }
    }
}
