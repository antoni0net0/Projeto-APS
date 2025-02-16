using System.Windows;
using aps.ViewModel;
using aps_project;

namespace aps.Views
{
    /// <summary>
    /// Lógica interna para AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public static Company LoggedCompany { get; set; } = null!;

        public AppWindow(Company comp)
        {
            InitializeComponent();
            LoggedCompany = comp;
            lblLoggedCompany.Text = LoggedCompany.Name;
            this.DataContext = new MainViewModel();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current is App app)
            {
                app.Restart();
            }
        }
    }
}
