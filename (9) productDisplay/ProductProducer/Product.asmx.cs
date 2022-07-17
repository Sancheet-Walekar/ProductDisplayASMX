using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProductProducer
{
    /// <summary>
    /// Summary description for Product
    /// </summary>
    [WebService(Namespace = "http://met.edu/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Product : System.Web.Services.WebService
    {
        //Disconnected Approach
        SqlConnection myConn;
        SqlCommand myCmd;
        SqlDataAdapter myAdpt;
        DataSet myDs;

        [WebMethod]
        public DataSet GetProducts()
        {
            myConn = new SqlConnection();
            myConn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            myCmd = new SqlCommand("Select * from dbo.Products", myConn);
            myAdpt = new SqlDataAdapter(myCmd);
            myDs = new DataSet();
            myAdpt.Fill(myDs);
            return myDs;
        }
        [WebMethod]
        public DataSet GetProductByName(String name)
        {
            myConn = new SqlConnection();
            myConn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            myCmd = new SqlCommand("Select * from dbo.Products where pname =@pn", myConn);
            myCmd.Parameters.AddWithValue("@pn", name);
            myAdpt = new SqlDataAdapter(myCmd);
            myDs = new DataSet();
            myAdpt.Fill(myDs);
            return myDs;
        }
    }
}
