using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Accounts.Bus;
using System.Drawing;
namespace Maticsoft.Web.Admin.Accounts
{
    public partial class UserPass : PageBaseAdmin
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
                }
            }
        }


        public void btnSave_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                SiteIdentity SID = new SiteIdentity(User.Identity.Name);
                if (SID.TestPassword(txtOldPassword.Text) == 0)
                {
                    this.lblMsg.ForeColor = Color.Red;
                    this.lblMsg.Text = "原密码输入错误！";
                }
                else
                    if (this.txtPassword.Text.Trim() != this.txtPassword1.Text.Trim())
                    {
                        this.lblMsg.ForeColor = Color.Red;
                        this.lblMsg.Text = "密码输入的不一致！请重试！";
                    }
                    else
                    {
                        AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                        User currentUser = new Maticsoft.Accounts.Bus.User(user);

                        currentUser.Password = AccountsPrincipal.EncryptPassword(txtPassword.Text);

                        if (!currentUser.Update())
                        {
                            this.lblMsg.ForeColor = Color.Red;
                            this.lblMsg.Text = Resources.Site.TooltipUpdateError;
                            //日志
                            //UserLog.AddLog(currentUser.UserName, currentUser.UserType, Request.UserHostAddress, Request.Url.AbsoluteUri, "用户密码更新失败");
                        }
                        else
                        {
                            this.lblMsg.ForeColor = Color.Blue;
                            this.lblMsg.Text = Resources.Site.TooltipSaveOK;
                            //日志
                            //UserLog.AddLog(currentUser.UserName, currentUser.UserType, Request.UserHostAddress, Request.Url.AbsoluteUri, "用户密码更新成功");
                        }

                    }
            }
        }
    }
}
