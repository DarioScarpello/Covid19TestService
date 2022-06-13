using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Covid19TestService_Library.Models;

namespace Covid19TestService_WPF
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void tb_submit_Click(object sender, RoutedEventArgs e)
        {
            if (await RestHelper.PostLoginAsync(tb_email.Text, tb_password.Text))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Login login = new Login ();
                login.Close();
            }
            MessageBox.Show("Falsche Anmelde Daten!");
        }
    }
}
