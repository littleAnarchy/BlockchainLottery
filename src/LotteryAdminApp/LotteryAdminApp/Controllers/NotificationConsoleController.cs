using System;
using LotteryAdminApp.Common;

namespace LotteryAdminApp.Controllers
{
    public class NotificationConsoleController
    {
        private static NotificationConsoleController _instance;

        public event EventHandler ConsoleUpdated;

        private NotificationConsoleController()
        {
        }

        public static void Initialize()
        {
            _instance = new NotificationConsoleController();
        }

        public static NotificationConsoleController GetInstance()
        {
            if (_instance == null) Initialize();
            return _instance;
        }

        public void AppendInfoMessage(string message)
        {
            if (_instance == null) Initialize();

            var messageModel = new NotificationConsoleMessage
            {
                MessageText = message,
                MessageType = NotificationConsoleMessageType.InfoMessage
            };

            _instance?.ConsoleUpdated?.Invoke(messageModel, EventArgs.Empty);
        }

        public void AppendAllertMessage(string message)
        {
            if (_instance == null) Initialize();

            var messageModel = new NotificationConsoleMessage
            {
                MessageText = message,
                MessageType = NotificationConsoleMessageType.AlertMessage
            };

            _instance?.ConsoleUpdated?.Invoke(messageModel, EventArgs.Empty);
        }

        public void AppendErrorMessage(string message)
        {
            if (_instance == null) Initialize();

            var messageModel = new NotificationConsoleMessage
            {
                MessageText = message,
                MessageType = NotificationConsoleMessageType.ErrorMessage
            };

            _instance?.ConsoleUpdated?.Invoke(messageModel, EventArgs.Empty);
        }

        public void AppendUrlMessage(CustomUrlMessage message)
        {
            if (_instance == null) Initialize();

            var messageModel = new NotificationConsoleMessage
            {
                MessageText = message.MessageText,
                UrlMessage = message,
                MessageType = NotificationConsoleMessageType.UrlMessage
            };

            _instance?.ConsoleUpdated?.Invoke(messageModel, EventArgs.Empty);
        }
    }
}
