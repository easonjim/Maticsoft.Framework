using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoCategories
{
    public partial class List : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.Categories bll = new Maticsoft.BLL.Tao.Categories();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnDelete.Attributes.Add("onclick", "return confirm(\"" + Resources.Site.TooltipDelConfirm + "\")");
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DeleteList)))
                {
                    btnDelete.Visible = false;
                }

                grdTopCategries.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                grdTopCategries.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
        }

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat("keywordField like '%{0}%'", txtKeyword.Text.Trim());
            }
            ds = bll.GetList(strWhere.ToString());

            grdTopCategries.DataSource = ds;
            grdTopCategries.DataBind();
        }

        #endregion gridView

        protected void grdTopCategries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int num = (int)DataBinder.Eval(e.Row.DataItem, "Depth");
                string str = DataBinder.Eval(e.Row.DataItem, "Name").ToString();
                e.Row.Cells[0].CssClass = "productcag" + num.ToString();
                if (num != 1)
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl control = e.Row.FindControl("spShowImage") as System.Web.UI.HtmlControls.HtmlGenericControl;
                    control.Visible = false;
                }
                Label label = e.Row.FindControl("lblCategoryName") as Label;
                label.Text = str;
            }
        }

        protected void grdTopCategries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
            int categoryId = (int)this.grdTopCategries.DataKeys[rowIndex].Value;
            if (e.CommandName == "Fall")
            {
                bll.SwapCategorySequence(categoryId, CategoryZIndex.Down);
            }
            else if (e.CommandName == "Rise")
            {
                bll.SwapCategorySequence(categoryId, CategoryZIndex.Up);
            }
            else if (e.CommandName == "DeleteImage")
            {
            }
            this.BindData();
        }

        protected void grdTopCategries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = bll.GetList(" CategoryId=" + (int)this.grdTopCategries.DataKeys[e.RowIndex].Value);
            CategoryActionStatus status = bll.DeleteCategory((int)this.grdTopCategries.DataKeys[e.RowIndex].Value);
            if (status == CategoryActionStatus.Success)
            {
                //s删除类别对应的ICO
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    HiUploader.DeleteImage(ds.Tables[0].Rows[0]["IconUrl"].ToString());
                }
                this.grdTopCategries.SelectedIndex = -1;
                this.BindData();
            }
            else
            {
                switch (status)
                {
                    case CategoryActionStatus.DeleteForbid:
                        //Maticsoft.Common.MessageBox.Show(this, "指定的分类下存在子分类,不能直接删除!");
                        return;

                    case CategoryActionStatus.DeleteForbidProducts:
                        //Maticsoft.Common.MessageBox.Show(this, "指定的分类下存在课程信息,不能直接删除!");
                        return;
                }
            }
        }
    }
}