using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für Tests.xaml
    /// </summary>
    public partial class Tests : Window
    {
        static Profile profile;
        public Tests(Profile selectedprofile)
        {
            InitializeComponent();
            profile = selectedprofile;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Pcr> observableCollectionpcr = new ObservableCollection<Pcr>();
            ObservableCollection<Antigen> observableCollectionAntigen = new ObservableCollection<Antigen>();
            List<Antigen> ListAntigen = new List<Antigen>();
            List<Pcr> ListPcr = new List<Pcr>();

            ListAntigen = await RestHelper.GetAntigenAsync(profile.Pid);
            ListPcr = await RestHelper.GetPcrsAsync(profile.Pid);

            foreach (var item in ListAntigen)
            {
                observableCollectionAntigen.Add(item);
            }
            foreach (var item in ListPcr)
            {
                observableCollectionpcr.Add(item);
            }
        }

        private void tb_back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void bt_pcr_Click(object sender, RoutedEventArgs e)
        {
            Pcr newpcr = new Pcr();

            newpcr.Pid = profile.Pid;
            newpcr.Pcrid = 1;
            newpcr.Takenon = DateTime.Now;
            newpcr.Ct = 30;
            newpcr.Ispositive = false;

            await RestHelper.PostPCRAsync(newpcr, profile.Pid);

            Tests tests2 = new Tests(profile);
            tests2.Show();
            Close();
        }

        private async void bt_antigen_Click(object sender, RoutedEventArgs e)
        {
            Antigen newAntigen = new Antigen();

            newAntigen.Pid = profile.Pid;
            newAntigen.Aid = 1;
            newAntigen.Takenon = DateTime.Now;
            newAntigen.Lines = 1;
            newAntigen.Ispositive = false;

            await RestHelper.PostAntigensync(newAntigen, profile.Pid);

            Tests tests2 = new Tests(profile);
            tests2.Show();
            Close();
        }
    }
}
