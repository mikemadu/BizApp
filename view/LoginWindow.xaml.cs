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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    { viewmodel.LoginViewModel vm;

        public LoginWindow()
        {
            InitializeComponent();
            vm = new viewmodel.LoginViewModel();
            this.DataContext = vm;
        }

        private void button_Click(object sender, RoutedEventArgs e)

        {   //Login button clicked

            if (vm.AuthenticateUser(txtUser.Text, TxtPass.Password ) == false)
            {
               
                vm.MsgText = "Type any password to login :-)";
            }
            else //if Authentication returns true proceed ....
            {
                if (App.mainShell == null)
                {
                    App.mainShell = new view.MainShell();
                }
                    App.mainShell.Show();
               this.Close();
            }
        }

        private void On_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Focus();
        }
    }
}
