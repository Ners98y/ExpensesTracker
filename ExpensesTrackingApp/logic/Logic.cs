using System;

namespace ExpensesTrackingApp
{
    public class Logic
    {
        private ExpensesManager _expensesManager = new ExpensesManager();
        private ConsoleReader _consoleReader = new ConsoleReader();
        private FileOperations _fileOperations = new FileOperations();
        public void ControlLoop()
        {
            _expensesManager = ImportData();
            Option option;
            do
            {
                ConsolePrinter.DisplayOptions();
                option = _consoleReader.GetOption();
                switch (option)
                {
                    case Option.Exit:
                        ExportData();
                        break;
                    case Option.AddExpense:
                        AddExpense();
                        break;
                    case Option.DisplayExpenses:
                        DisplayExpensesMenu();
                        break;
                    
                }
            } while (option != Option.Exit);
        }

        private void DisplayExpensesMenu()
        {
            ConsolePrinter.DisplayDisplayingOptions();
            DisplayOption displayOption = _consoleReader.GetDisplayOption();
            switch (displayOption)
            {
                case DisplayOption.Exit:
                    break;
                case DisplayOption.DisplayAllExpenses:
                    DisplayAllExpenses();
                    break;
                case DisplayOption.DisplayCurrentMonthExpenses:
                    DisplayCurrentMonthExpenses();
                    break;
                case DisplayOption.DisplayCurrentDayExpenses:
                    DisplayCurrentDayExpenses();
                    break;
                case DisplayOption.DisplayTypedExpenses:
                    DisplayTypeExpense();
                    break;
                case DisplayOption.DisplayPrevoiusMonthExpenses:
                    DisplayPreviousExpenses();
                    break;
            }
        }

        private void AddExpense()
        {
            Expense expense = _consoleReader.CreateExpenseFromInput();
            _expensesManager.RegisterExpense(expense);
        }

        private void DisplayAllExpenses()
        {
            try
            {
                var expenses = _expensesManager.GetExpenses();
                ConsolePrinter.DisplayExpenses(expenses);
            }
            catch (Exception e)
            {
                ConsolePrinter.Display(e.Message);
            }
        }

        private void DisplayCurrentMonthExpenses()
        {
            try
            {
                var currentMonth = DateTime.UtcNow.Month;
                var currentMonthExpenses = _expensesManager.FilterExpenses(e => e.DateOfExpense.Month == currentMonth);
                ConsolePrinter.DisplayExpenses(currentMonthExpenses);
            }
            catch (Exception e)
            {
                ConsolePrinter.Display(e.Message);
            }
        }

        private void DisplayCurrentDayExpenses()
        {
            try
            {
                var currentDay = DateTime.Now;
                var currentDayExpenses = _expensesManager.FilterExpenses(e => e.DateOfExpense.ToString("d") == currentDay.ToString("d"));
                ConsolePrinter.DisplayExpenses(currentDayExpenses);
            }
            catch (Exception e)
            {
                ConsolePrinter.Display(e.Message);
            }
        }

        private void DisplayTypeExpense()
        {
            try
            {
                ConsolePrinter.DisplayTypesOfExpenses();
                var type = _consoleReader.GetTypeOfExpense();
                var typedExpenses = _expensesManager.FilterExpenses(e => e.TypeOfExpense == type);
                ConsolePrinter.DisplayExpenses(typedExpenses);
            }catch(Exception e)
            {
                ConsolePrinter.Display(e.Message);
            }
        }

        private void DisplayPreviousExpenses()
        {
            _fileOperations.DislayFiles();
            ConsolePrinter.Display("Podaj rok:");
            int year = _consoleReader.GetIntValue();
            ConsolePrinter.Display("Podaj miesiąc:");
            int month = _consoleReader.GetIntValue(); ;
            var previousExpenses = _fileOperations.GetPreviousExpenses(month, year);

            ConsolePrinter.DisplayExpenses(previousExpenses);
        }

        private ExpensesManager ImportData()
        {
            return _fileOperations.ImportData();
        }

        private void ExportData()
        {
            try
            {
                _fileOperations.ExportExpensesData(_expensesManager);
            }
            catch (Exception e)
            {
                ConsolePrinter.DisplayException(e.Message);
            }
        }
    }
}
