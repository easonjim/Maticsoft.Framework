using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoCourses
{
    public partial class List : PageBaseAdmin
    {
        private BLL.Tao.Courses bll = new BLL.Tao.Courses();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BiudTree();
                btnDelete.Attributes.Add("onclick", "return confirm(\"" + Resources.Site.TooltipDelConfirm + "\")");
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DeleteList)))
                {
                    btnDelete.Visible = false;
                }

                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                gridView.OnBind();
            }
        }

        #region DropDpwnListTree

        private void BiudTree()
        {
            BLL.Tao.Categories CateBll = new BLL.Tao.Categories();
            DataTable dt = CateBll.GetList("").Tables[0];

            this.ddlCategory.Items.Clear();
            //加载树
            this.ddlCategory.Items.Add(new ListItem("  ", "0"));
            DataRow[] drs = dt.Select("ParentCategoryId= " + 0);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryId"].ToString();
                string text = r["Name"].ToString();
                text = "╋" + text;
                this.ddlCategory.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";
                BindNode(sonparentid, dt, blank);
            }
            this.ddlCategory.DataBind();
        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentCategoryId= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryId"].ToString();
                string text = r["Name"].ToString();
                text = blank + "『" + text + "』";

                this.ddlCategory.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }

        #endregion DropDpwnListTree

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            bll.DeleteList(idlist);
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipDelOK);
            gridView.OnBind();
        }

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue) && "0" != ddlCategory.SelectedValue)
            {
                strWhere.AppendFormat("CategoryId={0}", ddlCategory.SelectedValue);
                if (!string.IsNullOrEmpty(ddlState.SelectedValue) && "0" != ddlState.SelectedValue)
                {
                    strWhere.AppendFormat(" and Status={0}", ddlState.SelectedValue);
                    if (txtKeyword.Text.Trim() != "")
                    {
                        strWhere.AppendFormat(" and CourseName like '%{0}%'", txtKeyword.Text.Trim());
                    }
                }
                else
                {
                    if (txtKeyword.Text.Trim() != "")
                    {
                        strWhere.AppendFormat(" and CourseName like '%{0}%'", txtKeyword.Text.Trim());
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(ddlState.SelectedValue) && "0" != ddlState.SelectedValue)
                {
                    strWhere.AppendFormat("Status={0}", ddlState.SelectedValue);
                    if (txtKeyword.Text.Trim() != "")
                    {
                        strWhere.AppendFormat(" and CourseName like '%{0}%'", txtKeyword.Text.Trim());
                    }
                }
                else
                {
                    if (txtKeyword.Text.Trim() != "")
                    {
                        strWhere.AppendFormat("CourseName like '%{0}%'", txtKeyword.Text.Trim());
                    }
                }
            }
            ds = bll.GetList(strWhere.ToString());
            gridView.DataSetSource = ds;
        }

        public string ConvertTimme(object time)
        {
            if (time != null)
            {
                if (!string.IsNullOrEmpty(time.ToString()))
                {
                    int timedur = int.Parse(time.ToString());
                    return BLL.ConvertTime.SecondToDateTime(timedur);
                }
                else
                {
                    return "未&nbsp;&nbsp;&nbsp;知";
                }
            }
            else
            {
                return "未&nbsp;&nbsp;&nbsp;知";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.OnBind();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"" + Resources.Site.TooltipDelConfirm + "\")");
            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            bll.Delete(ID);
            gridView.OnBind();
        }

        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl(gridView.CheckBoxID);
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridView.DataKeys[i].Value != null)
                    {
                        //idlist += gridView.Rows[i].Cells[1].Text + ",";
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        #endregion gridView

        private void UpdateStatus(int Status)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            //状态：0:未完成,1:完成待审核,2:审核通过不上架(即下架),3:审核通过并发布上架;4:审核未通过
            bll.UpdateList(idlist, Status);
            gridView.OnBind();
            //Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipUpdateOK);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex > 0 && !string.IsNullOrEmpty(this.ddlStatus.SelectedValue))
            {
                if (PageValidate.IsNumber(this.ddlStatus.SelectedValue))
                {
                    UpdateStatus(int.Parse(this.ddlStatus.SelectedValue));
                }
            }
        }
    }
}