using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Security;
using Maticsoft.Accounts.Bus;
using System.IO;
using System.Globalization;
using Maticsoft.Common;
using System.Text;

using System.Data;

namespace Maticsoft.Web
{
    /// <summary>
    /// 页面层(表示层)基类,所有前台页面继承，无权限验证
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        protected string defaullogin = Maticsoft.Common.ConfigHelper.GetConfigString("defaullogin");
        protected static Hashtable ActHashtab;
        public string ToolTipDelete = Resources.Site.TooltipDelConfirm;
        protected string uploadFolders = "~/" + Maticsoft.Common.ConfigHelper.GetConfigString("UploadFolder") + "/";
        BLL.Tao.Categories categoriesBLL = new BLL.Tao.Categories();

        #region 用户信息

        protected AccountsPrincipal userPrincipal;
        private Maticsoft.Accounts.Bus.User currentUser;

        /// <summary>
        ///  权限角色验证对象
        /// </summary>
        public AccountsPrincipal UserPrincipal
        {
            get
            {
                return userPrincipal;
            }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Maticsoft.Accounts.Bus.User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set { this.currentUser = value; }
        }
        #endregion

        #region 初始化
        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            this.Error += new System.EventHandler(PageBase_Error);

            Actions bllAction = new Actions();
            ActHashtab = bllAction.GetHashListByCache();

        }
        private void InitializeComponent()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                userPrincipal = new AccountsPrincipal(Context.User.Identity.Name);
                if (Session["UserInfo"] == null)
                {
                    currentUser = new Maticsoft.Accounts.Bus.User(userPrincipal);
                    Session["UserInfo"] = currentUser;
                    Session["Style"] = currentUser.Style;
                }
                else
                {
                    currentUser = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                    Session["Style"] = currentUser.Style;
                }
            }
        }

        #endregion

        #region 错误处理
        //错误处理
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg = "";
            Model.SysManage.ErrorLog model = new Model.SysManage.ErrorLog();
            Exception currentError = Server.GetLastError();
            if (currentError is System.Data.SqlClient.SqlException)
            {
                System.Data.SqlClient.SqlException sqlerr = (System.Data.SqlClient.SqlException)currentError;
                if (sqlerr != null)
                {
                    string sqlMsg = GetSqlExceptionMessage(sqlerr.Number);
                    if (sqlerr.Number == 547)
                    {
                        errMsg += "<h1 >" + Resources.Site.ErrorSystemTip + "</h1><br/> " + sqlMsg;
                    }
                    else
                    {
                        errMsg += "<h1 >" + Resources.Site.ErrorSystemTip + "</h1><hr/> " +
                        "该信息已被系统记录，请稍后重试或与管理员联系。<br/>" +
                        "错误信息： " + sqlMsg;
                        model.Loginfo = sqlMsg;
                        model.StackTrace = currentError.ToString();
                        model.Url = Request.Url.AbsoluteUri;
                    }
                }
            }
            else
            {
                errMsg += "<h1 >" + Resources.Site.ErrorSystemTip + "</h1><hr/> " +
                    "该信息已被系统记录，请稍后重试或与管理员联系。<br/>" +
                    "错误信息： " + currentError.Message.ToString() + "<hr/>" +
                    "<b>Stack Trace:</b><br/>" + currentError.ToString();

                model.Loginfo = currentError.Message;
                model.StackTrace = currentError.ToString();
                model.Url = Request.Url.AbsoluteUri;

            }
            Maticsoft.BLL.SysManage.ErrorLog.Add(model);


            Session["CurrentError"] = errMsg;
            Server.Transfer("~/ErrorPage.aspx", true);


            //考虑不Response当前页面，直接弹出信息提示。根据不同信息做不同的样式处理：系统提示，系统错误
            //Response.Write(errMsg);
            //Server.ClearError();

        }


        private string GetSqlExceptionMessage(int number)
        {
            //set default value which is the generic exception message
            string error = Resources.Site.ErrorMessageSQL;
            switch (number)
            {
                case 17:
                    // 	SQL Server does not exist or access denied.
                    error = Resources.Site.ErrorMessageSQL17;
                    break;
                case 547:
                    // ForeignKey Violation
                    error = Resources.Site.ErrorMessageSQL547;
                    break;
                case 4060:
                    // Invalid Database
                    error = Resources.Site.ErrorMessageSQL4060;
                    break;
                case 18456:
                    // Login Failed
                    error = Resources.Site.ErrorMessageSQL18456;
                    break;
                case 1205:
                    // DeadLock Victim     
                    error = Resources.Site.ErrorMessageSQL1205;
                    break;
                case 2627:
                    error = Resources.Site.ErrorMessageSQL2627;
                    break;
                case 2601:
                    // Unique Index/Constriant Violation
                    error = Resources.Site.ErrorMessageSQL2601;
                    break;
                default:
                    // throw a general DAL Exception
                    error = Resources.Site.ErrorMessageSQL;
                    break;
            }

            return error;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 根据功能行为编号得到所属权限编号
        /// </summary>
        /// <returns></returns>
        public int GetPermidByActID(int ActionID)
        {
            object obj = ActHashtab[ActionID.ToString()];
            if (obj != null && obj.ToString().Length > 0)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 转换Bool类型的文本多语言描述
        /// </summary>
        /// <param name="bValid"></param>
        /// <returns></returns>
        public string GetboolText(object boolValue)
        {
            StringBuilder str = new StringBuilder();
            if (null != boolValue)
            {
                str.Append(boolValue.ToString().Trim().ToLower() == "true" ? "<span style=\"color: #006600;\">" + Resources.Site.lblTrue + "</span>" : "<span style=\"color: #800000;\">" + Resources.Site.lblFalse + "</span>");
            }
            return str.ToString();
        }

        protected void GoPage()
        {
            if (!string.IsNullOrEmpty(Request.Params["return"]))
            {
                //说明用户是被另一个页面导过来的,登录成功,我们把用户再导回去.
                Response.Redirect(Request.Params["return"]);
            }
            else
            {
                if (currentUser != null)
                {
                    switch (currentUser.UserType)//UU用户，EE商户，AG代理商，AA管理员
                    {
                        case "AA":
                            Response.Redirect("/Admin/Main.htm");
                            break;
                        case "UU":
                            Response.Redirect("/MyAccount/UserCenter.aspx");
                            break;
                        //case "EE":
                        //    Response.Redirect("/Enterprise/index.aspx");
                        //    break;
                        //case "AG":
                        //    Response.Redirect("/Agent/index.aspx");
                        //    break;
                        default:
                            break;
                    }
                }

            }
        }



        #endregion

        #region 字段数据转换

        /// <summary>
        /// 百分率转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string TranslateToPercent(string str)
        {
            decimal weight = Convert.ToDecimal(str);
            return weight.ToString("#0.##%", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 审批状态
        /// </summary>
        /// <param name="Value">审核人</param>
        /// <returns></returns>
        public string GetApprovedText(object Value)
        {
            bool isApproved = false;
            if (Value != null && Value.ToString().Length > 0)
            {
                if (Convert.ToInt32(Value) > 0)
                {
                    isApproved = true;
                }
            }
            return isApproved ? "<span style=\"color: #006600;\">" + Resources.Site.lblTrue + "</span>" : "<span style=\"color: #800000;\">" + Resources.Site.lblFalse + "</span>";
        }

        #endregion

        #region NewMethod

        #region 获取用户名
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetUserName(object intValue)
        {
            string username = "";
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    User currentUser = new Maticsoft.Accounts.Bus.User(Convert.ToInt32(intValue));
                    if (null != currentUser)
                    {
                        username = currentUser.TrueName;
                    }
                }
            }
            return username;
        }
        #endregion

        #region 时长转换：秒转换成时分秒。
        public string ConvertTime(object time)
        {
            if (time != null)
            {
                string strTime = time.ToString();
                if (!string.IsNullOrEmpty(strTime) && PageValidate.IsNumber(strTime))
                {
                    int timedur = int.Parse(strTime);
                    return BLL.ConvertTime.SecondToDateTime(timedur);
                }
                else
                {
                    return "未知";
                }
            }
            else
            {
                return "未知";
            }
        }
        #endregion

        #region Url编码
        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="obj"></param>
        public string UrlEncode(object obj)
        {
            StringBuilder str = new StringBuilder();
            if (null != obj)
            {
                str.Append(Server.UrlEncode(obj.ToString()));
            }
            return str.ToString();
        }
        #endregion

        #region 绑定站点导航
        public string BindSiteNav(int CategoryId)
        {
            StringBuilder str = new StringBuilder();
            Maticsoft.Model.Tao.Categories model = categoriesBLL.GetModelByCache(CategoryId);
            if (null != model)
            {
                string[] strPath = model.Path.Split('|');
                foreach (string s in strPath)
                {
                    if (PageValidate.IsNumber(s))
                    {
                        Maticsoft.Model.Tao.Categories categoriesModel = categoriesBLL.GetModelByCache(int.Parse(s));
                        if (null != categoriesModel)
                        {
                            str.Append("&nbsp;&gt;&gt;&nbsp;<a href=\"/courselist.aspx?CategoryId=" + s + "\">" + categoriesModel.Name + "</a>");
                        }
                    }
                }
            }
            return str.ToString();       
        }
        #endregion

        #region 将字符串转换为Html编码的字符串
        /// <summary>
        /// 将字符串转换为Html编码的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string strHtmlEncode(object obj)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            if (null != obj)
            {
                str.Append(HttpUtility.HtmlEncode(obj.ToString()));
            }
            return str.ToString();
        }
        #endregion
        #endregion
    }
}