using System;
using System.Windows.Forms;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "Minha Interface Gráfica";
        Width = 800;
        Height = 600;

        var button = new Button
        {
            Text = "Clique Aqui",
            Left = 10,
            Top = 10
        };
        button.Click += (sender, args) => MessageBox.Show("Botão clicado!");
        Controls.Add(button);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MainForm());
    }
}