﻿using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Tao.ApproveType
{
    public partial class List : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.ApproveType bll = new Maticsoft.BLL.Tao.ApproveType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
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
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat("ApproveName like '%{0}%'", txtKeyword.Text.Trim());
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
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗\")");

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

        #endregion
    }
}