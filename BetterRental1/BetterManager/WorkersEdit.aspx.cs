using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetterRental1.BetterManager
{
    public partial class WorkersEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string workerId = Request["wid"] ?? "-1";
                HiddenWorkerId.Value = workerId;
                if (workerId != "-1")
                {
                    FillWorkerDetails(int.Parse(workerId));
                }
            }
        }

        private void FillWorkerDetails(int workerId)
        {
            Workers worker = Workers.GetById(workerId); // שליפת עובד לפי מזהה
            if (worker != null)
            {
                txtFirstName.Text = worker.Wfname;
                txtLastName.Text = worker.Wlname;
                txtEmail.Text = worker.Wemail;
                txtPhone.Text = worker.Wphone;
                txtAddress.Text = worker.Wadress;
                txtSalaryHour.Text = worker.SaleryHour.ToString();
                txtSalaryMonth.Text = worker.SaleryMonth.ToString();
                txtJob.Text = worker.Wjob;
                ddlStatus.SelectedValue = worker.Status.ToString().ToLower();
                txtAddDate.Text = worker.AddDate.ToString("yyyy-MM-dd");
                txtRemarks.Text = worker.Remarks;
                txtCompanyCode.Text = worker.CompanyCode.ToString();
            }
        }

        protected void SaveWorker(object sender, EventArgs e)
        {
            Workers worker = new Workers
            {
                Wid = int.Parse(HiddenWorkerId.Value),
                Wfname = txtFirstName.Text,
                Wlname = txtLastName.Text,
                Wemail = txtEmail.Text,
                Wphone = txtPhone.Text,
                Wadress = txtAddress.Text,
                SaleryHour = float.Parse(txtSalaryHour.Text),
                SaleryMonth = float.Parse(txtSalaryMonth.Text),
                Wjob = txtJob.Text,
                Status = bool.Parse(ddlStatus.SelectedValue),
                AddDate = DateTime.Parse(txtAddDate.Text),
                Remarks = txtRemarks.Text,
                CompanyCode = int.Parse(txtCompanyCode.Text)
            };

            worker.Save(); // שמירת עובד (הוספה או עדכון)
            Response.Redirect("WorkerList.aspx");
        }
    }
}