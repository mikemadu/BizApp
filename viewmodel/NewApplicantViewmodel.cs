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
            _EnableSave = false;
        }

        //========================================================================
        /// <summary>
        /// Add a new applicant
        /// </summary>
        internal void SaveNewApplicant()

        {   //validate that the proper fields are filled up
           
                EnableSave = true;
                 if (NewApplicant != null)
            {   //generate a unique key. this key can be used to search for this applicant
                NewApplicant.key = Guid.NewGuid();
                NewApplicantCollection.Add(NewApplicant);//Add to our local collection that is bound to the datagrid in this view
                App.ApplicantCollection.Add(NewApplicant);//Add also to our global store. In a normal App, we can push to a database.
                NewApplicant = new model.ApplicantModel.Applicant();
                ClearEntries();
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

        public string Lastname
        {
            get { return _applicant.Lastname; }
            set { _applicant.Lastname = value;
                ValidateEntries();
                NotifyPropertyChanged("Lastname");

            }
        }

        public string Firstname
        {
            get { return _applicant.Firstname; }
            set
            {
                _applicant.Firstname = value;
                ValidateEntries();
                NotifyPropertyChanged("Firstname");

            }
        }

        public string MiddleName
        {
            get { return _applicant.MiddleName ; }
            set
            {
                _applicant.MiddleName = value;
                ValidateEntries();
                NotifyPropertyChanged("MiddleName");

            }
        }

        public string Job
        {
            get { return _applicant.Job ; }
            set
            {
                _applicant.Job = value;
                ValidateEntries();
                NotifyPropertyChanged("Job");

            }
        }

        public string Phone
        {
            get { return _applicant.Phone; }
            set
            {
                _applicant.Phone = value;
                ValidateEntries();
                NotifyPropertyChanged("Phone");

            }
        }
        /// <summary>
        /// Birth Date property
        /// </summary>
        public DateTime BirthDate
        {
            get { return _applicant.BirthDate; }
            set
            {
                _applicant.BirthDate  = value;
                GetAge();
                NotifyPropertyChanged("BirthDate");

            }
        }
        /// <summary>
        /// This method is called every time the relevant text fields change to validate the form
        /// </summary>
        private void ValidateEntries()
        {
            if (string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Job))
            {
                EnableSave = false;
            }
            else
            {
                EnableSave = true;
            }

        }

        public void ClearEntries()
        {
            Lastname = "";
            Firstname = "";
            MiddleName = "";
            Job = "";
            Phone = "";
            BirthDate = DateTime.Now.Date;

        }
        /// <summary>
        /// Compute the age of the aplicant
        /// </summary>
        public void GetAge()
        {
          //  DateTime _birthDate = new DateTime(BirthDate);
            DateTime newDate = DateTime.Now;

            // Difference in days, hours, and minutes between birthday and present.
            TimeSpan ts = newDate - BirthDate;
            // Difference in days.
            int differenceInDays = ts.Days;
            //convert days to years
            int age = (int)differenceInDays / 365;
            Age = age.ToString();
        }

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
