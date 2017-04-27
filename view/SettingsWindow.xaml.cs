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
using BizApp.viewmodel;

namespace BizApp.view
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        SettingsViewModel vm; //declare the viewmodel we will use for this view

        public SettingsWindow()
        {
            InitializeComponent();
            //Initialize the viewModel and bind it with the datacontext of this window
          //  vm = new SettingsViewModel();
         //   this.DataContext = vm;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //save the settings and close
            if (App.progSettings != null) //check that this object exists
            {
                model.SettingsModel.SaveSettings(App.progSettings);
            }

            this.Close();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            //When this window opens, load the settings from "progSettings"
            //But do it in the ViewModel assigned to this view
            
        }
    }
}
