using System;
using System.Collections.Generic;

namespace CurrencyConvertation_1_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;

            string stopWord = "exit";

            int userId = 0;
            User user = new User(userId);

            int usdBalance = 1500;
            int rubBalance = 60_000;
            int eurBalance = 7000;

            Wallet rubWallet = new Wallet(rubBalance, Currency.RUB);
            Wallet usdWallet = new Wallet(usdBalance, Currency.USD);
            Wallet eurWallet = new Wallet(eurBalance, Currency.EUR);

            user.AddWallet(rubWallet);
            user.AddWallet(usdWallet);
            user.AddWallet(eurWallet);

            Console.WriteLine("Здравствуйте, ваш баланс во всех валютах:");
            Console.WriteLine($"Рубли: {rubBalance}" +
                $"\nДоллары: {usdBalance}" +
                $"\nЕвро: {eurBalance}");

            Console.WriteLine($"Чтобы выйти напишите \"{stopWord}\"");

            while (isWorking)
            {
                Console.WriteLine($"Введите баланс, с которого хотите списать\n" +
                    $"{(int)Currency.RUB} - {Currency.RUB}\n" +
                    $"{(int)Currency.EUR} - {Currency.EUR}\n" +
                    $"{(int)Currency.USD} - {Currency.USD}");

                if(Console.ReadLine() == stopWord)
                {
                    isWorking = false;
                    break;
                }

                Currency currencyForDecreasing = (Currency)int.Parse(Console.ReadLine());

                Console.WriteLine($"Введите баланс, который хотите пополнить\n" +
                    $"{(int)Currency.RUB} - {Currency.RUB}\n" +
                    $"{(int)Currency.EUR} - {Currency.EUR}\n" +
                    $"{(int)Currency.USD} - {Currency.USD}");

                if (Console.ReadLine() == stopWord)
                {
                    isWorking = false;
                    break;
                }

                Currency currencyForIncreasing = (Currency)int.Parse(Console.ReadLine());

                Console.WriteLine("Введите сумму, которые хотите списать");

                if (Console.ReadLine() == stopWord)
                {
                    isWorking = false;
                    break;
                }
    
                int amount = int.Parse(Console.ReadLine());

                user.TransferToWallet(currencyForDecreasing, currencyForIncreasing, amount);

                user.DisplayWalletsStatus();
            }
        }
    }

    public class User
    {
        private int _id;
        private Dictionary<Currency, Wallet> _wallets =
            new Dictionary<Currency, Wallet>();

        public User(int id)
        {
            _id = id;
        }

        public void AddWallet(Wallet wallet)
        {
            _wallets[wallet.Currency] = wallet;
        }

        public void TransferToWallet(Currency currencyForSubstract, Currency currencyForIncresing, float amount)
        {
            Console.WriteLine($"substract: {currencyForSubstract}\nincreasing: {currencyForIncresing}");

            float convertedAmount = CurrencyConverter.GetConvertedAmount(currencyForSubstract, 
                currencyForIncresing, amount);

            _wallets[currencyForSubstract].SubstractMoney(amount);
            _wallets[currencyForIncresing].AddMoney(convertedAmount);
        }

        public void DisplayWalletsStatus()
        {
            Console.WriteLine("Ваш баланс:");

            foreach (Currency currency in _wallets.Keys)
            {              
                Console.WriteLine($"{currency} - {_wallets[currency].MoneyAmount}");         
            }
        }
    }

    public class Wallet
    {
        public Wallet(float moneyAmount, Currency currcency)
        {
            MoneyAmount = moneyAmount;
            Currency = currcency;
        }

        public Currency Currency { get; private set; }
        public float MoneyAmount { get; private set; }

        public void AddMoney(float amount)
        {
            MoneyAmount += amount;
        }

        public void SubstractMoney(float amount)
        {
            if (MoneyAmount < 0)
            {
                Console.WriteLine("НЕДОСТАТОЧНО СРЕДСТВ");
                return;
            }

            MoneyAmount -= amount;
        }
    }

    public static class CurrencyConverter
    {
        private static Dictionary<Currency, float> s_usdCoefficients = 
            new Dictionary<Currency, float>
        {
            { Currency.RUB, 0.01219f },
            { Currency.EUR, 1.08536f },
            { Currency.USD, 1f },
        };

        private static Dictionary<Currency, float> s_rubCoefficients = 
            new Dictionary<Currency, float>
        {
            { Currency.RUB, 1f },
            { Currency.EUR, 86f },
            { Currency.USD, 82f },
        };

        private static Dictionary<Currency, float> s_eurCoefficients = 
            new Dictionary<Currency, float>
        {
            { Currency.RUB, 0.0112f },
            { Currency.EUR, 1f },
            { Currency.USD, 0.95348f },
        };

        private static Dictionary<Currency, Dictionary<Currency, float>> s_coefficients = 
            new Dictionary<Currency, Dictionary<Currency, float>>()
        {
            [Currency.RUB] = s_rubCoefficients,
            [Currency.USD] = s_usdCoefficients,
            [Currency.EUR] = s_eurCoefficients,
        };

        public static void AddCurrencyCoefficients(Currency currency, 
            Dictionary<Currency, float> coefficientsToCurrencies)
        {
            s_coefficients[currency] = coefficientsToCurrencies;
        }

        public static float GetConvertedAmount(Currency currencyForSubstract, 
            Currency currencyForIncresing, float amount)
        {
            Console.WriteLine($"substract: {currencyForSubstract}\nincreasing: {currencyForIncresing}");
            return amount * s_coefficients[currencyForIncresing][currencyForSubstract];
        }
    }

    public enum Currency
    {
        RUB,
        EUR,
        USD,
    }
}
