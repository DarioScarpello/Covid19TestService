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
using Covid19TestService_Library.Models;

namespace Covid19TestService_WPF
{
    /// <summary>
    /// Interaktionslogik für Profile_add.xaml
    /// </summary>
    public partial class Profile_add : Window
    {
        static Users user;
        public Profile_add(Users selecteduser)
        {
            InitializeComponent();
            user = selecteduser;
        }

        private async void bt_save_Click(object sender, RoutedEventArgs e)
        {
            Profile newProfile = new Profile();

            newProfile.Firstname = tb_firstname.Text;
            newProfile.Lastname = tb_lastname.Text;
            newProfile.Phonenumber = Convert.ToInt32(tb_phonenumber.Text);
            newProfile.Ssn = Convert.ToInt32(tb_ssn.Text);
            newProfile.Dob = Convert.ToDateTime(tb_dob.Text);
            newProfile.Address = tb_address.Text;
            newProfile.City = tb_city.Text;
            newProfile.Country = tb_country.Text;

            await RestHelper.PostProfileAsync(newProfile);

            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            Close();
        }
    }
}
