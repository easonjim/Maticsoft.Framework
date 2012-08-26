/**
* TradeDetailsHandle.cs
*
* 功 能： [N/A]
* 类 名： TradeDetailsHandle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/6/29 9:54:14  Rock    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jayrock.Json;

namespace Maticsoft.Web.AjaxHandle
{
    public class TradeDetailsHandle : IHttpHandler
    {
        public const string TAO_KEY_STATUS = "STATUS";
        public const string TAO_KEY_DATA = "DATA";

        public const string TAO_STATUS_SUCCESS = "SUCCESS";
        public const string TAO_STATUS_FAILED = "FAILED";
        public const string TAO_STATUS_ERROR = "ERROR";

        BLL.Tao.TradeDetails bll = new BLL.Tao.TradeDetails();


        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Form["Action"];

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            try
            {
                switch (action)
                {
                    #region 本月账单
                    case "currentMon":
                        TradeLsit(context, action);
                        break;
                    #endregion
                    #region 全部账单
                    case "allMon":
                        TradeLsit(context, action);
                        break;
                    #endregion
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                JsonObject json = new JsonObject();
                json.Put(TAO_KEY_STATUS, TAO_STATUS_ERROR);
                json.Put(TAO_KEY_DATA, ex);
                context.Response.Write(json.ToString());
            }
        }

        private void TradeLsit(HttpContext context,string action)
        {
            int RowCount = 0;
            int PageCount = 0;
            decimal Balance = 0.0M;
            JsonObject json = new JsonObject();
            string strID = context.Request.Params["UserId"];
            int uid = Common.Globals.SafeInt(strID, 0);

            string strIndex = context.Request.Params["PageIndex"];
            int PageIndex = Common.Globals.SafeInt(strIndex, 1);
            int PageSize = 10;
            List<Model.Tao.TradeDetails> list = null;
            if (action == "currentMon")
            {
                 list = bll.GetListByUId(out RowCount, out PageCount, out Balance, uid, PageIndex, PageSize, true);
            }
            else
            {
                list = bll.GetListByUId(out RowCount, out PageCount, out Balance, uid, PageIndex, PageSize, false);
            }
            if (list.Count > 0)
            {
                JsonArray data = new JsonArray();
                list.ForEach(info => data.Add(new JsonObject(
                   new string[] { "ID", "DataTime", "InCome", "Pay", "Balance", "Remark" },
                   new object[] { info.ID, info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), info.TradeAmount, info.Pay, info.Balance, info.Remark }
                   )));
                json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                json.Put(TAO_KEY_DATA, data);
                json.Put("ROWCOUNT", RowCount);
                json.Put("PAGECOUNT", PageCount);
                json.Put("BALANCE", Balance);
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            context.Response.Write(json.ToString());
        }
    }
}