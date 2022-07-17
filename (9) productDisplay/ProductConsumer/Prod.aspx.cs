using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProductConsumer
{
    public partial class Prod : System.Web.UI.Page
    {
        ServiceReference1.ProductSoapClient p1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndata_Click(object sender, EventArgs e)
        {
            p1 = new ServiceReference1.ProductSoapClient();
            DataSet data = p1.GetProducts();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
               
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            p1 = new ServiceReference1.ProductSoapClient();
            DataSet data = p1.GetProductByName(txtsearch.Text);
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}