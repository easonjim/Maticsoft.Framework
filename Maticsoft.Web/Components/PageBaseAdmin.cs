using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Security;
using Maticsoft.Accounts.Bus;
using System.IO;
using System.Globalization;

using System.Text;
using Maticsoft.Common;

namespace Maticsoft.Web
{
    /// <summary>
    /// 页面层(表示层)基类,所有Admin页面继承该页面
    /// </summary>
    public class PageBaseAdmin : System.Web.UI.Page
    {
        string defaullogin = Maticsoft.Common.ConfigHelper.GetConfigString("defaulloginadmin");
        string uploadFolders = "~/" + Maticsoft.Common.ConfigHelper.GetConfigString("UploadFolder") + "/";

        static Hashtable ActHashtab;

        public string ToolTipDelete = Resources.Site.TooltipDelConfirm;

        BLL.Tao.Modules ModuleBLL = new BLL.Tao.Modules();
        BLL.Tao.Courses CourseBLL = new BLL.Tao.Courses();
        BLL.Tao.Categories CategoriesBLL = new Maticsoft.BLL.Tao.Categories();
        BLL.Tao.ApproveType ApproveTypeBLL = new BLL.Tao.ApproveType();

        #region 权限控制

        //子类通过 new 重写该值
        protected int Act_DeleteList = 1; //批量删除按钮
        protected int Act_ShowInvalid = 2; //查看失效数据        
        protected int Act_CloseList = 3; //批量关闭按钮
        protected int Act_OpenList = 8; //批量打开按钮
        protected int Act_ApproveList = 4; //批量审核按钮
        protected int Act_SetInvalid = 5; //批量设为无效
        protected int Act_SetValid = 6; //批量设为有效


        private int permissionid = -1;

        /// <summary>
        /// 页面访问需要的权限。可以在不同页面继承里来控制不同页面的权限。默认-1为无限制。
        /// </summary>
        public int PermissionID
        {
            set
            {
                permissionid = value;
            }
            get
            {
                return permissionid;
            }
        }

        private AccountsPrincipal userPrincipal;
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

        private Maticsoft.Accounts.Bus.User currentUser;
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Maticsoft.Accounts.Bus.User CurrentUser
        {
            get
            {
                return currentUser;
            }
        }


        #endregion

        #region 初始化
        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            this.Error += new System.EventHandler(PageBase_Error);

            SingleLogin slogin = new SingleLogin();
            if (slogin.ValidateForceLogin())
            {
                Response.Write("<script defer>window.alert('" + Resources.Site.TooltipForceLogin + "');parent.location='" + defaullogin + "';</script>");
            }

