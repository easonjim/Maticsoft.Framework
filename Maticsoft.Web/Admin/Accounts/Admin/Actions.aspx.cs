using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin.Accounts.Admin
{
    public partial class Actions : PageBaseAdmin
    {
        Maticsoft.Accounts.Bus.Actions bll = new Maticsoft.Accounts.Bus.Actions();
        Maticsoft.Accounts.Bus.Permissions bllperm = new Permissions();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable tabcategory = Maticsoft.Accounts.Bus.AccountsTool.GetAllCategories().Tables[0];
                DropListCategory.DataSource = tabcategory;
                DropListCategory.DataValueField = "CategoryID";
                DropListCategory.DataTextField = "Description";
                DropListCategory.DataBind();
                DropListCategory.Items.Insert(0, "--请选择权限类别--");

                DropListCategory2.DataSource = tabcategory;
                DropListCategory2.DataValueField = "CategoryID";
                DropListCategory2.DataTextField = "Description";
                DropListCategory2.DataBind();                

                gridView.OnBind();                
            }
        }

        public void DropListCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (DropListCategory.SelectedIndex > 0)
            {
                int categoryID = Convert.ToInt32(DropListCategory.SelectedItem.Value);
                DataTable tabperms = Maticsoft.Accounts.Bus.AccountsTool.GetPermissionsByCategory(categoryID).Tables[0];
                DropListPermissions.DataSource = tabperms;
                DropListPermissions.DataValueField = "PermissionID";
                DropListPermissions.DataTextField = "Description";
                DropListPermissions.DataBind();
                DropListPermissions.Items.Insert(0, "--请选择权限--");
            }
            else
            {
                DropListPermissions.Items.Clear();
            }
        }

        public void DropListCategory2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //if (DropListCategory2.SelectedIndex > 0)
            //{
                int categoryID = Convert.ToInt32(DropListCategory2.SelectedItem.Value);
                DataTable tabperms = Maticsoft.Accounts.Bus.AccountsTool.GetPermissionsByCategory(categoryID).Tables[0];
                DropListPermissions2.DataSource = tabperms;
                DropListPermissions2.DataValueField = "PermissionID";
                DropListPermissions2.DataTextField = "Description";
                DropListPermissions2.DataBind();                
            //}
            //else
            //{
            //    DropListPermissions.Items.Clear();
            //}
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Trim().Length>0)
            {
                if (bll.Exists(txtDescription.Text.Trim()))
                {
                    lblToolTip.Text = Resources.Site.TooltipDataExist;
                }
                else
                {
                    if (DropListPermissions.SelectedIndex > 0)
                    {
                        bll.Add(txtDescription.Text.Trim(),Convert.ToInt32(DropListPermissions.SelectedValue));
                    }
                    else
                    {
                        bll.Add(txtDescription.Text.Trim());
                    }

                    gridView.OnBind();
                }
            }
            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
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
            //    gridView.Columns[5].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[6].Visible = true;
            //}
            #endregion

            string strWhere = "";
            if (txtKeywords.Text.Trim() != "")
            {
                strWhere = "Description like '%"+txtKeywords.Text.Trim()+"%'"; 
            }
            DataSet ds = bll.GetList(strWhere);
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
                object obj1 = DataBinder.Eval(e.Row.DataItem, "PermissionID");
                if ((obj1 != null) && ((obj1.ToString() != "")))
                {
                    int PermissionID = Convert.ToInt32(obj1);
                    //Maticsoft.Accounts.Bus.User user = new User(userid);
                    e.Row.Cells[3].Text = "(" + PermissionID + ")" + bllperm.GetPermissionName(PermissionID);
                }              
            }
        }

        public void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            gridView.OnBind();
        }
        public void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            gridView.OnBind();
        }

        public void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gridView.DataKeys[e.RowIndex].Values[0].ToString();
            string Description = ((TextBox)gridView.Rows[e.RowIndex].FindControl("TBDescription")).Text;
            if (Description == "")
            {
                Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipNoNull); 
                return;
            }                        
            bll.Update(int.Parse(id), Description);

            gridView.EditIndex = -1;
            gridView.OnBind();
        }
        
        
        //public void gridView_RowDeleting(object sender, EventArgs e)
        //{
        //    int ID = (int)gridView.DataKeys[0].Value;
        //}

        //protected override void ExtractRowValues(System.Collections.Specialized.IOrderedDictionary fieldValues, GridViewRow row, bool includeReadOnlyFields, bool includePrimaryKey)
        //{
        //    TableCell expCell = row.Cells[0];
        //    row.Cells.Remove(expCell);
        //    base.ExtractRowValues(fieldValues, row, includeReadOnlyFields, includePrimaryKey);
        //}

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            bll.Delete(ID);
            gridView.OnBind();
        }

       

        #endregion                



        #region  权限设置
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

        protected void btnSetup_Click(object sender, EventArgs e)
        {
            string idlist=GetSelIDlist();
            if (idlist.Length > 0)
            {
                if ((DropListPermissions2.SelectedItem != null) && (DropListPermissions2.SelectedValue.Length > 0))                 
                {
                    bll.AddPermission(idlist, Convert.ToInt32(DropListPermissions2.SelectedValue));
                }
                lblToolTip2.Text = Resources.Site.TooltipSaveOK;
                gridView.OnBind();
            }
        }

        #endregion

    }
}
