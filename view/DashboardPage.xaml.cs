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
        public DashboardPage()
        {
            InitializeComponent();
            newApplicantPage = new view.NewApplicantPage();
            workerPoolPage = new WorkerPoolPage();

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
    }
}
