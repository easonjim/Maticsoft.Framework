using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Accounts.Bus;
using System.Data;
using System.Drawing;
namespace Maticsoft.Web.Admin.Accounts.Admin
{
    public partial class EditRoleC : PageBaseAdmin
    {
        private Role currentRole;
        private List<int> rolePermissionlist;
        public string RoleID = "";
        protected int Act_ShowReservedPerm = 14; //查看系统保留权限
        List<string> ReservedRoleIDs = Maticsoft.Common.StringPlus.GetStrArray(BLL.SysManage.ConfigSystem.GetValueByCache("ReservedRoleIDs"), ',', true);
        string ReservedPermIDs = BLL.SysManage.ConfigSystem.GetValueByCache("ReservedPermIDs");
        User bllUser = new Maticsoft.Accounts.Bus.User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblRoleID.Text = Request["RoleID"];
                if (!ReservedRoleIDs.Contains(lblRoleID.Text))
                {
                    RemoveRoleButton.Attributes.Add("onclick", "return confirm(\"" + Resources.Site.TooltipDelConfirm + "\")");
                }
                btnRemove.Attributes.Add("onclick", "return confirm(\"你确认要移除吗？\")");
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                gridView.OnBind();

                DoInitialDataBind();
                CategoryDownList_SelectedIndexChanged(sender, e);
            }
            RoleID = lblRoleID.Text;
        }

        #region 权限设置
        //绑定类别列表
        private void DoInitialDataBind()
        {
            currentRole = new Role(Convert.ToInt32(lblRoleID.Text));
            RoleLabel.Text = currentRole.Description;
            this.TxtNewname.Text = currentRole.Description;
                       
            
            DataSet allCategories = AccountsTool.GetAllCategories();
            CategoryDownList.DataSource = allCategories.Tables[0];
            CategoryDownList.DataTextField = "Description";
            CategoryDownList.DataValueField = "CategoryID";
            CategoryDownList.DataBind();
        }

        private void GetRolePermissionlist()
        {
            DataSet ds = currentRole.Permissions;
            if (ds.Tables.Count > 0)
            {
                rolePermissionlist = new List<int>();
                DataTable dt = ds.Tables["Permissions"];
                foreach (DataRow dr in dt.Rows)
                {
                    rolePermissionlist.Add(Convert.ToInt32(dr["PermissionID"]));
                }
            }
        }
        
        //选择类别，填充2个listbox
        public void CategoryDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            chkAll.Checked = false;
            if (CategoryDownList.SelectedItem != null && CategoryDownList.SelectedValue.Length > 0)
            {
                int categoryID = Convert.ToInt32(CategoryDownList.SelectedItem.Value);
                FillCategoryList(categoryID);
            }
        }

        //填充非权限列表
        public void FillCategoryList(int categoryId)
        {
            currentRole = new Role(Convert.ToInt32(lblRoleID.Text));
            GetRolePermissionlist();
            DataSet ds=AccountsTool.GetPermissionsByCategory(categoryId);

            DataView dv = ds.Tables[0].DefaultView;
            if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_ShowReservedPerm)))
            {
                dv.RowFilter = "PermissionID not in (" + ReservedPermIDs + ")";
            }
            chkPermissions.DataSource = dv;
            chkPermissions.DataValueField = "PermissionID";
            chkPermissions.DataTextField = "Description";
            chkPermissions.DataBind();            
            
        }

        public void chkPermissions_DataBinding(object sender, EventArgs e)
        {
            foreach (ListItem item in ((CheckBoxList)sender).Items)
            {
                if (rolePermissionlist.Contains(Convert.ToInt32(item.Value)))
                {
                    item.Selected = true;
                }
                
            }
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
            Role bllRole = new Role();
            bllRole.RoleID = Convert.ToInt32(lblRoleID.Text);            
            foreach (ListItem item in chkPermissions.Items)
            {
                if (item.Selected)
                {
                    bllRole.AddPermission(Convert.ToInt32(item.Value));
                }                    
                else
                {
                    bllRole.RemovePermission(Convert.ToInt32(item.Value));
                }
            }
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipSaveOK);

        }


        #region 角色编辑

        public void RemoveRoleButton_Click(object sender, System.EventArgs e)
        {
            if (ReservedRoleIDs.Contains(lblRoleID.Text))
            {
                Maticsoft.Common.MessageBox.Show(this,"该角色为系统保留角色，不能删除！");
                return;
            }    
            int currentRole = Convert.ToInt32(lblRoleID.Text);
            Role bizRole = new Role(currentRole);
            bizRole.Delete();
            Server.Transfer("RoleAdmin.aspx");
        }

        public void BtnUpName_Click(object sender, EventArgs e)
        {
            string newname = this.TxtNewname.Text.Trim();
            currentRole = new Role(Convert.ToInt32(lblRoleID.Text));
            currentRole.Description = newname;
            currentRole.Update();
            DoInitialDataBind();
            lblTiptool.Text = Resources.Site.TooltipUpdateOK;// "修改成功！";
        }

        public void btnBach_ServerClick(object sender, System.EventArgs e)
        {
            Response.Redirect("RoleAdmin.aspx");
        }

        #endregion

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                foreach (ListItem item in chkPermissions.Items)
                {
                    item.Selected = true;
                }
            }
            else
            {
                foreach (ListItem item in chkPermissions.Items)
                {
                    item.Selected = false;
                }
            }
        }

        #endregion

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();

            ds = bllUser.GetUsersByRole(int.Parse(lblRoleID.Text));
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
                object obj1 = DataBinder.Eval(e.Row.DataItem, "EmployeeID");
                if ((obj1 != null) && ((obj1.ToString() != "")))
                {
                    string EmployeeID = obj1.ToString().Trim();
                    if (EmployeeID == "-1")
                    {
                        e.Row.Cells[5].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[5].Text = EmployeeID;
                        //if (Maticsoft.Common.PageValidate.IsNumber(EmployeeID))
                        //{
                        //    e.Row.Cells[5].Text = GetEmpCode(int.Parse(EmployeeID));
                        //}
                    }
                }
                //object obj2 = DataBinder.Eval(e.Row.DataItem, "Sex");
                //if ((obj2 != null) && ((obj2.ToString().Trim() != "")))
                //{
                //    e.Row.Cells[2].Text = obj2.ToString().Trim() == "1" ? Resources.Site.fieldSexM : Resources.Site.fieldSexF;
                //}
            }
        }


        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = gridView.DataKeys[e.RowIndex].Value.ToString();
            List<string> UserIDlist = Maticsoft.Common.StringPlus.GetStrArray(BLL.SysManage.ConfigSystem.GetValueByCache("AdminUserID"), ',', true);
            if (UserIDlist.Contains(ID))
            {
                Maticsoft.Common.MessageBox.Show(this, "系统管理保留帐号，不能删除");
                return;
            }
            try
            {
                User User2 = new User(int.Parse(ID));
                User2.Delete();
                gridView.OnBind();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    Maticsoft.Common.MessageBox.Show(this, "该用户已被其他数据引用，不能删除！");
                }
            }
        }

        

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl(gridView.CheckBoxID);
                if (ChkBxItem != null && ChkBxItem.Checked)
                {                   
                    if (gridView.DataKeys[i].Value != null)
                    {
                        int userid =Convert.ToInt32(gridView.DataKeys[i].Value);
                        bllUser.RemoveRole(userid,int.Parse(lblRoleID.Text));
                    }
                }
            }
            gridView.OnBind();
        }


        #endregion

    }
}