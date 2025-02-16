using System.Configuration;
using System.Data;
using System.Windows;
using aps.src;
using aps_project;

namespace aps
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DatabaseService DbService { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DbService = new DatabaseService();
        }
    }

}
