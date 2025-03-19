using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BetterRental1.BetterManager;

namespace BetterRental1.BetterManager
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrders();
            }
        }

        private void BindOrders() // הצגת רשימת ההזמנות
        {
            List<Orders> LstOrders = Orders.GetAll(); // הנחת עבודה ש-GetAll הוא מתודה שמחזירה את רשימת כל ההזמנות
            RptOrders.DataSource = LstOrders;
            RptOrders.DataBind();
        }

        public void DeleteOrder(int OrderID) // מחיקת הזמנה
        {
            Orders.DeleteById(OrderID); 
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int OrderID = Convert.ToInt32(btn.CommandArgument);
            DeleteOrder(OrderID);
            BindOrders(); // רענון הרשימה לאחר המחיקה
        }
    }
}