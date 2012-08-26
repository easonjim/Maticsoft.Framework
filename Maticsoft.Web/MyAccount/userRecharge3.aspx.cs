using System;

namespace Maticsoft.Web.MyAccount
{
    public partial class userRecharge3 : PageBaseUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["total_fee"]))
                {
                    Response.Redirect("~/ErrorPage.aspx");
                }
            }
        }
    }
}