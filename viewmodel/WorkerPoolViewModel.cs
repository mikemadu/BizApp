using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BizApp.model.ApplicantModel;

namespace BizApp.viewmodel
{
    class WorkerPoolViewModel : ViewmodelBase

    {
        List<Applicant> _appList;
        public List<Applicant> ApplicantList { get; set; }
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
            }
        }

      
    }
}
