using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoCategories
{
    public partial class Show : PageBaseAdmin
    {
        private BLL.Tao.Categories bll = new BLL.Tao.Categories();
        public string strid, strIconUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["CategoryId"]))
                {
                    if (PageValidate.IsNumber(Request.Params["CategoryId"]))
                    {
                        strid = Request.Params["CategoryId"];
                        int CategoryId = Convert.ToInt32(strid);
                        ShowInfo(CategoryId);
                    }
                }
            }
        }

        private void ShowInfo(int CategoryId)
        {
            Maticsoft.Model.Tao.Categories model = bll.GetModel(CategoryId);
            if (null != model)
            {
                this.lblCategoryId.Text = model.CategoryId.ToString();
                this.lblName.Text = model.Name;
                if (null != model.Sequence)
                {
                    this.lblSequence.Text = model.Sequence.ToString();
                }
                this.lblParentCategoryId.Text = GetCategoriesName(model.ParentCategoryId);
                if (null != model.Sequence)
                {
                    this.lblDepth.Text = model.Depth.ToString();
                }
                this.lblPath.Text = model.Path;
                this.lblDescription.Text = model.Description;
                strIconUrl = GetImage(model.IconUrl, 45, 45);
                if (null != model.Status)
                {
                    this.lblStatus.Text = model.Status.ToString();//状态未使用
                }
                if (null != model.Status)
                {
                    this.lblCreatedDate.Text = model.CreatedDate.ToString();
                }
                this.lblCreatedUserID.Text = GetUserName(model.CreatedUserID);
                this.lblRewriteName.Text = model.RewriteName;
            }
        }
    }
}