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
    /// Interaction logic for WorkerManagedPage.xaml
    /// </summary>
    public partial class WorkerManagedPage : Page

    {
        WorkerPoolViewModel vm;
        public WorkerManagedPage()
        {
            InitializeComponent();
            vm = new WorkerPoolViewModel();
            this.DataContext = vm;
        }

        

        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {

        }
        private void On_Loaded(object sender, RoutedEventArgs e)
        {
            vm.ReloadData();
        }
    }
}
