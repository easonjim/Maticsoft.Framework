using System;
using System.Web.UI;
using Maticsoft.Model.Tao;
using Maticsoft.Payment.Web;

namespace Maticsoft.Web.Pay
{
    public partial class returnPay_url : PaymentReturnTemplatedPage<Orders>
    {
        private BLL.Tao.Orders manage = new BLL.Tao.Orders();

        public returnPay_url() : base(false) { }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Binddata(string resStr, string resUrl)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<scrip ttype=\"text/javascript\">countDown(5,'" + resUrl + "');</script>");
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
            return manage.ModifyBuyCourseStatus(order.OrderID);
        }

        #endregion 父类实现
    }
}