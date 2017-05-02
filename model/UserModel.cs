using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizApp.model
{
    public class UserModel
    {
       
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
           // public string Salt { get; set; }
            public string RealName { get; set; }
            public int Role { get; set; }
        }

        public enum UserRole
        {
            Invalid = 0,
            Admin = 1,
            Supervisor = 2,
            Staff = 3
        }

         [Serializable] public class UserStore
        {
            public List<User> UserList;
        }

        public List<User> GetDemoUsers()
        {
            List<User> UserList = new List<User>();
            User usr = new User();
            LoginModel.PasswordHasher   passwrdHasher = new LoginModel.PasswordHasher();
            

            usr.Username = "Micky";
            
            usr.Password = LoginModel.PasswordHasher.CreateHashedPassword( "1234");
            usr.RealName = "Mike Chuks";
            //usr.Salt = "ytyuuy";
            usr.Role = (int)UserRole.Admin;
            UserList.Add(usr);

             usr = new User();
            usr.Username = "Ray";
            usr.Password = LoginModel.PasswordHasher.CreateHashedPassword("1234");
            usr.RealName = "Raymond Delmundo";
           // usr.Salt = "ytyuuy";
            usr.Role = (int)UserRole.Staff;
            UserList.Add(usr);

            usr = new User();
            usr.Username = "Mely";
            usr.Password = LoginModel.PasswordHasher.CreateHashedPassword("1234");
            usr.RealName = "Imelda Santos";
            //usr.Salt = "ytyuuy";
            usr.Role = (int)UserRole.Supervisor;
            UserList.Add(usr);

           return UserList;
        }
    }
}
