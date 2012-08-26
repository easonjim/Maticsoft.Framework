using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web.Admin.SysManage
{
    public partial class OnlineUser : PageBaseAdmin
    {

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                gridView1.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView1.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                BindData();
            }
           

        }
        #region gridView

        public void BindData()
        {
            DataTable table = (DataTable)Application["OnlineUsers"];
            gridView1.DataSource = table;
            gridView1.DataBind();
      
            //for (int i =0; i < gridView1.Rows.Count; i++) { 
            //    gridView1.Rows[i].Cells[0].Text =Convert.ToString(i);
            //}
        }

        #endregion

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView1.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");            
           
        }
       
    }
}