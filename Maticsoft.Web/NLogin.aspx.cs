using System;
using System.Text;
using System.Web;
using System.Web.Security;
using Maticsoft.Accounts.Bus;

namespace Maticsoft.Web
{
    public partial class NLogin : PageBase
    {
        private Maticsoft.BLL.Tao.OrderItemHistory OrderItemHistoryBLL = new BLL.Tao.OrderItemHistory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                GoPage();
            }
            else
            {
                if (Request.Cookies["TaoUser"] != null && Request.Cookies["TaoPwd"] != null)
                {
                    string UserName = Request.Cookies["TaoUser"].Value;
                    string Pwd = Request.Cookies["TaoPwd"].Value;
                    if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Pwd))
                    {
                        return;
                    }
                    string DecPwd = Common.DEncrypt.DESEncrypt.Decrypt(Common.DEncrypt.DESEncrypt.Decrypt(Pwd.Remove(0, 2)).Remove(0, 2));
                    AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(UserName, DecPwd);
                    if (newUser != null)
                    {
                        CurrentUser = new Maticsoft.Accounts.Bus.User(newUser);
                        Session["UserInfo"] = CurrentUser;
                        //查询用户购买的所有的章节ID，存储在Session里面
                        Session["ModuleIDList"] = OrderItemHistoryBLL.GetIDList(CurrentUser.UserID);
                        FormsAuthentication.SetAuthCookie(CurrentUser.UserName, false);
                        GoPage();
                    }
                }
            }
        }

        protected string Encrypt(string pwd)
        {
            return Encrypt(pwd, "");
        }

        protected string Encrypt(string pwd, string key)
        {
            string s = "";
            if (key == null || key.Length == 0)
            {
                Random r = new Random();
                StringBuilder sult = new StringBuilder();
                for (int i = 0; i < 2; i++)
                {
                    sult.Append(((char)r.Next(65, 91)));
                }
                s = sult.ToString();
            }
            else
            {
                s = key;
            }
            string result = s + Common.DEncrypt.DESEncrypt.Encrypt((s + Common.DEncrypt.DESEncrypt.Encrypt(pwd)));
            return result;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = this.txtName.Value;
            string UserPwd = this.txtPwd.Value;
            byte[] encPassword = AccountsPrincipal.EncryptPassword(UserPwd);
            AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(UserName, UserPwd);
            if (newUser != null)
            {
                CurrentUser = new Maticsoft.Accounts.Bus.User(newUser);
                Context.User = newUser;

                if (!CurrentUser.Activity)
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "对不起，该帐号已被冻结，请联系管理员！");
                    return;
                }
                if (CurrentUser.UserType != "UU")
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "管理员不能从此处进入！");
                    return;
                }

                FormsAuthentication.SetAuthCookie(UserName, false);
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "登录成功", this);
                Session["UserInfo"] = CurrentUser;
                //查询用户购买的所有的章节ID，存储在Session里面。
                Session["ModuleIDList"] = OrderItemHistoryBLL.GetIDList(CurrentUser.UserID);

                HttpCookie cuser = new HttpCookie("TaoUser");
                cuser.Value = UserName;
                cuser.Expires = DateTime.Now.AddYears(10);
                Response.Cookies.Add(cuser);
                if (chkAutoLogin.Checked)
                {
                    HttpCookie cpwd = new HttpCookie("TaoPwd");
                    cpwd.Value = Encrypt(UserPwd);
                    cpwd.Expires = DateTime.Now.AddYears(10);
                    Response.Cookies.Add(cpwd);
                }
                GoPage();
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "用户名或密码错误！");
                LogHelp.AddUserLog(UserName, "", "登录失败!", this);
            }
        }
    }
}