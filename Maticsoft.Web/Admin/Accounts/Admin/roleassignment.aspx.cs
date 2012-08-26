﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Accounts.Bus;
using System.Collections;
using System.Data;
namespace Maticsoft.Web.Admin.Accounts.Admin
{
    public partial class roleassignment : PageBaseAdmin
    {
        protected int Act_ShowReservedRole = 13; //查看系统保留角色
        List<string> ReservedRoleIDs = Maticsoft.Common.StringPlus.GetStrArray(BLL.SysManage.ConfigSystem.GetValueByCache("ReservedRoleIDs"),',',true);

        public void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                if ((Request.Params["UserID"] != null) && (Request.Params["UserID"]!=""))
                {                  
                    string userID = Request.Params["UserID"];
                    lblUserID.Text = userID;
                    User currentUser = new User(Convert.ToInt32(userID));                    
                    DataSet dsRole = AccountsTool.GetRoleList();
                    CheckBoxList1.DataSource = dsRole.Tables[0].DefaultView;
                    CheckBoxList1.DataTextField = "Description";
                    CheckBoxList1.DataValueField = "RoleID";
                    CheckBoxList1.DataBind();

                    AccountsPrincipal newUser = new AccountsPrincipal(currentUser.UserName);
                    if (newUser.Roles.Count > 0)
                    {
                        ArrayList roles = newUser.Roles;
                        for (int i = 0; i < roles.Count; i++)
                        {                            
                            foreach (ListItem item in CheckBoxList1.Items)
                            {
                                if (item.Text == roles[i].ToString())
                                {
                                    item.Selected = true;
                                }                                
                            }                            
                        }
                    }

                    
                    //移除保留角色
                    if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_ShowReservedRole)))
                    {
                        for (int n = 0; n < CheckBoxList1.Items.Count; n++)
                        {
                            if (ReservedRoleIDs.Contains(CheckBoxList1.Items[n].Value))
                            {
                                CheckBoxList1.Items.Remove(CheckBoxList1.Items[n]);
                            }
                        }
                    }
                    
                                        
                }
               
            }
        }


        public void btnSave_Click(object sender, EventArgs e)
        {
            User currentUser = new User(Convert.ToInt32(lblUserID.Text));
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected == true)
                {
                    currentUser.AddToRole(Convert.ToInt32(item.Value));
                }
                else
                {
                    currentUser.RemoveRole(Convert.ToInt32(item.Value));
                }
            }
            Response.Redirect("UserAdmin.aspx?PageIndex=" + Request.Params["PageIndex"]);

        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAdmin.aspx?PageIndex=" + Request.Params["PageIndex"]);
        }




    }
}
