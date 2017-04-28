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
using BizApp.model;

namespace BizApp.view
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {viewmodel.SettingsViewModel vm;
        public SettingsView()
        {
            
            InitializeComponent();
            vm = new viewmodel.SettingsViewModel();
            this.DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //OK button 
            vm.SaveSettings();//call the save method of the viewmodel attached to this view

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   //Cancel button

            this.Close();
        }

      
    }
}
