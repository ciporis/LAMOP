using System;
using System.Collections.Generic;

namespace CurrenciesConvertation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;

            string stopWord = "exit";

            UserWallet userWallet = new UserWallet(8000, 1232, 7234348);

            Console.WriteLine("Здравствуйте, ваш баланс во всех валютах:");
            Console.WriteLine($"Рубли: {userWallet.GetBalanceCount("rub")}" +
                $"\nДоллары: {userWallet.GetBalanceCount("usd")}" +
                $"\nЕвро: {userWallet.GetBalanceCount("eur")}");

            Console.WriteLine("Чтобы выйти напишите \"exit\"");

            while (isWorking)
            {
                Console.WriteLine("Введите баланс, с которого хотите списать (usd, rub, eur):");
                string decreasingBalance = Console.ReadLine();
                if (decreasingBalance == stopWord) { return; }

                Console.WriteLine("Введит баланс, который хотите пополнить (usd, rub, eur):");
                string increasingBalance = Console.ReadLine();
                if (increasingBalance == stopWord) { return; }

                Console.WriteLine("Введите сумму, которую хотитет конвертировать:");
                float amount = float.Parse(Console.ReadLine());

                userWallet.ConvertBalances(decreasingBalance, increasingBalance, amount);

                Console.WriteLine("Ваш баланс во всех валютах:");
                Console.WriteLine($"Рубли: {string.Format("{0:0.00}", userWallet.GetBalanceCount("rub"))}" +
                    $"\nДоллары: {string.Format("{0:0.00}", userWallet.GetBalanceCount("usd"))}" +
                    $"\nЕвро: {string.Format("{0:0.00}", userWallet.GetBalanceCount("eur"))}");
            }
        }
    }

    public class UserWallet //
    {
        private Dictionary<string, Dictionary<string, double>> _balances = new Dictionary<string, Dictionary<string, double>>
        {
            ["rub"] = new Dictionary<string, double>
            {
                ["usd"] = 86,
                ["eur"] = 90,
                ["amount"] = 0
            },
            ["usd"] = new Dictionary<string, double>
            {
                ["rub"] = 0.0116, //
                ["eur"] = 1.04,
                ["amount"] = 0
            },
            ["eur"] = new Dictionary<string, double>
            {
                ["rub"] = 0.0111,
                ["usd"] = 0.96,
                ["amount"] = 0
            }
        };

        public UserWallet(double rubblesBalance, double dollarsBalance, double eurosBalance)
        {
            _balances["rub"]["amount"] = rubblesBalance;//
            _balances["usd"]["amount"] = dollarsBalance;
            _balances["eur"]["amount"] = eurosBalance;
        }

        public double GetBalanceCount(string balanceName)
        {
            return _balances[balanceName]["amount"];
        }

        public void ConvertBalances(string decreasingBalance, string increasingBalance, double amount)
        {
            _balances[decreasingBalance]["amount"] -= amount;
            double newAmount = amount * _balances[increasingBalance][decreasingBalance];
            _balances[increasingBalance]["amount"] += newAmount;
        }
    }
}
