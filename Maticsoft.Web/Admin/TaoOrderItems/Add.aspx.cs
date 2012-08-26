using System;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoOrderItems
{
    public partial class Add : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (!PageValidate.IsNumber(txtOrderID.Text))
            {
                strErr += "订单格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtCourseID.Text))
            {
                strErr += "课程格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtModuleID.Text))
            {
                strErr += "章节格式错误！\\n";
            }
            if (!PageValidate.IsDecimal(txtPrice.Text))
            {
                strErr += "价格格式错误！\\n";
            }
            if (this.txtItemDescription.Text.Trim().Length == 0)
            {
                strErr += "商品描述不能为空！\\n";
            }
            if (this.txtImageUrl.Text.Trim().Length == 0)
            {
                strErr += "图片不能为空！\\n";
            }
            if (this.txtRemark.Text.Trim().Length == 0)
            {
                strErr += "备注不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int OrderID = int.Parse(this.txtOrderID.Text);
            int CourseID = int.Parse(this.txtCourseID.Text);
            int ModuleID = int.Parse(this.txtModuleID.Text);
            decimal Price = decimal.Parse(this.txtPrice.Text);
            string ItemDescription = this.txtItemDescription.Text;
            string ImageUrl = this.txtImageUrl.Text;
            string Remark = this.txtRemark.Text;

            Model.Tao.OrderItems model = new Model.Tao.OrderItems();
            model.OrderID = OrderID;
            model.CourseID = CourseID;
            model.ModuleID = ModuleID;
            model.Price = Price;
            model.ItemDescription = ItemDescription;
            model.ImageUrl = ImageUrl;
            model.Remark = Remark;

            BLL.Tao.OrderItems bll = new BLL.Tao.OrderItems();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}