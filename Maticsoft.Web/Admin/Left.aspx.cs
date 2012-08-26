﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Accounts.Bus;
using System.Configuration;
namespace Maticsoft.Web.Admin
{
    public partial class Left : PageBaseAdmin
    {
        protected System.Web.UI.WebControls.Label lblMsg;        
        public string strWelcome;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                if (Session["UserInfo"] == null)
                {
                    return;
                }                
                Maticsoft.BLL.SysManage.SysTree sm = new Maticsoft.BLL.SysManage.SysTree();
                DataSet ds = sm.GetTreeList("");
                BindTreeView("mainFrame", ds.Tables[0]);
                //if (this.TreeView1.Nodes.Count == 0)
                //{
                //    strWelcome += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;但你没有任何模块的访问权";
                //}

            }
        }

        //邦定根节点
        public void BindTreeView(string TargetFrame, DataTable dt)
        {
            DataRow[] drs = dt.Select("ParentID= " + 0);//　选出所有子节点	

            //菜单状态
            string MenuExpanded = ConfigurationManager.AppSettings.Get("MenuExpanded");
            bool menuExpand = bool.Parse(MenuExpanded);

            TreeView1.Nodes.Clear(); // 清空树
            foreach (DataRow r in drs)
            {
                string nodeid = r["NodeID"].ToString();
                string text = r["TreeText"].ToString();
                string parentid = r["ParentID"].ToString();
                string location = r["Location"].ToString();
                string url = r["Url"].ToString();
                string imageurl = r["ImageUrl"].ToString();
                int permissionid = int.Parse(r["PermissionID"].ToString().Trim());
                string framename = TargetFrame;

                //treeview set
                this.TreeView1.Font.Name = "宋体";
                this.TreeView1.Font.Size = FontUnit.Parse("9");

                //权限控制菜单		
                if ((permissionid == -1) || (UserPrincipal.HasPermissionID(permissionid)))//绑定用户有权限的和没设权限的（即公开的菜单）
                {
                    TreeNode rootnode = new TreeNode();
                    rootnode.Text = text;
                    rootnode.Value = nodeid;
                    rootnode.NavigateUrl = url;
                    rootnode.Target = framename;
                    rootnode.Expanded = menuExpand;
                    rootnode.ImageUrl = imageurl;
                    rootnode.SelectAction = TreeNodeSelectAction.SelectExpand;

                    TreeView1.Nodes.Add(rootnode);

                    int sonparentid = int.Parse(nodeid);// or =location
                    CreateNode(framename, sonparentid, rootnode, dt);
                }
            }
        }

        //邦定任意节点
        public void CreateNode(string TargetFrame, int parentid, TreeNode parentnode, DataTable dt)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);//选出所有子节点			
            foreach (DataRow r in drs)
            {
                string nodeid = r["NodeID"].ToString();
                string text = r["TreeText"].ToString();
                string location = r["Location"].ToString();
                string url = r["Url"].ToString();
                string imageurl = r["ImageUrl"].ToString();
                int permissionid = int.Parse(r["PermissionID"].ToString().Trim());
                string framename = TargetFrame;

                //权限控制菜单
                if ((permissionid == -1) || (UserPrincipal.HasPermissionID(permissionid)))
                {
                    TreeNode node = new TreeNode();
                    node.Text = text;
                    node.Value = nodeid;
                    node.NavigateUrl = url;
                    node.Target = TargetFrame;
                    node.ImageUrl = imageurl;
                    node.SelectAction = TreeNodeSelectAction.SelectExpand;
                    int sonparentid = int.Parse(nodeid);// or =location

                    if (parentnode == null)
                    {
                        TreeView1.Nodes.Clear();
                        parentnode = new TreeNode();
                        TreeView1.Nodes.Add(parentnode);
                    }
                    parentnode.ChildNodes.Add(node);
                    CreateNode(framename, sonparentid, node, dt);
                }//endif

            }//endforeach		

        }

        #region

        /*

        //邦定根节点
        public void BindTreeView2(string TargetFrame, DataTable dt)
        {
            string nodeid = dt.Rows[0]["NodeID"].ToString();
            string text = dt.Rows[0]["TreeText"].ToString();
            string parentid = dt.Rows[0]["ParentID"].ToString();
            string location = dt.Rows[0]["Location"].ToString();
            string url = dt.Rows[0]["Url"].ToString();
            string imageurl = dt.Rows[0]["ImageUrl"].ToString();
            string permissionid = dt.Rows[0]["PermissionID"].ToString();
            string framename = TargetFrame;

            int i = this.TreeView1.Nodes.Count;

            TreeView1.Nodes.Clear(); // 清空树
            Microsoft.Web.UI.WebControls.TreeNode rootnode = new Microsoft.Web.UI.WebControls.TreeNode();
            rootnode.Text = text;
            rootnode.NodeData = nodeid;
            rootnode.NavigateUrl = url;
            rootnode.Target = framename;
            rootnode.Expanded = true;
            rootnode.ImageUrl = imageurl;

            //			rootnode.ExpandedImageUrl="open.gif";
            //			rootnode.SelectedImageUrl="close.gif";
            TreeView1.Nodes.Add(rootnode);



            //treeview set
            this.TreeView1.ShowLines = false;
            this.TreeView1.ShowPlus = true;//是否显示前面的加减号


            string sonparentid = parentid + nodeid + "_";// or =location

            CreateNode2(framename, sonparentid, rootnode, dt);


        }


        //邦定任意节点
        public void CreateNode2(string TargetFrame, string parentid, Microsoft.Web.UI.WebControls.TreeNode parentnode, DataTable dt)
        {

            DataRow[] drs = dt.Select("ParentID" + "= '" + parentid + "'");//　选出所有子节点			
            foreach (DataRow r in drs)
            {
                string nodeid = r["NodeID"].ToString();
                string text = r["TreeText"].ToString();
                //				string parentid=r["ParentID"].ToString();
                string location = r["Location"].ToString();
                string url = r["Url"].ToString();
                string imageurl = r["ImageUrl"].ToString();
                string permissionid = r["PermissionID"].ToString();
                string framename = TargetFrame;


                Microsoft.Web.UI.WebControls.TreeNode node = new Microsoft.Web.UI.WebControls.TreeNode();
                node.Text = text;
                node.NodeData = nodeid;
                node.NavigateUrl = url;
                node.Target = TargetFrame;
                node.ImageUrl = imageurl;
                node.Expanded = true;


                string sonparentid = parentid + nodeid + "_";// or =location

                //				if((permissionid==null)||(permissionid==-1))
                //				{
                //					DataRow [] drst = dt.Select("ParentID" +"= '" + sonparentid + "'");//　选出所有子节点
                //					//if(drst.Length
                //
                //				}
                //									  
                parentnode.Nodes.Add(node);



                CreateNode2(framename, sonparentid, node, dt);

            }
        }
*/

        #endregion

    }
}