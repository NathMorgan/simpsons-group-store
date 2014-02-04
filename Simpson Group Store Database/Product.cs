using Simpson_Group_Store_Database.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simpson_Group_Store_Database
{
    public class Product
    {
        bool AddProduct(string name, string description, string price)
        {
            return true;
        }

        bool RemoveProduct(int prodid)
        {
            using (var db = new SimpsonGroupEntities())
            {
                return true;
            }
            return true;
        }

        Simpson_Group_Store_Database.DataBase.Product GetProduct(int prodid)
        {
            using (var db = new SimpsonGroupEntities())
            {
                Simpson_Group_Store_Database.DataBase.Product product = (from p in db.Products
                                                                         where p.Productid == prodid
                                                                         select p).First();
                return product;
            }
        }

        List<Simpson_Group_Store_Database.DataBase.Product> GetProducts()
        {
            using (var db = new SimpsonGroupEntities())
            {
                List<Simpson_Group_Store_Database.DataBase.Product> products = (from p in db.Products
                                                                                select p).ToList();
                return products;
            }
        }
    }
}