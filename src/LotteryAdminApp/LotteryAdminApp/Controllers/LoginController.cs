using Nethereum.Web3;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace LotteryAdminApp.Controllers
{
    public class LoginController : ReactiveObject
    {
        public static bool IsLogin { get; private set; }
        [Reactive]
        public static Web3 Web3 { get; set; }
        [Reactive]
        public static string PrivateKey { get; set; }
        [Reactive]
        public static string NodeUrl { get; set; }
    }
}
