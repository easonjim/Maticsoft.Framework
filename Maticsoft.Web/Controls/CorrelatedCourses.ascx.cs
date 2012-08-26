using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class CorrelatedCourses : System.Web.UI.UserControl
    {
        private int courseId;
        private int top;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
                DataSet ds = courseBll.GetRecommendedCourseList(this.courseId, this.top);
                this.DataList_RecommendedList.DataSource = ds;
                this.DataList_RecommendedList.DataBind();
            }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public int Top
        {
            get { return top; }
            set { top = value; }
        }
    }
}