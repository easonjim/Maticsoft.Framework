using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoOrderItems
{
    public partial class Show : PageBaseAdmin
    {
        public string strid = "";
        private BLL.Tao.OrderItems bll = new BLL.Tao.OrderItems();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["ItemID"]))
                {
                    if (PageValidate.IsNumber(Request.Params["ItemID"]))
                    {
                        strid = Request.Params["ItemID"];
                        int ItemID = (Convert.ToInt32(strid));
                        ShowInfo(ItemID);
                    }
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
                    this.lblOrderID.Text = model.OrderID.ToString();
                }
                this.lblCourseID.Text = GetCourseName(model.CourseID);
                this.lblModuleID.Text = GetModuleName(model.ModuleID);
                if (null != model.Price)
                {
                    this.lblPrice.Text = model.Price.ToString();
                }
                this.lblItemDescription.Text = model.ItemDescription;
                this.imgImageUrl.ImageUrl = "~" + model.ImageUrl;
                this.lblRemark.Text = model.Remark;
            }
        }
    }
}