﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Model.SysManage;
using System.IO;
using System.Data;
namespace Maticsoft.Web.Admin.SysManage
{
    public partial class add : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //得到现有菜单
                BiudTree();
                //得到所有权限
                //BiudPermTree();
                BindImages();
            }
        }


        #region BiudTree

        private void BiudTree()
        {
            Maticsoft.BLL.SysManage.SysTree sm = new Maticsoft.BLL.SysManage.SysTree();
            DataTable dt = sm.GetTreeList("").Tables[0];


            this.listTarget.Items.Clear();
            //加载树
            this.listTarget.Items.Add(new ListItem("根目录", "0"));
            DataRow[] drs = dt.Select("ParentID= " + 0);


            foreach (DataRow r in drs)
            {
                string nodeid = r["NodeID"].ToString();
                string text = r["TreeText"].ToString();
                //string parentid=r["ParentID"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = "╋" + text;
                this.listTarget.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, dt, blank);

            }
            this.listTarget.DataBind();

        }
        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["NodeID"].ToString();
                string text = r["TreeText"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = blank + "『" + text + "』";

                this.listTarget.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";


                BindNode(sonparentid, dt, blank2);
            }
        }

        private void BiudPermTree()
        {
            //DataTable tabcategory = Maticsoft.Accounts.Bus.AccountsTool.GetAllCategories().Tables[0];
            //int rc = tabcategory.Rows.Count;
            //for (int n = 0; n < rc; n++)
            //{
            //    string CategoryID = tabcategory.Rows[n]["CategoryID"].ToString();
            //    string CategoryName = tabcategory.Rows[n]["Description"].ToString();
            //    CategoryName = "╋" + CategoryName;
            //    this.listPermission.Items.Add(new ListItem(CategoryName, CategoryID));

            //    DataTable tabforums = Maticsoft.Accounts.Bus.AccountsTool.GetPermissionsByCategory(int.Parse(CategoryID)).Tables[0];
            //    int fc = tabforums.Rows.Count;
            //    for (int m = 0; m < fc; m++)
            //    {
            //        string ForumID = tabforums.Rows[m]["PermissionID"].ToString();
            //        string ForumName = tabforums.Rows[m]["Description"].ToString();
            //        ForumName = "  ├『" + ForumName + "』";
            //        this.listPermission.Items.Add(new ListItem(ForumName, ForumID));
            //    }
            //}
            //this.listPermission.DataBind();
            //this.listPermission.Items.Insert(0, "--请选择--");
        }


        private void BindImages()
        {
            string dirpath = Server.MapPath("../Images/MenuImg");
            DirectoryInfo di = new DirectoryInfo(dirpath);
            FileInfo[] rgFiles = di.GetFiles("*.gif");
            this.imgsel.Items.Clear();
            foreach (FileInfo fi in rgFiles)
            {
                ListItem item = new ListItem(fi.Name, "Images/MenuImg/" + fi.Name);
                this.imgsel.Items.Add(item);
            }
            FileInfo[] rgFiles2 = di.GetFiles("*.jpg");
            foreach (FileInfo fi in rgFiles2)
            {
                ListItem item = new ListItem(fi.Name, "Images/MenuImg/" + fi.Name);
                this.imgsel.Items.Add(item);
            }
            this.imgsel.Items.Insert(0, "默认图标");
            this.imgsel.DataBind();
        }

        #endregion

        protected void btnSave_Click(object sender, System.EventArgs e)
        {

            string orderid = Maticsoft.Common.PageValidate.InputText(txtOrderid.Text, 10);
            string name = txtName.Text;
            string url = Maticsoft.Common.PageValidate.InputText(txtUrl.Text, 100);
            //string imgUrl=Maticsoft.Common.PageValidate.InputText(txtImgUrl.Text,100);
            string imgUrl = this.hideimgurl.Value;

            string target = this.listTarget.SelectedValue;
            int parentid = int.Parse(target);

            string strErr = "";

            if (orderid.Trim() == "")
            {
                strErr += "编号不能为空\\n";
            }
            try
            {
                int.Parse(orderid);
            }
            catch
            {
                strErr += "编号格式不正确\\n";

            }
            if (name.Trim() == "")
            {
                strErr += "名称不能为空\\n";
            }

            //if (this.listPermission.SelectedItem.Text.StartsWith("╋"))
            //{
            //    strErr += "权限类别不能做权限使用\\n";
            //}

            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }

            int permission_id = -1;
            if (UCDroplistPermission1.PermissionID > 0)
            {
                permission_id = UCDroplistPermission1.PermissionID;
            }

            int moduleid = -1;
            int keshidm = -1;
            string keshipublic = "false";
            string comment = Maticsoft.Common.PageValidate.InputText(txtDescription.Text, 100);

            SysNode node = new SysNode();
            node.TreeText = name;
            node.ParentID = parentid;
            node.Location = parentid + "." + orderid;
            node.OrderID = int.Parse(orderid);
            node.Comment = comment;
            node.Url = url;
            node.PermissionID = permission_id;
            node.ImageUrl = imgUrl;
            node.ModuleID = moduleid;
            node.KeShiDM = keshidm;
            node.KeshiPublic = keshipublic;
            Maticsoft.BLL.SysManage.SysTree sm = new Maticsoft.BLL.SysManage.SysTree();
            if (CheckBox1.Checked)
            {
                Maticsoft.Accounts.Bus.Permissions p = new Maticsoft.Accounts.Bus.Permissions();
                string permissionName = node.TreeText;
                int parentID = node.ParentID;
                if (parentID == 0)
                {
                    //根目录下不能选择同步创建权限
                    Maticsoft.Common.MessageBox.Show(this.Page, "根目录不能选择同步创建权限，请您手动创建！");
                    return;
                }
                SysNode parentNode = new SysNode();
                parentNode = sm.GetNode(parentID);
                int catalogID = sm.GetPermissionCatalogID(parentNode.PermissionID);
                int permissionID = p.Create(catalogID, permissionName);
                node.PermissionID = permissionID;
            }
            sm.AddTreeNode(node);
            lblMsg.Text = Resources.Site.TooltipSaveOK;
            if (chkAddContinue.Checked)
            {
                txtOrderid.Text = "";
                txtName.Text = "";
                txtUrl.Text = "";
                txtImgUrl.Text = "";
                txtDescription.Text = "";
            }
            else
            {
                Response.Redirect("treelist.aspx");
            }
        }


        protected void btnCancle_Click(object sender, System.EventArgs e)
        {
            txtOrderid.Text = "";
            txtName.Text = "";
            txtUrl.Text = "";
            txtImgUrl.Text = "";
            txtDescription.Text = "";
            chkAddContinue.Checked = false;
        }

    }
}
