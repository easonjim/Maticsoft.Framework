using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.PubCourse
{
    public partial class OrgClist : PageBaseUser
    {
        public string strMsg = string.Empty;

        private BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        private BLL.Tao.SendInvite sendBll = new BLL.Tao.SendInvite();
        private BLL.Tao.CourseModule coursesMBll = new BLL.Tao.CourseModule();

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.RecordCount = courseBll.PublishCourseCount(CurrentUser.UserID, 3, 1);
            AspNetPager2.RecordCount = courseBll.PublishCourseCount(CurrentUser.UserID, 0, 1);
            AspNetPager3.RecordCount = courseBll.orgCourseCount(CurrentUser.UserID);
            if (!IsPostBack)
            {
                BindPublishCourse();
                BindData();
                BindAttendCourse();
                BindInviteCourse();
            }
        }

        private void BindData()
        {
            DataSet ds = courseBll.GetPubLishCourse(CurrentUser.UserID, AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, 3, 1);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.ErrorMsg.Visible = false;
                this.Repeater_OrgCourse.DataSource = ds;
                this.Repeater_OrgCourse.DataBind();
            }
            else
            {
                this.ErrorMsg.Visible = false;
            }
        }

        private void BindPublishCourse()
        {
            DataSet ds = courseBll.GetPubLishCourse(CurrentUser.UserID, AspNetPager2.StartRecordIndex, AspNetPager2.PageSize, 0, 1);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.ErrorMsg.Visible = false;
                this.Repeater_unOrg.DataSource = ds;
                this.Repeater_unOrg.DataBind();
            }
            else
            {
                this.ErrorMsg.Visible = false;
            }
        }

        private void BindAttendCourse()
        {
            DataSet ds = courseBll.getOrgCourseInfo(AspNetPager3.StartRecordIndex, AspNetPager3.PageSize, CurrentUser.UserID);
            this.Repeater_AttendOrg.DataSource = ds;
            this.Repeater_AttendOrg.DataBind();
        }

        private void BindInviteCourse()
        {
            DataSet ds = BLL.Tao.SendInvite.GetInviteCourseById(CurrentUser.UserID);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Repeater_Invite.DataSource = ds;
                    Repeater_Invite.DataBind();
                }
            }
        }

        public string EncodeCourseName(string courseName)
        {
            return Server.UrlEncode(courseName);
        }

        protected void Repeater_OrgCourse_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }

        protected void Repeater_OrgCourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label labCid = e.Item.FindControl("labCID") as Label;
                Label labCount = e.Item.FindControl("labCount") as Label;
                if (labCid == null || labCount == null)
                {
                    return;
                }
                int cid = int.Parse(labCid.Text);
                labCount.Text = courseBll.getModelCount(cid).ToString();
            }
        }

        protected void Repeater_unOrg_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label labCid = e.Item.FindControl("labCID") as Label;
            if (labCid == null)
            {
                return;
            }
            if (e.CommandArgument.Equals("btnDel"))
            {
                int cid = int.Parse(labCid.Text);
                courseBll.DeleteCourseunApprove(cid);
            }
            if (e.CommandArgument.Equals("btnEdit"))
            {
                Response.Redirect("/PubCourse/OrganizeCourse.aspx?courseId=" + labCid.Text);
            }
        }

        protected void Repeater_unOrg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label labCid = e.Item.FindControl("labCID") as Label;
                Label labCount = e.Item.FindControl("labCount") as Label;
                if (labCid == null || labCount == null)
                {
                    return;
                }
                int cid = int.Parse(labCid.Text);
                labCount.Text = courseBll.getModelCount(cid).ToString();
            }
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindPublishCourse();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater_AttendOrg_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }

        protected void Repeater_AttendOrg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label labCid = e.Item.FindControl("labCID") as Label;
                Label labCount = e.Item.FindControl("labCount") as Label;
                Label labTeacherCount = e.Item.FindControl("labTeacherCount") as Label;
                if (labCid == null || labCount == null || labTeacherCount == null)
                {
                    return;
                }
                int cid = int.Parse(labCid.Text);
                labCount.Text = courseBll.getModelCount(cid).ToString();
                labTeacherCount.Text = "共" + getTeacherCount(cid).ToString() + "人";
            }
        }

        private int getTeacherCount(int courseId)
        {
            int count = coursesMBll.GetCourserteacher(courseId);
            return count;
        }

        public string VideoStatus(object status)
        {
            if (status == null)
            {
                return "未知错误";
            }
            string statusStr = status.ToString();
            switch (statusStr)
            {
                case "0":
                    return "未完成";
                case "1":
                    return "未审核";
                case "2":
                    return "未发布";
                case "3":
                    return "已发布";
                case "4":
                    return "审核失败";
                case "5":
                    return "已关闭";
                default:
                    return "未知错误";
            }
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            BindAttendCourse();
        }

        protected void Repeater_Invite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label labID = e.Item.FindControl("labID") as Label;
            Label LaInviteID = e.Item.FindControl("LaInviteID") as Label;
            if (e.CommandArgument.Equals("access"))
            {
                //接受邀请 更改courseModule表中的状态为 同意 并跳转到 上传视频页面
            }
            if (e.CommandArgument.Equals("refuse"))
            {
                //拒绝邀请 更改courseModule表中的状态为 拒绝：
                if (labID != null && LaInviteID != null)
                {
                    int id = int.Parse(labID.Text);
                    Model.Tao.CourseModule cmModle = coursesMBll.GetModel(id);
                    cmModle.Status = 3;
                    cmModle.UpdateDate = DateTime.Now;
                    int sid = int.Parse(LaInviteID.Text);
                    Model.Tao.SendInvite sendiModle = sendBll.GetModel(sid);
                    sendiModle.DisposeDate = DateTime.Now;
                    sendiModle.InviteStatus = 2;
                    sendBll.Update(sendiModle);
                    coursesMBll.Update(cmModle);
                    BindInviteCourse();
                }
            }
        }

        protected void Repeater_Invite_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btnAccess = e.Item.FindControl("btnAccsess") as Button;
                Button btnRefuse = e.Item.FindControl("btnRefuse") as Button;
                Label labText = e.Item.FindControl("labText") as Label;
                string statusStr = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[11].ToString();
                if (statusStr.Equals("0"))
                {
                    btnAccess.Visible = true;
                    btnRefuse.Visible = true;
                }
                else if (statusStr.Equals("1"))
                {
                    labText.Text = "<a href=\"#\">已接受邀请</a>";
                    btnAccess.Visible = false;
                    btnRefuse.Visible = false;
                }
                else if (statusStr.Equals("2"))
                {
                    labText.Text = "已拒绝";
                    btnAccess.Visible = false;
                    btnRefuse.Visible = false;
                }
                else
                {
                    labText.Text = "已拒绝";
                    btnAccess.Visible = false;
                    btnRefuse.Visible = false;
                }
            }
        }
    }
}