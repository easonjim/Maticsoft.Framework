using System;
using System.Web.UI;
using Maticsoft.Model.Tao;
using Maticsoft.Payment.Web;

namespace Maticsoft.Web.Pay
{
    public partial class return_url : PaymentReturnTemplatedPage<Orders>
    {
        private BLL.Tao.Orders manage = new BLL.Tao.Orders();

        public return_url() : base(false) { }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Binddata(string resStr, string resUrl)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language=javascript>countDown(5,'" + resUrl + "');</script>");
            this.Page.Controls.Add(new LiteralControl(sb.ToString()));
        }

        protected override void DisplayMessage(string status)
        {
            if (status.Equals("success"))
            {
                Response.Redirect("/LearnCourse/PerAccount.aspx");
            }
            else
            {
                Response.Redirect("/LearnCourse/PerAccount.aspx");
            }
            //switch (status)
            //{
            //case "ordernotfound":
            //    this.litMessage.Text = string.Format((string)HttpContext.GetGlobalResourceObject("Resources", "IDS_OrderStatus_OrderNotFound"), base.OrderId);
            //    return;

            //case "gatewaynotfound":
            //    this.litMessage.Text = string.Format((string)HttpContext.GetGlobalResourceObject("Resources", "IDS_OrderStatus_GatewayNotFound"), base.GatewayName);
            //    return;

            //case "verifyfaild":
            //    this.litMessage.Text = (string)HttpContext.GetGlobalResourceObject("Resources", "IDS_OrderStatus_VerifyFaild");
            //    return;

            //case "success":
            //    Response.Redirect("/LearnCourse/PerAccount.aspx");
            //    //Binddata("充值成功，", "LearnCourse/PerAccount.aspx");
            //    //this.Label1.Text ="充值成功";// string.Format((string)HttpContext.GetGlobalResourceObject("Resources", "IDS_OrderStatus_success"), base.OrderId, this.Amount.ToString("F"));
            //    return;
            //case "exceedordermax":
            //    this.litMessage.Text = "订单为团购订单，订购数量超过订购总数，支付失败";
            //    return;

            //case "groupbuyalreadyfinished":
            //    this.litMessage.Text = "订单为团购订单，团购活动已结束，支付失败";
            //    return;

            //case "fail":
            //    Binddata("充值失败，", "LearnCourse/PerAccount.aspx");
            //   //this.Label1.Text = "充值失败";//(string)HttpContext.GetGlobalResourceObject("Resources", "IDS_OrderStatus_fail");
            //    return;
            //}
            //this.litMessage.Text = (string)HttpContext.GetGlobalResourceObject("Resources", "IDS_OrderStatus_Unknow");
        }

        #region 父类实现

        /// <summary>
        /// 根据订单ID 获取订单信息
        /// </summary>
        protected override Orders GetOrderInfo(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                return null;
            }
            int oid = int.Parse(orderId);
            return manage.GetModel(oid);
        }

        /// <summary>
        /// 更新订单-完成付款
        /// </summary>
        protected override bool PayForOrder(Orders order)
        {
            return manage.ModifyOrderStatus(order.OrderID);
        }

        #endregion 父类实现
    }
}