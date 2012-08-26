using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class LearnCourse : System.Web.UI.UserControl
    {
        BLL.Tao.Orders orderBll = new BLL.Tao.Orders();

        public override void DataBind()
        {
            if (Flag)
            {
                AspNetPager1.RecordCount = RecordCount;// orderBll.BuyCourseCount(UserID);
                BindData(WhereStr);
            }
            else
            {
                AspNetPager1.RecordCount = RecordCount;// orderBll.CourseCountHis(UserID);
                BindData(WhereStr);
            }
        }

        private void BindData(string LimiteDate)
        {
            DataSet ds = orderBll.GetBuyCourse(this.AspNetPager1.StartRecordIndex, this.AspNetPager1.PageSize, UserID, WhereStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.rptPrice.DataSource = ds;
                this.rptPrice.DataBind();
            }
        }

        private bool _flag;
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string whereStr;
        public string WhereStr
        {
            get { return whereStr; }
            set { whereStr = value; }
        }

        private int _recordCount;

        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(WhereStr);
        }

        protected void rptPrice_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton imgBtn = e.Item.FindControl("imgBtn") as ImageButton;
                TextBox txtCom = e.Item.FindControl("txtCom") as TextBox;
                if (imgBtn == null || txtCom == null)
                {
                    return;
                }
                if (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[8] != null)
                {
                    if (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[8].ToString() != "")
                    {
                        imgBtn.Visible = false;
                        txtCom.Visible = false;
                    }
                }
                else
                {
                    imgBtn.Visible = true;
                    txtCom.Visible = true;
                }
            }
        }

        protected void rptPrice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument.Equals("btnCom"))
            {
                TextBox txtCom = e.Item.FindControl("txtCom") as TextBox;
                Label labOid = e.Item.FindControl("LabOid") as Label;
                Label labCid = e.Item.FindControl("labCid") as Label;
                if (txtCom == null || txtCom.Text == null || labOid == null)
                {
                    return;
                }
                int oid = int.Parse(labOid.Text);
                int cid = int.Parse(labCid.Text);

                Model.Tao.Comment commodel = new Model.Tao.Comment();
                commodel.OrderID = oid;
                commodel.CourseID = cid;
                commodel.ModuleID = -1;
                commodel.UserID = UserID;
                commodel.Comments = txtCom.Text;
                commodel.CommentDate = DateTime.Now;
                BLL.Tao.Comment combll = new BLL.Tao.Comment();
                if (combll.Add(commodel) > 0)
                {
                    this.DataBind();
                }
            }
        }
    }
}