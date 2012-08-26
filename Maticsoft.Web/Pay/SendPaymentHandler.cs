using System;
using Maticsoft.Model.Tao;
using Maticsoft.Payment.Handler;
using System.Web;
using Maticsoft.Payment.Model;

namespace Maticsoft.Web.Pay
{
    public class SendPaymentHandler : SendPaymentHandlerBase<Orders>
    {
        private static Maticsoft.BLL.Tao.Orders manage = new BLL.Tao.Orders();

        protected override Payment.Model.TradeInfo GetTrade(string orderIdStr, decimal orderTotal, Orders order)
        {
            TradeInfo info = new TradeInfo();
            info.Body = orderIdStr;
            info.BuyerEmailAddress = order.BuyerEmailAddress;
            info.Date = order.OrderDate;
            info.OrderId = orderIdStr;
            info.Showurl = HttpContext.Current.Request.Url.Host;
            info.Subject = "";
            info.TotalMoney = orderTotal;
            return info;
        }

        #region 实现父类
        protected override decimal GetOrderTotal(string[] orderIds)
        {
            Orders orderModel = manage.GetModel(int.Parse(orderIds[0]));
            if (orderModel != null && orderModel.Amount.HasValue)
            {
                return orderModel.Amount.Value;
            }
            else
            {
                //非法订单ID
                throw new FormatException("The OrderId can not convert to number.");
            }
        }

        protected override Orders GetOrderInfo(string orderId)
        {
            int id = 0;
            if (int.TryParse(orderId, out id))
            {
                return manage.GetModel(id);
            }
            else
            {
                //非法订单ID
                throw new FormatException("The OrderId can not convert to number.");
            }
        }
        #endregion
    }
}