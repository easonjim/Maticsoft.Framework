using System;
using Maticsoft.Common;

namespace Maticsoft.Web
{
    public partial class courselist : PageBase
    {
        public string strSiteNav = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //站点导航
                if (!string.IsNullOrEmpty(Request.Params["CategoryId"]) && Common.PageValidate.IsNumber(Request.Params["CategoryId"]))
                {
                    strSiteNav = BindSiteNav(int.Parse(Request.Params["CategoryId"]));
                }

                string strKey = Request.Params["key"];
                if (!string.IsNullOrEmpty(strKey))
                {
                    strSiteNav = "&nbsp;&gt;&gt;&nbsp;搜索与<a href=\"/courselist.aspx?key=" + Server.UrlEncode(InjectionFilter.SqlFilter(InjectionFilter.QuoteFilter(strKey))) + "\"><b>" + strKey + "</b></a>有关的课程信息";
                }
                //BoundDrop();
                //string dept = Request.Params["did"];
                //if (!string.IsNullOrEmpty(dept))
                //{
                //    this.ddlEnter.SelectedValue = dept;
                //}
            }
        }

        //private void BoundDrop()
        //{
        //    BLL.Tao.Enterprise enBll = new BLL.Tao.Enterprise();
        //this.ddlEnter.DataSource = enBll.GetList();

        //ddlEnter.DataTextField = "Name";
        //ddlEnter.DataValueField = "EnterpriseID";
        //ddlEnter.DataBind();
        //this.ddlEnter.Items.Insert(0, new ListItem("请选择所属机构", ""));
        //}
    }
}