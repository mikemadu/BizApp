using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using static BizApp.model.ApplicantModel;
using System.ComponentModel;
using System.Windows.Media;

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
        //=======================================================================
        ICollectionView _collectionView;
        public ICollectionView CollectionView// The Collection View as a property of this class 
                                                //so that it can be bound to the UI ListBox
        { get => _collectionView;

            set { _collectionView = value;
                NotifyPropertyChanged("CollectionView"); }
        }

        private Brush _srchColorFN;
        public Brush SearchColor_FirstName// This property is for changing the color of the search box as you type, 
            //depending on if the searched data matches what is typed..
        {
            get { return _srchColorFN; }
            set { _srchColorFN = value;
                NotifyPropertyChanged("SearchColor_FirstName");
            }
        }

        private Brush _srchColorLN;
        public Brush SearchColor_LastName// This property is for changing the color of the search box as you type, 
                                //depending on if the searched data matches what is typed..
        {
            get { return _srchColorLN; }
            set
            {
                _srchColorLN = value;
                NotifyPropertyChanged("SearchColor_LastName");
            }
        }



        //============== Class Constructor ======================================
        public WorkerPoolViewModel() {
            //We get data from model and populate the list of applicants which is bound to
            //our listbox on the user interface

            var applicantModel = new model.ApplicantModel();
            ApplicantList = applicantModel.GetApplicantList();

            CollectionView = CollectionViewSource.GetDefaultView(ApplicantList);


            App.ApplicantCollection = new ObservableCollection<Applicant>(ApplicantList);

           


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
            

        #region SEARCH ==========================
      
        private string _lastname_s;
       public string Lastname_s {
            get {
                return _lastname_s;
            }
            set {
                _lastname_s = value;
                NotifyPropertyChanged("Lastname_s");
              
                if (CollectionView != null)
                {
                    CollectionView.Filter = new Predicate<object>(ap => LastNameFilter(ap as Applicant));
                
                    if (String.IsNullOrEmpty(value) == false)
                    {
                        CollectionView.MoveCurrentToPosition(0);

                        SelectedApplicant = (Applicant)CollectionView.CurrentItem;
                        if (SelectedApplicant != null)
                        {
                            SearchColor_LastName = Brushes.PaleGreen; //If there is a match in the search term
                        }
                        else
                        {
                            SearchColor_LastName = Brushes.LightPink; // If there is NO match in the search text
                        }
                    }
                    else
                    {
                        SearchColor_LastName = Brushes.White; //When the search box is cleared

                        SelectedApplicant = new Applicant(); // Also clear the selected applicants details from the view
                    }
                }
            }

            }
       
        //=====================================================
        public bool LastNameFilter(object ap)
        {
            try
            {

                Applicant app1 = ap as Applicant;
                if (app1.Lastname == null)
                {
                    return false;
                }
                if (app1.Lastname.Trim().ToLower().StartsWith(_lastname_s.Trim().ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //============================================================================
        private string _firstname_s;
        public string Firstname_s
        {
            get
            {
                return _firstname_s;
            }
            set
            {
                _firstname_s = value;
                NotifyPropertyChanged("Firstname_s");
              
                if (CollectionView != null)
                {
                    CollectionView.Filter = new Predicate<object>(ap => FirstNameFilter(ap as Applicant));
                   
                    if (String.IsNullOrEmpty(value) == false)
                    {
                        CollectionView.MoveCurrentToPosition(0);

                        SelectedApplicant = (Applicant)CollectionView.CurrentItem;
                        if (SelectedApplicant != null)
                        {
                            SearchColor_FirstName = Brushes.PaleGreen; //If there is a match in the search term
                        }
                        else
                        {
                            SearchColor_FirstName = Brushes.LightPink; // If there is NO match in the search text
                        }
                    }
                    else
                    {
                        SearchColor_FirstName = Brushes.White; //When the search box is cleared

                        SelectedApplicant = new Applicant(); // Also clear the selected applicants details from the view
                    }
                }
            }

        }
        //========================================================
        public bool FirstNameFilter(object ap)
        {
            try
            {

                Applicant app1 = ap as Applicant;
                if (app1.Firstname == null)
                {
                    return false;
                }
                if (app1.Firstname.Trim().ToLower().StartsWith(_firstname_s.Trim().ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
    
  

   
        #endregion


    }

