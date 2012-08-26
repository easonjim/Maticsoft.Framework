using System;

namespace Maticsoft.Web.SysManage
{
    public partial class delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Maticsoft.BLL.SysManage.SysTree sm = new Maticsoft.BLL.SysManage.SysTree();
                string id = Request.Params["id"];
                sm.DelTreeNode(int.Parse(id));
                Response.Redirect("treelist.aspx");
            }
        }
    }
}
