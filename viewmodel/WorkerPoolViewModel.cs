using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BizApp.model.ApplicantModel;

namespace BizApp.viewmodel
{
    public class WorkerPoolViewModel : ViewmodelBase

    {
        List<Applicant> _appList;
        public List<Applicant> ApplicantList //property of this class
        { get {
                return _appList;
            }

            set {
                _appList = value;
                NotifyPropertyChanged("ApplicantList");
            }
        }
//============== Class Constructor ======================================
        public WorkerPoolViewModel() {
            //We get data from model and populate the list of applicants which is bound to
            //our listbox on the user interface

            var applicantModel = new model.ApplicantModel();
            ApplicantList = applicantModel.GetApplicantList();
            
        }
//==================================================================
        private Applicant _applicant;
        public Applicant SelectedApplicant
        {
            get
            {
                return _applicant;
            }
            set
            {
                _applicant = value;
                NotifyPropertyChanged("SelectedApplicant");
            }
        }

      
    }
}
