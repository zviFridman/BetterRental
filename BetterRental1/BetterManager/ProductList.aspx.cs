using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.SqlServer.Server;

namespace BetterRental1.BetterManager
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            List<Product> LstProducts = Product.GetAll();
            RptProds.DataSource = LstProducts;
            RptProds.DataBind();
        }

        public void Delete(int ProdId)
        {
            Product.DeleteById(ProdId);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int ProdId = Convert.ToInt32(btn.CommandArgument);
            Delete(ProdId);
            BindProducts(); // רענון הרשימה לאחר המחיקה
        }



       
    }
    //public static void SaveProduct()
    //{

    //}


}