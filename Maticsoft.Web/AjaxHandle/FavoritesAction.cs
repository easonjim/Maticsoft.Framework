using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;

namespace Maticsoft.Web.AjaxHandle
{
    public class FavoritesAction : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        Maticsoft.BLL.Tao.Courses coursesBLL = new Maticsoft.BLL.Tao.Courses();
        Maticsoft.BLL.Tao.CourseModule courseModuleBLL = new Maticsoft.BLL.Tao.CourseModule();
        BLL.Tao.Favorite favoriteBLL = new BLL.Tao.Favorite();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            string action = Request.Form["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "add":
                        AddFav(Request, Response);
                        break;
                    case "del":
                        DelFav(Request, Response);
                        break;
                    case "isFav":
                        IsFav(Request, Response);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Response.Write("-2");//未知错误
            }
        }

        private void AddFav(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Form["uid"]))
            {
                if (!string.IsNullOrEmpty(Request.Form["cid"]))
                {
                    Model.Tao.Favorite model = new Model.Tao.Favorite();
                    int courseID = int.Parse(Request.Form["cid"]);
                    if (!coursesBLL.Exists(courseID))
                    {
                        Response.Write("0");//错误的课程ID
                    }
                    model.CourseID = courseID;
                    if (!string.IsNullOrEmpty(Request.Form["mid"]) && PageValidate.IsNumber(Request.Form["mid"]))
                    {
                        model.ModuleID = int.Parse(Request.Form["mid"]);
                    }
                    else
                    {
                        model.ModuleID = courseModuleBLL.GetFirstModuleID(int.Parse(Request.Form["mid"]));
                    }
                    model.Remark = string.Empty;
                    model.Tags = string.Empty;
                    model.UserID = int.Parse(Request.Form["uid"]);
                    if (!favoriteBLL.ExistsFavorite(Convert.ToInt32(model.CourseID), int.Parse(Request.Form["uid"])))
                    {
                        if (0 < favoriteBLL.Add(model))
                        {
                            Response.Write("1");//收藏成功
                        }
                        else
                        {
                            Response.Write("2");//收藏shibai
                        }
                    }
                    else
                    {
                        Response.Write("3");//已经收藏了该课程
                    }
                }
                else
                {
                    Response.Write("0");//错误的课程ID
                }
            }
            else
            {
                Response.Write("-1");//未登录
            }
        }

        private void IsFav(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Form["uid"]))
            {
                int courseID = int.Parse(Request.Form["cid"]);
                if (!coursesBLL.Exists(courseID))
                {
                    Response.Write("0");//错误的课程ID
                }
                int uid = int.Parse(Request.Form["uid"]);
                //是否显示关注按钮和取消关注按钮
                if (favoriteBLL.ExistsFavorite(courseID, uid))
                {
                    Response.Write("1");//已关注 。关注按钮隐藏
                }
                else
                {
                    Response.Write("0");//未关注 
                }
            }
            else
            {
                Response.Write("0");//
            }
        }



        private void DelFav(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Form["uid"]))
            {
                int uid = int.Parse(Request.Form["uid"]);
                if (!string.IsNullOrEmpty(Request.Form["cid"]) && PageValidate.IsNumber(Request.Form["cid"]))
                {
                    int courseID = int.Parse(Request.Form["cid"]);
                    if (favoriteBLL.DelFavorite(courseID, uid))
                    {
                        Response.Write("1");//取消关注成功
                    }
                    else
                    {
                        Response.Write("0");//取消关注失败
                    }
                }
                else
                {
                    Response.Write("-2");//错误的课程ID
                }
            }
            else
            {
                Response.Write("-1");//未登录
            }
        }
    }
}