            Actions bllAction = new Actions();
            ActHashtab = bllAction.GetHashListByCache();

        }
        private void InitializeComponent()
        {
            //if (!Page.IsPostBack)
            {

                if (Context.User.Identity.IsAuthenticated)
                {
                    userPrincipal = new AccountsPrincipal(Context.User.Identity.Name);

                    if ((PermissionID != -1) && (!userPrincipal.HasPermissionID(PermissionID)))
                    {
                        Response.Clear();
                        Response.Write("<script defer>window.alert('" + Resources.Site.TooltipNoPermission + "');history.back();</script>");
                        Response.End();
                    }

                    if (Session["UserInfo"] == null)
                    {
                        currentUser = new Maticsoft.Accounts.Bus.User(userPrincipal);
                        Session["UserInfo"] = currentUser;
                        Session["Style"] = currentUser.Style;

                        ////Response.Write("<script defer>location.reload();</script>");
                        ////跳转到 session 超时页面，提示用户重新登录

                        //Response.Clear();
                        //Response.Write("<script defer>window.alert('" + Resources.Site.TooltipSessionExpired + "');parent.location='" + defaullogin + "';</script>");
                        //Response.End();

                    }
                    else
                    {
                        currentUser = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                        Session["Style"] = currentUser.Style;
                    }

                }
                else
                {
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + Resources.Site.TooltipNoAuthenticated + "');parent.location='" + defaullogin + "';</script>");
                    Response.End();
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
                        errMsg += "<h1 class=\"SystemTip\">" + Resources.Site.ErrorSystemTip + "</h1><br/> " +
                        "<font class=\"ErrorPageText\">" + sqlMsg + "</font>";
                    }
                    else
                    {
                        errMsg += "<h1 class=\"ErrorMessage\">" + Resources.Site.ErrorSystemTip + "</h1><hr/> " +
                        "该信息已被系统记录，请稍后重试或与管理员联系。<br/>" +
                        "错误信息： <font class=\"ErrorPageText\">" + sqlMsg + "</font>";
                        model.Loginfo = sqlMsg;
                        model.StackTrace = currentError.ToString();
                        model.Url = Request.Url.AbsoluteUri;
                    }
                }
            }
            else
            {
                errMsg += "<h1 class=\"ErrorMessage\">" + Resources.Site.ErrorSystemTip + "</h1><hr/> " +
                    "该信息已被系统记录，请稍后重试或与管理员联系。<br/>" +
                    "错误信息： <font class=\"ErrorPageText\">" + currentError.Message.ToString() + "<hr/>" +
                    "<b>Stack Trace:</b><br/>" + currentError.ToString() + "</font>";

                model.Loginfo = currentError.Message;
                model.StackTrace = currentError.ToString();
                model.Url = Request.Url.AbsoluteUri;

            }
            Maticsoft.BLL.SysManage.ErrorLog.Add(model);


            Session["ErrorMsg"] = errMsg;
            Server.Transfer("~/admin/ErrorPage.aspx", true);

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

        /// <summary>
        /// 状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetCourseStatus(object intValue)
        {
            StringBuilder strCourseStatus = new StringBuilder();
            if (null != intValue)
            {
                switch (intValue.ToString())
                {
                    //状态：0:未完成,1:完成待审核,2:审核通过不上架(即下架),3:审核通过并发布上架;4:审核未通过                    
                    case "0":
                        strCourseStatus.Append("未完成");
                        break;
                    case "1":
                        strCourseStatus.Append("完成待审核");
                        break;
                    case "2":
                        strCourseStatus.Append("审核通过未发布");
                        break;
                    case "3":
                        strCourseStatus.Append("发布中");
                        break;
                    case "4":
                        strCourseStatus.Append("审核未通过");
                        break;
                    default:
                        strCourseStatus.Append("错误的状态");
                        break;
                }
            }
            return strCourseStatus.ToString();
        }

        /// <summary>
        /// 截取字符串的长度 超出长度+....
        /// </summary>
        /// <param name="strValue">内容</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public string GetCourseDec(object strValue, int length)
        {
            StringBuilder strContent = new StringBuilder();
            if (null != strValue)
            {
                if (strValue.ToString().Length > length)
                {
                    strContent.Append(strValue.ToString().Substring(0, length) + "...");
                }
                else
                {
                    strContent.Append(strValue.ToString());
                }
            }
            return strContent.ToString();
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public string GetOrderStatus(object strValue)
        {
            StringBuilder strOrderStatus = new StringBuilder();
            if (null != strValue)
            {
                switch (strValue.ToString())
                {
                    case "0":
                        strOrderStatus.Append("未付款");
                        break;
                    case "1":
                        strOrderStatus.Append("已付款");
                        break;
                    case "2":
                        strOrderStatus.Append("已发货");
                        break;
                    case "3":
                        strOrderStatus.Append("已完成");
                        break;
                    case "4":
                        strOrderStatus.Append("申请退款");
                        break;
                    case "5":
                        strOrderStatus.Append("已退款");
                        break;
                    default:
                        strOrderStatus.Append("错误的状态");
                        break;
                }
            }
            return strOrderStatus.ToString();
        }

        /// <summary>
        /// 根据CourseID获取CourseName
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public string GetCourseName(object intValue)
        {
            StringBuilder strModuleName = new StringBuilder();
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    Model.Tao.Courses CourseModel = CourseBLL.GetCourseName(Convert.ToInt32(intValue));
                    if (CourseModel != null)
                    {
                        strModuleName.Append(CourseModel.CourseName);
                    }
                }
            }
            return strModuleName.ToString();
        }

        /// <summary>
        /// 根据ModuleID 获取ModuleName
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        public string GetModuleName(object intValue)
        {
            StringBuilder strModuleName = new StringBuilder();
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    Model.Tao.Modules ModulesModel = ModuleBLL.GetModuleName(Convert.ToInt32(intValue));
                    if (ModulesModel != null)
                    {
                        strModuleName.Append(ModulesModel.ModuleName);
                    }
                }
            }
            return strModuleName.ToString();
        }
        /// <summary>
        /// 企业性质
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetCompanyType(object obj)
        {
            StringBuilder strCompanyType = new StringBuilder();
            if (obj != null)
            {
                if (PageValidate.IsNumber(obj.ToString()))
                {
                    int id = Convert.ToInt32(obj);
                    switch (id)
                    {
                        case 0:
                            strCompanyType.Append("个体工商");
                            break;
                        case 1:
                            strCompanyType.Append("私营独资企业");
                            break;
                        case 2:
                            strCompanyType.Append("国营企业");
                            break;
                        default:
                            strCompanyType.Append("未定义");
                            break;
                    }
                }
            }
            return strCompanyType.ToString();
        }
        /// <summary>
        /// 企业状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetEnterpriseState(object obj)
        {
            StringBuilder strEnterpriseState = new StringBuilder();
            if (obj != null)
            {
                if (PageValidate.IsNumber(obj.ToString()))
                {
                    int id = Convert.ToInt32(obj);
                    switch (id)
                    {
                        case 0:
                            strEnterpriseState.Append("未审核");
                            break;
                        case 1:
                            strEnterpriseState.Append("正常");
                            break;
                        case 2:
                            strEnterpriseState.Append("冻结");
                            break;
                        default:
                            strEnterpriseState.Append("未定义");
                            break;
                    }
                }
            }
            return strEnterpriseState.ToString();
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="FileUploadID">上传控件ID</param>
        /// <param name="MaxSize">最大允许的图片大小</param>
        /// <returns></returns>
        public string UploadImage(System.Web.UI.WebControls.FileUpload FileUploadID, int MaxSize)
        {
            string strErr = "";
            string serverPath = "";
            string ext = "";

            if (FileUploadID.FileName.Length > 0)
            {
                ext = Path.GetExtension(FileUploadID.FileName);

                if (ext.ToLower() != ".jpg" && ext.ToLower() != ".gif" && ext.ToLower() != ".png")
                {
                    strErr += "上传的图片格式应为：jpg,gif,png";
                }

                int size = FileUploadID.PostedFile.ContentLength;

                if (size > 1024 * 1024 * MaxSize)
                {
                    strErr += "上传的图片不能超过" + MaxSize + "M!";
                }

                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return "";
                }

                Random rd = new Random();
                string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + rd.Next(10000).ToString() + ext;

                FileUploadID.PostedFile.SaveAs(Server.MapPath(uploadFolders) + fileName);

                serverPath = uploadFolders + fileName;
            }
            return serverPath;
        }
        /// <summary>
        /// 根据父级类别得到一个对象实体
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public string GetCategoriesName(object intValue)
        {
            StringBuilder strCategoriesName = new StringBuilder();
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    Model.Tao.Categories CategoriesModel = CategoriesBLL.GetModelByParentCategoryId(Convert.ToInt32(intValue));
                    if (CategoriesModel != null)
                    {
                        strCategoriesName.Append(CategoriesModel.Name);
                    }
                    else
                    {
                        strCategoriesName.Append("父级类别");
                    }
                }
            }
            return strCategoriesName.ToString();
        }
        /// <summary>
        /// 获得认证资料类型名称
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        public string GetApproveName(object intValue)
        {
            StringBuilder strApproveName = new StringBuilder();
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    Model.Tao.ApproveType ApproveTypeModel = ApproveTypeBLL.GetModel(Convert.ToInt32(intValue));
                    if (ApproveTypeModel != null)
                    {
                        strApproveName.Append(ApproveTypeModel.ApproveName);
                    }
                }
            }
            return strApproveName.ToString();
        }
        /// <summary>
        /// 获得审核状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetStatus(object obj)
        {
            StringBuilder strStatus = new StringBuilder();
            if (obj != null)
            {
                if (PageValidate.IsNumber(obj.ToString()))
                {
                    int id = Convert.ToInt32(obj);
                    switch (id)
                    {
                        case 0:
                            strStatus.Append("未审核");
                            break;
                        case 1:
                            strStatus.Append("审核通过");
                            break;
                        case 2:
                            strStatus.Append("认证失败");
                            break;
                        default:
                            strStatus.Append("未定义");
                            break;
                    }
                }
            }
            return strStatus.ToString();
        }
        /// <summary>
        /// 获得用户ID
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public int GetUserID(object strValue)
        {
            int uid = 0;
            if (null != strValue)
            {
                User user = new Maticsoft.Accounts.Bus.User(strValue.ToString());
                if (null != user)
                {
                    uid = user.UserID;
                }
            }
            return uid;
        }

        /// <summary>
        /// 获取视频类型
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        public string GetTypeName(object intValue)
        {
            StringBuilder strTypeName = new StringBuilder();
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    switch (Convert.ToInt32(intValue))
                    {
                        case 0:
                            strTypeName.Append("本地视频");
                            break;
                        case 1:
                            strTypeName.Append("flash网址");
                            break;
                        case 2:
                            strTypeName.Append("Html代码");
                            break;
                        default:
                            strTypeName.Append("");
                            break;
                    }
                }
            }
            return strTypeName.ToString();
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

        /// <summary>
        /// 获取用户真实姓名
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetUserTrueName(object intValue)
        {
            string strTrueName = "";
            if (null != intValue)
            {
                if (PageValidate.IsNumber(intValue.ToString()))
                {
                    User currentUser = new Maticsoft.Accounts.Bus.User(Convert.ToInt32(intValue));
                    if (null != currentUser)
                    {
                        strTrueName = currentUser.TrueName;
                    }
                }
            }
            return strTrueName;
        }
        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetImage(object obj, int height, int width)
        {
            string strImgUrl = "";
            if (null != obj && !string.IsNullOrEmpty(obj.ToString()))
            {
                strImgUrl = "<a href=\"" + StringPlus.TrimStart(obj.ToString(), "~") + "\" Target=\"_blank\"><img src=\"" + StringPlus.TrimStart(obj.ToString(), "~") + "\" style=\" height:" + height + "px;width:" + width + "px;border:none;\" /></a>";
            }
            else
            {
                strImgUrl = "<img src=\"../images/none.gif\" style=\" height:" + height + "px;width:" + width + "px\"/>";
            }
            return strImgUrl;
        }
        #endregion

        #region 导出excel

        /// <summary>
        /// HTML Table表格数据(html)导出EXCEL
        /// </summary>
        /// <param name="tabHead"></param>
        /// <param name="tabData"></param>
        protected void ExportToExcel(string tabHead, string tabData)
        {
            string sheetName = "sheetName";
            string fileName = "fileName";
            if (tabData != null)
            {
                StringWriter sw = new StringWriter();
                #region
                sw.WriteLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                sw.WriteLine("<head>");
                sw.WriteLine("<!--[if gte mso 9]>");
                sw.WriteLine("<xml>");
                sw.WriteLine(" <x:ExcelWorkbook>");
                sw.WriteLine("  <x:ExcelWorksheets>");
                sw.WriteLine("   <x:ExcelWorksheet>");
                sw.WriteLine("    <x:Name>" + sheetName + "</x:Name>");
                sw.WriteLine("    <x:WorksheetOptions>");
                sw.WriteLine("      <x:Print>");
                sw.WriteLine("       <x:ValidPrinterInfo />");
                sw.WriteLine("      </x:Print>");
                sw.WriteLine("    </x:WorksheetOptions>");
                sw.WriteLine("   </x:ExcelWorksheet>");
                sw.WriteLine("  </x:ExcelWorksheets>");
                sw.WriteLine("</x:ExcelWorkbook>");
                sw.WriteLine("</xml>");
                sw.WriteLine("<![endif]-->");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                #endregion
                sw.WriteLine("<table>");
                sw.WriteLine("<tr style=\"background-color: #e4ecf7; text-align: center; font-weight: bold\">");
                sw.WriteLine(tabHead);
                sw.WriteLine("</tr>");
                sw.WriteLine(tabData);
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
                sw.Close();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                //Response.Charset = "GB2312";
                this.EnableViewState = false;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".xls");
                Response.ContentType = "application/ms-excel";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                Response.Write(sw);
                Response.End();
            }
        }

        /// <summary>
        /// 将控件内容，导出EXCEL
        /// </summary>
        /// <param name="ctr"></param>
        public void ExportToExcel(System.Web.UI.Control ctr)
        {
            string style = @"<style> .text { mso-number-format:\@; } </script> ";
            Response.ClearContent();
            Response.Write("<meta   http-equiv=Content-Type   content=text/html;charset=GB2312>");
            Response.AddHeader("content-disposition", "attachment; filename=filename.xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            ctr.RenderControl(htw);
            // Style is added dynamically
            Response.Write(style);
            Response.Write(sw.ToString());
            Response.End();
        }

        #endregion
    }
}
