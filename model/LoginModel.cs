using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BizApp.model
{
    public class LoginModel
    {
        internal static bool AuthenticateUser(string username, string password)
        {
            //In a real application, we will authenticate the user
            //and return true or false 
            //For our demo purposes, let//s just return true if username and password contain something;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        //public class PasswordHasher
        //{

        //    public const int SALT_BYTE_SIZE = 24;
        //    public const int HASH_BYTE_SIZE = 24;

        //public const int SALT_INDEX  = 1;
        ///// <summary>
        ///// Creates a hashed password from plain text. Salt is created and attached to the end of the password.
        ///// </summary>
        ///// <param name="plainTextPass">Plain text password to be hashed</param>
        ///// <returns>Hashed password with salt appended</returns>
        //    public static string CreateHashedPassword(string plainTextPass)  {
        //        // Generate a random salt
        //        var csprng = new RNGCryptoServiceProvider();

        //        byte salt[SALT_BYTE_SIZE];
        //    csprng.GetBytes(salt);

        //    //Hash the password and encode the parameters
        //        byte[] hash = HashIt(plainTextPass, salt, 1000, HASH_BYTE_SIZE);
        //        return Convert.ToBase64String(hash) & ":" & Convert.ToBase64String(salt);

        //}
        //    /// <summary>
        //    /// Will validate a password against its hash
        //    /// </summary>
        //    /// <param name="password">plain text password</param>
        //    /// <param name="correctHash">correct hash</param>
        //    /// <returns>true if hash is a representation of plain password</returns>
        //    public static bool ValidatePassword(string password, string correctHash) {
        //        //Extract the parameters from the hash
        //        try
        //        {
        //            var delimiter = cchar(":");
        //            string[] splited = correctHash.Split(delimiter);
        //            var iterations = 1000;
        //            byte[] hash = Convert.FromBase64String(splited[0]);
        //        var salt As Byte() = Convert.FromBase64String(splited(SALT_INDEX))


        //        byte[] testHash = HashIt(password, salt, iterations, hash.Length);
        //      if (Convert.ToBase64String(hash) == Convert.ToBase64String(testHash){
        //                return true;
        //            }else{
        //                return false;
        //            }
               
                   
               
        //        }
        //        catch (Exception)
        //        {
        //            return false;

        //        }



        //    }

        ///// <summary>
        ///// Computes the PBKDF2-SHA1 hash of a password.
        ///// </summary>
        ///// <param name="password"></param>
        ///// <param name="salt"></param>
        ///// <param name="iterations"></param>
        ///// <param name="outputBytes"></param>
        ///// <returns>A hash of the password.</returns>
        ///// <remarks></remarks>
        //    private static byte[] HashIt(string password, byte[] salt, int iterations, int outputBytes)
        //    {
        //        var pbkdf2_ = new Rfc2898DeriveBytes(password, salt);
        //        pbkdf2_.IterationCount = iterations;
        //        return pbkdf2_.GetBytes(outputBytes);
        //    }


        //}


    }
}
