using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.PubCourse
{
    public partial class OfflineCourse : PageBaseUser
    {
        BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();

        public string liClass1 = string.Empty;
        public string liClass2 = string.Empty;
        public string divClass1 = string.Empty;
        public string divClass2 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SelectedTab();
            }
            BindUnPubCourse();
            BindPublisCourse();
            BindUnApproveCourse();
            BindFinishedCourse();
            //detailInfo.Visible = false;
        }

        /// <summary>
        /// 绑定已发布的课程信息
        /// </summary>
        private void BindPublisCourse()
        {
            this.ucOffLineCourseDetailInfo.Flag = true;
            this.ucOffLineCourseDetailInfo.LimiteDate = null;
            this.ucOffLineCourseDetailInfo.UserID = CurrentUser.UserID;
            this.ucOffLineCourseDetailInfo.DataBind();
        }

        /// <summary>
        /// 绑定未发布的课程
        /// </summary>
        private void BindUnPubCourse()
        {
            AspNetPager2.RecordCount = courseBll.unOffLinePublishCount(CurrentUser.UserID, 2);
            BoundDate();
        }

        /// <summary>
        /// 审核尚未完成的课程
        /// </summary>
        private void BindUnApproveCourse()
        {
            this.ucUnFinshOffLineCourse.UserId = CurrentUser.UserID;
            this.ucUnFinshOffLineCourse.Status = 1;
            this.ucUnFinshOffLineCourse.DataBind();
        }

        private void BindFinishedCourse()
        {
            this.ucUnFinshOffLineCourse1.UserId = CurrentUser.UserID;
            this.ucUnFinshOffLineCourse1.Status = 0;
            this.ucUnFinshOffLineCourse1.DataBind();
        }


        private void BoundDate()
        {
            System.Data.DataSet ds = courseBll.unPublishOfflineCourseInfo(CurrentUser.UserID, AspNetPager2.StartRecordIndex, AspNetPager2.PageSize, 2);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.ErrorMsg2.Visible = false;
                this.Repeater_PubCourse.DataSource = ds;
                this.Repeater_PubCourse.DataBind();
            }
            else
            {
                this.ErrorMsg2.Visible = false;
            }
        }

        protected void Repeater_PubCourse_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument.Equals("btnPub"))
            {
                Label labCid = e.Item.FindControl("labCID") as Label;
                int courseId = int.Parse(labCid.Text);
                if (bll.UpdateOffLineCourseStatus(3, courseId))
                {
                    Maticsoft.Common.MessageBox.ResponseScript(this, "alert('发布成功！')");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "发布失败！");
                }
            }
            if (e.CommandArgument.Equals("btnEditInfo"))
            {
                //对审核通过的课程进行修改----将状态改为完成待审核
                Label labCid = e.Item.FindControl("labCID") as Label;
                int courseId = int.Parse(labCid.Text);
                if (courseBll.UpdataCourseStatus(courseId))
                {
                    Response.Redirect("/PublishCourse/NewPubCourse.aspx?CourseId=" + labCid.Text);
                }
                else
                {
                    Session["CurrentError"] = "未知错误，请联系管理员！";
                    Server.Transfer("~/ErrorPage.aspx");
                }
            }
        }

        protected void Repeater_PubCourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
            }
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BoundDate();
        }

        public void SelectedTab()
        {
            if (!string.IsNullOrEmpty(Request.Params["type"]))
            {
                liClass1 = "";
                liClass2 = "opentabin";
                divClass1 = "balancexq";
                divClass2 = "balancecontentin";
            }
            else
            {
                liClass1 = "opentabin";
                liClass2 = "";
                divClass1 = "balancecontentin";
                divClass2 = "balancexq";
            }
        }
    }
}