﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
using System.Drawing;
using Maticsoft.Accounts.Bus;
using System.Text;
namespace Maticsoft.Web.Admin.SysManage
{
    public partial class Treelist : PageBaseAdmin
    {
        Maticsoft.BLL.SysManage.SysTree bll = new Maticsoft.BLL.SysManage.SysTree();
        //int PermId_Modify = 81;
        //int PermId_Delete = 82;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DeleteList)))
                {
                    btnDelete.Visible = false;
                }
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                BiudTree();

                gridView.OnBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder strSql=new StringBuilder();
            string connector = "";
            int ParentID = -1;
            if ((listTarget.SelectedItem != null) && (listTarget.SelectedIndex > 0))             
            {
                ParentID = Convert.ToInt32(listTarget.SelectedValue);
                strSql.AppendFormat("parentid={0}" ,ParentID);
                connector = "and";
            }            
            if (txtKeyword.Text.Trim() != "")
            {
                strSql.AppendFormat(" {0} TreeText like '%{1}%'",connector,txtKeyword.Text.Trim());
            }
            if (strSql.Length>0)
            {
                Session["strWhereTreelist"] = strSql.ToString();
            }
            gridView.OnBind();
        }

        #region 绑定菜单树
        private void BiudTree()
        {

            Maticsoft.BLL.SysManage.SysTree sm = new Maticsoft.BLL.SysManage.SysTree();
            DataTable dt = sm.GetTreeList("").Tables[0];


            this.listTarget.Items.Clear();
            this.listTarget2.Items.Clear();
            //加载树
            this.listTarget.Items.Add(new ListItem("全部菜单", "-1"));
            this.listTarget.Items.Add(new ListItem("根目录", "0"));            
            this.listTarget2.Items.Add(new ListItem("根目录", "0"));
            DataRow[] drs = dt.Select("ParentID= " + 0);


            foreach (DataRow r in drs)
            {
                string nodeid = r["NodeID"].ToString();
                string text = r["TreeText"].ToString();
                string parentid = r["ParentID"].ToString();
                string permissionid = r["PermissionID"].ToString();
                text = "╋" + text;
                this.listTarget.Items.Add(new ListItem(text, nodeid));
                this.listTarget2.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, dt, blank);

            }
            this.listTarget.DataBind();
            this.listTarget2.DataBind();

        }
        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["NodeID"].ToString();
                string text = r["TreeText"].ToString();
                string permissionid = r["PermissionID"].ToString();
                text = blank + "『" + text + "』";

                DataRow[] tempdrs = dt.Select("ParentID= " + nodeid);
                if (tempdrs.Length > 0)
                {
                    this.listTarget.Items.Add(new ListItem(text, nodeid));
                }
                this.listTarget2.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";


                BindNode(sonparentid, dt, blank2);
            }
        }
        #endregion

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();            
            string strWhere = "";
            if (Session["strWhereTreelist"] != null && Session["strWhereTreelist"].ToString() != "")
            {
                strWhere = Session["strWhereTreelist"].ToString();
            }
            ds = bll.GetTreeList(strWhere);
            gridView.DataSetSource = ds;
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
            }
        }


        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            bll.DelTreeNode(ID);
            gridView.OnBind();
        }

        
        #endregion


        #region btn

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
                    idlist += gridView.Rows[i].Cells[1].Text + ",";
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist(); if(idlist.Trim().Length == 0) return;
            bll.DelTreeNodes(idlist);
            gridView.OnBind();
        }

        protected void btnMoveTo_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist(); if(idlist.Trim().Length == 0) return;
            int ParentID = -1;
            if ((listTarget2.SelectedItem != null) && (listTarget2.SelectedValue.Length > 0))             
            {
                ParentID = Convert.ToInt32(listTarget2.SelectedValue);
            }
            bll.MoveNodes(idlist, ParentID);
            gridView.OnBind();
        }

        #endregion 


    }
}
