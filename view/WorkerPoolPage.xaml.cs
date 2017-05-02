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
using BizApp.viewmodel;

namespace BizApp.view
{
    /// <summary>
    /// Interaction logic for WorkerPoolPage.xaml
    /// </summary>
    public partial class WorkerPoolPage : Page
    {
        WorkerPoolViewModel vm;
        public WorkerPoolPage()
        {
            InitializeComponent();
            vm = new WorkerPoolViewModel();
            this.DataContext = vm;
        }

        
        private void On_FirstName_Focus(object sender, RoutedEventArgs e)
        {
            textBox.Clear();

        }

        private void On_LastName_Focused(object sender, RoutedEventArgs e)
        {
            textBox_Copy.Clear();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //reload data
            vm.LoadData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             //delete selected applicant
                vm.DeleteApplicant();
            
           
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Update selected applicant
            vm.UpdateApplicant();
        }
    }
}
