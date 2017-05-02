using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using static BizApp.model.ApplicantModel;
using static BizApp.model.UserModel;

namespace BizApp.model
{
    public class DataAccess
    {   //This class will simulate our database

        public ApplicantStore ApplicantStore = new ApplicantStore();


        public UserStore UserStore = new UserStore();

     

       public DataAccess()
        {
            //Initialize the Applicant store list
            ApplicantStore.ApplicantList = new List<Applicant>();

            //read applicants from file on disk if it exists 
            ReadApplicants(ref ApplicantStore.ApplicantList, "applicant_store.txt");
            //if it does not exist..
            if (ApplicantStore.ApplicantList.Count==0)
            {   //fill it with our demo data
                var appModel = new ApplicantModel();
                ApplicantStore.ApplicantList = appModel.GetDemoApplicants();
                //Save it to disk so that from now on we can find the data on disk
               WriteApplicants(ref ApplicantStore.ApplicantList, "applicant_store.txt");
            }

            //Initialize the User store list. This contains users who can login
            UserStore.UserList = new List<User>();

            //read Users from file on the disk if it exists
            ReadUsers(ref UserStore.UserList, "user_store.txt");
            //if it does not exist, get the demo users
            if (UserStore.UserList.Count == 0)
            {   
                var userModel = new UserModel();
                UserStore.UserList = userModel.GetDemoUsers();

                //Save it to disk so that from now on we can find the data on disk
                WriteUsers(ref UserStore.UserList, "user_store.txt");
            }

          
        }

        
        /// <summary>
        /// Creates an applicant record on disk. Its added to a list of applicants in memory 
        /// and writes the list to disk
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public List<Applicant> CreateApplicant(Applicant applicant)
        {
            ApplicantStore.ApplicantList.Add(applicant);
            //write to disk
            WriteApplicants(ref ApplicantStore.ApplicantList, "applicant_store.txt");// write to disk
            return ApplicantStore.ApplicantList; //return full list to caller
        }

        /// <summary>
        /// Returns a list of applicants from a disk file if it exists.
        /// </summary>
        /// <returns></returns>
        public List<Applicant> GetApplicants()

        {
            //read from disk
            ReadApplicants(ref ApplicantStore.ApplicantList , "applicant_store.txt");
            return ApplicantStore.ApplicantList; //return list to caller
        }

        public List<Applicant> UpdateApplicant(Applicant applicant)
        {
            //find the applicant
            if(ApplicantStore.ApplicantList != null)
            {
                var oneApplicant = (from a in ApplicantStore.ApplicantList where a.key.Equals(applicant.key) select a).FirstOrDefault();
                if (oneApplicant != null)
                {
                    oneApplicant.Lastname = applicant.Lastname;
                    oneApplicant.Firstname = applicant.Firstname;
                    oneApplicant.MiddleName = applicant.MiddleName;

                    //save the whole collection to disk
                    WriteApplicants(ref ApplicantStore.ApplicantList, "applicant_store.txt");

                }
                return ApplicantStore.ApplicantList;
            }else
            return null;

        }

        public List<Applicant> DeleteApplicant(Guid applKey)
        {
            //find the applicant
            if (ApplicantStore.ApplicantList != null)
            {
                var oneApplicant = (from a in ApplicantStore.ApplicantList where a.key.Equals(applKey) select a).FirstOrDefault();
                if (oneApplicant != null)
                {
                    ApplicantStore.ApplicantList.Remove(oneApplicant);

                    //save the whole collection to disk
                    WriteApplicants(ref ApplicantStore.ApplicantList, "applicant_store.txt");

                }
                return ApplicantStore.ApplicantList;
            }else
            return null;
        }

        public Applicant GetApplicantByKey(string key)

        {
            if (ApplicantStore.ApplicantList != null)
            {
                var db = (from a in ApplicantStore.ApplicantList where a.key.Equals(key) select a).FirstOrDefault();
                if (db != null)
                {
                    return db;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public List<User> CreateUser(User usr)
        {
            UserStore.UserList.Add(usr);//add a user to the list 
            WriteUsers(ref UserStore.UserList, "user_store.txt");//write it to disk
            return UserStore.UserList;//return the full list to the caller

        }

        public  List<User> GetUsers()
        {
            //read from disk 
            ReadUsers(ref UserStore.UserList, "user-store.txt");
            //return the list
            return UserStore.UserList;
        }

        /// <summary>
        /// Will write a list of applicants to a disk file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        public void WriteApplicants( ref List<Applicant> obj, string filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                var objWriter = new StreamWriter(filename, false);
                serializer.Serialize(objWriter, obj);
                objWriter.Close();
               
            }
            catch (Exception)
            {
               
            }
        }

        /// <summary>
        /// Will hydrate a list of Applicants in memory with data read from disk
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        public void ReadApplicants(ref List<Applicant> obj, string filename)
        {
            try
            {
                XmlSerializer de_serializer = new XmlSerializer(obj.GetType());

                //create a streamreader that reads from the file on disk
                StreamReader oRead = new StreamReader(filename);
                //instruct serializer to deserialize an object reference form the file and cast it to the
                //appropriate reference type
                obj = (List<Applicant>)de_serializer.Deserialize(oRead);

                oRead.Close();

            }
            catch (Exception)
            {

            }
          
        }

        /// <summary>
        /// Will write a list of users to a disk file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        public void WriteUsers(ref List<User> obj, string filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                var objWriter = new StreamWriter(filename, false);
                serializer.Serialize(objWriter, obj);
                objWriter.Close();

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Will hydrate a list of Users in memory with data read from disk
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        public void ReadUsers(ref List<User> obj, string filename)
        {
            try
            {
                XmlSerializer de_serializer = new XmlSerializer(obj.GetType());

                //create a streamreader that reads from the file on disk
                StreamReader oRead = new StreamReader(filename);
                //instruct serializer to deserialize an object reference form the file and cast it to the
                //appropriate reference type
                obj = (List<User>)de_serializer.Deserialize(oRead);

                oRead.Close();

            }
            catch (Exception)
            {

            }

        }


    }
}
