using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Collections;
using System.Data;

namespace Maticsoft.Web
{
    public class Global : System.Web.HttpApplication
    {
        //private static System.Threading.Timer timer;

        private const int interval = 1000 * 60 * 10;  //检查在线用户的间隔时间


        /// <summary>
        /// 必需的设计器变量
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            #region 默认蓝


            Application["1xtop1_bgimage"] = "images/login1/top-1.gif"; //顶框背景图片
            Application["1xtop2_bgimage"] = "images/login1/top-2.gif"; //顶框背景图片
            Application["1xtop3_bgimage"] = "images/login1/top-3.gif"; //顶框背景图片
            Application["1xtop4_bgimage"] = "images/login1/top-4.gif"; //顶框背景图片
            Application["1xtop5_bgimage"] = "images/login1/top-5.gif"; //顶框背景图片
            Application["1xtopbj_bgimage"] = "images/login1/top-bj.gif"; //顶框背景图片



            Application["1xtopbar_bgimage"] = "images/login1/topbar_01.jpg"; //顶框工具条背景图片
            Application["1xfirstpage_bgimage"] = "images/login1/dbsx_01.gif"; //首页背景图片
            Application["1xforumcolor"] = "#f0f4fb";
            Application["1xleft_width"] = "204"; //左框架宽度


            Application["1xtree_bgcolor"] = "#e3eeff"; //左框架树背景色
            Application["1xleft1_bgimage"] = "images/login1/left-1.gif";
            Application["1xleft2_bgimage"] = "images/login1/left-2.gif";
            Application["1xleft3_bgimage"] = "images/login1/left-3.gif";
            Application["1xleftbj_bgimage"] = "images/login1/left-bj.gif";


            Application["1xspliter_color"] = "#6B7DDE"; //分隔块色


            Application["1xdesktop_bj"] = "";//images/login1/right-bj.gif
            Application["1xdesktop_bgimage"] = "images/login1/desktop_01.gif";//right.gif

            Application["1xtable_bgcolor"] = "#F5F9FF"; //最外层表格背景
            Application["1xtable_bordercolorlight"] = "#4F7FC9"; //中层表格亮边框
            Application["1xtable_bordercolordark"] = "#D3D8E0"; //中层表格暗边框
            Application["1xtable_titlebgcolor"] = "#E3EFFF"; //中层表格标题栏


