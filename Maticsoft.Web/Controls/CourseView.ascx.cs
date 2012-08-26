using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Controls
{
    public partial class CourseView : System.Web.UI.UserControl
    {
        BLL.Tao.Courses courseBLL = new BLL.Tao.Courses();
        Model.Tao.Courses courseModel = null;

        private int? _userID;
        private int? _status;
        private int? _courseTypes;

        private string _teacherName;

        public string TeacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        public string isMore = string.Empty;

        public override void DataBind()
        {
            courseModel=new Model.Tao.Courses();
            courseModel.CreatedUserID = UserID;
            courseModel.Status = Status;
            System.Data.DataSet ds = courseBLL.PublishCourseInfo(courseModel);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.Repeater_CourseView.DataSource = ds;
                    this.Repeater_CourseView.DataBind();
                    isMore = "<div class=\"more\"><a href=\"/searchCourse.aspx?key=" + TeacherName + "&uid=" + UserID + "\">更 多课程&nbsp;>></a></div>";
                }
            }
        }

        public int? UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public int? Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int? CourseTypes
        {
            get { return _courseTypes; }
            set { _courseTypes = value; }
        }
    }
}