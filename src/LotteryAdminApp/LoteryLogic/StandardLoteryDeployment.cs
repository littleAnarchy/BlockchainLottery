using Nethereum.Contracts;

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
    }
}
