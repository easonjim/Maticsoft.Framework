using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoOrderItems
{
    public partial class Modify : PageBaseAdmin
    {
        private BLL.Tao.OrderItems bll = new BLL.Tao.OrderItems();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["ItemID"]))
                {
                    int ItemID = Convert.ToInt32(Request.Params["ItemID"]);
                    ShowInfo(ItemID);
                }
            }
        }

        private void ShowInfo(int ItemID)
        {
            Model.Tao.OrderItems model = bll.GetModel(ItemID);
            if (null != model)
            {
                this.lblItemID.Text = model.ItemID.ToString();
                if (null != model.OrderID)
                {
                    this.txtOrderID.Text = model.OrderID.ToString();
                }
                if (null != model.ModuleID)
                {
                    this.txtCourseID.Text = model.ModuleID.ToString();
                }
                if (null != model.ModuleID)
                {
                    this.txtModuleID.Text = model.ModuleID.ToString();
                }
                if (null != model.Price)
                {
                    this.txtPrice.Text = model.Price.ToString();
                }
                this.txtItemDescription.Text = model.ItemDescription;
                this.txtImageUrl.Text = model.ImageUrl;
                this.txtRemark.Text = model.Remark;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
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
            int ItemID = int.Parse(this.lblItemID.Text);
            int OrderID = int.Parse(this.txtOrderID.Text);
            int CourseID = int.Parse(this.txtCourseID.Text);
            int ModuleID = int.Parse(this.txtModuleID.Text);
            decimal Price = decimal.Parse(this.txtPrice.Text);
            string ItemDescription = this.txtItemDescription.Text;
            string ImageUrl = this.txtImageUrl.Text;
            string Remark = this.txtRemark.Text;

            Model.Tao.OrderItems model = new Model.Tao.OrderItems();
            model.ItemID = ItemID;
            model.OrderID = OrderID;
            model.CourseID = CourseID;
            model.ModuleID = ModuleID;
            model.Price = Price;
            model.ItemDescription = ItemDescription;
            model.ImageUrl = ImageUrl;
            model.Remark = Remark;

            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}