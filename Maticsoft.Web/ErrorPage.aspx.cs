using System;
using System.Web.UI;

namespace Maticsoft.Web
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CurrentError"] == null)
                {
                    return;
                }

                lblMsg.Text = "该信息已被系统记录，请稍后重试或与管理员联系。";
                try
                {
                    lblMsg.Text = Session["CurrentError"].ToString();
                }
                catch (System.Exception exx)
                {
                    lblMsg.Text = exx.Message + "<br><br>该信息已被系统记录，请稍后重试或与管理员联系。";
                }
                Session["CurrentError"] = null;
                Server.ClearError();
            }
        }
    }
}