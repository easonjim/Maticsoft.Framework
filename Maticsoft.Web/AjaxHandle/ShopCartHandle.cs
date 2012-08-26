using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jayrock.Json;

namespace Maticsoft.Web.AjaxHandle
{
    public class ShopCartHandle : IHttpHandler
    {
        public const string TAO_KEY_STATUS = "STATUS";
        public const string TAO_KEY_DATA = "DATA";

        public const string TAO_STATUS_SUCCESS = "SUCCESS";
        public const string TAO_STATUS_FAILED = "FAILED";
        public const string TAO_STATUS_ERROR = "ERROR";
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(Request.Form["cid"]) && !string.IsNullOrEmpty(Request.Form["mids"]) && !string.IsNullOrEmpty(Request.Form["uid"]) && !string.IsNullOrEmpty(Request.Form["uEmail"]) && !string.IsNullOrEmpty(Request.Form["uName"]) && !string.IsNullOrEmpty(Request.Form["SellerId"]) && !string.IsNullOrEmpty(Request.Form["tprice"]))
            {
                int cid = int.Parse(Request.Form["cid"]);
                string mids = Request.Form["mids"];
                int type = -1;
                if(mids.Contains(','))
                {
                    mids = mids.TrimEnd(',');
                    type = 1;
                }
                else
                {
                    type = 0;
                }
                int uid = int.Parse(Request.Form["uid"]);
                string email = Request.Form["uEmail"];
                int sellerId = int.Parse(Request.Form["SellerId"]);
                decimal totalPrice = decimal.Parse(Request.Form["tprice"]);
                string uName = Request.Form["uName"];
                Model.Tao.Orders orderList = new Model.Tao.Orders();
                orderList.BuyerID = uid;
                orderList.Email = email;
                orderList.Amount = totalPrice;
                orderList.UserName = uName;
                orderList.SellerID = sellerId;
                BLL.Tao.Orders orderBll = new BLL.Tao.Orders();
                int OId = orderBll.CreateNewOrderInfo(orderList, cid, mids, type);
                if (OId > 0)
                {

                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                    json.Put(TAO_KEY_DATA, OId);
                }
                else
                {
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
                }
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }

            context.Response.Write(json.ToString());
        }
    }
}