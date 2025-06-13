using System;

namespace Library_5_4
{
    internal class CommandsService
    {
        public string CheckIfInputIsDate(string input)
        {
            bool isDate = false;

            isDate = IsDate(input);

            while(isDate == false)
            {
                Console.WriteLine("Input date please");
                isDate = IsDate(Console.ReadLine());
            }

            return input;
        }

        private bool IsDate(string input)
        {
            int minYear = 1500;
            int maxYear = DateTime.Now.Year;

            if (int.TryParse(input, out int date) == true)
            {
                if (date >= minYear && date <= maxYear)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public string CheckIfNumberIsCorrect(int minNumber, 
            int maxNumber, string value)
        {
            bool isCommandNumber = IsCorrectCommandNumber(minNumber,
                maxNumber, value);

            while(isCommandNumber == false)
            {
                Console.WriteLine("Try again");
                isCommandNumber = IsCorrectCommandNumber(minNumber, 
                    maxNumber, Console.ReadLine());
            }

            return value;
        }

        private bool IsCorrectCommandNumber(int min, int max, string value)
        {
            bool canParseInput = int.TryParse(value, out int result);

            if (canParseInput == false)
                return false;

            return (min <= result && result <= max);
        }
    }
}
