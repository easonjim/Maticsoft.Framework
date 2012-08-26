using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoFavorite
{
    public partial class Modify : PageBaseAdmin
    {
        private BLL.Tao.Favorite bll = new BLL.Tao.Favorite();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int FavoriteID = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(FavoriteID);
                }
            }
        }

        private void ShowInfo(int FavoriteID)
        {
            Model.Tao.Favorite model = bll.GetModel(FavoriteID);
            this.lblFavoriteID.Text = model.FavoriteID.ToString();
            this.txtCourseID.Text = model.CourseID.ToString();
            this.txtModuleID.Text = model.ModuleID.ToString();
            this.txtUserID.Text = model.UserID.ToString();
            this.txtTags.Text = model.Tags;
            this.txtRemark.Text = model.Remark;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (!PageValidate.IsNumber(txtCourseID.Text))
            {
                strErr += "课程格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtModuleID.Text))
            {
                strErr += "节次格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtUserID.Text))
            {
                strErr += "用户格式错误！\\n";
            }
            if (this.txtTags.Text.Trim().Length == 0)
            {
                strErr += "关键字不能为空！\\n";
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
            int FavoriteID = int.Parse(this.lblFavoriteID.Text);
            int CourseID = int.Parse(this.txtCourseID.Text);
            int ModuleID = int.Parse(this.txtModuleID.Text);
            int UserID = int.Parse(this.txtUserID.Text);
            string Tags = this.txtTags.Text;
            string Remark = this.txtRemark.Text;

            Model.Tao.Favorite model = new Model.Tao.Favorite();
            model.FavoriteID = FavoriteID;
            model.CourseID = CourseID;
            model.ModuleID = ModuleID;
            model.UserID = UserID;
            model.Tags = Tags;
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