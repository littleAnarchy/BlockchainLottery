using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

namespace LoteryLogic
{
    public class StandardLoteryDeployment : ContractDeploymentMessage
    {
        public StandardLoteryDeployment(string byteCode) : base(byteCode)
        {
        }

        public StandardLoteryDeployment() : base("")
        {
        }

        [Parameter("uint256", "_loteryEnd")]
        public BigInteger LoteryEnd { get; set; }

        [Parameter("uint256", "_tokenPrice")]
        public BigInteger TokenPrice { get; set; }

        [Parameter("uint256", "_commision")]
        public BigInteger Comission { get; set; }
    }
}
