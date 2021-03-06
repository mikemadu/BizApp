﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BizApp.model;
using static BizApp.model.ApplicantModel;
using static BizApp.model.SettingsModel;
using static BizApp.model.UserModel;

namespace BizApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application

    { //Declare an observable list of Applicants. We will use this later to populate our applicants for binding to the UI

        private static ObservableCollection<Applicant> applicantCollection;// = new ObservableCollection<Applicant>();
        public List<User> UserList;

        public static DataAccess DataAccess = new model.DataAccess();

        //make an instance of the settings class
        public static  ProgramSettings progSettings = new ProgramSettings();
       
        public static view.NewApplicantPage applcntPage = new view.NewApplicantPage();
        public static view.WorkerPoolPage workerPoolPage = new view.WorkerPoolPage();
        public static view.WorkerManagedPage workerManagedPage = new view.WorkerManagedPage();
        public static view.DashboardPage dashboardPage = new view.DashboardPage();
        public static view.MainShell mainShell;

        public static ObservableCollection<Applicant> ApplicantCollection { get { return applicantCollection; } set { applicantCollection = value; } }
    }
}
