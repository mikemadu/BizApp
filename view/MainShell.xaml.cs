using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BizApp.view
{
    /// <summary>
    /// Interaction logic for MainShell.xaml
    /// </summary>
    public partial class MainShell : Window
    {
        public MainShell()
        {
            InitializeComponent();

            //The config setting is used to open the appropriate page
            if (App.progSettings != null)
            {
                if (App.progSettings.OpenToDashboard)
                {
                    _mainFrame.Navigate(App.dashboardPage);

                }
                else if (App.progSettings.OpenToNewApplicant)
                {
                    _mainFrame.Navigate(App.applcntPage);
                }
                else
                {//or default to the dashboard page if nothing has been chosen yet 
                    _mainFrame.Navigate(App.dashboardPage);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Settings button
            SettingsView sv = new SettingsView();
            sv.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //dashboard
            if (App.dashboardPage == null)
            {
                App.dashboardPage = new DashboardPage();
            }
            _mainFrame.Navigate(App.dashboardPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //worker pool page
            if (App.workerPoolPage==null)
            {
                App.workerPoolPage = new WorkerPoolPage();
            }
            _mainFrame.Navigate(App.workerPoolPage);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //new applicant page
            if (App.applcntPage == null)
            {
                App.applcntPage = new NewApplicantPage();
            }
            _mainFrame.Navigate(App.applcntPage);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Managed Applicants
            if (App.workerManagedPage == null)
            {
                App.workerManagedPage = new WorkerManagedPage();
            }

            this._mainFrame.Navigate(App.workerManagedPage);
        }
    }
}
