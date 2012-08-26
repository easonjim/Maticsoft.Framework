using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin.Accounts.Admin
{
    public partial class RoleAdmin : PageBaseAdmin
    {
        protected int Act_ShowReservedRole = 13; //查看系统保留角色        
        string ReservedRoleIDs = BLL.SysManage.ConfigSystem.GetValueByCache("ReservedRoleIDs").Trim();

        private DataSet roles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                dataBind();
            }
        }

        private void dataBind()
        {
            roles = AccountsTool.GetRoleList();            
            DataView dv = roles.Tables["Roles"].DefaultView;
            //保留角色
            if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_ShowReservedRole)))
            {
                dv.RowFilter = "RoleID not in (" + ReservedRoleIDs + ")";
            }
            RoleList.DataSource = dv; //roles.Tables["Roles"];
            RoleList.DataBind();            
        }
               
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtRoleName.Text.Trim().Length<=0)
            {
                Maticsoft.Common.MessageBox.Show(this,"角色为空不能保存");
                return;
            }
            Role role = new Role();
            role.Description = txtRoleName.Text;
            try
            {
                role.Create();
                Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipSaveOK);
            }
            catch(Exception ex)
            {
                lblToolTip.Text = ex.Message;
                return;
            }
            txtRoleName.Text = "";            
            dataBind();

        }
    }
}
