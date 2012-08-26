using System;
using System.Text;
using Maticsoft.Common;

namespace Maticsoft.Web
{
    public partial class Offlineshow : PageBase
    {
        private BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();
        private Maticsoft.BLL.Tao.Courses coursesBLL = new Maticsoft.BLL.Tao.Courses();
        private BLL.UserExp.UsersExp usersExtBLL = new BLL.UserExp.UsersExp();
        public string strSiteNav = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CourseID <= 0)
                {
                    Session["CurrentError"] = "课程信息有误！";
                    Server.Transfer("~/ErrorPage.aspx");
                    return;
                }
                if (null != CurrentUser)
                {
                    this.hfUid.Value = CurrentUser.UserID.ToString();

                    this.hfCurrent.Value = CurrentUser.UserID.ToString();
                }

                #region 显示课程信息

                ShowCourseInfo(CourseID);

                #endregion 显示课程信息
            }
        }

        public int CourseID
        {
            get
            {
                int courseId = 0;
                if (!string.IsNullOrEmpty(Request.Params["cid"]))
                {
                    courseId = Globals.SafeInt(Request.Params["cid"], 0);
                } return courseId;
            }
        }

        #region 显示课程信息

        private void ShowCourseInfo(int CourseID)
        {
            Maticsoft.Model.Tao.OffLineCourse coursesModel = bll.GetModel(CourseID);
            if (null != coursesModel)
            {
                //注意：课程状态是否已经审核通过并发布
                if (3 != coursesModel.Status)
                {
                    Session["CurrentError"] = "课程信息有误！";
                    Server.Transfer("~/ErrorPage.aspx");
                    return;
                }
                this.imgCourse.ImageUrl = coursesModel.ImageURL;
                this.litCourseName.Text = coursesModel.CourseName;
                this.litStartTime.Text = coursesModel.StartTime.ToString("yyyy-MM-dd");
                ////标签
                System.Text.StringBuilder sbstr = new StringBuilder();
                if (!string.IsNullOrEmpty(coursesModel.Tags))
                {
                    string[] strTags = coursesModel.Tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < strTags.Length; i++)
                    {
                        string strCon = "<a href=\"searchCourse.aspx?key=" + strTags[i] + "\" >" + strTags[i] + "</a>";
                        sbstr.Append(strCon + "&nbsp;&nbsp;");
                    }
                    this.litTags.Text = sbstr.ToString();
                }
                else
                {
                    this.litTags.Text = "";
                }
                //站点导航
                strSiteNav = BindSiteNav(coursesModel.CategoryId);
                //分类
                this.litCate.Text = BindSiteNav(coursesModel.CategoryId);
                //if (coursesModel.TimeDuration.HasValue)
                //{
                //    this.litTime.Text = ConvertTime(coursesModel.TimeDuration.Value);
                //}

                this.LitDesc.Text = coursesModel.Description;

                #region 课程的所有老师信息

                this.litTeachers.Text = usersExtBLL.GetUname(coursesModel.CreatedUserID);

                #endregion 课程的所有老师信息

                this.litePrice.Text = coursesModel.CoursePrice.ToString() == "0.00" ? "免费" : coursesModel.CoursePrice.ToString();

                //if (coursesModel.SalesVolume.HasValue)
                //{
                //    this.litSell.Text = coursesModel.SalesVolume.Value.ToString();
                //}
                //else
                //{
                //    this.litSell.Text = "0";
                //}

                int uid = coursesModel.CreatedUserID;
                string strUserName = GetUserName(uid);
                //this.hfUid.Value = coursesModel.CreatedUserID.ToString();
                this.litUName.Text = strUserName;
                Model.UserExp.UsersExp model = usersExtBLL.GetModel(uid);
                if (null != model)
                {
                    this.imgUserAvatar.ImageUrl = "~" + model.UserAvatar;
                    this.litTeacherInfo.Text = GetCourseDec(model.TeachDescription, 194);
                }
                this.litPubCourse.Text = coursesBLL.GetPubSourse(uid).ToString();
                this.litPeople.Text = coursesBLL.GetSellCourseNum(CourseID).ToString();
                //this.litFav.Text = favoriteBLL.GetFavCourseCount(CourseID).ToString();

                this.litdet.Text = "<a  href='TeacherDes.aspx?uid=" + model.UserID + "'>了解更多>></a>";

                //标签
                System.Text.StringBuilder sbTeacher = new StringBuilder();
                if (!string.IsNullOrEmpty(model.Tags))
                {
                    string[] strTags = coursesModel.Tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < strTags.Length; i++)
                    {
                        string strCon = "<a href=\"searchCourse.aspx?key=" + strTags[i] + "\" >" + strTags[i] + "</a>";
                        sbTeacher.Append(strCon + "&nbsp;&nbsp;");
                    }
                    this.litTeacherTags.Text = sbTeacher.ToString();
                }
                else
                {
                    this.litTeacherTags.Text = "";
                }
            }
        }

        public string GetCourseDec(object strValue, int length)
        {
            StringBuilder strContent = new StringBuilder();
            if (null != strValue)
            {
                if (strValue.ToString().Length > length)
                {
                    strContent.Append(strValue.ToString().Substring(0, length) + "...");
                }
                else
                {
                    strContent.Append(strValue.ToString());
                }
            }
            return strContent.ToString();
        }

        #endregion 显示课程信息
    }
}