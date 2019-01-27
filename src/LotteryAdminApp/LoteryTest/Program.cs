using System;
using System.Threading.Tasks;
using LoteryLogic;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace LoteryTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        public static async Task MainAsync()
        {
            //create web3 account manager
            var url = "https://ropsten.infura.io";
            var privateKey = "0x7EE36F0D1F92F30637EE3688241917EF3B8A474DB0BCA064FDC3667D392A1A5A";

            var account = new Account(privateKey);
            var web3 = new Web3(account, url);

            //deploy
            var deployer = new SmartContractDeployer(web3);
            var contractAddress = await deployer.Deploy();
            Console.WriteLine(contractAddress);

            //test
            var controller = new SmartContractController(contractAddress, web3);
            Console.WriteLine($"X: {await controller.GetData()}");
            await controller.SetData(5);
            Console.WriteLine($"X: {await controller.GetData()}");

            Console.ReadLine();
        }
    }
}
