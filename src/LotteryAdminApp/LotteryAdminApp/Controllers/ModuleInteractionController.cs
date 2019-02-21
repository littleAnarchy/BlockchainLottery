using System;

namespace LotteryAdminApp.Controllers
{
    public class ModuleInteractionController
    {
        public static event EventHandler ContractDeployed;

        public static void RaiseContractDeployed(string contractAddress)
        {
            ContractDeployed?.Invoke(contractAddress, null);
        }
    }
}
