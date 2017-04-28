using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizApp.viewmodel
{
    public class SettingsViewModel: ViewmodelBase

    {
       public SettingsViewModel()
        {
            LoadSettings();
        }

        //================ Radio button for Dashboard ========
        private bool _toDash;
        public bool ToDashboard {
            get { return _toDash; }

            set { _toDash = value;
                App.progSettings.OpenToDashboard = value;
                NotifyPropertyChanged("ToDashboard");
            } }

        //================ Radio button for New Applicant Page =============
        private bool _toApplicant;
        public bool ToNewApplicant { get { return _toApplicant; }

            set {
                _toApplicant = value;
                App.progSettings.OpenToNewApplicant = value;
                NotifyPropertyChanged("ToNewApplicant");
            }
        }

        public void LoadSettings()
        {
            if (App.progSettings != null)
            {
                //load the settings into our controls
                ToNewApplicant = App.progSettings.OpenToNewApplicant;
                ToDashboard = App.progSettings.OpenToDashboard;

            }
        }

        public void  SaveSettings()
        {
            model.SettingsModel.SaveSettings( App.progSettings);
        }
    }
}
