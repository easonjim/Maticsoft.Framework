/**
* AccountBasic.cs
*
* 功 能： [N/A]
* 类 名： AccountBasic
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/6/28 12:58:53  Rock    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Maticsoft.Accounts.Bus;

namespace Maticsoft.Web.MyAccount
{
    public partial class AccountBasic : System.Web.UI.MasterPage
    {
        public string loginInfo = "<span><a href=\"/NLogin.aspx\">登录</a>&nbsp;|&nbsp;</span><span><a href=\"/NRegister.aspx\">注册</a></span>";
        private BLL.Tao.Categories categoriesBLL = new BLL.Tao.Categories();
        private BLL.Tao.Courses coursesBLL = new BLL.Tao.Courses();

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 验证用户

            Maticsoft.Accounts.Bus.User currentUser = null;
            if (Context.User.Identity.IsAuthenticated)
            {
                AccountsPrincipal userPrincipal = new AccountsPrincipal(Context.User.Identity.Name);
                if (Session["UserInfo"] == null)
                {
                    currentUser = new Maticsoft.Accounts.Bus.User(userPrincipal);
                    Session["UserInfo"] = currentUser;
                }
                else
                {
                    currentUser = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                }
            }

            if (currentUser != null)
            {
                switch (currentUser.UserType)//UU用户，AA管理员
                {
                    case "AA":
                        loginInfo = "<span>欢迎您，&nbsp;" + currentUser.TrueName + "&nbsp;|&nbsp;</span><span><a href=\"/Admin/Main.htm\">管理中心</a>&nbsp;|&nbsp;</span><span><a href=\"/Logout.aspx\">退出</a></span>";
                        break;

                    case "UU":
                        loginInfo = "<span>欢迎您， &nbsp;" + currentUser.TrueName + "&nbsp;|&nbsp;</span><span><a href=\"/MyAccount/UserCenter.aspx\">我的账户</a>&nbsp;|&nbsp;</span><span><a href=\"/Logout.aspx\">退出</a></span>";
                        break;
                    default:
                        loginInfo = "<span>欢迎您， &nbsp;" + currentUser.TrueName + "&nbsp;|&nbsp;</span><span><a href=\"Logout.aspx\">退出</a></span>";
                        break;
                }
            }

            #endregion 验证用户

            BindList();
            if (!IsPostBack)
            {
            }
        }

        #region 左侧菜单数据

        private void BindList()
        {
            List<Model.Tao.Categories> model = categoriesBLL.GetCate(0);
            if (model != null && model.Count > 0)
            {
                this.Repeater_One.DataSource = model;
                this.Repeater_One.DataBind();
            }
        }

        protected void Repeater_One_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater list = (Repeater)e.Item.FindControl("Repeater_Two");
                if (list != null)
                {
                    Label labCid = (Label)e.Item.FindControl("labCid");
                    if (labCid == null)
                    {
                        return;
                    }
                    int CategriesId = int.Parse(labCid.Text);
                    List<Model.Tao.Categories> model = categoriesBLL.GetCate(CategriesId);
                    if (model != null && model.Count > 0)
                    {
                        list.DataSource = model;
                        list.DataBind();
                    }
                }
            }
        }

        public string resturnDiv(string CateId)
        {
            string IsHasData = "";
            int CategriesId = int.Parse(CateId);
            List<Model.Tao.Categories> model = categoriesBLL.GetCate(CategriesId);
            if (model != null && model.Count > 0)
            {
                IsHasData = Resources.MenuInfo.HasDataSource;
                return IsHasData;
            }
            else
            {
                IsHasData = Resources.MenuInfo.NoDataSource;
                return IsHasData;
            }
        }

        public void Repeater_Two_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater list = (Repeater)e.Item.FindControl("Repeater_Three");
            if (list != null)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label labCid = (Label)e.Item.FindControl("labCCid");
                    int CategriesId = int.Parse(labCid.Text);
                    List<Model.Tao.Categories> clist = categoriesBLL.GetCate(CategriesId);
                    if (clist != null && clist.Count > 0)
                        list.DataSource = clist;
                    list.DataBind();
                }
            }
        }

        #endregion 左侧菜单数据
    }
}