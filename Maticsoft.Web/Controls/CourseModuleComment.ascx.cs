using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class CourseModuleComment : System.Web.UI.UserControl
    {
        private int? courseID;
        private int? userID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.CommonCode.CheckUserLogin())
            {
                Common.CommonCode.GoLoginPage();
            }
            if (Request.QueryString["CourseID"] != null)
            {
                this.CourseID = int.Parse(Request.QueryString["CourseID"]);
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            BLL.Tao.Comment commentBll = new BLL.Tao.Comment();
            int iPageIndex = this.comment_AspNetPager.CurrentPageIndex;
            int iPageSize = this.comment_AspNetPager.PageSize;
            int iTotal = commentBll.GetCommentCount(5);
            DataTable dt = commentBll.GetCourseMoule(5, iPageIndex, iPageSize);
            this.comment_AspNetPager.RecordCount = iTotal;
            this.DataList_CommentList.DataSource = dt;
            this.DataList_CommentList.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                if (!string.IsNullOrEmpty(this.txtComment.Text.Trim()))
                {
                    Maticsoft.Accounts.Bus.User user = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                    Model.Tao.Comment commentModel = new Model.Tao.Comment();
                    commentModel.CourseID = (int)this.CourseID;
                    commentModel.UserID = user.UserID;
                    commentModel.CommentDate = DateTime.Now;
                    if (!string.IsNullOrEmpty(HiddenField1.Value))
                    {
                        commentModel.ParentID = int.Parse(HiddenField1.Value);
                    }
                    commentModel.Comments = this.txtComment.Text.Trim();

                    BLL.Tao.Comment commentBll = new BLL.Tao.Comment();
                    if (commentBll.Add(commentModel) > 0)
                    {
                        BindData();
                    }
                }
                else
                {
                    this.lblComment.Visible = true;
                }
            }
            else
            {
                Common.CommonCode.GoLoginPage();
            }
        }

        /// <summary>
        /// 当前课程ID
        /// </summary>
        public int? CourseID
        {
            get { return courseID; }
            set { courseID = 5; }
        }
        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public int? UserID
        {
            get { return userID; }
            set { userID = 66; }
        }

        protected void comment_AspNetPager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}