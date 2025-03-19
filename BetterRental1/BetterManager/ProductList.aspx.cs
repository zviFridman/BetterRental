using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.SqlServer.Server;
using static System.Net.Mime.MediaTypeNames;

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

        private void BindProducts()//הצגת רשימת המוצרים
        {
            List<Product> LstProducts = Product.GetAll();
            RptProds.DataSource = LstProducts;
            RptProds.DataBind();
        }

        public void Delete(int ProdId)//מחיקת מוצר
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




}