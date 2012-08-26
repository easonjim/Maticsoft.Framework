using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maticsoft.Web.AjaxHandle
{
    public class LearnCourseHandle : IHttpHandler
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
            BLL.Tao.Orders orderBll = new BLL.Tao.Orders();
            if (!string.IsNullOrEmpty(Request.Form["uid"]))
            {

                if (!string.IsNullOrEmpty(Request.Form["cid"]) && !string.IsNullOrEmpty(Request.Form["mid"]) && !string.IsNullOrEmpty(Request.Form["uid"]) && !string.IsNullOrEmpty(Request.Form["uEmail"]) && !string.IsNullOrEmpty(Request.Form["uName"]) && !string.IsNullOrEmpty(Request.Form["SellerId"]) && !string.IsNullOrEmpty(Request.Form["tprice"]))
                {
                    int cid = int.Parse(Request.Params["cid"]);
                    int mid = int.Parse(Request.Params["mid"]);
                    int sellId = int.Parse(Request.Form["SellerId"]);
                    int uid = int.Parse(Request.Form["uid"]);
                    string uName = Request.Form["uName"];
                    string uEmail = Request.Form["uEmail"];
                    decimal price = decimal.Parse(Request.Form["tprice"]);

                    if (orderBll.IsBuyed(cid, uid, mid))
                    {
                        Response.Write("{'status':'3'}");//已经购买了该课程
                    }
                    else
                    {
                        Model.Tao.Orders ordersModle = new Model.Tao.Orders();
                        ordersModle.BuyerID = uid;
                        ordersModle.Email = uEmail;
                        ordersModle.SellerID = sellId;
                        ordersModle.Amount = price;
                        ordersModle.UserName = uName;
                        if (orderBll.SaveLeanCourse(ordersModle, cid, mid) > 0)
                        {
                            Response.Write("{'status':'1'}");
                        }
                        else
                        {
                            Response.Write("{'status':'2'}");//系统繁忙
                        }
                    }
                }
                else
                {
                    Response.Write("{'status':'2'}");//系统繁忙
                }
            }
            else
            {
                Response.Write("{'status':'-1'}");//未登录
            }
        }
    }
}