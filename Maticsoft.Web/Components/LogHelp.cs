using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class LogHelp
    {
        /// <summary>
        /// Add User oprate log
        /// </summary>      
        public static void AddUserLog(string Username, string UserType,string OPInfo,System.Web.UI.Page page)
        {
            Maticsoft.Model.SysManage.UserLog model=new Maticsoft.Model.SysManage.UserLog();
            model.OPInfo=OPInfo;            
            model.Url=page.Request.Url.AbsoluteUri;
            model.UserIP= page.Request.UserHostAddress;
            model.UserName=Username;
            model.UserType=UserType;
            Maticsoft.BLL.SysManage.UserLog.LogUserAdd(model);            
        }


        /// <summary>
        /// Add system error log
        /// </summary>      
        public static void AddErrorLog(string Loginfo, string StackTrace,System.Web.UI.Page page)
        {
            Maticsoft.Model.SysManage.ErrorLog model = new Maticsoft.Model.SysManage.ErrorLog();
            model.Loginfo = Loginfo;                        
            model.StackTrace = "";
            model.Url = page.Request.Url.AbsoluteUri;            
            Maticsoft.BLL.SysManage.ErrorLog.Add(model);
        }
    }
}
