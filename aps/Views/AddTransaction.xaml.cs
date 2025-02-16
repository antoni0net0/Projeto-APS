using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using aps.ViewModel;
using aps_project;

namespace aps.Views
{
    /// <summary>
    /// Lógica interna para AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
        public AddTransaction()
        {
            InitializeComponent();
        }

        private void Add_Transaction(object sender, RoutedEventArgs e)
        {
            string desc = txtDesc.Text;
            string date = txtDate.Text;
            string value = txtValue.Text;
            string type = ((ComboBoxItem)cboType.SelectedItem).Content.ToString();
            string status = ((ComboBoxItem)cboStatus.SelectedItem).Content.ToString();

            if (string.IsNullOrWhiteSpace(desc) ||
                string.IsNullOrWhiteSpace(date) ||
                string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(value) ||
                string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedValue))
            {
                MessageBox.Show("Valor inválido. Insira um número válido (use ponto como separador decimal).");
                return;
            }

            Transaction transaction = new Transaction(desc, date, type, parsedValue, status, AppWindow.LoggedCompany.Id, null);
            int transactionId = App.DbService.AddTransaction(transaction);
            if (transactionId >= 0)
            {
                transaction.Id = transactionId;

                // Retrieve the MainViewModel from the MainWindow's DataContext
                if (Application.Current.MainWindow is AppWindow mainWindow &&
                    mainWindow.DataContext is MainViewModel mainVM)
                {
                    // Add the new transaction to the ObservableCollection in MoneyViewModel
                    mainVM.MoneyVM.AddTransaction(transaction);

                    this.Close();
                }
                return;
            }
            else
            {
                MessageBox.Show("Erro em adicionar nova movimentaçao");
                return;
            }
        }

        private void Cancel_Transaction(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
