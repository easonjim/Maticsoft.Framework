using System;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoFavorite
{
    public partial class Add : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
            int CourseID = int.Parse(this.txtCourseID.Text);
            int ModuleID = int.Parse(this.txtModuleID.Text);
            int UserID = int.Parse(this.txtUserID.Text);
            string Tags = this.txtTags.Text;
            string Remark = this.txtRemark.Text;

            Model.Tao.Favorite model = new Model.Tao.Favorite();
            model.CourseID = CourseID;
            model.ModuleID = ModuleID;
            model.UserID = UserID;
            model.Tags = Tags;
            model.Remark = Remark;

            BLL.Tao.Favorite bll = new BLL.Tao.Favorite();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}