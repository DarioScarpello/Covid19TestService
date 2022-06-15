using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        static Users user;
        public MainWindow(Users selecteduser)
        {
            InitializeComponent();
            user = selecteduser;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Profile> allprofiles = new ObservableCollection<Profile>();
            List<Profile> allprofileslist = new List<Profile>();
            allprofileslist = await RestHelper.GetAllProfilsAsync(user.Uid);

            foreach (var item in allprofileslist)
            {
                allprofiles.Add(item);
            }
            lb_profiles.ItemsSource = allprofiles;
        }

        private void bt_logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private async void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            Profile selectedprofile = lb_profiles.SelectedItem as Profile;
            await RestHelper.DeleteProfileAsnyc(selectedprofile.Pid);
        }

        private void bt_submit_Click(object sender, RoutedEventArgs e)
        {
            Profile selectedprofile = lb_profiles.SelectedItem as Profile;
            Tests tests = new Tests(selectedprofile);
            tests.Show();
        }

        private void bt_edit_Click(object sender, RoutedEventArgs e)
        {
            Profile selectedprofile = lb_profiles.SelectedItem as Profile;
            Profile_Edit profile_Edit= new Profile_Edit(selectedprofile);
            profile_Edit.Show();
        }
    }
}
