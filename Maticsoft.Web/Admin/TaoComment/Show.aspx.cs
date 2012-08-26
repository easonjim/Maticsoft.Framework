using System;
using System.Text;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoComment
{
    public partial class Show : PageBaseAdmin
    {
        private BLL.Tao.Comment bll = new BLL.Tao.Comment();
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    strid = Request.Params["id"];
                    int CommentID = (Convert.ToInt32(strid));
                    ShowInfo(CommentID);
                }
            }
        }

        private void ShowInfo(int CommentID)
        {
            Model.Tao.Comment model = bll.GetModel(CommentID);

            if (null != model)
            {
                this.lblCommentID.Text = model.CommentID.ToString();
                this.lblCourseName.Text = GetCourseName(model.CourseID);
                this.lblModuleName.Text = GetModuleName(model.ModuleID);
                this.lblUserName.Text = GetUserName(model.UserID);
                this.lblComment.Text = model.Comments;
                if (null != model.CommentDate)
                {
                    this.lblCommentDate.Text = model.CommentDate.ToString();
                }
                if (null != model.Score)
                {
                    this.lblScore.Text = model.Score.ToString();
                }
                lblStatus.Text = GetStatus(model.Status);
            }
        }

        public new string GetStatus(object obj)
        {
            StringBuilder strStatus = new StringBuilder();
            if (obj != null)
            {
                if (PageValidate.IsNumber(obj.ToString()))
                {
                    int id = Convert.ToInt32(obj);
                    switch (id)
                    {
                        case 0:
                            strStatus.Append("未审核");
                            break;

                        case 1:
                            strStatus.Append("审核");
                            break;
                        default:
                            strStatus.Append("未定义");
                            break;
                    }
                }
            }
            return strStatus.ToString();
        }
    }
}