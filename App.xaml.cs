using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BizApp.model;
using static BizApp.model.ApplicantModel;
using static BizApp.model.SettingsModel;

namespace BizApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application

    { //Declare an observable list of Applicants. We will use this later to populate our applicants for binding to the UI

        private static ObservableCollection<Applicant> applicantCollection;// = new ObservableCollection<Applicant>();

        //make an instance of the settings class
      public static  ProgramSettings progSettings = new ProgramSettings();

               
        // read the config settings
      //  model.SettingsModel.SaveSettings();
     

       public static  view.LoginPage loginPage = new view.LoginPage();

        public static ObservableCollection<Applicant> ApplicantCollection { get => applicantCollection; set => applicantCollection = value; }
    }
}
