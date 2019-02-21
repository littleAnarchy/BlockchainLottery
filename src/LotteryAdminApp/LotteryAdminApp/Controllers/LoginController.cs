using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace LotteryAdminApp.Controllers
{
    public class LoginController
    {
        private static readonly object Locker = new object();

        public static bool IsLogin { get; private set; }
        public static Web3 Web3 { get; private set; }
        public static string PrivateKey { get; private set; }
        public static string NodeUrl { get; private set; } = "https://ropsten.infura.io";

        public static void SetPrivateKey(string privateKey)
        {
            lock (Locker)
            {
                if (!Web3.IsChecksumAddress(Web3.GetAddressFromPrivateKey(privateKey)))
                    throw new Exception("Private key is not valid");
                PrivateKey = privateKey;
                var account = new Account(PrivateKey);
                Web3 = new Web3(account, NodeUrl);
                IsLogin = true;
            }
        }
    }
}
