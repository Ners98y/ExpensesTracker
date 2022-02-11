using System;

namespace ExpensesTrackingApp
{
    public class ConsoleReader
    {
        public Expense CreateExpenseFromInput()
        {
            ConsolePrinter.Display("Podaj nazwę wydatku");
            string name = Console.ReadLine();
            ConsolePrinter.Display("Podaj wartość wydatku");
            double value = GetDoubleValue();
            ConsolePrinter.DisplayTypesOfExpenses();
            Type type = GetTypeOfExpense();
            return new Expense(name, value, type);
        }

        public int GetIntValue()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if(int.TryParse(input, out int output))
                {
                    return output;
                }
                ConsolePrinter.DisplayException("sprawdź format danych");
            }
        }

        public DisplayOption GetDisplayOption()
        {

            int length = Enum.GetValues(typeof(DisplayOption)).Length - 1;

            while (true)
            {
                int input = GetIntValue();
                if (!(input < 0 || input > length))
                {
                    return (DisplayOption)(input);
                }

                ConsolePrinter.DisplayException("Nie ma takiej wartości");
            }
        }

        public Option GetOption()
        {
            int length = Enum.GetValues(typeof(Option)).Length - 1;
            while (true)
            {
                int input = GetIntValue();
                if (!(input < 0 || input > length))
                {
                    return (Option)(input);
                }

                ConsolePrinter.DisplayException("Nie ma takiej wartości");
            }
        }

        public Type GetTypeOfExpense()
        {
            int length = Enum.GetValues(typeof(Type)).Length;
            while (true)
            {
                int input = GetIntValue();
                if (!(input < 0 || input > length))
                {
                    return (Type)(input);
                }

                ConsolePrinter.DisplayException("Nie ma takiej wartości");
            }
        }

        private double GetDoubleValue()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (double.TryParse(input, out double output))
                {
                    return output;
                }
                ConsolePrinter.DisplayException("sprawdź format danych");
            }
        }
    }
}
