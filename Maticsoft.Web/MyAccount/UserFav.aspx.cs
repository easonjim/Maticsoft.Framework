using System;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserFav : PageBaseUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            this.FavoriteCourse1.UserId = CurrentUser.UserID;
            this.FavoriteCourse1.IsFav = true;
            this.FavoriteCourse1.DataBind();
        }
    }
}