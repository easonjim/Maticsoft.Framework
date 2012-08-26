using System;
using Maticsoft.Accounts.Bus;

namespace Maticsoft.Web.MyAccount
{
    public partial class UpdatePwd : PageBaseUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //检测旧密码是否争取
            string uInput = this.txtOldpws.Value.Trim();
            AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(CurrentUser.UserName, uInput);
            if (newUser == null)
            {
                Common.MessageBox.ShowFailTip(this, "旧密码错误，请重新输入！");
                return;
            }
            string NewPwd = this.txtSurePwd.Value;
            AccountsPrincipal APUser = new AccountsPrincipal(Context.User.Identity.Name);
            User currentUser = new Maticsoft.Accounts.Bus.User(APUser);
            currentUser.Password = AccountsPrincipal.EncryptPassword(NewPwd);
            if (!currentUser.Update())
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "'系统忙，请稍后再试！");
                return;
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowSuccessTip(this, "密码修改成功！下次登录生效！");
            }
        }
    }
}