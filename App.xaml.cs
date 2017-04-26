using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using static BizApp.model.SettingsModel;

namespace BizApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application

    { //make an instance of the settings class
        ProgramSettings progSettings = new ProgramSettings();

       
        
        
        // read the config settings
      //  model.SettingsModel.SaveSettings();
     

       public view.LoginPage loginPage = new view.LoginPage();
        
        
    }
}
