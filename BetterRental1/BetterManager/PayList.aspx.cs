using BLL;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetterRental1.BetterManager
{
    public partial class PayList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPayments();
            }
        }

        private void BindPayments() // הצגת רשימת התשלומים
        {
            List<Pay> lstPayments = Pay.GetAll(); // הנחת עבודה ש-GetAll היא מתודה שמחזירה את רשימת כל התשלומים
            RptPayments.DataSource = lstPayments;
            RptPayments.DataBind();
        }

        public void DeletePayment(int paymentId) // מחיקת תשלום
        {
            Pay.DeleteById(paymentId); // הנחת עבודה שיש מתודה סטטית למחיקה לפי מזהה
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int paymentId = Convert.ToInt32(btn.CommandArgument);
            DeletePayment(paymentId);
            BindPayments(); // רענון הרשימה לאחר המחיקה
        }
    }
}
