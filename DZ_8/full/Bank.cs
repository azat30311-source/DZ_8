
using System.Collections;

namespace DZ_8
{
    public class BankAccount : IDisposable
    {
        private static int count = 0;

        private readonly int _accountNumber;
        private decimal _balance;
        private Queue _transactions;

        public AccountType AccountTypeProperty { get; set; }

        public BankAccount()
        {
            _accountNumber = GenerateAccountID();
            _balance = 0;
            AccountTypeProperty = AccountType.Current;
            _transactions = new Queue();
        }

        public BankAccount(decimal balance)
        {
            _accountNumber = GenerateAccountID();
            Balance = balance;
            AccountTypeProperty = AccountType.Current;
            _transactions = new Queue();
            if (balance > 0)
            {
                _transactions.Enqueue(new BankTransaction(balance));
            }
        }

        public BankAccount(AccountType accountType)
        {
            _accountNumber = GenerateAccountID();
            _balance = 0;
            AccountTypeProperty = accountType;
            _transactions = new Queue();
        }

        public BankAccount(decimal balance, AccountType accountType)
        {
            _accountNumber = GenerateAccountID();
            Balance = balance;
            AccountTypeProperty = accountType;
            _transactions = new Queue();
            if (balance > 0)
            {
                _transactions.Enqueue(new BankTransaction(balance));
            }
        }

        private static int GenerateAccountID()
        {
            count++;
            return count;
        }

        public int AccountNumber => _accountNumber;

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Баланс счета не может быть отрицательным!");
                }
                _balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Пополняемая сумма должна быть положительна!");
            }
            _balance += amount;
            _transactions.Enqueue(new BankTransaction(amount));
        }

        public void Withdraw(decimal amount)
        {
            if (_balance < amount)
            {
                throw new ArgumentException("Недостаточно средств!");
            }
            _balance -= amount;
            _transactions.Enqueue(new BankTransaction(-amount));
        }

        public void Dispose()
        {
            string fileName = $"transactions_account_{_accountNumber}.txt";

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.WriteLine($"История транзакций по счету №{_accountNumber}:");
                foreach (BankTransaction transaction in _transactions)
                {
                    string type = transaction.Amount >= 0 ? "Пополнение" : "Снятие";
                    writer.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {Math.Abs(transaction.Amount)} руб. ({type})");
                }
            }

            GC.SuppressFinalize(this);
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {_accountNumber}");
            Console.WriteLine($"Баланс счета: {_balance} руб.");
            Console.WriteLine($"Тип счета: {AccountTypeProperty}");
            Console.WriteLine();
        }
    }
}