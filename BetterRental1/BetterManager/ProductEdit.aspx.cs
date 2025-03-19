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

    public partial class ProductEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            // שליפת קוד המוצר שנשלח לדף
            // שמירת הקוד בתוך שדה נסתר, או את הערך מינוס אחת במידה ולא נשלח דבר
            // נטען את העמוד ונמלא פרטים במידת הצורך
            // במידה וקיבלנו קוד מוצר, אז נציג את פרטי המוצר בשדות המתאימים
            if (!IsPostBack)
            {
                string Pid = Request["pid"] + "";
                if (Pid == "")
                {
                    Pid = "-1";
                }
                HiddenPid.Value = Pid;
                Filldata(Pid);
            }

          

        }
        public void Filldata(string Pid)//פונקציה המציגה את פרטי המוצרבמידה ואנחנו בעריכה
        {
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BetterRentalDb.mdf;Integrated Security=True;Connect Timeout=30";
            //                                 // הרשאות גישה - Authorization
            string Sql = $"Select * From T_product where Pid={Pid}";
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Connstr;
            Conn.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = Sql;
            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())// המוצר נמצא, נציג את פרטיו על מנת לערוך אותם
            {
                txtPname.Text = Dr["Pname"].ToString();
                int v = int.Parse(Dr["Pprice"].ToString());
                textPprice.Text = v.ToString();
                textPdesc.Text = Dr["Pdesc"].ToString();
                textPinventory.Text= Dr["Pinventory"].ToString();
                textCid.Text = Dr["Cid"].ToString();
                textPdesc.Text = Dr["Pdesc"].ToString();
                textRemarks.Text =Dr["Remarks"].ToString();

                // הגדרת סטטוס המוצר
                bool isActive = Convert.ToBoolean(Dr["Status"]);
                textStatus.SelectedValue = isActive ? "1" : "0"; // הגדרת הערך הנבחר ב-DropDownList
            }
            else
            {
                HiddenPid.Value = "-1";// עוברי למצב הוספת מוצר חדש
            }

            Conn.Close();

        }

        protected void SaveProduct(object sender, EventArgs e)//פונקציה המבצעת עריכה או הוספה
        {

            string selectedStatus = textStatus.SelectedValue;//החלפת קלט סטטוס למשתנה בוליאני
            bool status;

            if (selectedStatus == "1")
            {
                status = true; // קוד עבור סטטוס "פעיל"
            }
            else
            {
                status = false; // קוד עבור סטטוס "לא פעיל"
            }
           


            // נבצע בדיקת תקינות לנתונים
            // ניצור אובייקט חדש מסוג מוצר, ונמלא אותו בפרטים שבדף
            // ניצור למחלקת המוצר שיטה לשמירת פרטי המוצר ונפעיל אותה

            Product Tmp = new Product()
            {




                Pname = txtPname.Text,
                Pid = int.Parse(HiddenPid.Value),
                Pdesc = textPdesc.Text,
                Pprice = int.Parse(textPprice.Text),
                Picname = "ששש",
                Cid = int.Parse(textCid.Text),
                Pinventory = int.Parse(textPinventory.Text),
                Remarks = textRemarks.Text,
                AddDate = new DateTime(2023, 11, 24, 10, 30, 0),
                Status = status,
                CompanyCode = 15
            };
            Tmp.Save();
            // הצגת הודעת הצלחה ב-Label
            lblMessage.Text = "הפרטים נשמרו בהצלחה!";
            lblMessage.ForeColor = System.Drawing.Color.Blue; // אפשר לשנות צבע במקרה של הודעת הצלחה
            lblMessage.Visible = true;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
       "setTimeout(function() { window.location = 'ProductList.aspx'; }, 2000);", true);
            //// רענון הרשימה לאחר העריכה
            //Response.Redirect("ProductList.aspx");

        }


    }
}