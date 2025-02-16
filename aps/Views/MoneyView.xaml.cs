using System.Windows;
using System.Windows.Controls;
using aps.ViewModel;


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

            if (Application.Current.MainWindow is AppWindow mainWindow &&
                mainWindow.DataContext is MainViewModel mainVM)
            {
                this.DataContext = mainVM.MoneyVM;
            }
        }

        private void Add_Transaction(object sender, RoutedEventArgs e)
        {

            if (Application.Current.MainWindow is AppWindow mainWindow &&
                    mainWindow.DataContext is MainViewModel mainVM)
            {
                AddTransaction transactionAddWindow = new AddTransaction();
                transactionAddWindow.Owner = mainWindow; 
                transactionAddWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Erro ao carregar janela de movimentação");
            }
        }

        private void Remove_Transaction(object sender, RoutedEventArgs e)
        {
            dynamic transaction = listView.SelectedItem;

            if (transaction == null)
            {
                MessageBox.Show("Por favor selecione uma movimentação para remover");
                return;
            }

            if (Application.Current.MainWindow is AppWindow mainWindow &&
                mainWindow.DataContext is MainViewModel mainVM)
            {
                mainVM.MoneyVM.RemoveTransaction(transaction.Id);
            }
        }
    }
}
