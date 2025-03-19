using BLL;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetterRental1.BetterManager
{
    public partial class WorkerList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindWorkers();
            }
        }

        private void BindWorkers() // הצגת רשימת העובדים
        {
            List<Workers> lstWorkers = Workers.GetAll(); // הנחת עבודה ש-GetAll היא מתודה שמחזירה את כל העובדים
            RptWorkers.DataSource = lstWorkers;
            RptWorkers.DataBind();
        }

        public void DeleteWorker(int workerId) // מחיקת עובד
        {
            Workers.DeleteById(workerId); // הנחת עבודה שקיימת מתודה סטטית למחיקת עובד
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int workerId = Convert.ToInt32(btn.CommandArgument);
            DeleteWorker(workerId);
            BindWorkers(); // רענון הרשימה לאחר מחיקה
        }
    }
}
