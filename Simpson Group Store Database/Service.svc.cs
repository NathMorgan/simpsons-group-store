using Simpson_Group_Store_Database.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace Simpson_Group_Store_Database
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public string GetProducts()
        {
            using(var db = new SimpsonGroupEntities())
            {
                string json;
                try
                {
                    var products = (from p in db.Products
                                    select p).ToList();
                    json = new JavaScriptSerializer().Serialize(products);
                }
                catch (Exception e)
                {
                    Error dberror = new Error();
                    dberror.DateTime = DateTime.Now;
                    dberror.Errorid = e.HResult;
                    dberror.Message = e.Message;
                    dberror.Type = "Database query error";
                    db.Errors.Add(dberror);
                    db.SaveChanges();
                    json = new JavaScriptSerializer().Serialize("false");
                }
                return json;
            }
        }

        public string GetProduct(int id)
        {
            using (var db = new SimpsonGroupEntities())
            {
                string json;
                try
                {
                    var product = (from p in db.Products
                                       where id == p.Productid
                                       select p).First();
                    json = new JavaScriptSerializer().Serialize(product);
                }
                catch (Exception e)
                {
                    Error dberror = new Error();
                    dberror.DateTime = DateTime.Now;
                    dberror.Errorid = e.HResult;
                    dberror.Message = e.Message;
                    dberror.Type = "Database query error";
                    db.Errors.Add(dberror);
                    db.SaveChanges();
                    json = new JavaScriptSerializer().Serialize("false");
                }
                return json;
            }
        }

        public string Login(string username, string password, string remember, string ip)
        {
            Account account = new Account();
            if (!account.Login(username, password, remember, ip))
                return new JavaScriptSerializer().Serialize("false");

            return new JavaScriptSerializer().Serialize("true");
        }

        public string Register(string username, string password, string dob, string email, string ip)
        {
            Account account = new Account();
            if (!account.Register(username, password, dob, email))
                return new JavaScriptSerializer().Serialize("false");

            return new JavaScriptSerializer().Serialize("true");
        }
    }
}
