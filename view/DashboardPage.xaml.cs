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
       
        public DashboardPage()
        {
            InitializeComponent();           
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //New applicant button clicked
            if (App.applcntPage  == null)
            {
                App.applcntPage = new NewApplicantPage();
            }

                this.NavigationService.Navigate(App.applcntPage);
         }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Applicant pool button clicked
            if(App.workerPoolPage == null)
            {
                App.workerPoolPage = new WorkerPoolPage();
            }
          
            this.NavigationService.Navigate(App.workerPoolPage);
        }

        private void managed_Click(object sender, RoutedEventArgs e)
        {
            //Managed Applicant pool button clicked
            if (App.workerManagedPage == null)
            {
                App.workerManagedPage = new WorkerManagedPage();
            }
            this.NavigationService.Navigate(App.workerManagedPage);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //open the settings window
            view.SettingsView settingsWindow = new SettingsView();
            settingsWindow.ShowDialog();
        }
    }
}
