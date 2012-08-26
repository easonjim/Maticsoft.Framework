using System;
using System.Web.UI;

namespace Maticsoft.Web.Pay
{
    public partial class returnpay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["alipayKey"];
            string orderNumber = this.GetQueryString("out_trade_no");
            string state = this.GetQueryString("returncode");
            string fee = this.GetQueryString("total_fee");
            string returnSign = this.GetQueryString("sign");

            string userSign = Common.CommonCode.Md5Compute(orderNumber + state + fee + key);

            if (state == "ok")
            {
                int orderId = int.Parse(orderNumber);
                BLL.Tao.Orders orderBll = new BLL.Tao.Orders();
                if (orderBll.ModifyBuyCourseStatus(orderId))
                {
                    Response.Redirect("/LearnCourse/PerAccount.aspx");
                    //Binddata("充值成功，", "LearnCourse/PerAccount.aspx");
                    //this.Label1.Text = "支付成功";
                }
                else
                {
                    this.Label1.Text = "支付失败";
                }
            }
        }

        protected void Binddata(string resStr, string resUrl)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<scrip ttype=\"text/javascript\">countDown(5,'" + resUrl + "');</script>");
            this.Page.Controls.Add(new LiteralControl(sb.ToString()));
        }

        protected string GetQueryString(string key)
        {
            if (Request[key] != null)
            {
                return Request[key];
            }
            else
            {
                //应该转向订单,但是还没做,先转到购物车
                Response.Redirect("/ShowMsg.aspx?msg=" + Server.UrlEncode("支付宝返回的参数丢失!~"));
                return "";
            }
        }
    }
}