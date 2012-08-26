using System;
using Maticsoft.Model.Tao;
using Maticsoft.Payment.Handler;
using Maticsoft.Payment.Model;
using Maticsoft.Common;

namespace Maticsoft.Web.Pay
{
    public class PurchaseHandler : SendPaymentHandlerBase<Orders>
    {
        private static Maticsoft.BLL.Tao.Orders manage = new BLL.Tao.Orders();
        #region 获取支付网关
        /// <summary>
        /// 获取支付网关
        /// </summary>
        protected  override GatewayInfo GetGateway(string gatewayName)
        {
            GatewayInfo info = new GatewayInfo();
            info.ReturnUrl = Globals.FullPath(string.Format("/pay/returnPay_url.aspx?HIGW={0}", gatewayName));
            info.NotifyUrl = Globals.FullPath(string.Format("/pay/notify_url.aspx?HIGW={0}", gatewayName));
            return info;
        }


        #endregion

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