using System.Numerics;

namespace LoteryLogic.Models
{
    public class TransactionParamentrsModel
    {
        public BigInteger Gas { get; set; }
        public BigInteger GasPrice { get; set; }
        public BigInteger AmountToSend { get; set; }
    }
}
