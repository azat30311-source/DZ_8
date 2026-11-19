
namespace DZ_8
{
    class Program
    {
        static void Main(string[] args)
        {
            task1();
            task2();
        }

        static void task1()
        {
            Console.WriteLine("\t Упражнение 9.1 - 9.3 \t\n");

            try
            {
                Console.Write("Введите количество денег на счете: ");
                decimal balance = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Выберите тип счета.");
                Console.WriteLine("Текущий (Current)");
                Console.WriteLine("Сберегательный (Savings)");
                Console.Write("Введите тип счета: ");
                AccountType accountType = Console.ReadLine().Trim().ToLower() switch
                {
                    "current" => AccountType.Current,
                    "savings" => AccountType.Savings,
                    _ => throw new ArgumentException("Неверно введен тип счёта")
                };

                using (BankAccount myAccount = new BankAccount(balance, accountType))
                {
                    Console.WriteLine("\n--- Информация о созданном счете ---");
                    myAccount.PrintAccountInfo();

                    Console.Write("Введите сумму для пополнения: ");
                    decimal depositAmount = decimal.Parse(Console.ReadLine());

                    myAccount.Deposit(depositAmount);
                    Console.WriteLine("Счет успешно пополнен!");
                    myAccount.PrintAccountInfo();

                    Console.Write("Введите сумму для снятия: ");
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                    myAccount.Withdraw(withdrawAmount);
                    Console.WriteLine("Средства успешно списаны!");
                    myAccount.PrintAccountInfo();

                    Console.WriteLine("\nСейчас метод завершится, сработает Dispose() и запишется файл с транзакциями...");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n Нужно было ввести число, а не текст!");
            }
        }
        static void task2()
        {
            Console.WriteLine("\t Домашняя работа 9.1 \t\n");
            Song song1 = new Song("Imagine", "John Lennon");
            Song song2 = new Song("Bohemian Rhapsody", "Queen", song1);
            Song song3 = new Song("Надежда", "GONE.Fludd", song2);
            song1.PrintSongInfo();
            song2.PrintSongInfo();
            song3.PrintSongInfo();
            Console.WriteLine($"\nСравнение песен: {song1.Title()} и {song2.Title()}");
            Console.WriteLine($"Результат сравнения: {song1.Equals(song2)}");
        }
    }
}
