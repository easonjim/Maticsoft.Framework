using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Controls
{
    public partial class UnFinshOffLineCourse : System.Web.UI.UserControl
    {
        BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();
        public string strFlag = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Status.Equals(0))
            {
                strFlag = "/PubCourse/NewPubCourse.aspx?CourseId=";
            }
            if (Status.Equals(1))
            {
                strFlag = "../PreviewVideo.aspx?id=";
            }
        }

        public override void DataBind()
        {
            AspNetPager1.RecordCount = bll.unPublishCount(UserId, Status);
            BoundDate();
        }

        private void BoundDate()
        {
            System.Data.DataSet ds = bll.unPublishCourseInfo(UserId, AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, Status);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.ErrorMsg1.Visible = false;
                this.Repeater_PubCourse.DataSource = ds;
                this.Repeater_PubCourse.DataBind();
            }
            else
            {
                this.ErrorMsg1.Visible = false;
            }
        }

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BoundDate();
        }

        protected void Repeater_PubCourse_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label labCid = e.Item.FindControl("labCID") as Label;
            if (labCid == null)
            {
                return;
            }
            if (e.CommandArgument.Equals("btnDel"))
            {
                int cid = int.Parse(labCid.Text);
                bll.DeleteCourseunApprove(cid);

                Response.Redirect(Request.RawUrl);
            }
            if (e.CommandArgument.Equals("btnEdit"))
            {
                Response.Redirect("/PubCourse/OrganizeCourse.aspx?courseId=" + labCid.Text);
            }
        }

        protected void Repeater_PubCourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Label labCid = e.Item.FindControl("labCID") as Label;
                //Label labCount = e.Item.FindControl("labCount") as Label;
                //if (labCid == null || labCount == null)
                //{
                //    return;
                //}
                //int cid = int.Parse(labCid.Text);
                //labCount.Text = courseBll.getModelCount(cid).ToString();
            }
        }
    }
}