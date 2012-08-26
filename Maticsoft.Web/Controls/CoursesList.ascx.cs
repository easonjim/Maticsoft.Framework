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
    public partial class CoursesList : System.Web.UI.UserControl
    {
        private RepeatDirection repeatDirection;
        private int repeatColumns = 2;
        private QueryCourses query;
        private int iTotal = 0;
        
        public override void DataBind()
        {
            //DataList显示方式
            this.DataList_Course.RepeatDirection = this.RepeatDirection;
            //DataList显示列数
            this.DataList_Course.RepeatColumns = this.RepeatColumns;

            BLL.Tao.CourseModule coursesBll = new BLL.Tao.CourseModule();
            query.PageIndex = this.AspNetPager1.CurrentPageIndex;
            query.PageSize = this.AspNetPager1.PageSize;
            DataTable dt = coursesBll.GetCourseList(query);
            this.AspNetPager1.RecordCount = this.ITotal;
            this.DataList_Course.DataSource = dt;
            this.DataList_Course.DataBind();
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

        public RepeatDirection RepeatDirection
        {
            get
            {
                return this.repeatDirection;
            }
            set
            {
                this.repeatDirection = value;
            }
        }

        public int RepeatColumns
        {
            get
            {
                return this.repeatColumns;
            }
            set
            {
                this.repeatColumns = value;
            }
        }

        public int ITotal
        {
            get { return iTotal; }
            set { iTotal = value; }
        }

        private bool displayBtn;

        public bool DisplayBtn
        {
            get { return displayBtn; }
            set { displayBtn = value; }
        }

        protected void DataList_Course_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if(e.Item.ItemType== ListItemType.Item || e.Item.ItemType== ListItemType.AlternatingItem)
            {
                if (this.DisplayBtn)
                {
                    Button btn = (Button)e.Item.FindControl("btn");
                    btn.Visible = true;
                }
            }
        }
    }
}