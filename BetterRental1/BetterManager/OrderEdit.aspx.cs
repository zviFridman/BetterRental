using BLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetterRental1.BetterManager
{
    public partial class OrderEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // שליפת קוד ההזמנה שנשלח לדף
            // שמירת הקוד בתוך שדה נסתר, או את הערך מינוס אחת במידה ולא נשלח דבר
            // נטען את העמוד ונמלא פרטים במידת הצורך
            // במידה וקיבלנו קוד הזמנה, אז נציג את פרטי ההזמנה בשדות המתאימים
            if (!IsPostBack)
            {
                string OrderId = Request["oid"] + "";
                if (OrderId == "")
                {
                    OrderId = "-1";
                }
                HiddenOrderId.Value = OrderId;
                FillData(OrderId);
            }
        }

        public void FillData(string OrderId) // פונקציה המציגה את פרטי ההזמנה במידה ואנחנו בעריכה
        {
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BetterRentalDb.mdf;Integrated Security=True;Connect Timeout=30";
            string Sql = $"SELECT * FROM T_orders WHERE Oid={OrderId}";
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Connstr;
            Conn.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = Sql;
            SqlDataReader Dr = Cmd.ExecuteReader();

            if (Dr.Read()) // ההזמנה נמצאת, נציג את פרטיה על מנת לערוך אותם
            {
                txtOrderDate.Text = Convert.ToDateTime(Dr["Odate"]).ToString("yyyy-MM-dd");
                txtCustomerCode.Text = Dr["CAid"].ToString();
                txtCollectionDate.Text = Convert.ToDateTime(Dr["CollectionDate"]).ToString("yyyy-MM-dd");
                txtReturnDate.Text = Convert.ToDateTime(Dr["ReturnDate"]).ToString("yyyy-MM-dd");
                ddlStatusReady.SelectedValue = Convert.ToBoolean(Dr["StatusRedy"]) ? "1" : "0";
                ddlStatusOrder.SelectedValue = Convert.ToBoolean(Dr["StatusOrder"]) ? "1" : "0";
                ddlStatusPay.SelectedValue = Convert.ToBoolean(Dr["StatusPay"]) ? "1" : "0";
                txtCollection.SelectedValue = Convert.ToBoolean(Dr["Collection"]) ? "1" : "0"; // איסוף או חלוקה
                txtPlaceToSend.Text = Dr["PlaceToSend"].ToString();
                txtSumOrder.Text = Dr["SumOrder"].ToString();
                txtRemarks.Text = Dr["Remarks"].ToString();
            }
            else
            {
                HiddenOrderId.Value = "-1"; // עובר למצב הוספת הזמנה חדשה
            }

            Conn.Close();
        }

        protected void SaveOrder(object sender, EventArgs e) // פונקציה המבצעת עריכה או הוספה
        {
            bool collection = txtCollection.SelectedValue == "1";
            bool statusReady = ddlStatusReady.SelectedValue == "1";  // אם הסטטוס "מוכן"
            bool statusOrder = ddlStatusOrder.SelectedValue == "1";  // אם הסטטוס "פעיל"
            bool statusPay = ddlStatusPay.SelectedValue == "1";      // אם הסטטוס "שולם"

            // נבצע בדיקת תקינות לנתונים
            // ניצור אובייקט חדש מסוג הזמנה, ונמלא אותו בפרטים שבדף
            // ניצור למחלקת ההזמנה שיטה לשמירת פרטי הזמנה ונפעיל אותה

            Orders Tmp = new Orders()
            {
                Oid = int.Parse(HiddenOrderId.Value),
                Odate = DateTime.Parse(txtOrderDate.Text),
                CAid = int.Parse(txtCustomerCode.Text),
                CollectionDate = DateTime.Parse(txtCollectionDate.Text),
                ReturnDate = DateTime.Parse(txtReturnDate.Text),
                StatusRedy = statusReady,
                StatusOrder = statusOrder,
                StatusPay = statusPay,
                Collection = collection,
                PlaceToSend = txtPlaceToSend.Text,
                AddDate = new DateTime(2023, 11, 24, 10, 30, 0),
                Remarks = txtRemarks.Text,
                CompanyCode = 15,
                SumOrder = int.Parse(txtSumOrder.Text)

            };

            Tmp.Save(); // שמירת ההזמנה בעזרת מתודעת השמירה שהגדרת במחלקת ההזמנות

            // הצגת הודעת הצלחה ב-Label
            lblMessage.Text = "הפרטים נשמרו בהצלחה!";
            lblMessage.ForeColor = System.Drawing.Color.Blue; // אפשר לשנות צבע במקרה של הודעת הצלחה
            lblMessage.Visible = true;

            // המתנה של 2 שניות ואז הפנייה חזרה לדף הרשימה
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "setTimeout(function() { window.location = 'OrderList.aspx'; }, 2000);", true);
        }
    }
}
