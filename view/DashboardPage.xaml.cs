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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BizApp.view
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
        
    {
        NewApplicantPage newApplicantPage;
        WorkerPoolPage workerPoolPage;
        WorkerManagedPage workerManagedPage;

        public DashboardPage()
        {
            InitializeComponent();
            newApplicantPage = new view.NewApplicantPage();
            workerPoolPage = new WorkerPoolPage();
            workerManagedPage = new WorkerManagedPage();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //New applicant button clicked
            if(newApplicantPage != null)
            {
                this.NavigationService.Navigate(newApplicantPage);
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Applicant pool button clicked
            if (workerPoolPage != null)
            {
                this.NavigationService.Navigate(workerPoolPage);
            }

        }

        private void managed_Click(object sender, RoutedEventArgs e)
        {
            //Applicant pool button clicked
            if (workerManagedPage != null)
            {
                this.NavigationService.Navigate(workerManagedPage);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //open the settings window
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
    }
}
