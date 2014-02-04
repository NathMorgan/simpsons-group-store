using Simpson_Group_Store_Database.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

//Account class was created by me for a side project (Equestria Galleries) I will be using this class to help me deal with account management for the Simpson Group Store.
namespace Simpson_Group_Store_Database
{
    public class Account
    {
        public static bool IsAuthenticated { get; set; }
        public static string Username { get; set; }

        private readonly string saltKey = "rEth8TRAtR@SwetrA&uxuf?edecuguf?A&ejE8udRU$6$seCHuCHeCHuKaruVuyu";

        // Register
        // Checks the inputs then adds them to a database
        // INPUTS: Userame, Password, Email, dob
        // OUTPUT: bool (Sucsessfull registration)
        public bool Register(string username, string password, string email, string dob)
        {
            //Checking the inputs are not empty
            if (username == null)
                return false;
            if (password == null)
                return false;
            if (email == null)
                return false;
            if (dob == null)
                return false;

            //Checking the username exists
            if (GetUserid(username) != 0)
                return false;

            //Generating the salt and encripting the password with the salt
            Encryption encrypter = new Encryption();
            string salt = encrypter.sha256encrypt(username + saltKey + email);
            string encriptedpassword = encrypter.sha256encrypt(password + salt);

            username = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(username);

            //Adding account details to the database
            using (var db = new SimpsonGroupEntities())
            {
                db.Users.Add(new User { Username = username, Email = email, DoB = Convert.ToDateTime(dob), Registered = DateTime.Now });
                db.Passwords.Add(new Password { UserPassword = encriptedpassword, Salt = salt, LastLogin = DateTime.Now, LastPasswordChange = DateTime.Now });

                //Try to save the database
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    AddError("Database Error", e.Message);
                }

                return true;
            }
        }

        public bool ChangePassword(string username, string password)
        {
            return true;
        }

        public bool Login(string username, string password, string rememberme, string ip)
        {
            if (username == null)
                return false;
            if (password == null)
                return false;
            if (rememberme == null)
                return false;
            if (ip == null)
                return false;

            int userid = GetUserid(username);

            if (userid == 0)
            {
                AddLoginResult(false, username, ip, userid);
                return false;
            }
            using (var db = new SimpsonGroupEntities())
            {
                var passwordquery = from n in db.Passwords
                                    where n.Userid == userid
                                    select n;
                if (passwordquery.Count() == 0)
                {
                    AddLoginResult(false, username, ip, userid);
                    return false;
                }

                Encryption encrypter = new Encryption();
                string encriptedpassword = encrypter.sha256encrypt(password + passwordquery.First().Salt);

                var loginquery = from n in db.Users
                                 where n.Username == username && n.Password.UserPassword == encriptedpassword
                                 select n;
                if (loginquery.Count() == 0)
                {
                    AddLoginResult(false, username, ip, userid);
                    return false;
                }

                //Checking that the cookie hasent been deleted if deleted remove the session from database issue new one
                var cookiequery = from n in db.Sessions
                                  where n.Userid == userid
                                  select n;
                if (cookiequery.Count() > 0)
                {
                    db.Sessions.Remove(db.Sessions.Find(userid));
                    db.SaveChanges();
                }
            }

            return true;
        }

        public void AddLoginResult(bool result, string username, string ip, int userid)
        {
            using (var db = new SimpsonGroupEntities())
            {
                db.LoginResults.Add(new LoginResult { Userid = userid, Result = result, ipaddress = ip, DateTime = DateTime.Now });
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    AddError("Database Error", e.Message);
                }
            }
        }

        public void AddError(string type, string message)
        {
            using (var db = new SimpsonGroupEntities())
            {
                db.Errors.Add(new Error { Type = type, Message = message, DateTime = DateTime.Now});
            }
        }

        public static int GetUserid(string username)
        {
            using (var db = new SimpsonGroupEntities())
            {
                var query = from n in db.Users
                            where n.Username == username
                            select n;
                if (query.Count() == 0)
                    return 0;
                else
                    return query.First().Userid;
            }
        }

        public void Logout()
        {

        }

        public static bool AuthenticateCookie()
        {
            return true;
        }
    }
}