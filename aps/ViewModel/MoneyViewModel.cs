using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aps.src;
using aps_project;

namespace aps.ViewModel
{
    public class MoneyViewModel : ObservableObject
    {
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        public MoneyViewModel(int companyId)
        {
            LoadTransactions(companyId);
        }

        public void LoadTransactions(int companyId)
        {
            // Fetch transactions from the database
            var loadedTransactions = App.DbService.GetTransactions(companyId);
            Transactions.Clear();
            foreach (var transaction in loadedTransactions)
            {
                Transactions.Add(transaction);
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void RemoveTransaction(int transactionId)
        {
            App.DbService.RemoveTransaction(transactionId);
            var transaction = Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction != null)
            {
                Transactions.Remove(transaction);
            }
        }
    }
}
