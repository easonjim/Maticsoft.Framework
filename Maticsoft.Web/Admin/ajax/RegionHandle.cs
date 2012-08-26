using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.Admin.ajax
{
    /// <summary>
    /// 注册新用户
    /// </summary>
    public class RegionHandle:IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            string Action = string.Empty;
            if(!string.IsNullOrEmpty(Request.Form["action"]))
            {
                Action = Request.Form["action"];
            }
            switch (Action)
            {
                case "checkUser":
                    CheckUser(Request,Response);
                    break;
                case "CheckEmail":
                    CheckEmail(Request, Response);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 注册时检测将注册的用户名是否存在
        /// </summary>
        private void CheckUser(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Form["UserName"]))
            {
                string UserName = Request.Form["UserName"];
                if (new Maticsoft.Accounts.Data.User().HasUser(UserName))
                {
                    //存在
                    Response.Write("yes");
                }
                else
                {
                    //不存在
                    Response.Write("no");
                }
            }
        }

        /// <summary>
        ///  检测注册邮箱是否存在 ，如果存在则不允许注册
        /// </summary>
        private void CheckEmail(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Form["EmailAdd"]))
            {
                BLL.UserExp.UsersExp userBll=new BLL.UserExp.UsersExp();
                string EmailAdd = Request.Form["EmailAdd"];
                if (userBll.EmailExist(EmailAdd))
                {
                    //存在
                    Response.Write("yes");
                }
                else
                {
                    //不存在
                    Response.Write("no");
                }
            }
        }
    }
}