using System;
using System.Web;
using System.Web.Security;
using Maticsoft.Accounts.Bus;

namespace Maticsoft.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Maticsoft.Common.ConfigHelper.GetConfigBool("LocalTest"))
            //{
            //    AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin("admin", "1");
            //    User currentUser = new Maticsoft.Accounts.Bus.User(newUser);
            //    Context.User = newUser;
            //    FormsAuthentication.SetAuthCookie(currentUser.UserName, false);
            //    Session["UserInfo"] = currentUser;
            //    Session["Style"] = currentUser.Style;
            //    Response.Redirect("main.htm");
            //}
        }

        public void btnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
            {
                int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                if (PassErroeCount > 3)
                {
                    txtUsername.Enabled = false;
                    txtPass.Enabled = false;
                    btnLogin.Enabled = false;
                    this.lblMsg.Text = "对不起，你已经登录错误三次，系统锁定，请联系管理员！";
                    return;
                }
            }
            if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString() != ""))
            {
                if (Session["CheckCode"].ToString().ToLower() != this.CheckCode.Value.ToLower())
                {
                    this.lblMsg.Text = "验证码错误!";
                    Session["CheckCode"] = null;
                    return;
                }
                else
                {
                    Session["CheckCode"] = null;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            #region

            string userName = Maticsoft.Common.PageValidate.InputText(txtUsername.Text.Trim(), 30);
            string Password = Maticsoft.Common.PageValidate.InputText(txtPass.Text.Trim(), 30);
            AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(userName, Password);
            if (newUser != null)
            {
                User currentUser = new Maticsoft.Accounts.Bus.User(newUser);
                if (currentUser.UserType != "AA")
                {
                    this.lblMsg.Text = "你非管理员用户，你没有权限登录后台系统！";
                    return;
                }
                Context.User = newUser;
                if (((SiteIdentity)User.Identity).TestPassword(Password) == 0)
                {
                    try
                    {
                        this.lblMsg.Text = "密码错误！";
                        LogHelp.AddUserLog(userName, "", lblMsg.Text, this);
                    }
                    catch
                    {
                        Response.Redirect("LoginUser.aspx");
                    }
                }
                else
                {
                    if (!currentUser.Activity)
                    {
                        Maticsoft.Common.MessageBox.Show(this, "对不起，该帐号已被冻结，请联系管理员！");
                        return;
                    }
                    SingleLogin slogin = new SingleLogin();

                    //if (slogin.IsLogin(currentUser.UserID))
                    //{
                    //    Maticsoft.Common.MessageBox.Show(this, "对不起，你的帐号已经登录！");
                    //    return;
                    //}
                    slogin.UserLogin(currentUser.UserID);

                    FormsAuthentication.SetAuthCookie(userName, false);
                    //log
                    LogHelp.AddUserLog(currentUser.UserName, currentUser.UserType, "登录成功", this);

                    Session["UserInfo"] = currentUser;
                    Session["Style"] = currentUser.Style;

                    string strLanguage = dropLanguage.SelectedValue;
                    Session["language"] = strLanguage;

                    HttpCookie mCookie = new HttpCookie("language");
                    mCookie.Value = strLanguage;
                    mCookie.Expires = DateTime.MaxValue;
                    Response.AppendCookie(mCookie);

                    if (Session["returnPage"] != null)
                    {
                        string returnpage = Session["returnPage"].ToString();
                        Session["returnPage"] = null;
                        Response.Redirect(returnpage);
                    }
                    else
                    {
                        Response.Redirect("main.htm");
                    }
                }
            }
            else
            {
                this.lblMsg.Text = "登录失败，请确认用户名或密码是否正确。";
                if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
                {
                    int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                    Session["PassErrorCountAdmin"] = PassErroeCount + 1;
                }
                else
                {
                    Session["PassErrorCountAdmin"] = 1;
                }
                //log
                LogHelp.AddUserLog(userName, "", "登录失败!", this);
            }

            #endregion
        }
    }
}