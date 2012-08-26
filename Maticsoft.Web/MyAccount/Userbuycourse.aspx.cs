using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.MyAccount
{
    public partial class Userbuycourse : PageBaseUser
    {
        private BLL.Tao.Orders orderBll = new BLL.Tao.Orders();

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.RecordCount = orderBll.BuyCourseCount(CurrentUser.UserID);
            AspNetPager2.RecordCount = orderBll.CourseCountHis(CurrentUser.UserID);
            if (!IsPostBack)
            {
                BindData();
                BindDatabf();
            }
        }

        #region MyRegion

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
                if (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[7] != null)
                {
                    if (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[7].ToString() != "")
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
                Label labMid = e.Item.FindControl("labMid") as Label;
                if (txtCom == null || txtCom.Text == null || labOid == null || labMid == null)
                {
                    return;
                }
                int oid = int.Parse(labOid.Text);
                int cid = int.Parse(labCid.Text);

                Model.Tao.Comment commodel = new Model.Tao.Comment();
                commodel.OrderID = oid;
                commodel.CourseID = cid;
                commodel.ModuleID = int.Parse(labMid.Text);
                commodel.UserID = CurrentUser.UserID;
                commodel.Comments = txtCom.Text;
                commodel.CommentDate = DateTime.Now;
                commodel.Status = 1;
                BLL.Tao.Comment combll = new BLL.Tao.Comment();
                if (combll.Add(commodel) > 0)
                {
                    BindData();
                }
            }
        }

        private void BindData()
        {
            DataSet ds = orderBll.GetBuyCourse(this.AspNetPager1.StartRecordIndex, this.AspNetPager1.PageSize, CurrentUser.UserID, "");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.rptPrice.DataSource = ds;
                this.rptPrice.DataBind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        #endregion MyRegion

        private void BindDatabf()
        {
            DataSet ds = orderBll.GetBuyCourse(this.AspNetPager2.StartRecordIndex, this.AspNetPager2.PageSize, CurrentUser.UserID, "true");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.rptPricebf.DataSource = ds;
                this.rptPricebf.DataBind();
            }
        }

        protected void rptPricebf_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton imgBtn = e.Item.FindControl("imgBtn") as ImageButton;
                TextBox txtCom = e.Item.FindControl("txtCom") as TextBox;
                if (imgBtn == null || txtCom == null)
                {
                    return;
                }
                if (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[7] != null)
                {
                    if (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[7].ToString() != "")
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

        protected void rptPricebf_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument.Equals("btnCom"))
            {
                TextBox txtCom = e.Item.FindControl("txtCom") as TextBox;
                Label labOid = e.Item.FindControl("LabOid") as Label;
                Label labCid = e.Item.FindControl("labCid") as Label;
                Label labMid = e.Item.FindControl("labMid") as Label;
                if (txtCom == null || txtCom.Text == null || labOid == null || labMid == null)
                {
                    return;
                }
                int oid = int.Parse(labOid.Text);
                int cid = int.Parse(labCid.Text);

                Model.Tao.Comment commodel = new Model.Tao.Comment();
                commodel.OrderID = oid;
                commodel.CourseID = cid;
                commodel.ModuleID = int.Parse(labMid.Text);
                commodel.UserID = CurrentUser.UserID;
                commodel.Comments = txtCom.Text;
                commodel.CommentDate = DateTime.Now;
                commodel.Status = 1;
                BLL.Tao.Comment combll = new BLL.Tao.Comment();
                if (combll.Add(commodel) > 0)
                {
                    BindDatabf();
                }
            }
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindDatabf();
        }
    }
}