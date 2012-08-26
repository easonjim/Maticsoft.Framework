using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web
{
    public partial class OnLineCourse : PageBase
    {
        private Maticsoft.BLL.Tao.Courses coursesBLL = new Maticsoft.BLL.Tao.Courses();
        private BLL.Tao.CourseMaterial courseMaterialBLL = new BLL.Tao.CourseMaterial();
        private BLL.UserExp.UsersExp usersExtBLL = new BLL.UserExp.UsersExp();
        private Maticsoft.BLL.Tao.Modules modulesBLL = new Maticsoft.BLL.Tao.Modules();
        private BLL.Tao.Favorite favoriteBLL = new BLL.Tao.Favorite();
        private BLL.Tao.CourseNotes courseNotesBLL = new BLL.Tao.CourseNotes();
        private Maticsoft.BLL.Tao.CourseModule courseModuleBLL = new Maticsoft.BLL.Tao.CourseModule();
        public string strSiteNav = string.Empty;

        /// <summary>
        /// 学习资料
        /// </summary>
        public string strCourseMaterial = string.Empty;

        /// <summary>
        /// 视频HtmlCode
        /// </summary>
        public string strVideoHtmlCode = string.Empty;

        /// <summary>
        /// 用户笔记
        /// </summary>
        public string strCourseNotes = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.Params["cid"]) && string.IsNullOrEmpty(Request.Params["mid"]))
            {
                Session["CurrentError"] = "您访问的页面不存在！";
                Server.Transfer("~/ErrorPage.aspx");
            }

            if (!string.IsNullOrEmpty(Request.Params["cid"]) && PageValidate.IsNumber(Request.Params["cid"]))
            {
                string strCid = Request.Params["cid"];
                hfCourseID.Value = strCid;
            }
            else
            {
                Session["CurrentError"] = "您访问的页面不存在！";
                Server.Transfer("~/ErrorPage.aspx");
            }
            if (!string.IsNullOrEmpty(Request.Params["mid"]) && PageValidate.IsNumber(Request.Params["mid"]))
            {
                string strMid = Request.Params["mid"];
                hfModuleID.Value = strMid;
            }

            int courseID = int.Parse(hfCourseID.Value);
            if (!coursesBLL.Exists(courseID))
            {
                Session["CurrentError"] = "您访问课程信息不存在！";
                Server.Transfer("~/ErrorPage.aspx");
                return;
            }
            //当前用户已经登录
            if (null != CurrentUser)
            {
                this.hfUid.Value = CurrentUser.UserID.ToString();

                this.hfCurrent.Value = CurrentUser.UserID.ToString();
            }

            #region 显示课程信息

            ShowCourseInfo(courseID);

            #endregion 显示课程信息

            if (!string.IsNullOrEmpty(hfModuleID.Value))
            {
                int mid = int.Parse(hfModuleID.Value);
                GetModuleInfo(mid);
                //学习资料
                strCourseMaterial += ShowCourseMaterial(courseID);
                //更新章节浏览量
                if (!Page.IsPostBack)
                {
                }
                //人气
                //Model.Tao.Courses model = coursesBLL.GetModel(courseID);
                //if (null != model)
                //{
                //    this.lblPV.Text = "0";
                //    if (model.PV.HasValue)
                //    {
                //        this.lblPV.Text = model.PV.Value + "";
                //    }
                //}
            }
            else
            {
                if (0 < courseModuleBLL.GetFirstModuleID(courseID))
                {
                    int ModuleID = courseModuleBLL.GetFirstMID(courseID);
                    this.hfModuleID.Value = ModuleID.ToString();
                    GetModuleInfo(ModuleID);
                    if (!Page.IsPostBack)
                    {
                        //更新课程浏览量
                        coursesBLL.UpdatePV(courseID);
                        //更新章节浏览量
                        modulesBLL.UpdatePV(ModuleID);
                    }
                    //人气
                    //Model.Tao.Courses model = coursesBLL.GetModel(courseID);
                    //if (null != model)
                    //{
                    //    this.lblPV.Text = "0";
                    //    if (model.PV.HasValue)
                    //    {
                    //        this.lblPV.Text = model.PV.Value + "";
                    //    }
                    //}
                    //学习资料
                    strCourseMaterial += ShowCourseMaterial(courseID);
                }
                else
                {
                    Session["CurrentError"] = "课程信息有误！";
                    Server.Transfer("~/ErrorPage.aspx");
                    return;
                }
            }
        }

        #region 获得某节课程信息，注意状态

        /// <summary>
        /// 获得某节课程信息，注意状态
        /// </summary>
        private void GetModuleInfo(int ModuleID)
        {
            Maticsoft.Model.Tao.Modules model = modulesBLL.GetModel(ModuleID);
            List<Model.Tao.Modules> list = modulesBLL.GetModuleInfo(int.Parse(hfCourseID.Value));
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.ImageUrl))
                    {
                        this.imgListen.ImageUrl = item.ImageUrl;
                    }
                    else
                    {
                        this.imgListen.ImageUrl = "images/none.gif";
                    }
                }
            }
            else
            {
                hfModuleID.Value = "";
                Session["CurrentError"] = "课程信息有误！";
                Server.Transfer("~/ErrorPage.aspx");
                return;
            }
        }

        #endregion 获得某节课程信息，注意状态

        #region 显示课程信息

        private void ShowCourseInfo(int CourseID)
        {
            Maticsoft.Model.Tao.Courses coursesModel = coursesBLL.GetModel(CourseID);
            if (null != coursesModel)
            {
                //注意：课程状态是否已经审核通过并发布
                if (3 != coursesModel.Status)
                {
                    hfCourseID.Value = "";
                    Session["CurrentError"] = "课程信息有误！";
                    Server.Transfer("~/ErrorPage.aspx");
                    return;
                }

                this.litCInfo.Text = "<a href=\"show.aspx?cid=" + coursesModel.CourseID + "\" class=\"img\"> <img src=\"" + coursesModel.ImageUrl + "\" width=\"334\" height=\"224\" />" + coursesModel.CourseName + "</a>";

                this.litMore.Text = "<a href=\"show.aspx?cid=" + coursesModel.CourseID + "\" class=\"more\" target='_blank'>更多章节>></a>";

                //this.imgCourse.ImageUrl = string.IsNullOrEmpty(coursesModel.ImageUrl) ? "images/imgbox.jpg" : coursesModel.ImageUrl;

                //this.litCourseName.Text = coursesModel.CourseName;

                //标签
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

                if (coursesModel.CategoryId.HasValue)
                {
                    //站点导航
                    strSiteNav = BindSiteNav(coursesModel.CategoryId.Value);
                    //分类
                    this.litCate.Text = BindSiteNav(coursesModel.CategoryId.Value);
                }

                if (coursesModel.TimeDuration.HasValue)
                {
                    this.litTime.Text = ConvertTime(coursesModel.TimeDuration.Value);
                }

                this.litDes.Text = coursesModel.ShortDescription;

                #region 课程的所有老师信息

                //课程的所有老师信息
                StringBuilder str = new StringBuilder();
                DataSet ds = coursesBLL.GetCreatedUserIDList(CourseID);
                if (null != ds && 0 != ds.Tables.Count && 0 != ds.Tables[0].Rows.Count && 0 != ds.Tables[0].Columns.Count)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        str.Append("<a href='SearchTeacher.aspx?key=" + Server.UrlEncode(dr["TrueName"].ToString()) + "'>" + dr["TrueName"].ToString() + "</a>&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                }
                if (str.Length > 0)
                {
                    this.litTeachers.Text = str + "";
                }

                #endregion 课程的所有老师信息

                this.litePrice.Text = coursesModel.Price.ToString() == "0.00" ? "免费" : coursesModel.Price.ToString();

                if (coursesModel.SalesVolume.HasValue)
                {
                    // this.litSell.Text = coursesModel.SalesVolume.Value.ToString();
                }
                else
                {
                    // this.litSell.Text = "0";
                }

                if (coursesModel.CreatedUserID.HasValue && PageValidate.IsNumber(coursesModel.CreatedUserID.ToString()))
                {
                    int uid = coursesModel.CreatedUserID.Value;
                    string strUserName = GetUserName(uid);
                    this.hfUid.Value = coursesModel.CreatedUserID.ToString();
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

                    // 标签
                    System.Text.StringBuilder sbTeacher = new StringBuilder();
                    if (!string.IsNullOrEmpty(model.Tags))
                    {
                        string[] strTags = coursesModel.Tags.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
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
        }

        #endregion 显示课程信息

        #region 学习资料

        /// <summary>
        /// 学习资料
        /// </summary>
        /// <param name="CourseID"></param>
        /// <param name="ModuleID"></param>
        /// <param name="Status"></param>
        private string ShowCourseMaterial(int CourseID)
        {
            StringBuilder str = new StringBuilder();
            DataSet ds = courseMaterialBLL.GetCourseMaterialList(CourseID, 0);
            if (null != ds && 0 != ds.Tables.Count && 0 != ds.Tables[0].Rows.Count && 0 != ds.Tables[0].Columns.Count)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    str.Append("<li><a href=\"" + dr["MaterialURL"] + "\"  target=\"_blank\">" + dr["MaterialName"] + "</a></li>");
                }
            }
            else
            {
                str.Append("尚未上传与该课程相关任何学习资料！");
            }
            return str.ToString();
        }

        #endregion 学习资料

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
    }
}