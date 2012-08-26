using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.TaoEnterprise.Enterprise
{
    public partial class List : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.Enterprise bll = new Maticsoft.BLL.Tao.Enterprise();

        //Maticsoft.BLL.SysManage.Users bllUsers = new Maticsoft.BLL.SysManage.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？删除企业的同时，和企业相关联的用户也同时删除！\")");
                BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            bll.DeleteList(idlist);

            //删除企业同时删除和企业相关的用户
            //bllUsers.DeleteListByDepartmentID(idlist);

            BindData();
        }

        #region gridView

        public void BindData()
        {
            #region

            //if (!Context.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    gridView.Columns[6].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[7].Visible = true;
            //}

            #endregion gridView

            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue) && "-1" != ddlStatus.SelectedValue)
            {
                strWhere.AppendFormat("Status={0}", ddlStatus.SelectedValue);
                if (txtKeyword.Text.Trim() != "")
                {
                    strWhere.AppendFormat("and Name like '%{0}%'", txtKeyword.Text.Trim());
                }
            }
            else
            {
                if (txtKeyword.Text.Trim() != "")
                {
                    strWhere.AppendFormat("Name like '%{0}%'", txtKeyword.Text.Trim());
                }
            }
            ds = bll.GetList(strWhere.ToString());
            gridView.DataSource = ds;
            gridView.DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？删除企业的同时，和企业相关联的用户也同时删除！\")");

                //object obj1 = DataBinder.Eval(e.Row.DataItem, "Levels");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    e.Row.Cells[1].Text = obj1.ToString();
                //}
            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            bll.Delete(ID);

            //删除企业同时删除和企业相关的用户
            //bllUsers.DeleteByDepartmentID(ID);

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

        #region 批量审核

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApproveList_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            string strWhere = "Status=" + 1;
            bll.UpdateList(idlist, strWhere);
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipUpdateOK);
            gridView.OnBind();
        }

        #endregion 批量审核

        #region 批量未审核

        /// <summary>
        /// 批量未审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInverseApprove_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            string strWhere = "Status=" + 0;
            bll.UpdateList(idlist, strWhere);
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipUpdateOK);
            gridView.OnBind();
        }

        #endregion 批量未审核

        #region 批量冻结

        /// <summary>
        /// 批量冻结
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateState_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            string strWhere = "Status=" + 2;
            bll.UpdateList(idlist, strWhere);
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipUpdateOK);
            gridView.OnBind();
        }

        #endregion 批量冻结

        #endregion
    }
}