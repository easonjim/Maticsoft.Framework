using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Maticsoft.Accounts.Bus;
using System.Configuration;

namespace Maticsoft.Web.Admin.Accounts
{
    public partial class UserModify : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    User currentUser = new Maticsoft.Accounts.Bus.User(user);

                    this.lblName.Text = currentUser.UserName;
                    txtTrueName.Text = currentUser.TrueName;
                    //if (currentUser.Sex.Trim().ToUpper() == "1")
                    //    RadioButton1.Checked = true;
                    //else
                    //    RadioButton2.Checked = true;
                    //this.txtPhone.Text = currentUser.Phone;
                    txtEmail.Text = currentUser.Email;

                    //					for(int i=0;i<this.Dropdepart.Items.Count;i++)
                    //					{
                    //						if(this.Dropdepart.Items[i].Value==currentUser.DepartmentID)
                    //						{
                    //							this.Dropdepart.Items[i].Selected=true;
                    //						}
                    //					}

                    //for (int i = 0; i < this.dropUserType.Items.Count; i++)
                    //{
                    //    if (this.dropUserType.Items[i].Value == currentUser.UserType)
                    //    {
                    //        this.dropUserType.Items[i].Selected = true;
                    //    }
                    //}

                    //this.dropStyle.SelectedIndex = currentUser.Style - 1;

                    //					BindRoles(user);


                }



            }
        }

        //private void BindRoles(AccountsPrincipal user)
        //{
        //    if (user.Permissions.Count > 0)
        //    {
        //        RoleList.Visible = true;
        //        ArrayList Permissions = user.Permissions;
        //        RoleList.Text = "权限列表:<ul>";
        //        for (int i = 0; i < Permissions.Count; i++)
        //        {
        //            RoleList.Text += "<li>" + Permissions[i] + "</li>";
        //        }
        //        RoleList.Text += "</ul>";
        //    }
        //}

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = this.lblName.Text.Trim();
                AccountsPrincipal user = new AccountsPrincipal(username);
                User currentUser = new Maticsoft.Accounts.Bus.User(user);
                currentUser.UserName = username;
                currentUser.TrueName = txtTrueName.Text.Trim();
                //if (RadioButton1.Checked)
                //    currentUser.Sex = "1";
                //else
                //    currentUser.Sex = "0";
                //currentUser.Phone = this.txtPhone.Text.Trim();
                currentUser.Email = txtEmail.Text.Trim();
                //currentUser.UserType = dropUserType.SelectedValue;
                //int style = int.Parse(this.dropStyle.SelectedValue);
                //currentUser.Style = style;
                if (!currentUser.Update())
                {
                    this.lblMsg.ForeColor = Color.Red;
                    this.lblMsg.Text = Resources.Site.TooltipUpdateError;
                }
                else
                {
                    this.lblMsg.ForeColor = Color.Blue;
                    this.lblMsg.Text = Resources.Site.TooltipSaveOK;
                }
               

            }
        }




    }
}
