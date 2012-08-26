using System;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoOrders
{
    public partial class Add : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
            DateTime OrderDate = DateTime.Parse(this.txtOrderDate.Text);
            int BuyerID = int.Parse(this.txtBuyerID.Text);
            string UserName = this.txtUserName.Text;
            string Email = this.txtEmail.Text;
            string Remark = this.txtRemark.Text;
            decimal Amount = decimal.Parse(this.txtAmount.Text);
            int Status = int.Parse(this.txtStatus.Text);
            int SellerID = int.Parse(this.txtSellerID.Text);

            Model.Tao.Orders model = new Model.Tao.Orders();
            model.OrderDate = OrderDate;
            model.BuyerID = BuyerID;
            model.UserName = UserName;
            model.Email = Email;
            model.Remark = Remark;
            model.Amount = Amount;
            model.Status = Status;
            model.SellerID = SellerID;

            BLL.Tao.Orders bll = new BLL.Tao.Orders();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}