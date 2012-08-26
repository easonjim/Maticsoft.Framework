using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Model.SysManage;

namespace Maticsoft.Web.Admin.SysManage
{
    public partial class show : PageBaseAdmin
    {
        public string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                id = Request.Params["id"];
                if (id == null || id.Trim() == "")
                {
                    Response.Redirect("treelist.aspx");
                    Response.End();
                }

                Maticsoft.BLL.SysManage.SysTree sm = new Maticsoft.BLL.SysManage.SysTree();
                SysNode node = sm.GetNode(int.Parse(id));
                lblID.Text = id;
                this.lblOrderid.Text = node.OrderID.ToString();
                lblName.Text = node.TreeText;
                if (node.ParentID == 0)
                {
                    this.lblTarget.Text = "根目录";
                }
                else
                {
                    lblTarget.Text = sm.GetNode(node.ParentID).TreeText;
                }
                lblUrl.Text = node.Url;
                lblImgUrl.Text = node.ImageUrl;
                Maticsoft.Accounts.Bus.Permissions perm = new Maticsoft.Accounts.Bus.Permissions();
                if (node.PermissionID == -1)
                {
                    this.lblPermission.Text = "没有权限限制";
                }
                else
                {
                    this.lblPermission.Text = perm.GetPermissionName(node.PermissionID);
                }

                lblDescription.Text = node.Comment;
                //				if(node.ModuleID!=-1)
                //				{
                //					this.lblModule.Text=sm.GetModuleName(node.ModuleID);
                //				}
                //				else
                //				{
                //					this.lblModule.Text="未归属任何模块";
                //				}
                //
                //				if(node.KeShiDM!=-1)
                //				{
                //					this.lblModuledept.Text=Maticsoft.BLL.PubConstant.GetKeshiName(node.KeShiDM);
                //				}
                //				else
                //				{
                //					this.lblModuledept.Text="未归属任何部门";
                //				}
                //				if(node.KeshiPublic=="true")
                //				{
                //					this.lblKeshiPublic.Text="作为部门内部公有部分出现";
                //				}

            }
        }
    }
}
