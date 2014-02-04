using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Simpson_Group_Store_Database
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        string GetProducts();

        [OperationContract]
        string GetProduct(int id);

        [OperationContract]
        string Login(string username, string password);

        [OperationContract]
        string Register(string username, string password, string email);

        // TODO: Add your service operations here
    }
}
