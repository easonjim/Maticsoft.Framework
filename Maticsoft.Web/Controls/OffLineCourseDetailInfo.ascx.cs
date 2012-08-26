using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class OffLineCourseDetailInfo : System.Web.UI.UserControl
    {
        BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();

        public override void DataBind()
        {
            AspNetPager1.RecordCount = courseBll.PublishOfflineCourseCount(UserID, 3);
            BindData(LimiteDate);
        }

        private void BindData(string Limitdate)
        {
            DataSet ds = courseBll.GetPubLishOffLineCourse(UserID, AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, 3);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.ErrorMsg.Visible = false;
                this.btnOutOfStock.Visible = true;
                this.Repeater_Detail.DataSource = ds;
                this.Repeater_Detail.DataBind();
            }
            else
            {
                this.ErrorMsg.Visible = false;
                this.btnOutOfStock.Visible = false;
            }
        }

        #region MyRegion

        private bool _flag;
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        //private int _recordCount;
        public int RecordCount
        {
            set { AspNetPager1.RecordCount = value; }
        }

        private string _limiteDate;

        public string LimiteDate
        {
            get { return _limiteDate; }
            set { _limiteDate = value; }
        }
        
        #endregion

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(LimiteDate);
        }

        protected void Repeater_Detail_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void btnOutOfStock_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater_Detail.Items)
            {
                Label labCid = item.FindControl("labCID") as Label;
                if (labCid == null) { return; }
                if (string.IsNullOrEmpty(labCid.Text)) { return; }
                CheckBox chose = item.FindControl("ckCourse") as CheckBox;
                int cid = int.Parse(labCid.Text);
                if (chose.Checked)
                {
                    bll.UpdateOffLineCourseStatus(2,cid);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}