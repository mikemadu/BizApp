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
    /// Interaction logic for NewApplicantPage.xaml
    /// </summary>
    public partial class NewApplicantPage : Page
    {
      viewmodel.NewApplicantViewmodel vm;
        public NewApplicantPage()
        {
            InitializeComponent();
            vm = new viewmodel.NewApplicantViewmodel();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Save button clicked
            vm.SaveNewApplicant();
        }
    }
}
