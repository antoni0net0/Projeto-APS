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

namespace aps.Views.UserControls
{
    /// <summary>
    /// Interação lógica para SidebarButton.xam
    /// </summary>
    public partial class SidebarButton : UserControl
    {
        public SidebarButton()
        {
            InitializeComponent();
        }

        private string button_content;

        public string Button_Content
        {
            get { return button_content; }
            set 
            {
                button_content = value;
                btnText.Content = value;
            }
        }

    }
}
