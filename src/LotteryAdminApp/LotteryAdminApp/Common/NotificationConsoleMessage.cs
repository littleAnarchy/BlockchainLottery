namespace LotteryAdminApp.Common
{
    public class NotificationConsoleMessage
    {
        public NotificationConsoleMessageType MessageType { get; set; }
        public string MessageText { get; set; }
        public CustomUrlMessage UrlMessage { get; set; }
    }
}
