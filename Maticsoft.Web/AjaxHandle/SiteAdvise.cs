using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.AjaxHandle
{
    public class SiteAdvise : IHttpHandler
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
            string Content = string.Empty;
            if (!string.IsNullOrEmpty(Request.Form["adviseContent"]))
            {
                Content = Request.Form["adviseContent"];
                BLL.Messages.ReceivedMessages receivedMsgBll = new BLL.Messages.ReceivedMessages();
                Model.Messages.ReceivedMessages receivedModel = new Model.Messages.ReceivedMessages();
                receivedModel.AddresserId = -1;
                receivedModel.IsRead = false;
                receivedModel.LastTime = DateTime.Now;
                receivedModel.PublishDate = DateTime.Now;
                receivedModel.AddresseeId = 1;
                receivedModel.Title = "网站建设意见";
                receivedModel.PublishContent = Content;
                if (receivedMsgBll.Add(receivedModel) > 0)
                {
                    Response.Write("yes");
                }
                else
                {
                    Response.Write("no");
                }
            }
            
        }
    }
}