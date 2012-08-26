using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
namespace Maticsoft.Web.Admin.Accounts.images
{
    public partial class t : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, System.EventArgs e)
        {
            string username = this.txtUserName.Text;
            string passward = this.txtPassword.Text;
            Maticsoft.Accounts.Bus.User currentUser = new Maticsoft.Accounts.Bus.User();
            if (!currentUser.SetPassword(username, passward))
            {
                this.lblMsg.ForeColor = Color.Red;
                this.lblMsg.Text = "更新用户信息发生错误！";
            }
            else
            {
                this.lblMsg.ForeColor = Color.Blue;
                this.lblMsg.Text = "用户信息更新成功！";
            }

        }

    }
}