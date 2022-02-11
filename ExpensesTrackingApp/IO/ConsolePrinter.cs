using System;
using System.Collections.Generic;

namespace ExpensesTrackingApp
{
    public static class ConsolePrinter
    {
        public static void Display<T>(T t)
        {
            Console.WriteLine(t);
        }

        public static void DisplayException(string text)
        {
            //
            Console.ForegroundColor = ConsoleColor.Red;
            Display(text);
            Console.ResetColor();
        }

        public static void DisplayTypesOfExpenses()
        {
            Console.WriteLine("Podaj typ wydatku:");
            Console.WriteLine("1 - jedzenie");
            Console.WriteLine("2 - środki czystości");
            Console.WriteLine("3 - kosmetyki");
            Console.WriteLine("4 - transport");
            Console.WriteLine("5 - rachunki");
            Console.WriteLine("6 - kredyty");
            Console.WriteLine("7 - inwestycje");
            Console.WriteLine("8 - rozrywka");
            Console.WriteLine("9 - inne");
        }

        public static void DisplayOptions()
        {
            Console.WriteLine("Wyjście - 0");
            Console.WriteLine("Dodaj wydatek - 1");
            Console.WriteLine("Wyświetl wydatki - 2");
        }

        public static void DisplayDisplayingOptions()
        {
            Console.WriteLine("Wyjście - 0");
            Console.WriteLine("Wyświetl wszystkie wydatki - 1");
            Console.WriteLine("Wyświetl wydatki z tego miesiąca - 2");
            Console.WriteLine("Wyświetl wydatki z dzisiaj - 3");
            Console.WriteLine("Wyświetl wydatki określonego typu - 4");
            Console.WriteLine("Wyświetl wydatki z poprzednich miesięcy - 5");
        }

        public static void DisplayExpenses(List<Expense> expenses)
        {
            if (expenses.Count == 0)
            {
                throw new Exception("Nie zarejestrowano takich wydatków");
            }
            expenses.ForEach(e => Display(e));
        }
    }
}
