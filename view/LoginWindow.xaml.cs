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

        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(TxtPass.Password))
            {
                //TO DO: Message
                vm.MsgText = "Type anything to login :-)";
            }
            else
            {
                if (App.mainShell == null)
                {
                    App.mainShell = new view.MainShell();
                }
                 
                    App.mainShell.Show();
               this.Close();
            }


            // DashboardPage dashPage = new DashboardPage();
            //  MainWindow main = new MainWindow();
            //  main.Show(); 
            /*
              SettingsModel.ReadSettings(ref App.progSettings);

            // read the config settings

            if (App.progSettings.OpenToDashboard == true)
            {

            }
            else
            {

            }
            LoginPage loginPg = new LoginPage();
            _mainFrame.Navigate(loginPg);
             * */
        }
    }
}
