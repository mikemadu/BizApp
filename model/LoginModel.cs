using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizApp.model
{
    public class LoginModel
    {
        internal static bool AuthenticateUser(string username, string password)
        {
            //In a real application, we will authenticate the user
            //and return true or false 
            //For our demo purposes, let's just return true if username and password contain something;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
