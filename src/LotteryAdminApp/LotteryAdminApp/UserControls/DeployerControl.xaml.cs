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
            NotificationConsoleController.GetInstance().ConsoleUpdated += UpdateNotificationControl;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Uri.OriginalString)) return;
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void UpdateNotificationControl(object sender, EventArgs args)
        {
            var message = (NotificationConsoleMessage) sender;

            Dispatcher.Invoke(() =>
            {
                switch (message.MessageType)
                {
                    case NotificationConsoleMessageType.InfoMessage:
                        NotificationConsole.Children.Add(new TextBlock { Text = message.MessageText, Foreground = Brushes.AliceBlue });
                        break;
                    case NotificationConsoleMessageType.ErrorMessage:
                        NotificationConsole.Children.Add(new TextBlock
                        { 
                            Text = message.MessageText,
                            Foreground = Brushes.Red
                        });
                        break;
                    case NotificationConsoleMessageType.UrlMessage:
                        var hyperlink = new Hyperlink
                        {
                            Foreground = Foreground = Brushes.DodgerBlue,
                            Inlines = {message.UrlMessage.AdditionalMessageText},
                            NavigateUri = new Uri(message.UrlMessage.AdditionalMessageUrl)
                        };
                        hyperlink.RequestNavigate += Hyperlink_RequestNavigate;

                        NotificationConsole.Children.Add(new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Children =
                            {
                                new TextBlock {Text = message.UrlMessage.MessageText, Foreground = Brushes.AliceBlue},
                                new TextBlock
                                {
                                    Foreground = Brushes.DodgerBlue,
                                    Inlines =
                                    {
                                        hyperlink,
                                    }
                                }
                            }
                        });
                        break;
                    case NotificationConsoleMessageType.AlertMessage:
                        NotificationConsole.Children.Add(new TextBlock
                        {
                            Text = message.MessageText,
                            Foreground = Brushes.Orange,
                            FontWeight = FontWeights.Bold
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }
    }
}
