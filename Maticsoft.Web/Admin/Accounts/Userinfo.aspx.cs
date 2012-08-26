using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin.Accounts
{
    public partial class Userinfo : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    User currentUser = new Maticsoft.Accounts.Bus.User(user);                    
                    this.lblName.Text = currentUser.UserName;
                    this.lblTruename.Text = currentUser.TrueName;
                    //this.lblSex.Text = currentUser.Sex.Trim() == "1" ? Resources.Site.fieldSexM : Resources.Site.fieldSexF;
                    //this.lblPhone.Text = currentUser.Phone;
                    this.lblEmail.Text = currentUser.Email;
                    lblUserIP.Text = Request.UserHostAddress;
                    //switch(currentUser.Style)
                    //{
                    //    case 1:
                    //        this.lblStyle.Text = "DefaultBlue";
                    //        break;
                    //    case 2:
                    //        this.lblStyle.Text = "Olive";
                    //        break;
                    //    case 3:
                    //        this.lblStyle.Text = "Red";
                    //        break;
                    //    case 4:
                    //        this.lblStyle.Text = "Green";
                    //        break;
                    //}


                }
            }

        }
    }
}
