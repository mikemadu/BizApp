using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BizApp.model;

namespace BizApp.viewmodel
{
    public class NewApplicantViewmodel : ViewmodelBase
    {
       private ObservableCollection<ApplicantModel.Applicant> _apcol;
      public  ObservableCollection<ApplicantModel.Applicant> NewApplicantCollection { get { return _apcol; }
            set {
                _apcol = value;
                NotifyPropertyChanged("NewApplicantCollection");
            } }
        /// <summary>
        /// New Applicant property. this is bound to our UI
        /// </summary>
        private ApplicantModel.Applicant _applicant;
        public ApplicantModel.Applicant NewApplicant
        {
            get { return _applicant; }
            set
            {
                _applicant = value;
                //Verify the that the following properties of NewApplicant are filled
             /*   if (string.IsNullOrEmpty(NewApplicant.Lastname) ||
                    string.IsNullOrEmpty(NewApplicant.Firstname) ||
                    string.IsNullOrEmpty(NewApplicant.Job) ||
                    string.IsNullOrEmpty(NewApplicant.Phone))
                {
                    EnableSave = false; //If even one is not filled, don't enable the SAVE button
                }
                else
                {
                    EnableSave = true; // else enable the SAVE button
                }*/
               //TODO: Compute the age

                NotifyPropertyChanged("NewApplicant");//notify the binding engine that the NewApplicant property has changed.
            }
        }

        //=========================================================================
        /// <summary>
        /// Our Constructor for this class
        /// </summary>
        public NewApplicantViewmodel()
        {
            NewApplicant = new model.ApplicantModel.Applicant();
            NewApplicantCollection = new ObservableCollection<model.ApplicantModel.Applicant>();
            _EnableSave = true;
        }

        //========================================================================
        /// <summary>
        /// Add a new applicant
        /// </summary>
        internal void SaveNewApplicant()
        {
            if (NewApplicant != null)
            {
                NewApplicantCollection.Add(NewApplicant);//Add to our local collection that is bound to the datagrid in this view
                App.ApplicantCollection.Add(NewApplicant);//Add also to our global store. In a normal App, we can push to a database.
                NewApplicant = new model.ApplicantModel.Applicant();
            }
        }

        //===============================================================================
        /// <summary>
        /// We wanna compute the age on the fly. We will bind to this property
        /// </summary>
        private string _age;
        public string Age { get { return _age; }

            set { _age = value;
                NotifyPropertyChanged("Age");
            } }

        //==============================================================================
        /// <summary>
        ///property for enabling and disabling the Save button ///
        /// </summary>
        private bool _EnableSave;
        public bool EnableSave
        {
            get { return _EnableSave; }

            set
            {
                _EnableSave = value;
                NotifyPropertyChanged("EnableSave");
            }
        }
    }
}
