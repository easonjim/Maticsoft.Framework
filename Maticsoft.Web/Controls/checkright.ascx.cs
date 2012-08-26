using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Maticsoft.Accounts.Bus;
using Maticsoft.Common;
namespace Maticsoft.Web.Controls
{
    public partial class checkright : System.Web.UI.UserControl
    {
        public int PermissionID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 
        override protected void OnInit(EventArgs e)
        {
            //InitializeComponent();
            base.OnInit(e);
        }        
        private void InitializeComponent()
        {
            if (!Page.IsPostBack)
            {               
                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    if (Session["UserInfo"] == null)
                    {
                        Maticsoft.Accounts.Bus.User currentUser = new Maticsoft.Accounts.Bus.User(user);
                        Session["UserInfo"] = currentUser;
                        Session["Style"] = currentUser.Style;
                        Response.Write("<script defer>location.reload();</script>");
                    }
                    if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                    {
                        Response.Clear();
                        Response.Write("<script defer>window.alert('You do not have permission to access this page！\\n Please login again or contact your administrator');history.back();</script>");
                        Response.End();
                    }
                }
                else
                {
                    string defaullogin = Maticsoft.Common.ConfigHelper.GetConfigString("defaulloginadmin");
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                    Response.Clear();
                    Response.Write("<script defer>window.alert('You do not have permission to access this page or session expired！\\n Please login again or contact your administrator！');parent.location='" + defaullogin + "';</script>");
                    Response.End();
                }

            }
        }
        #endregion
    }
}