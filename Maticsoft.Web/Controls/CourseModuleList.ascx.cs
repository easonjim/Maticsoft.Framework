using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Model;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class CourseModuleList : System.Web.UI.UserControl
    {
        private QueryCourses query;
        private int iTotal = 0;
        
        public override void DataBind()
        {
            BLL.Tao.CourseModule coursesBll = new BLL.Tao.CourseModule();
            query.PageIndex = this.AspNetPager1.CurrentPageIndex;
            query.PageSize = this.AspNetPager1.PageSize;
            DataTable dt = coursesBll.GetModuleList(query);
            this.AspNetPager1.RecordCount = this.iTotal;
            this.grd_ModuleList.DataSource = dt;
            this.grd_ModuleList.DataBind();
        }

        override protected void OnInit(EventArgs e)
        {
            //InitializeComponent();
            base.OnInit(e);
        }

        public QueryCourses Query
        {
            get
            {
                return this.query;
            }
            set
            {
                this.query = value;
            }
        }
        public int ITotal
        {
            get { return iTotal; }
            set { iTotal = value; }
        }

        private bool displayBuy;

        public bool DisplayBuy
        {
            get { return displayBuy; }
            set { displayBuy = value; }
        }

        protected void grd_ModuleList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!DisplayBuy)
                {
                    e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}