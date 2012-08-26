using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoOrders
{
    public partial class Modify : PageBaseAdmin
    {
        private BLL.Tao.Orders bll = new BLL.Tao.Orders();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["OrderId"]))
                {
                    int OrderID = Convert.ToInt32(Request.Params["OrderId"]);
                    ShowInfo(OrderID);
                }
            }
        }

        private void ShowInfo(int OrderID)
        {
            Model.Tao.Orders model = bll.GetModel(OrderID);
            if (null != model)
            {
                this.lblOrderID.Text = model.OrderID.ToString();
                this.txtOrderDate.Text = model.OrderDate.ToString();
                this.txtBuyerID.Text = model.BuyerID.ToString();
                this.txtUserName.Text = model.UserName;
                this.txtEmail.Text = model.Email;
                this.txtRemark.Text = model.Remark;
                if (null != model.Amount)
                {
                    this.txtAmount.Text = model.Amount.ToString();
                }
                this.txtStatus.Text = model.Status.ToString();
                if (null != model.SellerID)
                {
                    this.txtSellerID.Text = model.SellerID.ToString();
                }
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (!PageValidate.IsDateTime(txtOrderDate.Text))
            {
                strErr += "订单日期格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtBuyerID.Text))
            {
                strErr += "购买者格式错误！\\n";
            }
            if (this.txtUserName.Text.Trim().Length == 0)
            {
                strErr += "用户名称不能为空！\\n";
            }
            if (this.txtEmail.Text.Trim().Length == 0)
            {
                strErr += "邮箱不能为空！\\n";
            }
            if (this.txtRemark.Text.Trim().Length == 0)
            {
                strErr += "备注不能为空！\\n";
            }
            if (!PageValidate.IsDecimal(txtAmount.Text))
            {
                strErr += "总金额格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtStatus.Text))
            {
                strErr += "状态格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtSellerID.Text))
            {
                strErr += "发布人格式错误！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int OrderID = int.Parse(this.lblOrderID.Text);
            DateTime OrderDate = DateTime.Parse(this.txtOrderDate.Text);
            int BuyerID = int.Parse(this.txtBuyerID.Text);
            string UserName = this.txtUserName.Text;
            string Email = this.txtEmail.Text;
            string Remark = this.txtRemark.Text;
            decimal Amount = decimal.Parse(this.txtAmount.Text);
            int Status = int.Parse(this.txtStatus.Text);
            int SellerID = int.Parse(this.txtSellerID.Text);

            Model.Tao.Orders model = new Model.Tao.Orders();
            model.OrderID = OrderID;
            model.OrderDate = OrderDate;
            model.BuyerID = BuyerID;
            model.UserName = UserName;
            model.Email = Email;
            model.Remark = Remark;
            model.Amount = Amount;
            model.Status = Status;
            model.SellerID = SellerID;

            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}