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

            var byteCode =
                "608060405234801561001057600080fd5b5060008054600160a060020a03191633908117825581526001602052604090206005905560586002556101d7806100486000396000f3fe60806040526004361061005b577c010000000000000000000000000000000000000000000000000000000060003504636dcbf2a3811461006057806373d4a13a146100b25780638da5cb5b146100c7578063a5f8cdbb14610105575b600080fd5b34801561006c57600080fd5b506100a06004803603602081101561008357600080fd5b503573ffffffffffffffffffffffffffffffffffffffff16610147565b60408051918252519081900360200190f35b3480156100be57600080fd5b506100a0610159565b3480156100d357600080fd5b506100dc61015f565b6040805173ffffffffffffffffffffffffffffffffffffffff9092168252519081900360200190f35b34801561011157600080fd5b506101456004803603602081101561012857600080fd5b503573ffffffffffffffffffffffffffffffffffffffff1661017b565b005b60016020526000908152604090205481565b60025481565b60005473ffffffffffffffffffffffffffffffffffffffff1681565b73ffffffffffffffffffffffffffffffffffffffff1660009081526001602081905260409091208054909101905556fea165627a7a723058208db894f28ad60fdb2f411d190aa1c8b20193856166fcce9cc345665a4bb855d60029";

            //deploy
            var deployer = new SmartContractDeployer(web3);
            var contractAddress = await deployer.Deploy(byteCode);
            Console.WriteLine($"Contract address {contractAddress}");

            //test
            var controller = new SmartContractController(contractAddress, web3);

            Console.ReadLine();
        }
    }
}
