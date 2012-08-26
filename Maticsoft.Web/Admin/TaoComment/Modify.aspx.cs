using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoComment
{
    public partial class Modify : PageBaseAdmin
    {
        private BLL.Tao.Comment CommentBLL = new BLL.Tao.Comment();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    int CommentID = Convert.ToInt32(Request.Params["id"]);
                    ShowInfo(CommentID);
                }
            }
        }

        private void ShowInfo(int CommentID)
        {
            Model.Tao.Comment model = CommentBLL.GetModel(CommentID);
            if (null != model)
            {
                this.lblCommentID.Text = model.CommentID.ToString();
                txtCourseID.Text = model.CourseID.ToString();
                txtModuleID.Text = model.ModuleID.ToString();
                txtUserID.Text = model.UserID.ToString();
                this.txtComment.Text = model.Comments;
                txtCommentDate.Text = model.CommentDate.ToString();
                if (null != model.Score)
                {
                    this.txtScore.Text = model.Score.ToString();
                }
            }
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
                strErr += "评论人格式错误！\\n";
            }
            if (this.txtComment.Text.Trim().Length == 0)
            {
                strErr += "内容不能为空！\\n";
            }
            if (!PageValidate.IsDateTime(txtCommentDate.Text))
            {
                strErr += "评论时间格式错误！\\n";
            }
            if (!PageValidate.IsNumber(txtScore.Text))
            {
                strErr += "评论分值格式错误！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int CommentID = int.Parse(this.lblCommentID.Text);
            int CourseID = int.Parse(this.txtCourseID.Text);
            int ModuleID = int.Parse(this.txtModuleID.Text);
            int UserID = int.Parse(this.txtUserID.Text);
            string Comment = this.txtComment.Text;
            DateTime CommentDate = DateTime.Parse(this.txtCommentDate.Text);
            int Score = int.Parse(this.txtScore.Text);

            Model.Tao.Comment model = new Model.Tao.Comment();
            model.CommentID = CommentID;
            model.CourseID = CourseID;
            model.ModuleID = ModuleID;
            model.UserID = UserID;
            model.Comments = Comment;
            model.CommentDate = CommentDate;
            model.Score = Score;
            model.Status = 1;
            CommentBLL.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}