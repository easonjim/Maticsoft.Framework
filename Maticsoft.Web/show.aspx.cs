using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web
{
    public partial class show : PageBase
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
                    // modulesBLL.UpdatePV(mid);
                    //用户笔记
                    if (null != CurrentUser)
                    {
                        ShowCourseNotes(CurrentUser.UserID, courseID, mid);
                    }
                    else
                    {
                        strCourseNotes = "您尚未登录，无法浏览记录的笔记信息！";
                        this.NotebookArea.Value = "对不起，您尚未登录，无法进行添加笔记操作，请登录后再进行操作！";
                        this.NotebookArea.Disabled = true;
                        this.btnAddCourseNotes.Enabled = false;
                    }
                }
                //人气
                Model.Tao.Courses model = coursesBLL.GetModel(courseID);
                if (null != model)
                {
                    this.lblPV.Text = "0";
                    if (model.PV.HasValue)
                    {
                        this.lblPV.Text = model.PV.Value + "";
                    }
                }
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

                        //用户笔记
                        if (null != CurrentUser)
                        {
                            ShowCourseNotes(CurrentUser.UserID, courseID, ModuleID);
                        }
                        else
                        {
                            strCourseNotes = "您尚未登录，无法浏览记录的笔记信息！";
                            this.NotebookArea.Value = "对不起，您尚未登录，无法进行添加笔记操作，请登录后再进行操作！";
                            this.NotebookArea.Disabled = true;
                            this.btnAddCourseNotes.Enabled = false;
                        }
                    }
                    //人气
                    Model.Tao.Courses model = coursesBLL.GetModel(courseID);
                    if (null != model)
                    {
                        this.lblPV.Text = "0";
                        if (model.PV.HasValue)
                        {
                            this.lblPV.Text = model.PV.Value + "";
                        }
                    }
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
            if (null != model)
            {
                if (model.Status != 3)
                {
                    hfModuleID.Value = "";
                    Session["CurrentError"] = "课程信息有误！";
                    Server.Transfer("~/ErrorPage.aspx");
                    return;
                }

                Maticsoft.Model.Tao.CourseModule CourseModuleModel = courseModuleBLL.GetModel(int.Parse(this.hfCourseID.Value), ModuleID);
                if (CourseModuleModel != null)
                {
                    //this.lblModeleIndex.Text = CourseModuleModel.ModuleIndex.HasValue ? CourseModuleModel.ModuleIndex.Value.ToString() : "1";
                }
                //lblModuleName.Text = model.ModuleName;
                if (model.CreatedUserID.HasValue)
                {
                    //this.lblTrueName.Text = this.lblTeacher.Text = GetUserName(model.CreatedUserID);
                }
                if (model.Price.HasValue)
                {
                    if (0 < model.Price.Value)
                    {
                        #region 课程价格不免费的时候

                        this.litNoBuy.Text = "<a href=\"shopCart.aspx?CourseId=" + hfCourseID.Value + "&mid=0\" target=\"_blank\"><img src=\"imagesN/TLaoShi_bt030.gif\" /></a>";
                        if (null != Session["ModuleIDList"])
                        {
                            //查询所有的购买的章节ID
                            List<int> list = (List<int>)Session["ModuleIDList"];
                            if (null != list)
                            {
                                if (list.Contains(ModuleID))
                                {
                                    //this.btnLearnCourse.Visible = false;
                                    //this.imgbtnBuy.Visible = false;
                                    //this.lblModuleName.Text = model.ModuleName;
                                    if (model.Type.HasValue)
                                    {
                                        if (!string.IsNullOrEmpty(model.VideoContent))
                                        {
                                            //根据视频
                                            switch (model.Type)
                                            {
                                                case 0: //本地视频 后期处理
                                                    string strVideoExt = System.IO.Path.GetExtension(model.VideoContent).ToLower();
                                                    if (strVideoExt.Equals(".swf"))
                                                    {
                                                        strVideoHtmlCode = GetpalyerUrl(model.VideoContent);
                                                    }
                                                    else
                                                    {
                                                        if (strVideoExt.Equals(".mp4") || strVideoExt.Equals(".flv"))
                                                        {
                                                            strVideoHtmlCode += "<a href=\"" + model.VideoContent + "\" style=\"display: block;width: 600px; height: 515px;\" id=\"player\"></a>";
                                                            strVideoHtmlCode += "<script>flowplayer(\"player\", \"../flowplayer/flowplayer-3.2.7.swf\",{	clip:{autoPlay:false,autoBuffering:true}});</script>";
                                                        }
                                                        else
                                                        {
                                                            strVideoHtmlCode = "视频正在转码中，暂不能播放！目前只支持flv,swf,mp4格式的视频,其他格式需要转码之后才能播放。";
                                                        }
                                                    }
                                                    break;

                                                case 1://视频地址
                                                    //播放flash地址代码
                                                    strVideoHtmlCode = GetpalyerUrl(model.VideoContent);
                                                    break;

                                                case 2: //Html代码
                                                    string videoContent = model.VideoContent;
                                                    string playerUrl = getHtmlscript(model.VideoContent);
                                                    videoContent = GetpalyerUrl(playerUrl);
                                                    strVideoHtmlCode = videoContent;
                                                    break;
                                                default:
                                                    //strVideo = "";
                                                    //strVideoHtmlCode = "";
                                                    break;
                                            }
                                        }
                                    }
                                    //strDes = model.Description;
                                }
                                else
                                {
                                    //对不起，你还没有购买该课程下的这个章节
                                    strVideoHtmlCode = "<div><strong>对不起,您尚未购买,不能进行观看！</strong></div><br/><img style=\"margin-top:0px;width:600px; height: 515px;\" src=\"" + model.ImageUrl + "\">";
                                    this.litNoBuy.Text = "<a href=\"shopCart.aspx?CourseId=" + hfCourseID.Value + "&mid=0\" target=\"_blank\"><img src=\"imagesN/TLaoShi_bt030.gif\" /></a>";
                                    //this.txtContent.Text = "您尚未购买，不能进行评论!";
                                    //this.txtContent.ReadOnly = true;
                                    //this.imgbtnSubmit.Enabled = false;
                                    //this.imgbtnReset.Enabled = false;
                                    //strIsShowReply = "display:none";

                                    //this.imgbtnBuy.Visible = true;
                                    //this.btnLearnCourse.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            //对不起，你还没有购买该课程下的这个章节
                            strVideoHtmlCode = "<div><strong>对不起,您尚未购买,不能进行观看！</strong></div><br/><img style=\"margin-top:0px;width:600px; height: 515px;\" src=\"" + model.ImageUrl + "\">";
                            this.litNoBuy.Text = "<a href=\"shopCart.aspx?CourseId=" + hfCourseID.Value + "&mid=0\" target=\"_blank\"><img src=\"imagesN/TLaoShi_bt030.gif\" /></a>";
                            //this.imgbtnBuy.Visible = true;
                            //this.btnLearnCourse.Visible = false;
                        }

                        #endregion 课程价格不免费的时候
                    }
                    else
                    {
                        #region 价格免费的时候

                        //this.imgbtnBuy.Visible = false;
                        //this.btnLearnCourse.Visible = true;
                        //this.lblModuleName.Text = model.ModuleName;
                        if (null != model.Type)
                        {
                            //根据视频
                            switch (model.Type)
                            {
                                case 0: //本地视频 后期处理
                                    string strVideoExt = System.IO.Path.GetExtension(model.VideoContent).ToLower();
                                    if (strVideoExt.Equals(".swf"))
                                    {
                                        strVideoHtmlCode = GetpalyerUrl(model.VideoContent);
                                    }
                                    else
                                    {
                                        if (strVideoExt.Equals(".mp4") || strVideoExt.Equals(".flv"))
                                        {
                                            strVideoHtmlCode += "<a href=\"" + model.VideoContent + "\" style=\"display: block;width:600px; height: 515px;\" id=\"player\"></a>";
                                            strVideoHtmlCode += "<script>flowplayer(\"player\", \"../flowplayer/flowplayer-3.2.7.swf\",{	clip:{autoPlay:false,autoBuffering:true}});</script>";
                                        }
                                        else
                                        {
                                            strVideoHtmlCode = "视频正在转码中，暂不能播放！目前只支持flv,swf,mp4格式的视频,其他格式需要转码之后才能播放。";
                                        }
                                    }
                                    break;

                                case 1://视频地址
                                    //播放flash地址代码
                                    strVideoHtmlCode = GetpalyerUrl(model.VideoContent);
                                    break;

                                case 2: //Html代码
                                    string videoContent = model.VideoContent;
                                    string playerUrl = getHtmlscript(model.VideoContent);
                                    videoContent = GetpalyerUrl(playerUrl);
                                    strVideoHtmlCode = videoContent;
                                    break;
                                default:
                                    //strVideo = "";
                                    //strVideoHtmlCode = "";
                                    break;
                            }
                        }
                        // strDes = model.Description;

                        #endregion 价格免费的时候
                    }
                }
            }
        }

        private string GetpalyerUrl(string defaultUrl)
        {
            return "<object codeBase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0\" height=\"515\" width=\"600\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\"> <PARAM NAME=\"Movie\" VALUE=\"" + defaultUrl + "\"><PARAM NAME=\"Src\" VALUE=\"" + defaultUrl + "\"><param name=\"allowFullScreen\" value=\"true\" /><param name=\"allowScriptAccess\" value=\"always\"></param><PARAM NAME=\"WMode\" VALUE=\"transparent\"><embed src=\"" + defaultUrl + "\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" wmode=\"transparent\" allowScriptAccess=\"always\" allowFullScreen=\"true\" type=\"application/x-shockwave-flash\" width=\"598\" height=\"515\"></embed></object>";
        }

        #endregion 获得某节课程信息，注意状态

        #region 视频地址的处理

        private string getHtmlscript(string HtmlScript)
        {
            string ScriptSrc = string.Empty;
            if (HtmlScript.Contains("youku") || HtmlScript.Contains("ku6") || HtmlScript.Contains("tudou"))
            {
                string regStr = @"<embed[^>]*src=\""(?<src>[^\""]+)\""[^>]*></embed>";//<embed[^>]*src=\"(?<src>[^\"]+)\"[^>]*></embed>
                Regex regex = new System.Text.RegularExpressions.Regex(regStr, System.Text.RegularExpressions.RegexOptions.Singleline);
                MatchCollection mc = regex.Matches(HtmlScript);
                //是合法的Http 网址
                if (mc.Count > 0)
                {
                    foreach (Match match in mc)
                    {
                        ScriptSrc = match.Groups["src"].Value;
                    }
                }
                return ScriptSrc;
            }
            else if (HtmlScript.Contains("126") || HtmlScript.Contains("163"))
            {
                string regStr = @"<object.+?><param\s*name=""movie""\s*value=\""(?<src>[^\""]+)\""[^>]*></param>.+</object>";
                Regex regex = new System.Text.RegularExpressions.Regex(regStr, System.Text.RegularExpressions.RegexOptions.Singleline);
                MatchCollection mc = regex.Matches(HtmlScript);
                //是合法的Http 网址
                if (mc.Count > 0)
                {
                    foreach (Match match in mc)
                    {
                        ScriptSrc = match.Groups["src"].Value;
                    }
                }
                return ScriptSrc;
            }
            else if (HtmlScript.Contains("sina"))
            {
                //<div><object.*?src=\'(?<src>[^\"]+)\'\s*type=.+?</div>
                string regStr = @"<div><object.*?src=\'(?<src>[^\""]+)\'\s*type=.+?</div>";
                Regex regex = new System.Text.RegularExpressions.Regex(regStr, System.Text.RegularExpressions.RegexOptions.Singleline);
                MatchCollection mc = regex.Matches(HtmlScript);
                //是合法的Http 网址
                if (mc.Count > 0)
                {
                    foreach (Match match in mc)
                    {
                        ScriptSrc = match.Groups["src"].Value;
                    }
                }
                return ScriptSrc;
            }
            else
            {
                return ScriptSrc;
            }
        }

        #endregion 视频地址的处理

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

                this.litCourseName.Text = coursesModel.CourseName;

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

                this.litDes.Text = this.LitDesc.Text = coursesModel.ShortDescription;

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
                    this.litSell.Text = coursesModel.SalesVolume.Value.ToString();
                }
                else
                {
                    this.litSell.Text = "0";
                }

                if (coursesModel.CreatedUserID.HasValue && PageValidate.IsNumber(coursesModel.CreatedUserID.ToString()))
                {
                    int uid = coursesModel.CreatedUserID.Value;
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
                    this.litPeople.Text = this.litHaveChose.Text = coursesBLL.GetSellCourseNum(CourseID).ToString();
                    this.litFav.Text = favoriteBLL.GetFavCourseCount(CourseID).ToString();

                    this.litdet.Text = "<a  href='TeacherDes.aspx?uid=" + model.UserID + "'>了解更多>></a>";

                    //标签
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

        #region 用户笔记

        /// <summary>
        /// 用户笔记
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CourseID"></param>
        /// <param name="ModuleID"></param>
        private string ShowCourseNotes(int UserID, int CourseID, int ModuleID)
        {
            StringBuilder str = new StringBuilder();
            DataSet ds = courseNotesBLL.GetCourseNotesList(UserID, CourseID, ModuleID);
            if (null != ds && 0 != ds.Tables.Count && 0 != ds.Tables[0].Rows.Count && 0 != ds.Tables[0].Columns.Count)
            {
                rptCourseNotes.DataSource = ds.Tables[0];
                rptCourseNotes.DataBind();
            }
            else
            {
                rptCourseNotes.DataSource = null;
                rptCourseNotes.DataBind();
                str.Append("您尚未记录任何与该课程有关的笔记内容！");
            }
            return str.ToString();
        }

        protected void rptCourseNotes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label labNoteID = e.Item.FindControl("labNoteId") as Label;
            Label labMid = e.Item.FindControl("labMid") as Label;
            Label labCid = e.Item.FindControl("labCid") as Label;//labontent
            Label labContent = e.Item.FindControl("labontent") as Label;
            if (labNoteID == null || labMid == null || labCid == null || labContent == null)
            {
                return;
            }
            if (e.CommandArgument.Equals("editC"))
            {
                if (!string.IsNullOrEmpty(labNoteID.Text) && !string.IsNullOrEmpty(labMid.Text) && !string.IsNullOrEmpty(labCid.Text))
                {
                    this.labNID.Text = labNoteID.Text;
                    this.NotebookArea.Value = labContent.Text;
                }
            }
            if (e.CommandArgument.Equals("delC"))
            {
                if (!string.IsNullOrEmpty(labNoteID.Text) && !string.IsNullOrEmpty(labMid.Text) && !string.IsNullOrEmpty(labCid.Text))
                {
                    int nid = int.Parse(labNoteID.Text);
                    courseNotesBLL.Delete(nid);
                    int CourseID = int.Parse(labCid.Text);
                    int mid = int.Parse(labMid.Text);
                    ShowCourseNotes(CurrentUser.UserID, CourseID, mid);
                    this.labNID.Text = string.Empty;
                    this.NotebookArea.Value = string.Empty;
                }
            }
        }

        protected void btnAddCourseNotes_Click(object sender, ImageClickEventArgs e)
        {
            if (CurrentUser == null)
            {
                Maticsoft.Common.MessageBox.Show(this, "对不起，您尚未登录，无法进行添加笔记操作，请登录后再进行操作！");
                return;
            }
            if (string.IsNullOrEmpty(this.NotebookArea.Value))
            {
                Maticsoft.Common.MessageBox.Show(this, "请输入笔记内容！");
                return;
            }
            if (!string.IsNullOrEmpty(this.labNID.Text))
            {
                int nid = int.Parse(labNID.Text);
                Model.Tao.CourseNotes model = courseNotesBLL.GetModel(nid);
                model.Contents = this.NotebookArea.Value;
                if (courseNotesBLL.Update(model))
                {
                    ShowCourseNotes(CurrentUser.UserID, int.Parse(this.hfCourseID.Value), int.Parse(this.hfModuleID.Value));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
                {
                    Model.Tao.CourseNotes model = new Model.Tao.CourseNotes();
                    model.CourseID = int.Parse(this.hfCourseID.Value);
                    model.ModuleID = courseModuleBLL.GetFirstModuleID(int.Parse(this.hfCourseID.Value));
                    if (!string.IsNullOrEmpty(this.hfModuleID.Value) && PageValidate.IsNumber(this.hfModuleID.Value))
                    {
                        model.ModuleID = int.Parse(this.hfModuleID.Value);
                    }
                    model.Contents = this.NotebookArea.Value;
                    model.Updatetime = DateTime.Now;
                    model.UserID = CurrentUser.UserID;
                    if (courseNotesBLL.Add(model) > 0)
                    {
                        ShowCourseNotes(CurrentUser.UserID, int.Parse(this.hfCourseID.Value), int.Parse(this.hfModuleID.Value));
                    }
                }
            }
            this.labNID.Text = string.Empty;
            this.NotebookArea.Value = string.Empty;
        }

        #endregion 用户笔记
    }
}