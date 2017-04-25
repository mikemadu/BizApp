using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizApp.model
{
    class ApplicantModel

    {
        public List<Applicant> GetApplicantList()
        {
            List<Applicant> lst = new List<Applicant>();//declare a list of Applicant variable

           Applicant app;
            app= new Applicant();//make a new applicant and populate the properties

            app.Lastname = "Chuks";
            app.Firstname = "Micky";
            app.MiddleName = "C.";
            app.id = 1;
            lst.Add(app);//add to the list

            app = new Applicant();//make a new applicant and populate the properties

            app.Lastname = "Santos";
            app.Firstname = "Vicky";
            app.MiddleName = "P.";
            app.id = 2;
            lst.Add(app);//add to the list

            app = new Applicant();//make a new applicant and populate the properties

            app.Lastname = "Petronelo";
            app.Firstname = "John";
            app.MiddleName = "W.";
            app.id = 3;
            lst.Add(app);//add to the list

            app = new Applicant();//make a new applicant and populate the properties

            app.Lastname = "Escardo";
            app.Firstname = "Marilyn";
            app.MiddleName = "M.";
            app.id = 4;
            lst.Add(app);//add to the list

            return lst;
        }
      public  class Applicant
        {
          public  string Lastname { get; set; }
            public string Firstname { get; set; }
            public string MiddleName { get; set; }
            public DateTime BirthDate { get; set; }
            public int id { get; set; }

        }
    }
}
