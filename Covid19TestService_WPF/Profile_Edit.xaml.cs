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
    /// Interaktionslogik für Profile_Edit.xaml
    /// </summary>
    public partial class Profile_Edit : Window
    {
        static Profile profile;

        public Profile_Edit(Profile selectedprofile)
        {
            InitializeComponent();
            profile = selectedprofile;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tb_firstname.Text = profile.Firstname;
            tb_lastname.Text = profile.Lastname;
            tb_phonenumber.Text = Convert.ToString(profile.Phonenumber);
            tb_ssn.Text = Convert.ToString(profile.Ssn);
            tb_dob.Text = Convert.ToString(profile.Dob);
            tb_address.Text = profile.Address;
            tb_city.Text = profile.City;
            tb_country.Text = profile.Country;
        }

        private async void bt_save_Click(object sender, RoutedEventArgs e)
        {
            Profile editprofile = new Profile();

            editprofile.Firstname = tb_firstname.Text;
            editprofile.Lastname = tb_lastname.Text;
            editprofile.Phonenumber = Convert.ToInt32(tb_phonenumber.Text);
            editprofile.Ssn = Convert.ToInt32(tb_ssn.Text);
            editprofile.Dob = Convert.ToDateTime(tb_dob.Text);
            editprofile.Address = tb_address.Text;
            editprofile.City = tb_city.Text;
            editprofile.Country = tb_country.Text;

            await RestHelper.PatchProfileAsync(profile.Pid, editprofile);
            Close();
        }
    }
}
