using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BizApp.model.ApplicantModel;
using static BizApp.model.UserModel;

namespace BizApp.model
{
    public class DataAccess
    {//This class will simulate our database

        public List<Applicant> ApplicantList = new List<Applicant>();
        public List<User> UserList = new List<User>();

       public DataAccess()
        {
          
            //read applicants from file if it exists
            if (ApplicantList.Count==0)
            {
                var appModel = new ApplicantModel();
                ApplicantList = appModel.GetDemoApplicants();
            }

            //read Users from file
            if (UserList.Count  == 0)
            {
                var usrModel = new UserModel();
                UserList = usrModel.GetDemoUsers();
            }

        }
        public bool CreateApplicant(Applicant applicant)
        {
            ApplicantList.Add(applicant);
            return true;
        }

        public List<Applicant> GetApplicants()
        {
            return ApplicantList;
        }

        public Applicant GetApplicantByKey(string key)
        {
            var db = (from a in ApplicantList where a.key.Equals(key) select a).FirstOrDefault();
            if (db != null)
            {
                return db;
            }
            else
            {
                return null;
            }

        }

        public bool CreateUser(User usr)
        {
            bool Created = false;


            return Created;

        }

        public  List<User> GetUsers()
        {
            return UserList;
        }

        public object SaveData( ref object obj, string filename)
        {
            return null;
        }

        public object ReadData(ref object obj, string filename)
        {
            return null;
        }

     
    }
}
