using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.Admin.ajax
{
    /// <summary>
    /// 保存已选课程信息的评价
    /// </summary>
    public class EvaluateHandle : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        Model.Tao.Comment comModel = new Model.Tao.Comment();
        BLL.Tao.Comment comBll = new BLL.Tao.Comment();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            string action = string.Empty;
            if (!string.IsNullOrEmpty(Request.Form["action"])&&!string.IsNullOrEmpty(Request.Form["courseID"])&&!string.IsNullOrEmpty(Request.Form["content"])&&!string.IsNullOrEmpty(Request.Form["mark"]))
            {
                action = Request.Form["action"];
            }
            else
            {
                Response.Write("Error");
            }
            switch (action)
            {
                case "nolearn":
                    updataCourseMark(Request, Response);
                    break;
                case "comment":
                    break;
                default:
                    break;
            }
        }

        private void updataCourseMark(HttpRequest Request, HttpResponse Response)
        {
            //评论内容敏感词过滤---待加
            comModel.CourseID = int.Parse(Request.Form["courseID"]);
            comModel.Score = int.Parse(Request.Form["mark"]);
            comModel.Comments =Common.CommonCode.NoHTML( Request.Form["content"]);//去掉评论中的HTML标签和JS标签
            comModel.UserID = int.Parse(Request.Form["userId"]);
            comModel.ParentID = -1;
            if (comBll.CourseComment(comModel))
            {
                Response.Write("Success");
            }
            else
            {
                Response.Write("Faile");
            }
        }
    }
}