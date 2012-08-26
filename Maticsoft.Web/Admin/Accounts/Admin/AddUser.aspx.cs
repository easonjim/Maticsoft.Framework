using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin.Accounts.Admin
{
    public partial class AddUser : PageBaseAdmin
    {
        public string adminname = "Management";

        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
            User newUser = new User();
            string strErr = "";            
            if (newUser.HasUser(txtUserName.Text))
            {
                strErr += Resources.Site.TooltipUserExist;
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            newUser.UserName = txtUserName.Text;
            newUser.Password = AccountsPrincipal.EncryptPassword(txtPassword.Text);
            newUser.TrueName = txtTrueName.Text;
            newUser.Sex = "1";
            //if (RadioButton1.Checked)
            //    newUser.Sex = "1";//男
            //else
            //    newUser.Sex = "0";//女
            newUser.Phone = txtPhone.Text.Trim();
            newUser.Email = txtEmail.Text;
            newUser.EmployeeID = 0;
            //newUser.DepartmentID=this.Dropdepart.SelectedValue;
            newUser.Activity = true;
            newUser.UserType = dropUserType.SelectedValue;
            newUser.Style = 1;
            newUser.User_dateCreate = DateTime.Now;
            newUser.User_iCreator = CurrentUser.UserID;
            newUser.User_dateValid = DateTime.Now;
            newUser.User_cLang = "zh-CN";

            int userid = newUser.Create();
            if (userid == -100)
            {
                this.lblMsg.Text = Resources.Site.TooltipUserExist;
                this.lblMsg.Visible = true;
            }
            else
            {
                Response.Redirect("RoleAssignment.aspx?UserID=" + userid);
            }

        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAdmin.aspx");
        }
    }
}
