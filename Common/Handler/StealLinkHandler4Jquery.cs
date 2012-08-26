#define DEBUG
using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Maticsoft.Common.DEncrypt;

namespace Maticsoft.Common.Handler
{
    public class StealLinkHandler4Jquery : StealLinkHandlerBase
    {
        #region 实现BaseHandler
        /// <summary>
        /// Request请求处理扩展
        /// </summary>
        protected override void ProcessRequestEx(HttpContext context)
        {
            try
            {
                #region Check 请求是否合法
                string action = context.Request["Action"];
                if (string.IsNullOrEmpty(action) ||
                    string.IsNullOrEmpty(context.Request["Text"]))
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write("{\"Status\":\"Unauthorized request\"}");
                    return;
                }
                #endregion

                switch (action)
                {
                    //进行URL解密
                    case "Authorization":
                        this.Authorization(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/json";
#if DEBUG
                context.Response.Write("{\"Status\":\"" + exception.Message.Replace("\"", "'") + "\"}");
#else
                context.Response.Write("{\"Status\":\"ERROR\"}");
#endif
            }
        }

        /// <summary>
        /// 允许重复使用Handler
        /// </summary>
        protected override bool IsReusableEx
        {
            get { return true; }
        }
        #endregion

        #region 解密并输出字符
        /// <summary>
        /// 解密并输出字符
        /// </summary>
        private void Authorization(HttpContext context)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            string text = context.Request["Text"];
            if (!string.IsNullOrEmpty(text))
            {
                text = DESEncrypt.Decrypt(text);
                builder.Append("\"Status\":\"OK\",");
            }
            else
            {
                builder.Append("\"Status\":\"Fail\",");
            }
            builder.AppendFormat("\"Vaule\":\"{0}\"", text);
            builder.Append("}");
            context.Response.ContentType = "text/plain";
            context.Response.Write(builder.ToString());
        } 
        #endregion

    }
}