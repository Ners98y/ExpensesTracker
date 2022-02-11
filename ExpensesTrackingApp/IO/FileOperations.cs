using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ExpensesTrackingApp
{
    public class FileOperations
    {
        public void ExportExpensesData(ExpensesManager expensesManager)
        {
            var path = GenerateFileName();
            var expenses = expensesManager.GetExpenses();
            using StreamWriter streamWriter = new StreamWriter(path);
            expenses.ForEach(e => streamWriter.WriteLine(e.ToExportFormat()));
        }

        public ExpensesManager ImportData()
        {
            var expensesManager = new ExpensesManager();
            string path = @"C:/wydatki/wydatki2_2022.txt";
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Expense expense = CreateExpenseFromLine(line);
                    expensesManager.RegisterExpense(expense);

                }
            }
            return expensesManager;
        }

        public List<Expense> GetPreviousExpenses(int month, int year)
        {
            List<Expense> expensesList = new List<Expense>();
            string fileName = FindFileName(month, year);
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Expense expense = CreateExpenseFromLine(line);
                    expensesList.Add(expense);
                }
            }

            return expensesList;
        }

        public void DislayFiles()
        {
            ConsolePrinter.Display("Poprzednie zestawienia:");
            var fileList = Directory.GetFiles(@"C:/wydatki");
            foreach (string fileName in fileList)
            {
                ConsolePrinter.Display(fileName);
            }
        }

        private string FindFileName(int month, int year)
        {
            return $@"C:/wydatki/wydatki{month}_{year}.txt";
        }

        private string GenerateFileName()
        {
            var monthNumber = DateTime.UtcNow.Month;
            var yearNumber = DateTime.UtcNow.Year;

            return $@"C:/wydatki/wydatki{monthNumber}_{yearNumber}.txt";
        }

        private Expense CreateExpenseFromLine(string line)
        {
            var expenseData = line.Split("/");
            DateTime dateOfExpense = DateTime.Parse(expenseData[0]);
            string name = expenseData[1];
            double value = double.Parse(expenseData[2]);
            Type typeOfExpenses = Enum.Parse<Type>(expenseData[3]);

            return new Expense(name, value, dateOfExpense, typeOfExpenses);
        }
    }

    public class SerializeOperations
    {
        public void ExportSerializedData(ExpensesManager expensesManager)
        {
            var fileName = GenerateFileName();
            var serializedData = SerializeData(expensesManager);
            File.WriteAllText(fileName, serializedData);
        }

        public ExpensesManager ImportSerializedData()
        {
            string deserializedText = DeserializeData();
            var deserializedData = JsonConvert.DeserializeObject<ExpensesManager>(deserializedText);

            return deserializedData;
        }

        private string SerializeData(ExpensesManager expensesManager)
        {
            var serializedText = JsonConvert.SerializeObject(expensesManager);
            return serializedText;
        }

        private string DeserializeData()
        {
            var fileName = GenerateFileName(); //---> znajdź plik, który chcesz zdeserializować
            var content = File.ReadAllText(fileName);
            return content;
        }

        private string FindFileName(int month, int year)
            => $@"C:/zapis/zapis{month}_{year}.json";

        private string GenerateFileName()
        {
            var monthNumber = DateTime.UtcNow.Month;
            var yearNumber = DateTime.UtcNow.Year;

            return $@"C:/zapis/zapis{monthNumber}_{yearNumber}.txt";
        }
    }
}
