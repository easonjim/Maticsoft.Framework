using System;

namespace Maticsoft.Web.PubCourse
{
    public partial class OffLineDocu : PageBaseUser
    {
        private BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();

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
                Maticsoft.Common.MessageBox.ResponseScript(this, "alert('请先填写教师信息！');history.back()");
            }
            if (!IsPostBack)
            {
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OffLineTeacherInfo.aspx?CourseId=" + CourseId);
        }

        protected void btnPub_Click(object sender, EventArgs e)
        {
            this.btnPub.Enabled = false;
            this.btnBack.Enabled = false;
            if (!bll.Exists(CourseId))
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "没找到该课程的相关信息！");
                return;
            }

            Model.Tao.OffLineCourse model = bll.GetModel(CourseId);
            model.UpdatedDate = DateTime.Now;
            model.Status = 1;
            if (bll.Update(model))
            {
                //发布成功 并导向一个页面
                Session["courseId"] = null;
                Maticsoft.Common.MessageBox.ShowLoadingTip(this, "发布成功,正在跳转...", "OfflineCourse.aspx");
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