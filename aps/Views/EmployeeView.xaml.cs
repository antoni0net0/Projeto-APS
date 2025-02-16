using System.Windows;
using System.Windows.Controls;
using aps.ViewModel;

namespace aps.Views
{
    /// <summary>
    /// Interação lógica para EmployeeView.xam
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();

            if (Application.Current.MainWindow is AppWindow mainWindow &&
                            mainWindow.DataContext is MainViewModel mainVM)
            {
                this.DataContext = mainVM.EmployeeVM;
            }
        }

        private void Add_Employee(object sender, RoutedEventArgs e)
        {

            if (Application.Current.MainWindow is AppWindow mainWindow &&
                    mainWindow.DataContext is MainViewModel mainVM)
            {
                AddEmployee employeeAddWindow = new AddEmployee();
                employeeAddWindow.Owner = mainWindow;
                employeeAddWindow.ShowDialog();

            }
            else
            {
                MessageBox.Show("Erro ao carregar janela de funcionário");
            }
        }

        private void Remove_Employee(object sender, RoutedEventArgs e)
        {
            dynamic employee = listView.SelectedItem;

            if (employee == null)
            {
                MessageBox.Show("Por favor selecione um funcionário para remover");
                return;
            }

            if (Application.Current.MainWindow is AppWindow mainWindow &&
                mainWindow.DataContext is MainViewModel mainVM)
            {
                mainVM.EmployeeVM.RemoveEmployee(employee.Id);
            }
        }

        private void Create_User(object sender, RoutedEventArgs e)
        {
            dynamic employee = listView.SelectedItem;

            if (employee == null)
            {
                MessageBox.Show("Por favor selecione um funcionário para remover");
                return;
            }

            if (Application.Current.MainWindow is AppWindow mainWindow &&
                mainWindow.DataContext is MainViewModel mainVM)
            {
                mainVM.EmployeeVM.CreateUser(employee.Id);
            }
        }
    }
}
