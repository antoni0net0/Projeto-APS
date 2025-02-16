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
using System.Windows.Shapes;

namespace aps.Views
{
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message, string title)
        {
            InitializeComponent();
            Title = title;
            MessageText.Text = message;

            // Enable Ctrl+C to copy
            MessageText.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
                {
                    Clipboard.SetText(MessageText.Text);
                    e.Handled = true;
                }
            };
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Static method to show the dialog
        public static void Show(string message, string title = "Message")
        {
            var dialog = new CustomMessageBox(message, title);
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowDialog();
        }
    }
}
