using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class ISPublishCourse : System.Web.UI.UserControl
    {
        BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        public override void DataBind()
        {
            this.AspNetPager1.RecordCount = courseBll.unPubCourseCount(UserID, Status);
            BindData();
        }

        private void BindData()
        {
            DataSet ds = courseBll.UnPubCourse(UserID, this.AspNetPager1.StartRecordIndex, this.AspNetPager1.PageSize, Status);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.ErrorMsg.Visible = false;
                this.Repeater_View.DataSource = ds;
                this.Repeater_View.DataBind();
            }
            else
            {
                this.ErrorMsg.Visible = true;
            }
        }

        protected void Repeater_View_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button imgBtn = (Button)e.Item.FindControl("btnContiue");
                if (DisplayBtn)
                {
                    if (imgBtn != null)
                    {
                        imgBtn.Visible = true;
                    }
                }
                else
                {
                    if (imgBtn != null)
                    {
                        imgBtn.Visible = false;
                    }
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _recordCount;
        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private bool displayBtn;
        public bool DisplayBtn
        {
            get { return displayBtn; }
            set { displayBtn = value; }
        }
    }
}