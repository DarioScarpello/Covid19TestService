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
using Covid19TestService_Library.Models;

namespace Covid19TestService_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Users user = null;
        public MainWindow(Users selecteduser)
        {
            InitializeComponent();
            user = selecteduser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var allprofiles = RestHelper.GetAllProfilsAsync(user.Uid);
        }

        private void bt_logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            RestHelper.DeleteProfileAsnyc(lb_profiles.SelectedItem.pid);
        }
    }
}
