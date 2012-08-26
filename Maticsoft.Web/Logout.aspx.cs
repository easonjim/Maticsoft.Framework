using System;
using System.Web;
using System.Web.Security;

namespace Maticsoft.Web
{
    public partial class logout : System.Web.UI.Page
    {
        private string defaullogin = Maticsoft.Common.ConfigHelper.GetConfigString("defaullogin");

        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpCookie cpwd = Request.Cookies["TaoPwd"];
            if (cpwd != null)
            {
                cpwd.Value = null;
                Response.Cookies.Add(cpwd);
            }
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            Response.Redirect(defaullogin);
            Response.End();
        }
    }
}