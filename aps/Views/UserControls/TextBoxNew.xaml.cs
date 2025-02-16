using System;
using System.Windows;
using System.Windows.Controls;

namespace aps.Views.UserControls
{
    /// <summary>
    /// Interação lógica para TextBoxNew.xaml
    /// </summary>
    public partial class TextBoxNew : UserControl
    {
        public TextBoxNew()
        {
            InitializeComponent();
        }

        private string placeholder = string.Empty;
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                tbPlaceholder.Text = placeholder;
            }
        }

        // DependencyProperty para a propriedade Text.
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(TextBoxNew),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        // Callback chamado quando a propriedade Text é alterada.
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBoxNew control)
            {
                string novoTexto = e.NewValue as string;
                // Se o texto interno não estiver sincronizado, atualiza-o.
                if (control.txtInput.Text != novoTexto)
                {
                    control.txtInput.Text = novoTexto;
                }
                // Atualiza a visibilidade do placeholder.
                control.tbPlaceholder.Visibility = string.IsNullOrEmpty(novoTexto) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        // Evento chamado quando o texto interno do TextBox é alterado.
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Atualiza a propriedade Text (DependencyProperty) para refletir o que foi digitado.
            SetCurrentValue(TextProperty, txtInput.Text);
            // Alterna a visibilidade do placeholder conforme o conteúdo do TextBox.
            tbPlaceholder.Visibility = string.IsNullOrEmpty(txtInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }
    }
}
