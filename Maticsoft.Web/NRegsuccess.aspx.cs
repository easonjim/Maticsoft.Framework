using System;

namespace Maticsoft.Web
{
    public partial class NRegsuccess : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Regsuccess"] != null)
            {
                if (Session["UserInfo"] != null)
                {
                    Maticsoft.Accounts.Bus.User user = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                    this.lblUname.Text = user.UserName;
                    Session["Regsuccess"] = null;
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            Response.Redirect("/LearnCourse/PerAccount.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
        }

        protected void btnTeach_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PublishCourse/NewPubCourse.aspx");
        }
    }
}