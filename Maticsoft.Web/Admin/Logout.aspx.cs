using System;
using System.Web.Security;

namespace Maticsoft.Web.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        private string defaullogin = Maticsoft.Common.ConfigHelper.GetConfigString("defaulloginadmin");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                Maticsoft.Accounts.Bus.User currentUser = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                LogHelp.AddUserLog(currentUser.UserName, currentUser.UserType, "退出系统", this);
            }
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            Response.Redirect(defaullogin);
            //Response.Write("<script defer>window.location='" + defaullogin + "';</script>");
            Response.End();
        }
    }
}