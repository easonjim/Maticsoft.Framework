using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoOrders
{
    public partial class Show : PageBaseAdmin
    {
        private BLL.Tao.Orders bll = new BLL.Tao.Orders();
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["OrderId"]))
                {
                    if (PageValidate.IsNumber(Request.Params["OrderId"]))
                    {
                        strid = Request.Params["OrderId"];
                        int OrderID = Convert.ToInt32(strid);
                        ShowInfo(OrderID);
                    }
                }
            }
        }

        private void ShowInfo(int OrderID)
        {
            Model.Tao.Orders model = bll.GetModel(OrderID);
            if (null != model)
            {
                this.lblOrderID.Text = model.OrderID.ToString();
                this.lblOrderDate.Text = model.OrderDate.ToString();
                this.lblBuyerID.Text = GetUserName(model.BuyerID);
                this.lblUserName.Text = model.UserName;
                this.lblEmail.Text = model.Email;
                this.lblRemark.Text = model.Remark;
                this.lblAmount.Text = model.Amount.ToString();
                this.lblStatus.Text = GetOrderStatus(model.Status);
                this.lblSellerID.Text = GetUserName(model.SellerID);
            }
        }
    }
}