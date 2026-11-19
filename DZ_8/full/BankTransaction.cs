
namespace DZ_8
{
    public class BankTransaction
    {
        private readonly DateTime _transactionDate;
        private readonly decimal _amount;

        public BankTransaction(decimal amount)
        {
            _transactionDate = DateTime.Now;
            _amount = amount;
        }

        public DateTime TransactionDate => _transactionDate;
        public decimal Amount => _amount;
    }
}
