using System;
using System.Web.Security;
using Maticsoft.Accounts.Bus;

namespace Maticsoft.Web
{
    public partial class NRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.btnSubmit.Enabled = false;
            User useModel = new User();
            string UserName = this.txtUserName.Value;
            string Email = this.txtMail.Value;
            string pwd = this.txtConfirm.Value;
            useModel.UserName = UserName;
            useModel.TrueName = UserName;
            useModel.Password = AccountsPrincipal.EncryptPassword(pwd);
            useModel.Email = Email;
            useModel.Activity = true;
            useModel.UserType = "UU";
            useModel.User_dateCreate = DateTime.Now;
            int userid = useModel.Create();
            if (userid > 0)
            {
                useModel.UserID = userid;
                FormsAuthentication.SetAuthCookie(UserName, false);
                Session["UserInfo"] = useModel;
                Session["Regsuccess"] = true;
                //查询用户购买的所有的章节ID，存储在Session里面。
                BLL.Tao.OrderItemHistory OrderItemHistoryBLL = new BLL.Tao.OrderItemHistory();
                Session["ModuleIDList"] = OrderItemHistoryBLL.GetIDList(userid);
                Response.Redirect("NRegsuccess.aspx");
            }
            else
            {
                Common.MessageBox.ShowFailTip(this, "系统忙，请稍后再试");
                return;
            }
        }
    }
}