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



        protected void SaveProduct(object sender, EventArgs e)
        {

            // נבצע בדיקת תקינות לנתונים
            // ניצור אובייקט חדש מסוג מוצר, ונמלא אותו בפרטים שבדף
            // ניצור למחלקת המוצר שיטה לשמירת פרטי המוצר ונפעיל אותה

            Product Tmp = new Product()
            {




                Pname = txtPname.Text,
                Pid =1000 /*int.Parse(HFPid.Value)*/,
                Pdesc = textPdesc.Text,
                Pprice = int.Parse(textPprice.Text),
                Picname="ששש",
                Cid = int.Parse(textCid.Text),
                Pinventory = int.Parse(textPinventory.Text),
                Remarks = textRemarks.Text,
                AddDate = new DateTime(2023, 11, 24, 10, 30, 0),
                Status = true /*bool.Parse(textStatus.Text)*/,
                CompanyCode=15
            };
            Tmp.Save();
            BindProducts(); // רענון הרשימה לאחר העריכה
            //Response.Redirect("ProductList.aspx");

        }



    }
   
    


}