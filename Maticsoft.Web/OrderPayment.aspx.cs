using System;
using System.Collections.Generic;

namespace Maticsoft.Web
{
    public partial class OrderPayment : PageBaseUser
    {
        private BLL.Tao.Orders orderBll = new BLL.Tao.Orders();
        private BLL.UserExp.UsersExp uexpBll = new BLL.UserExp.UsersExp();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string orderStr = Request.QueryString["OrderId"];
                if (!string.IsNullOrEmpty(orderStr))
                {
                    this.labUAccount.Text = CurrentUser.Email;
                    this.hfOrderId.Value = orderStr;
                    int Oid = int.Parse(orderStr);
                    List<Model.Tao.Orders> list = orderBll.GetTotalPrice(Oid);
                    if (list != null)
                    {
                        this.labTotalMoney.Text = (list[0].Amount).ToString();
                        int balance = uexpBll.GetUserBalance(CurrentUser.UserID);
                        this.labBalance.Text = balance.ToString();
                        if (balance < list[0].Amount)
                        {
                            this.btnLocal.Visible = false;
                        }
                    }
                }
                else
                {
                    Session["CurrentError"] = "订单不存在！";
                    Server.Transfer("~/ErrorPage.aspx");
                }
            }
        }

        public string BalanceInfo()
        {
            if (!string.IsNullOrEmpty(this.hfOrderId.Value))
            {
                int Oid = int.Parse(this.hfOrderId.Value);
                List<Model.Tao.Orders> list = orderBll.GetTotalPrice(Oid);
                if (list != null)
                {
                    this.labTotalMoney.Text = list[0].Amount.ToString();
                    int balance = uexpBll.GetUserBalance(CurrentUser.UserID);
                    if (balance < list[0].Amount)
                    {
                        return "<div style='width:auto;'><p>剩余学币不足以支付，请充值后支付或选择其他支付方式。</p></div>";
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Model.Tao.Orders model = new Model.Tao.Orders();
            if (fsRadio.Checked)
            {
                List<Maticsoft.Payment.Model.PaymentModeInfo> listPay = Maticsoft.Payment.BLL.PaymentModeManage.GetPaymentModes();
                if (listPay != null)
                {
                    if (listPay.Count == 0)
                    {
                        //Session["CurrentError"] = "没有可用的支付方式！";
                        //throw new Exception("1");
                        Server.Transfer("~/ErrorPage.aspx");
                    }
                    if (listPay[0].ModeId <= 0)
                    {
                        //throw new Exception("2");
                        Server.Transfer("~/ErrorPage.aspx");
                    }
                    if (!string.IsNullOrEmpty(this.hfOrderId.Value))
                    {
                        model.PaymentTypeId = listPay[0].ModeId;//支付类型接口
                        model.OrderID = int.Parse(this.hfOrderId.Value);
                        BLL.Tao.Orders order = new BLL.Tao.Orders();
                        order.UpdatePaymentID(model);
                    }
                }
                else
                {
                    //Session["CurrentError"] = "没有可用的支付方式！";
                    Server.Transfer("~/ErrorPage.aspx");
                }
            }
            if (string.IsNullOrEmpty(this.hfOrderId.Value))
            {
                //Session["CurrentError"] = "没找到该订单信息，请联系管理员！";
                Server.Transfer("~/ErrorPage.aspx");
            }
            int resOrderId = int.Parse(this.hfOrderId.Value);
            if (resOrderId > 0)
            {
                Response.Redirect(string.Format("/PurchaseHandler.aspx?OrderIds={0}", resOrderId));
            }
            else
            {
                Session["CurrentError"] = "订单生成失败，请联系管理员！";
                Server.Transfer("~/ErrorPage.aspx");
            }
        }

        protected void btnLocal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hfOrderId.Value))
            {
                int orderId = int.Parse(this.hfOrderId.Value);
                BLL.Tao.Orders orderBll = new BLL.Tao.Orders();
                if (orderBll.ModifyOrderInfo(orderId))
                {
                    Maticsoft.Common.MessageBox.ResponseScript(this, "购买成功，您可以进行观看了！");
                    Response.Redirect("/LearnCourse/PerBuycourse.aspx");
                }
            }
        }
    }
}