using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    clsLoginBAL objLoginBAL = new clsLoginBAL();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblWelcome.Style.Add("display", "");
            pnlLogin.Style.Add("display", "none");
            hpNewUser.Style.Add("display", "none");
            
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        objLoginBAL.UserId = txtUserId.Text;
        objLoginBAL.Password = txtPassword.Text;
        string userId = txtUserId.Text;
        if (userId[0].ToString() == "A")
        {
            objLoginBAL.Category = "Adminstrator";
            ds = objLoginBAL.Login();
            try
            {
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    Response.Write("<script> alert('Please Check Login details');</script>");
                    lblWelcome.Style.Add("display", "none");
                    lblLogin.Text = "Adminstrator Login";
                    pnlLogin.Style.Add("display", "");
                }
                else
                {
                    Session["Name"] = ds.Tables[0].Rows[0]["Category"].ToString();
                    Session["UserId"] = ds.Tables[0].Rows[0]["UserId"].ToString();
                    Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                    Response.Redirect("~/code/Adminstrator/AdminHome.aspx");
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                objLoginBAL = null;
            }
        }
        else if (userId[0].ToString() == "G")
        {
            objLoginBAL.Category = "User";
            ds = objLoginBAL.Login();
            try
            {
                if (ds.Tables[0].Rows.Count <= 0)
                {
                   Response.Write( "<script> alert('Please Check Login details');</script>");
                    lblWelcome.Style.Add("display", "none");
                    lblLogin.Text = "User Login";
                    pnlLogin.Style.Add("display", "");
                    hpNewUser.Style.Add("display", "");
                }
                else
                {
                    Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();
                    Session["UserId"] = ds.Tables[0].Rows[0]["UserId"].ToString();
                    Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                    Response.Redirect("~/code/User/UserWelcome.aspx");
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                objLoginBAL = null;
            }

        }

    }
    
}
