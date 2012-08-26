using System;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserAccount : PageBaseUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hfUid.Value = CurrentUser.UserID.ToString();
            }
        }
    }
}