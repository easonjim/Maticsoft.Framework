using System;
using System.Web.UI;

namespace Maticsoft.Web.PubCourse
{
    public partial class publishCourse : PageBaseUser
    {
        private BLL.Tao.Courses courseBll = new BLL.Tao.Courses();

        private int CourseId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["CourseId"]))
            {
                string courseStr = Request.QueryString["CourseId"];
                CourseId = int.Parse(courseStr);
                this.hfCourseID.Value = courseStr;
            }
            else
            {
                Maticsoft.Common.MessageBox.ResponseScript(this, "alert('请先课程定价！');history.back()");
            }
            if (!IsPostBack)
            {
            }
        }

        protected void btnOrganCourse_Click(object sender, ImageClickEventArgs e)
        {
            if (courseBll.changeCourseType(CourseId) > 0)
            {
                Response.Redirect("/PublishCourse/SendLink.aspx?CourseId=" + CourseId);
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "系统忙，请稍后再试！");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoursePrice.aspx?CourseId=" + CourseId);
        }

        protected void btnPub_Click(object sender, EventArgs e)
        {
            this.btnPub.Enabled = false;
            this.btnBack.Enabled = false;
            if (!courseBll.Exists(CourseId))
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "没找到该课程的相关信息！");
                return;
            }
            //更新Course表中的Status=1 已发布，更新Module表中的Status=1 已发布
            if (courseBll.PublishCourse(CourseId) > 0)
            {
                //发布成功 并导向一个页面
                Session["courseId"] = null;
                Maticsoft.Common.MessageBox.ShowLoadingTip(this, "发布成功,正在跳转...", "OnlineCourse.aspx");
            }
            else
            {
                this.btnPub.Enabled = true;
                this.btnBack.Enabled = true;
                Maticsoft.Common.MessageBox.ShowFailTip(this, "系统忙，请稍后再试！");
            }
        }
    }
}