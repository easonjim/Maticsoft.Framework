using System;

namespace Maticsoft.Web.PubCourse
{
    public partial class CourseComment : PageBaseUser
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