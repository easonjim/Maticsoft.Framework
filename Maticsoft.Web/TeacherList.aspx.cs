using System;
using Maticsoft.Common;

namespace Maticsoft.Web
{
    public partial class TeacherList : System.Web.UI.Page
    {
        public string strSiteNav = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            strSiteNav = "&nbsp;&gt;&gt;&nbsp;搜索与<a href=\"/courselist.aspx?key=" + Server.UrlEncode(InjectionFilter.SqlFilter(InjectionFilter.QuoteFilter(Request.Params["key"]))) + "\"><b>" + Request.Params["key"] + "</b></a>有关的教师信息";
        }
    }
}