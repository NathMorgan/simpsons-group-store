//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Simpson_Group_Store_Database.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Orderid { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
