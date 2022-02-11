using System;
using System.Linq;
using System.Collections.Generic;

namespace ExpensesTrackingApp
{
    public class ExpensesManager
    {
        private List<Expense> _expensesList = new List<Expense>();

        public void RegisterExpense(Expense expense)
        {
            _expensesList.Add(expense);
        }

        public List<Expense> FilterExpenses(Func<Expense, bool> predicate)
        {
            return _expensesList.Where(predicate).ToList();
        }

        public List<Expense> GetExpenses()
        {
            return _expensesList;
        }

    }
}
