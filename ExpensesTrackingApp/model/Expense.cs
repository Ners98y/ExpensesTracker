using System;

namespace ExpensesTrackingApp
{
    public class Expense
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime DateOfExpense { get; set; }
        public Type TypeOfExpense { get; set; }

        public Expense(string name, double value, Type typeOfExpense)
        {
            Name = name;
            Value = value;
            DateOfExpense = DateTime.UtcNow;
            TypeOfExpense = typeOfExpense;
        }

        public Expense(string name, double value, DateTime dateOfExpense, Type typeOfExpense)
        {
            Name = name;
            Value = value;
            DateOfExpense = dateOfExpense;
            TypeOfExpense = typeOfExpense;
        }

        public override string ToString()
        {
            return $"{DateOfExpense.ToString("d")} {Name} {Value} {TypeOfExpense}";
        }

        public string ToExportFormat()
        {
            return $"{DateOfExpense.ToString("d")}/{Name}/{Value}/{TypeOfExpense}";
        }
    }
}