            Application["1xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

            Application["1xfirstpage_topimage"] = "images/login1/top_01.gif";
            Application["1xfirstpage_bottomimage"] = "images/login1/bottom_01.gif";
            Application["1xfirstpage_middleimage"] = "images/login1/bg_01.gif";

            Application["1xabout_bgimage"] = "images/login1/about_01.gif"; //关于我们背景图片

            #endregion

            #region 绿色


            Application["2xtop1_bgimage"] = "images/login1/top-1-2.gif"; //顶框背景图片
            Application["2xtop2_bgimage"] = "images/login1/top-2-2.gif"; //顶框背景图片
            Application["2xtop3_bgimage"] = "images/login1/top-3-2.gif"; //顶框背景图片
            Application["2xtop4_bgimage"] = "images/login1/top-4-2.gif"; //顶框背景图片
            Application["2xtop5_bgimage"] = "images/login1/top-5-2.gif"; //顶框背景图片
            Application["2xtopbj_bgimage"] = "images/login1/top-bj-2.gif"; //顶框背景图片

            Application["2xtopbar_bgimage"] = "images/login1/topbar_01.jpg"; //顶框工具条背景图片
            Application["2xfirstpage_bgimage"] = "images/login1/dbsx_01.gif"; //首页背景图片
            Application["2xforumcolor"] = "#f0f4fb";
            Application["2xleft_width"] = "204"; //左框架宽度


            Application["2xtree_bgcolor"] = "#e3ffe9"; //左框架树背景色			
            Application["2xleft1_bgimage"] = "images/login1/left-1-2.gif";
            Application["2xleft2_bgimage"] = "images/login1/left-2-2.gif";
            Application["2xleft3_bgimage"] = "images/login1/left-3-2.gif";
            Application["2xleftbj_bgimage"] = "images/login1/left-bj-2.gif";

            Application["2xspliter_color"] = "#51C94F"; //分隔块色


            Application["2xdesktop_bj"] = "";//images/login1/right-bj-2.gif
            Application["2xdesktop_bgimage"] = "images/login1/desktop_02.gif";//right-2.gif


            Application["2xtable_bgcolor"] = "#F5FFF5"; //最外层表格背景
            Application["2xtable_bordercolorlight"] = "#7DBD7B"; //中层表格亮边框
            Application["2xtable_bordercolordark"] = "#D3E0D3"; //中层表格暗边框
            Application["2xtable_titlebgcolor"] = "#E4FFE3"; //中层表格标题栏


            Application["2xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

            Application["2xfirstpage_topimage"] = "images/login1/top_01.gif";
            Application["2xfirstpage_bottomimage"] = "images/login1/bottom_01.gif";
            Application["2xfirstpage_middleimage"] = "images/login1/bg_01.gif";



            #endregion

            #region 红色

            Application["3xtop1_bgimage"] = "images/login1/top-1-1.gif"; //顶框背景图片
            Application["3xtop2_bgimage"] = "images/login1/top-2-1.gif"; //顶框背景图片
            Application["3xtop3_bgimage"] = "images/login1/top-3-1.gif"; //顶框背景图片
            Application["3xtop4_bgimage"] = "images/login1/top-4-1.gif"; //顶框背景图片
            Application["3xtop5_bgimage"] = "images/login1/top-5-1.gif"; //顶框背景图片
            Application["3xtopbj_bgimage"] = "images/login1/top-bj-1.gif"; //顶框背景图片

            Application["3xtopbar_bgimage"] = "images/login1/topbar_01.jpg"; //顶框工具条背景图片
            Application["3xfirstpage_bgimage"] = "images/login1/dbsx_01.gif"; //首页背景图片
            Application["3xforumcolor"] = "#f0f4fb";
            Application["3xleft_width"] = "204"; //左框架宽度


            Application["3xtree_bgcolor"] = "#ffe3e5"; //左框架树背景色			
            Application["3xleft1_bgimage"] = "images/login1/left-1-1.gif";
            Application["3xleft2_bgimage"] = "images/login1/left-2-1.gif";
            Application["3xleft3_bgimage"] = "images/login1/left-3-1.gif";
            Application["3xleftbj_bgimage"] = "images/login1/left-bj-1.gif";

            Application["3xspliter_color"] = "#C94F4F"; //分隔块色


            Application["3xdesktop_bj"] = "";//images/login1/right-bj-1.gif
            Application["3xdesktop_bgimage"] = "images/login1/desktop_03.gif";//right-1.gif


            Application["3xtable_bgcolor"] = "#FFF5F5"; //最外层表格背景
            Application["3xtable_bordercolorlight"] = "#BD7B7B"; //中层表格亮边框
            Application["3xtable_bordercolordark"] = "#E1D3D3"; //中层表格暗边框
            Application["3xtable_titlebgcolor"] = "#FFE3E3"; //中层表格标题栏


            Application["3xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

            Application["3xfirstpage_topimage"] = "images/login1/top_01.gif";
            Application["3xfirstpage_bottomimage"] = "images/login1/bottom_01.gif";
            Application["3xfirstpage_middleimage"] = "images/login1/bg_01.gif";



            #endregion

            #region 深绿色


            Application["4xtop1_bgimage"] = "images/login1/top-1-3.gif"; //顶框背景图片
            Application["4xtop2_bgimage"] = "images/login1/top-2-3.gif"; //顶框背景图片
            Application["4xtop3_bgimage"] = "images/login1/top-3-3.gif"; //顶框背景图片
            Application["4xtop4_bgimage"] = "images/login1/top-4-3.gif"; //顶框背景图片
            Application["4xtop5_bgimage"] = "images/login1/top-5-3.gif"; //顶框背景图片
            Application["4xtopbj_bgimage"] = "images/login1/top-bj-3.gif"; //顶框背景图片

            Application["4xtopbar_bgimage"] = "images/login1/topbar_01.jpg"; //顶框工具条背景图片
            Application["4xfirstpage_bgimage"] = "images/login1/dbsx_01.gif"; //首页背景图片
            Application["4xforumcolor"] = "#f0f4fb";
            Application["4xleft_width"] = "204"; //左框架宽度


            Application["4xtree_bgcolor"] = "#e3ffe9"; //左框架树背景色			
            Application["4xleft1_bgimage"] = "images/login1/left-1-3.gif";
            Application["4xleft2_bgimage"] = "images/login1/left-2-3.gif";
            Application["4xleft3_bgimage"] = "images/login1/left-3-3.gif";
            Application["4xleftbj_bgimage"] = "images/login1/left-bj-3.gif";

            Application["4xspliter_color"] = "#51C94F"; //分隔块色


            Application["4xdesktop_bj"] = "";//images/login1/right-bj-3.gif
            Application["4xdesktop_bgimage"] = "images/login1/desktop_02.gif";//right-3.gif


            Application["4xtable_bgcolor"] = "#F5FFF5"; //最外层表格背景
            Application["4xtable_bordercolorlight"] = "#7DBD7B"; //中层表格亮边框
            Application["4xtable_bordercolordark"] = "#D3E0D3"; //中层表格暗边框
            Application["4xtable_titlebgcolor"] = "#E4FFE3"; //中层表格标题栏


            Application["4xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

            Application["4xfirstpage_topimage"] = "images/login1/top_01.gif";
            Application["4xfirstpage_bottomimage"] = "images/login1/bottom_01.gif";
            Application["4xfirstpage_middleimage"] = "images/login1/bg_01.gif";



            #endregion
            
            #region OnlineUsers

            try
            {
                DataTable userTable = new DataTable();
                userTable.Columns.Add("SessionID");
                userTable.Columns.Add("UserIP");
                userTable.Columns.Add("Browser");
                userTable.Columns.Add("OSName");
                //userTable.Columns.Add("Area");			

                userTable.AcceptChanges();
                Application.Lock();
                Application["OnlineUsers"] = userTable;
                Application.UnLock();
            }
            catch
            { }

            #endregion
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Style"] = 1;
            //Session["language"] = "zh-CN";   
   
            #region OnlineUsers
            try
            {
                string seesionid = Session.SessionID;
                string UserIP = Request.UserHostAddress;               
                HttpBrowserCapabilities bc = Request.Browser;
                string OSName = "Win2000";
                switch (bc.Platform)
                {
                    case "Win98":
                        OSName = "Windows98";
                        break;
                    case "WinNT 5.1":
                    case "WinXP":
                        OSName = "Windows XP";
                        break;
                    case "WinNT 5.0":
                        OSName = "Win2000";
                        break;
                    case "WinNT":
                        OSName = "Win7";
                        break;
                    default:
                        OSName = bc.Platform;
                        break;
                }
                string Browser = bc.Type;

                DataTable userTable = (DataTable)Application["OnlineUsers"];
                if (userTable == null)
                    return;
                DataRow[] curRow = userTable.Select("SessionID='" + seesionid + "'");
                if (curRow.Length == 0)
                {
                    DataRow newRow = userTable.NewRow();
                    newRow["SessionID"] = seesionid;
                    newRow["UserIP"] = UserIP;
                    newRow["Browser"] = Browser;
                    newRow["OSName"] = OSName;                    
                    userTable.Rows.Add(newRow);

                    userTable.AcceptChanges();

                    Application.Lock();
                    Application["OnlineUsers"] = userTable;
                    Application.UnLock();
                }

                #region
                //if (Application["OnlineUsers"] == null)
                //{
                //    Application["OnlineUsers"] = 0;
                //}
                //int onlineCount = (int)Application["OnlineUsers"];
                //onlineCount++;
                //Application["OnlineUsers"] = onlineCount;
                #endregion
            }
            catch
            { }

            #endregion
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["language"] != null)
                {
                    string lang = Request.Cookies["language"].Value.ToString();
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            #region

            //Exception ex = Server.GetLastError();
            //bool LogInFile = bool.Parse(Maticsoft.BLL.ConfigSystem.GetValueByCache("LogInFile"));
            //bool LogInDB = bool.Parse(Maticsoft.BLL.ConfigSystem.GetValueByCache("LogInDB"));
            ////string LogLastDays = ConfigurationManager.AppSettings.Get("LogLastDays");
            //string errmsg = "";
            //string StackTrace = "";
            //if (ex.InnerException != null)
            //{
            //    errmsg = ex.InnerException.Message;
            //    StackTrace = ex.InnerException.StackTrace;
            //}
            //else
            //{
            //    errmsg = ex.Message;
            //    StackTrace = ex.StackTrace;
            //}

            //if (LogInFile)
            //{
            //    string filename = Server.MapPath("~/log/ErrorMessage.txt");
            //    string strTime = DateTime.Now.ToString();
            //    StreamWriter sw = new StreamWriter(filename, true);
            //    sw.WriteLine(strTime + "：" + errmsg);
            //    sw.WriteLine(StackTrace);
            //    sw.WriteLine("");
            //    sw.Close();
            //}
            //if (LogInDB)
            //{
            //    Maticsoft.BLL.SysManage.ErrorLog.Add(new Maticsoft.Model.SysManage.ErrorLog("", errmsg, StackTrace));

            //    //Assistant.DelOverdueLog(LogLastDays);
            //}
            //Server.Transfer("ErrorMsg.aspx");


            #endregion
        }

        protected void Session_End(object sender, EventArgs e)
        {            
            try
            {
                string seesionid = Session.SessionID;
                DataTable userTable = (DataTable)Application["OnlineUsers"];
                if (userTable == null)
                    return;
                foreach (DataRow row in userTable.Select("SessionID='" + seesionid + "'"))
                {
                    userTable.Rows.Remove(row);
                }
                userTable.AcceptChanges();
                Application.Lock();
                Application["OnlineUsers"] = userTable;
                Application.UnLock();
            }
            catch
            { }
            
        }
        
        protected void Application_End(object sender, EventArgs e)
        {
        }
        
    }
}