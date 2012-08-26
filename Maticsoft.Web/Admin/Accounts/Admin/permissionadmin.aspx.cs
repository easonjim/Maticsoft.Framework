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
    public partial class permissionadmin : PageBaseAdmin
    {
        protected int Act_ShowReservedPerm = 14; //查看系统保留权限
        List<string> ReservedPermIDs = Maticsoft.Common.StringPlus.GetStrArray(BLL.SysManage.ConfigSystem.GetValueByCache("ReservedPermIDs"), ',', true);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                CategoriesDatabind();
                if (ClassList.SelectedItem != null)
                {
                    gridView.OnBind();
                }
            }
        }


        public void CategoriesDatabind()
        {
            DataSet CategoriesList = AccountsTool.GetAllCategories();
            ClassList.DataSource = CategoriesList;
            ClassList.DataTextField = "Description";
            ClassList.DataValueField = "CategoryID";
            ClassList.DataBind();


            droplistCategories.DataSource = CategoriesList;
            droplistCategories.DataTextField = "Description";
            droplistCategories.DataValueField = "CategoryID";
            droplistCategories.DataBind();
            
        }


        public void ClassList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            gridView.OnBind();
        }

        public void btnSaveCategories_Click(object sender, EventArgs e)
        {
            string Category = this.CategoriesName.Text.Trim();
            if (Category != "")
            {
                PermissionCategories c = new PermissionCategories();
                c.Create(Category);
                CategoriesDatabind();
                if (this.ClassList.SelectedItem != null)
                {
                    gridView.OnBind();
                }
                this.CategoriesName.Text = "";
            }
            else
            {
                this.lbltip1.Text = Resources.Site.TooltipNoNull; // "Name not null！";
            }
        }


        public void btnSavePermissions_Click(object sender, EventArgs e)
        {
            string Permissions = this.PermissionsName.Text.Trim();
            if (Permissions != "")
            {
                int CategoryId = int.Parse(ClassList.SelectedValue);
                Permissions p = new Permissions();
                p.Create(CategoryId, Permissions);
                if (this.ClassList.SelectedItem != null)
                {
                    gridView.OnBind();
                }
                this.PermissionsName.Text = "";
            }
            else
            {
                this.lbltip2.Text = Resources.Site.TooltipNoNull;// "Name can't be null！";
            }

        }


        #region gridView

        public void BindData()
        {
            if (ClassList.SelectedItem != null && ClassList.SelectedValue.Length > 0)
            {
                int CategoryId = int.Parse(ClassList.SelectedValue);
                DataSet ds = AccountsTool.GetPermissionsByCategory(CategoryId);               
                gridView.DataSetSource = ds;
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
                
                object obj1 = DataBinder.Eval(e.Row.DataItem, "PermissionID");
                if ((obj1 != null) && ((obj1.ToString() != "")))
                {
                    //保留权限
                    if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_ShowReservedPerm)))
                    {
                        if (ReservedPermIDs.Contains(obj1.ToString()))
                        {
                            e.Row.Visible = false;
                        }
                    }
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
                Maticsoft.Common.MessageBox.Show(this,"请输入内容！");
                return;
            }
            Permissions p = new Permissions();
            p.Update(int.Parse(id), Description);

            gridView.EditIndex = -1;
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


        protected void btnMoveTo_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist(); 
            if (idlist.Trim().Length == 0) 
                return;
            
            if ((droplistCategories.SelectedItem != null) && (droplistCategories.SelectedValue.Length > 0))
            {
                int CategoriesID = Convert.ToInt32(droplistCategories.SelectedValue);
                Permissions bllPerm = new Permissions();
                bllPerm.UpdateCategory(idlist, CategoriesID);
                gridView.OnBind();
            }            
        }


        #endregion                

    }
}
