using BLL;
using System;
using System.Data.SqlClient;
using System.Web.UI;
namespace BetterRental1.BetterManager
{
    public partial class CustomerEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CustomerId = Request["cuid"] + "";
                if (CustomerId == "")
                {
                    CustomerId = "-1";
                }
                HiddenCustomerId.Value = CustomerId;
                FillData(CustomerId);
            }
        }

        public void FillData(string CustomerId)
        {
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BetterRentalDb.mdf;Integrated Security=True;Connect Timeout=30";
            string Sql = $"SELECT * FROM T_customers WHERE CUid={CustomerId}";
            using (SqlConnection Conn = new SqlConnection(Connstr))
            {
                Conn.Open();
                SqlCommand Cmd = new SqlCommand(Sql, Conn);
                SqlDataReader Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    txtCustomerCode.Text = Dr["CUid"].ToString();
                    txtFullName.Text = Dr["CUname"].ToString();
                    txtEmail.Text = Dr["CUemail"].ToString();
                    txtPhone.Text = Dr["CUphone"].ToString();
                    txtAddress.Text = Dr["CUadress"].ToString();
                    ddlCustomerType.SelectedValue = Convert.ToBoolean(Dr["CUtype"]) ? "true" : "false";
                    txtBalance.Text = Dr["Money"].ToString();
                    ddlStatus.SelectedValue = Convert.ToBoolean(Dr["Status"]) ? "true" : "false";
                    //txtAddDate.Text = Convert.ToDateTime(Dr["AddDate"]).ToString("yyyy-MM-dd");
                    txtRemarks.Text = Dr["Remarks"].ToString();
                    txtLtd.Text = Dr["Ltd"].ToString();
                    txtGid.Text = Dr["Gid"].ToString();
                    txtPayName.Text = Dr["Payname"].ToString();
                    txtPayPhone.Text = Dr["Payphone"].ToString();
                    txtOblogo.Text = Dr["Oblogo"].ToString();
                }
            }
        }

        protected void SaveCustomer(object sender, EventArgs e)
        {
            var customer = new Customers
            {
                CUname = txtFullName.Text.Trim(),
                CUadress = txtAddress.Text.Trim(),
                CUemail = txtEmail.Text.Trim(),
                CUphone = txtPhone.Text.Trim(),
                CUtype = ddlCustomerType.SelectedValue == "true",
                CUid = int.Parse(HiddenCustomerId.Value),
                Money = float.Parse(txtBalance.Text),
                Gid = int.Parse(txtGid.Text),
                Ltd = txtLtd.Text.Trim(),
                Payname = txtPayName.Text.Trim(),
                Oblogo = float.Parse(txtOblogo.Text),
                Payphone = txtPayPhone.Text.Trim(),
                Remarks = txtRemarks.Text.Trim(),
                AddDate = new DateTime(2023, 11, 24, 10, 30, 0),
                Status = ddlStatus.SelectedValue == "true",
                CompanyCode = 15,

            };

            customer.Save();

            lblMessage.Text = "הפרטים נשמרו בהצלחה!";
            lblMessage.Visible = true;

            ScriptManager.RegisterStartupScript(this, GetType(), "redirect",
                "setTimeout(function() { window.location = 'CustomersList.aspx'; }, 2000);", true);
        }
    }
}