#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace Maticsoft.Common.Handler
{
    public abstract class StealLinkHandlerBase : IHttpHandler, IRequiresSessionState
    {
        #region 实现IHttpHandler
        /// <summary>
        /// Request请求处理
        /// </summary>
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Session["BAN"] != null) return;

                //Check盗链
                if (CheckUrlReferrer(context)) return;

                #region Check 用户登录
                if (//!context.User.Identity.IsAuthenticated
                    context.Session["UserInfo"] == null
                    )
                {
                    context.Session["BAN"] = "BAN";
                    context.Response.End();
                    return;
                }
                #endregion

                #region Check 请求的客户端标识
                //过滤迅雷请求
                if (context.Request.UserAgent.IndexOf("CLR") > -1)
                {
                    context.Session["BAN"] = "BAN";
                    context.Response.End();
                    return;
                }
                #endregion

                //调用子类实现
                this.ProcessRequestEx(context);
            }
#if DEBUG
            catch (Exception exception)
            {
                throw exception;
            }
#else
            catch (Exception) { }
#endif
        }

        /// <summary>
        /// 是否允许重复使用 [Handler]
        /// </summary>
        public bool IsReusable
        {
            //调用子类实现
            get { return this.IsReusableEx; }
        }
        #endregion

        #region 防盗链
        /// <summary>
        /// Check 盗链
        /// </summary>
        /// <returns>true:盗链 | false:非盗链</returns>
        protected bool CheckUrlReferrer(HttpContext context)
        {
            //获取请求之前的URI
            Uri referrerUri = context.Request.UrlReferrer;
            Uri currentUri = context.Request.Url;
            ////获取前页面名称
            //string referrerPage = referrerUri.LocalPath.Substring(referrerUri.LocalPath.LastIndexOf('/') + 1);

            //非直接访问 -> 域名相同 -> [*判断前页是否是指定页面]
            if (referrerUri != null &&
                referrerUri.Host == currentUri.Host
                //[*&& referrerPage != "Details.aspx"]
                )
            {
                return false;
            }

            //盗链跳转
            context.Response.Redirect("~/", false);
            return true;
        }
        #endregion

        #region 子类实现
        /// <summary>
        /// Request请求处理扩展
        /// 子类实现
        /// </summary>
        protected abstract void ProcessRequestEx(HttpContext context);

        /// <summary>
        /// 是否允许重复使用 [Handler]
        /// ★请注意异步和并发情况★
        /// </summary>
        protected abstract bool IsReusableEx { get; }
        #endregion

    }
}
