using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using aps_project;

namespace aps.Views
{
    /// <summary>
    /// Interação lógica para MoneyView.xam
    /// </summary>
    public partial class MoneyView : UserControl
    {
        public MoneyView()
        {
            InitializeComponent();

            var transactions = new List<Transaction>()
            {
                new(0, "Compra ferramentas", "21/1/2025", "Despesa", 1900.50, "Pendente"),
                new(1, "Recebeu cliente", "24/1/2025", "Receita", 1300, "Concluído"),
                new(2, "Dogao", "01/2/2025", "Despesa", 100, "Cancelado"),
            };

            listView.ItemsSource = transactions;
        }
    }
}
