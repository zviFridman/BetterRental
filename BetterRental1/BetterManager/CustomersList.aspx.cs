using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetterRental1.BetterManager
{
    public partial class CustomersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomers();
            }
        }

        private void BindCustomers() // הצגת רשימת הלקוחות
        {
            List<Customers> LstCustomers = Customers.GetAll(); // הנחת עבודה ש-GetAll היא מתודה שמחזירה את רשימת כל הלקוחות
            RptCustomers.DataSource = LstCustomers;
            RptCustomers.DataBind();
        }

        public void DeleteCustomer(int CustomerID) // מחיקת לקוח
        {
            Customers.DeleteById(CustomerID); //  
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int CustomerID = Convert.ToInt32(btn.CommandArgument);
            DeleteCustomer(CustomerID);
            BindCustomers(); // רענון הרשימה לאחר המחיקה
        }
    }
}