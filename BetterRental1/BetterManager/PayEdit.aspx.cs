using BLL;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace BetterRental1.BetterManager
{
    public partial class PayEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string PayId = Request["pid"] + "";
                if (PayId == "")
                {
                    PayId = "-1";
                }
                HiddenPayId.Value = PayId;
                FillData(PayId);
            }
        }

        public void FillData(string PayId)
        {
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BetterRentalDb.mdf;Integrated Security=True;Connect Timeout=30";
            string Sql = $"SELECT * FROM T_pay WHERE Paid={PayId}";
            using (SqlConnection Conn = new SqlConnection(Connstr))
            {
                Conn.Open();
                SqlCommand Cmd = new SqlCommand(Sql, Conn);
                SqlDataReader Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    txtPayId.Text = Dr["Paid"].ToString();
                    txtPayDate.Text = Convert.ToDateTime(Dr["Padata"]).ToString("yyyy-MM-dd");
                    txtPaySum.Text = Dr["PaySum"].ToString();
                    txtPtid.Text = Dr["Ptid"].ToString();
                    txtCaid.Text = Dr["Caid"].ToString();
                    ddlStatus.SelectedValue = Convert.ToBoolean(Dr["Status"]) ? "true" : "false";
                    txtOid.Text = Dr["Oid"].ToString();
                    //txtAddDate.Text = Convert.ToDateTime(Dr["AddDate"]).ToString("yyyy-MM-dd");
                    txtRemarks.Text = Dr["Remarks"].ToString();
                    //txtCompanyCode.Text = Dr["CompanyCode"].ToString();
                }
            }
        }

        protected void SavePay(object sender, EventArgs e)
        {
            var pay = new Pay
            {
                Paid = int.Parse(HiddenPayId.Value),
                Padata = DateTime.Parse(txtPayDate.Text),
                PaySum = float.Parse(txtPaySum.Text),
                Ptid = int.Parse(txtPtid.Text),
                Caid = int.Parse(txtCaid.Text),
                Status = ddlStatus.SelectedValue == "true",
                Oid = int.Parse(txtOid.Text),
                AddDate = new DateTime(2023, 11, 24, 10, 30, 0),
                Remarks = txtRemarks.Text.Trim(),
                CompanyCode = 15
            };

            pay.Save();

            lblMessage.Text = "הפרטים נשמרו בהצלחה!";
            lblMessage.Visible = true;

            ScriptManager.RegisterStartupScript(this, GetType(), "redirect",
                "setTimeout(function() { window.location = 'PayList.aspx'; }, 2000);", true);
        }
    }
}
