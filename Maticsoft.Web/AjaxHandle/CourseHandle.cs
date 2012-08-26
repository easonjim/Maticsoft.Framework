using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jayrock.Json;
using System.IO;

namespace Maticsoft.Web.AjaxHandle
{
    public class CourseHandle : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            string Action = string.Empty;
            if (!string.IsNullOrEmpty(Request.Params["action"]))
            {
                Action = Request.Params["action"];
            }
            switch (Action)
            {
                case "cancleFav":
                    CancleFav(Request, Response);
                    break;
                case "existCourse":
                    IsExistCourse(Request, Response);
                    break;
                case "uploadico":
                    string strFileUrl = Maticsoft.Common.ConfigHelper.GetConfigString("UploadDocument");
                    UploadPic(Request, Response, strFileUrl);
                    break;
                default:
                    break;
            }
        }


        private void UploadPic(HttpRequest Request, HttpResponse Response, string strFileUrl)
        {
            HttpPostedFile file = Request.Files["Filedata"];
            if (file != null)
            {
                //文件夹是否存在
                string pathStr = HttpContext.Current.Server.MapPath( strFileUrl);
                if (!Directory.Exists(pathStr))
                {
                    //不存在则自动创建文件夹
                    Directory.CreateDirectory(pathStr);
                }
                string ext = Path.GetExtension(file.FileName).ToLower();
                string fileName = Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture) + ext;
                string savepath = pathStr + "/" + fileName;
                JsonObject json = new JsonObject();
                try
                {
                    file.SaveAs(savepath);
                    json.Accumulate("Status", "OK");
                    json.Accumulate("SavePath", "/" + strFileUrl + "/" + fileName);
                    Response.Write(("1|" + json.ToString()));
                }
                catch (Exception)
                {
                    json.Accumulate("Status", "Failed");
                    json.Accumulate("ErrorMessage", "ERROR401，请联系管理员！");
                    Response.Write("0|" + json.ToString());
                }
            }
            else
            {
                JsonObject json = new JsonObject();
                json.Accumulate("Status", "Failed");
                json.Accumulate("ErrorMessage", "ERROR402，请联系管理员！");
                Response.Write("0|" + json.ToString());
            }
        }


        private void CancleFav(HttpRequest Request, HttpResponse Response)
        {
            BLL.Tao.Favorite favBll = new BLL.Tao.Favorite();
            if (!string.IsNullOrEmpty(Request.Form["id"]))
            {
                int _ids = int.Parse(Request.Form["id"].ToString());
                if (favBll.Delete(_ids))
                {
                    Response.Write("Succ");
                    Response.End();
                }
                else
                {
                    Response.Write("Faile");
                    Response.End();
                }
            }
        }

        private void IsExistCourse(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Form["courseId"]))
            {
                BLL.Tao.CourseModule manage = new BLL.Tao.CourseModule();
                int cid = int.Parse(Request.Form["courseId"]);
                if (manage.Exists(cid))
                {
                    Response.Write("Succ");
                    Response.End();
                }
                else
                {
                    Response.Write("Faile");
                    Response.End();
                }
            }
            else
            {
                Response.Write("Faile");
                Response.End();
            }
        }
    }
}