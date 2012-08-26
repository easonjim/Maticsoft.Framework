using System;
using System.Collections.Generic;

namespace Maticsoft.Web.MyAccount
{
    public partial class userRecharge2 : PageBaseUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 进行支付, 新窗口打开
                this.Form.Target = "_blank";
                if (!string.IsNullOrEmpty(Request.QueryString["total_fee"]) && !string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    this.litAccount.Text = CurrentUser.Email;
                    decimal totalMoney = Common.Globals.SafeDecimal(Request.QueryString["total_fee"], 0);
                    this.litNum.Text = (totalMoney).ToString();
                    this.litMoney.Text = Request.QueryString["total_fee"];
                }
                else
                {
                    Response.Redirect("~/ErrorPage.aspx");
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //生成订单
            Model.Tao.Orders model = new Model.Tao.Orders();
            BLL.Tao.Orders orderBll = new BLL.Tao.Orders();
            model.BuyerID = CurrentUser.UserID;//充值人的ID
            model.UserName = CurrentUser.TrueName;//充值人姓名
            model.Email = this.litAccount.Text;//充值人的Email
            decimal totalMoney = Common.Globals.SafeDecimal(Request.QueryString["total_fee"], 0);
            if (totalMoney == 0)
            {
                Server.Transfer("~/ErrorPage.aspx");
            }
            model.Amount = totalMoney;//充值金额
            List<Maticsoft.Payment.Model.PaymentModeInfo> listPay = Maticsoft.Payment.BLL.PaymentModeManage.GetPaymentModes();
            if (listPay.Count == 0)
            {
                Server.Transfer("~/ErrorPage.aspx");
            }
            if (listPay[0].ModeId <= 0)
            {
                Server.Transfer("~/ErrorPage.aspx");
            }
            model.PaymentTypeId = listPay[0].ModeId;//支付类型接口

            int resOrderId = orderBll.Rechange(model);

            if (resOrderId > 0)
            {
                model.OrderID = resOrderId;
                orderBll.UpdatePaymentID(model);
                Response.Redirect(string.Format("/SendPayment.aspx?OrderIds={0}", resOrderId));
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "订单生成失败，请联系管理员！");
                return;
            }
        }
    }
}