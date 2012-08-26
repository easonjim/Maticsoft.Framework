using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.Common.Video;
using VideoEncoder;

namespace Maticsoft.Web.PubCourse
{
    public partial class UploadCourse : PageBaseUser
    {
        private string uploadFile = Maticsoft.Common.ConfigHelper.GetConfigString("CoursePath");
        public string strDivClass = string.Empty;
        private BLL.Tao.Modules ModulesBLL = new BLL.Tao.Modules();
        private BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        private BLL.Tao.Enterprise EnterpriseBLL = new BLL.Tao.Enterprise();
        private VideoSpider VideoSpiderBLL = new VideoSpider();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string courseStr = Request.QueryString["CourseId"];
                if (!string.IsNullOrEmpty(courseStr) && PageValidate.IsNumber(courseStr))
                {
                    this.hfCourseID.Value = courseStr;
                }
                else
                {
                    Maticsoft.Common.MessageBox.ResponseScript(this, "alert('请先填写教师简介！');history.back()");
                    return;
                }

                #region 初始化课程信息

                InitData();

                #endregion 初始化课程信息

                InitSelIndex();
                InitCourseInfo();
                CreateSeq();
            }
        }

        #region 课程信息

        private void InitData()
        {
            if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
            {
                int cid = int.Parse(this.hfCourseID.Value);
                Model.Tao.Courses course = courseBll.GetModel(int.Parse(this.hfCourseID.Value));
                if (course == null)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(course.ImageUrl))
                {
                    this.CourseThumbnai.Src = course.ImageUrl;
                }
                else
                {
                    this.CourseThumbnai.Src = "/Images/none.gif";
                }
                if (!string.IsNullOrEmpty(CurrentUser.DepartmentID))
                {
                    if (PageValidate.IsNumber(CurrentUser.DepartmentID))
                    {
                        Maticsoft.Model.Tao.Enterprise EnterpriseModel = EnterpriseBLL.GetModelByDepartmentID(int.Parse(CurrentUser.DepartmentID));
                        if (null != EnterpriseModel)
                        {
                            this.litDept.Text = EnterpriseModel.Name;
                        }
                    }
                }
                else
                {
                }

                int selType = BLL.Tao.Courses.GetUploadType(cid);
                if (selType.Equals(-1))
                {
                    this.radl.SelectedValue = "0";
                    divUrl.Visible = false;
                    divScript.Visible = false;
                }
                else if (selType.Equals(1))
                {
                    this.radl.SelectedValue = "1";
                    LocalUp.Visible = false;
                    divScript.Visible = false;
                } if (selType.Equals(2))
                {
                    this.radl.SelectedValue = "2";
                    divUrl.Visible = false;
                    LocalUp.Visible = false;
                }
                else
                {
                    this.radl.SelectedValue = "0";
                    divUrl.Visible = false;
                    divScript.Visible = false;
                }

                this.litCourseName.Text = StringPlus.strHtmlEncode(course.CourseName);
                this.litTeacherName.Text = CurrentUser.TrueName;
                this.hfRuturnUrl.Value = Request.Url.ToString();
            }
        }

        private void InitCourseInfo()
        {
            if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
            {
                int cid = int.Parse(this.hfCourseID.Value);
                DataSet ds = new DataSet();
                switch (radl.SelectedValue)
                {
                    case "0":
                        ds = rptLocal(cid, ds);
                        break;

                    case "1":
                        ds = rptUrl(cid, ds);
                        break;

                    case "2":
                        ds = rptHtml(cid, ds);
                        break;
                }
                CreateSeq();
            }
        }

        #endregion 课程信息

        #region 自动填写章节编号

        private void CreateSeq()
        {
            if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
            {
                int cid = int.Parse(this.hfCourseID.Value);
                switch (radl.SelectedValue)
                {
                    case "0":
                        int MaxSeq = ModulesBLL.GetMaxModuleSeq(cid, 0);
                        this.txtSequence.Value = (MaxSeq + 1).ToString();
                        break;

                    case "1":
                        int UrlMaxSeq = ModulesBLL.GetMaxModuleSeq(cid, 1);
                        this.txtUrlSeq.Value = (UrlMaxSeq + 1).ToString();
                        break;

                    case "2":
                        int HtmlMaxSeq = ModulesBLL.GetMaxModuleSeq(cid, 2);
                        this.txtCodeSeq.Value = (HtmlMaxSeq + 1).ToString();
                        break;
                }
            }
        }

        #endregion 自动填写章节编号

        #region 初始化选择类型

        private void InitSelIndex()
        {
            if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
            {
                int cid = int.Parse(this.hfCourseID.Value);
                DataSet ds = new DataSet();
                switch (radl.SelectedValue)
                {
                    case "0":
                        ds = rptLocal(cid, ds);
                        LocalUp.Visible = true;
                        divUrl.Visible = false;
                        divScript.Visible = false;
                        this.btnCancle.Visible = false;
                        break;

                    case "1":
                        ds = rptUrl(cid, ds);
                        LocalUp.Visible = false;
                        divUrl.Visible = true;
                        divScript.Visible = false;
                        break;

                    case "2":
                        ds = rptHtml(cid, ds);
                        LocalUp.Visible = false;
                        divUrl.Visible = false;
                        divScript.Visible = true;
                        break;
                }
            }
            CreateSeq();
        }

        private DataSet rptHtml(int cid, DataSet ds)
        {
            ds = ModulesBLL.GetModuleByCid(cid, 2, CurrentUser.UserID);
            if (ds != null)
            {
                this.Repeater1.DataSource = ds;
                this.Repeater1.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.txtCodeTitle.Value = "第 " + (ds.Tables[0].Rows.Count + 1) + " 节";
                }
                else
                {
                    this.txtCodeTitle.Value = "第 1 节";
                }
                DivHHeight();
            }
            return ds;
        }

        private DataSet rptUrl(int cid, DataSet ds)
        {
            ds = ModulesBLL.GetModuleByCid(cid, 1, CurrentUser.UserID);
            if (ds != null)
            {
                this.Repeater1.DataSource = ds;
                this.Repeater1.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.txtUrlMName.Value = "第 " + (ds.Tables[0].Rows.Count + 1) + " 节";
                }
                else
                {
                    this.txtUrlMName.Value = "第 1 节";
                }
                DivHHeight();
            }
            return ds;
        }

        private DataSet rptLocal(int cid, DataSet ds)
        {
            ds = ModulesBLL.GetModuleByCid(cid, 0, CurrentUser.UserID);
            if (ds != null)
            {
                this.Repeater1.DataSource = ds;
                this.Repeater1.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.txtMName.Value = "第 " + (ds.Tables[0].Rows.Count + 1) + " 节";
                }
                else
                {
                    this.txtMName.Value = "第 1 节";
                }
                DivHHeight();
            }
            return ds;
        }

        protected void radl_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSelIndex();
        }

        #endregion 初始化选择类型

        #region 本地视频上传

        protected void btnUp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
            {
                string serverPath = uploadFile + CurrentUser.UserID + "/" + this.hfCourseID.Value;
                string ext = "";
                int cid = int.Parse(this.hfCourseID.Value);
                if (!string.IsNullOrEmpty(hfMid.Value) && PageValidate.IsNumber(hfMid.Value))
                {
                    //修改视频信息
                    int mid = int.Parse(hfMid.Value);
                    Model.Tao.Modules ModfyModle = ModulesBLL.GetModel(mid);
                    ModfyModle.ModuleName = this.txtMName.Value;
                    //ModfyModle.Description = this.txtDescription.Value;
                    ModfyModle.Tags = txtTags.Value;
                    ModfyModle.Status = 0;
                    ModfyModle.Type = 0;
                    ModfyModle.Price = 0;
                    ModfyModle.UpdatedDate = DateTime.Now;
                    ModfyModle.Sequence = int.Parse(this.txtSequence.Value);
                    ModfyModle.ModuleID = mid;
                    if (fileVideoNew.FileName.Length > 0)
                    {
                        //重新上传视频
                        ext = Path.GetExtension(fileVideoNew.FileName);

                        if (ext.ToLower() != ".flv" && ext.ToLower() != ".swf" && ext.ToLower() != ".wmv" && ext.ToLower() != ".avi" && ext.ToLower() != ".mp4")
                        {
                            Maticsoft.Common.MessageBox.ShowFailTip(this, "上传的视频格式应为：flv,wmv,avi,mp4!"); return;
                        }
                        int size = fileVideoNew.PostedFile.ContentLength;
                        if (size > 1024 * 1024 * 50)
                        {
                            Maticsoft.Common.MessageBox.ShowFailTip(this, "上传的视频不能超过50M!"); return;
                        }

                        Random rd = new Random();
                        string fileName = Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture) + ext;//文件重命名_userId_CourseID
                        string pathStr = HttpContext.Current.Server.MapPath("/" + serverPath);
                        if (!System.IO.Directory.Exists(pathStr))
                        {
                            System.IO.Directory.CreateDirectory(pathStr);
                        }
                        string path = "/" + serverPath + "/" + fileName;
                        fileVideoNew.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(path));

                        serverPath = path;

                        ModfyModle.VideoContent = serverPath;
                        string VideoExt = Path.GetExtension(this.fileVideoNew.FileName);
                        string jpgFileName = Path.Combine(HttpContext.Current.Server.MapPath(serverPath), Path.ChangeExtension(serverPath, ".jpg"));
                        if (VideoExt.Equals(".flv") || VideoExt.Equals(".mp4") || VideoExt.Equals(".swf"))
                        {
                            //视频格式无需转换 直接可以播放 获取视频时间和截图
                            CreateThumb(HttpContext.Current.Server.MapPath(serverPath), HttpContext.Current.Server.MapPath(jpgFileName));
                            ModfyModle.ImageUrl = jpgFileName;
                            TimeSpan totalTime = getVodeotime(HttpContext.Current.Server.MapPath(serverPath));
                            int ts = BLL.ConvertTime.TimeToSecond(totalTime.Hours, totalTime.Minutes, totalTime.Seconds);
                            ModfyModle.TimeDuration = ts;
                            //更新上传的视频信息
                            ModulesBLL.UpDateLocalModule(ModfyModle, cid);
                            Maticsoft.Common.MessageBox.ShowSuccessTip(this, "修改成功！");
                        }
                        else
                        {
                            //视频需要格式转换
                            ModulesBLL.UpdateModuleExtInfo(ModfyModle, cid);
                            Maticsoft.Common.MessageBox.ShowSuccessTip(this, "修改成功！");
                        }
                    }
                    else
                    {
                        //保留原来的视频信息 只修改了 文字信息
                        ModulesBLL.Update(ModfyModle);
                        Maticsoft.Common.MessageBox.ShowSuccessTip(this, "修改成功！");
                    }
                }
                else
                {
                    //上传视频信息
                    Model.Tao.Modules ModuleModel = new Model.Tao.Modules();
                    ModuleModel.ModuleName = this.txtMName.Value;
                    ModuleModel.CreatedDate = DateTime.Now;
                    //ModuleModel.Description = this.txtDescription.Value;
                    ModuleModel.Tags = txtTags.Value;
                    ModuleModel.Status = 0;
                    ModuleModel.Type = 0;
                    ModuleModel.Price = 0;
                    ModuleModel.UpdatedDate = DateTime.Now;
                    ModuleModel.CreatedUserID = CurrentUser.UserID;
                    ModuleModel.Sequence = int.Parse(this.txtSequence.Value);

                    if (fileVideoNew.FileName.Length > 0)
                    {
                        ext = Path.GetExtension(fileVideoNew.FileName);

                        if (ext.ToLower() != ".flv" && ext.ToLower() != ".swf" && ext.ToLower() != ".wmv" && ext.ToLower() != ".avi" && ext.ToLower() != ".mp4")
                        {
                            Maticsoft.Common.MessageBox.ShowFailTip(this, "上传的视频格式应为：flv,wmv,avi,mp4!"); return;
                        }
                        int size = fileVideoNew.PostedFile.ContentLength;
                        if (size > 1024 * 1024 * 50)
                        {
                            Maticsoft.Common.MessageBox.ShowFailTip(this, "上传的视频不能超过50M!"); return;
                        }

                        Random rd = new Random();
                        string fileName = Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture) + ext;//文件重命名_userId_CourseID
                        string pathStr = HttpContext.Current.Server.MapPath("/" + serverPath);
                        if (!System.IO.Directory.Exists(pathStr))
                        {
                            System.IO.Directory.CreateDirectory(pathStr);
                        }
                        string path = "/" + serverPath + "/" + fileName;
                        fileVideoNew.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(path));

                        serverPath = path;
                    }
                    else
                    {
                        return;
                    }
                    ModuleModel.VideoContent = serverPath;
                    string VideoExt = Path.GetExtension(this.fileVideoNew.FileName);
                    string jpgFileName = Path.Combine(HttpContext.Current.Server.MapPath(serverPath), Path.ChangeExtension(serverPath, ".jpg"));
                    if (VideoExt.Equals(".flv") || VideoExt.Equals(".mp4") || VideoExt.Equals(".swf"))
                    {
                        //视频格式无需转换 直接可以播放 获取视频时间和截图
                        CreateThumb(HttpContext.Current.Server.MapPath(serverPath), HttpContext.Current.Server.MapPath(jpgFileName));
                        ModuleModel.ImageUrl = jpgFileName;
                        TimeSpan totalTime = getVodeotime(HttpContext.Current.Server.MapPath(serverPath));
                        int ts = BLL.ConvertTime.TimeToSecond(totalTime.Hours, totalTime.Minutes, totalTime.Seconds);
                        ModuleModel.TimeDuration = ts;

                        ModulesBLL.CreateNewModule(ModuleModel, cid);
                        ModuleCount(cid, ts);
                        Maticsoft.Common.MessageBox.ShowSuccessTip(this, "视频上传成功！");
                    }
                    else
                    {
                        //视频需要格式转换
                        ModulesBLL.CreateModuleExtInfo(ModuleModel, cid);
                        ModuleCount(cid, 0);
                        Maticsoft.Common.MessageBox.ShowSuccessTip(this, "视频上传成功！");
                    }
                }
                this.txtSequence.Value = (int.Parse(this.txtSequence.Value) + 1).ToString();
                this.txtMName.Value = string.Empty;
                //this.txtDescription.Value = string.Empty;
                this.hfChoseCourse.Value = string.Empty;
                this.txtTags.Value = string.Empty;
                this.hfMid.Value = string.Empty;
                this.labOldVideo.Value = string.Empty;
                this.btnUp.Text = "上传";
                InitCourseInfo();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label labMid = e.Item.FindControl("labModuleID") as Label;
            Label labCid = e.Item.FindControl("labCourseID") as Label;
            Label labSeq = e.Item.FindControl("labSeq") as Label;
            Label labDesc = e.Item.FindControl("labDesc") as Label;
            Label labVideo = e.Item.FindControl("labVideo") as Label;
            Label labTime = e.Item.FindControl("labTime") as Label;
            Label labTags = e.Item.FindControl("labTags") as Label;
            Label labModuleName = e.Item.FindControl("labModuleName") as Label;
            if (e.CommandArgument.Equals("btndel"))
            {
                if (labMid != null && labCid != null)
                {
                    if (!string.IsNullOrEmpty(labCid.Text) && !string.IsNullOrEmpty(labMid.Text))
                    {
                        int mid = int.Parse(labMid.Text);
                        int cid = int.Parse(labCid.Text);

                        if (ModulesBLL.DeleteModuleInfo(cid, mid))
                        {
                            Maticsoft.Common.MessageBox.ShowSuccessTip(this, "删除成功！");
                            InitSelIndex();
                        }
                        else
                        {
                            Maticsoft.Common.MessageBox.ShowFailTip(this, "删除失败！");
                        }
                    }
                }
            }
            if (e.CommandArgument.Equals("btnedit"))
            {
                if (labMid != null && labCid != null && labSeq != null && labDesc != null && labVideo != null && labTime != null && labTags != null)
                {
                    if (!string.IsNullOrEmpty(labCid.Text) && !string.IsNullOrEmpty(labMid.Text))
                    {
                        switch (radl.SelectedValue)
                        {
                            case "0":
                                this.txtMName.Value = labModuleName.Text;
                                this.txtSequence.Value = labSeq.Text;
                                this.txtTags.Value = labTags.Text;
                                //this.txtDescription.Value = labDesc.Text;
                                this.hfMid.Value = labMid.Text;
                                this.labOldVideo.Value = labVideo.Text;
                                this.btnCancle.Visible = true;
                                this.btnUp.Text = "修改";
                                break;

                            case "1":
                                this.txtUrlSeq.Value = labSeq.Text;
                                //this.txtdesc.Value = labDesc.Text;
                                this.txtUrlMName.Value = labModuleName.Text;
                                this.txtUrlTags.Value = labTags.Text;
                                this.hfMid.Value = labMid.Text;
                                this.txtVideoContent.Value = labVideo.Text;
                                int totalSec = 0;
                                if (!string.IsNullOrEmpty(labTime.Text) && PageValidate.IsNumber(labTime.Text))
                                {
                                    totalSec = int.Parse(labTime.Text);
                                }
                                TimeSpan tss = new TimeSpan(0, 0, totalSec);
                                this.txtTimeHour.Value = tss.Hours.ToString();
                                this.txtMinute.Value = tss.Minutes.ToString();
                                this.txtSeconds.Value = tss.Seconds.ToString();
                                this.btnUrlSave.Text = "修改";
                                break;

                            case "2":
                                this.txtCodeSeq.Value = labSeq.Text;
                                this.txtCodeTitle.Value = labModuleName.Text;
                                //this.txtCodeDes.Value = labDesc.Text;
                                this.txtCodeTags.Value = labTags.Text;
                                this.txtHtmlCode.Value = labVideo.Text;
                                this.hfMid.Value = labMid.Text;
                                this.labHtmlMid.Text = labMid.Text;
                                int seconds = 0;
                                if (!string.IsNullOrEmpty(labTime.Text) && PageValidate.IsNumber(labTime.Text))
                                {
                                    seconds = int.Parse(labTime.Text);
                                }
                                TimeSpan ts = new TimeSpan(0, 0, seconds);
                                this.txtCodeHour.Value = ts.Hours.ToString();
                                this.txtCodeMinute.Value = ts.Minutes.ToString();
                                this.txtCodeSeconds.Value = ts.Seconds.ToString();
                                this.btnHtmlSave.Text = "修改";
                                break;
                        }
                    }
                }
            }
        }

        #endregion 本地视频上传

        #region 视频截取和获取视频时长

        /// <summary>
        /// 视频截图
        /// </summary>
        private void CreateThumb(string srcFileName, string jpgFileName)
        {
            //创建并启动一个新进程
            Process p = new Process();
            //设置进程启动信息属性StartInfo，这是ProcessStartInfo类，包括了一些属性和方法：
            p.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe";           //程序名
            p.StartInfo.UseShellExecute = false;
            //-y选项的意思是当输出文件存在的时候自动覆盖输出文件，不提示“y/n”这样才能自动化

            p.StartInfo.Arguments = "-i " + srcFileName + " -y -f mjpeg  -ss 2 -t 3 -s 598x520 " + jpgFileName;    //执行参数 截取第3秒图片
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;//把外部程序错误输出写到StandardError流中
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.Start();
            p.BeginErrorReadLine();//开始异步读取
            p.WaitForExit();//阻塞等待进程结束
            p.Close();//关闭进程
            p.Dispose();//释放资源
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e) { }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e) { }

        /// <summary>
        /// 获得视频总时长
        /// </summary>
        private TimeSpan getVodeotime(string videoPath)
        {
            VideoEncoder.Encoder enc = new VideoEncoder.Encoder();
            //ffmpeg.exe的路径，程序会在执行目录下找此文件，
            enc.FFmpegPath = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg.exe";
            //视频路径
            string videoFilePath = videoPath;
            VideoFile videoFile = new VideoFile(videoFilePath);

            enc.GetVideoInfo(videoFile);

            TimeSpan totaotp = videoFile.Duration;
            return totaotp;
        }

        #endregion 视频截取和获取视频时长

        #region 更新课程节数和总时间

        private void ModuleCount(int courseId, int totalTime)
        {
            int count = courseBll.getModelCount(courseId);
            courseBll.UpdateModuleCount(courseId, count, totalTime);
        }

        #endregion 更新课程节数和总时间

        #region 时间转换

        public string ConvertTimme(object time)
        {
            if (time != null)
            {
                if (!string.IsNullOrEmpty(time.ToString()))
                {
                    int timedur = int.Parse(time.ToString());
                    return BLL.ConvertTime.SecondToDateTime(timedur);
                }
                else
                {
                    return "未&nbsp;&nbsp;&nbsp;知";
                }
            }
            else
            {
                return "未&nbsp;&nbsp;&nbsp;知";
            }
        }

        #endregion 时间转换

        #region 样式控制

        private void DivHHeight()
        {
            if (Repeater1.Items.Count > 7)
            {
                strDivClass = "height:540px;overflow-y:auto;border:0px solid #7F9DB9;";
            }
            else
            {
                strDivClass = "height:auto;overflow-y:auto;border:0px solid #7F9DB9;";
            }
        }

        #endregion 样式控制

        protected void btnHtmlSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
            {
                int cid = int.Parse(this.hfCourseID.Value);

                if (!string.IsNullOrEmpty(labHtmlMid.Text) && PageValidate.IsNumber(labHtmlMid.Text))
                {
                    int mid = int.Parse(labHtmlMid.Text);
                    Model.Tao.Modules modleEdit = ModulesBLL.GetModel(mid);
                    modleEdit.Sequence = int.Parse(this.txtCodeSeq.Value);
                    modleEdit.ModuleName = this.txtCodeTitle.Value;
                    //modleEdit.Description = this.txtCodeDes.Value;
                    modleEdit.VideoContent = this.txtHtmlCode.Value;
                    modleEdit.Tags = this.txtCodeTags.Value;
                    string imageUrl = string.Empty;
                    string videoInfo = getHtmlscript(txtHtmlCode.Value);
                    getHtmlCode(videoInfo, out imageUrl);
                    if (!string.IsNullOrEmpty(videoInfo))
                    {
                        modleEdit.VideoContent = txtHtmlCode.Value;
                        VideoInfo info = VideoSpiderBLL.GetInfo(videoInfo);
                        if (null != info)
                        {
                            if (!string.IsNullOrEmpty(imageUrl))
                            {
                                modleEdit.ImageUrl = imageUrl;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(info.PicUrl))
                                {
                                    modleEdit.ImageUrl = info.PicUrl;
                                }
                                else
                                {
                                    modleEdit.ImageUrl = "static/img/novideopic.png";
                                }
                            }
                            if (!string.IsNullOrEmpty(info.Time))
                            {
                                modleEdit.TimeDuration = int.Parse(info.Time);
                            }
                            else
                            {
                                int totalSeconds = BLL.ConvertTime.TimeToSecond(int.Parse(txtCodeHour.Value), int.Parse(txtCodeMinute.Value), int.Parse(txtCodeSeconds.Value));
                                modleEdit.TimeDuration = totalSeconds;
                            }
                        }
                        ModulesBLL.UpDateLocalModule(modleEdit, cid);
                        Maticsoft.Common.MessageBox.ShowSuccessTip(this, "修改成功！");
                    }
                }
                else
                {
                    Model.Tao.Modules ModuleModel = new Model.Tao.Modules();
                    string Imgpath = string.Empty;
                    string contentStr1 = getHtmlscript(txtHtmlCode.Value);
                    getHtmlCode(contentStr1, out Imgpath);
                    if (!string.IsNullOrEmpty(contentStr1))
                    {
                        ModuleModel.VideoContent = txtHtmlCode.Value;
                        VideoInfo info = VideoSpiderBLL.GetInfo(contentStr1);
                        if (null != info)
                        {
                            if (!string.IsNullOrEmpty(Imgpath))
                            {
                                ModuleModel.ImageUrl = Imgpath;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(info.PicUrl))
                                {
                                    ModuleModel.ImageUrl = info.PicUrl;
                                }
                                else
                                {
                                    ModuleModel.ImageUrl = "static/img/novideopic.png";
                                }
                            }
                            if (!string.IsNullOrEmpty(info.Time))
                            {
                                ModuleModel.TimeDuration = int.Parse(info.Time);
                            }
                            else
                            {
                                int totalSeconds = BLL.ConvertTime.TimeToSecond(int.Parse(txtCodeHour.Value), int.Parse(txtCodeMinute.Value), int.Parse(txtCodeSeconds.Value));
                                ModuleModel.TimeDuration = totalSeconds;
                            }
                        }
                        ModuleModel.Sequence = int.Parse(this.txtCodeSeq.Value);
                        ModuleModel.Type = 2;
                        ModuleModel.ModuleName = this.txtCodeTitle.Value;
                        ModuleModel.Tags = this.txtCodeTags.Value;
                        //ModuleModel.Description = txtCodeDes.Value;
                        ModuleModel.CreatedUserID = CurrentUser.UserID;

                        ModulesBLL.CreateNewModule(ModuleModel, cid);
                        ModuleCount(cid, ModuleModel.TimeDuration.Value);
                        Maticsoft.Common.MessageBox.ShowSuccessTip(this, "保存成功！");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.ShowFailTip(this, "不是合法的视频脚本！");
                        this.btnBack.Visible = true;
                        return;
                    }
                }
                this.txtCodeSeq.Value = string.Empty;
                this.txtCodeTitle.Value = string.Empty;
                this.txtHtmlCode.Value = string.Empty;
                //this.txtCodeDes.Value = string.Empty;
                this.txtCodeHour.Value = "0";
                this.txtCodeMinute.Value = "0";
                this.txtCodeSeconds.Value = "0";
                this.txtCodeTags.Value = string.Empty;
                this.labHtmlMid.Text = string.Empty;
                this.btnHtmlSave.Text = "保存";
                InitCourseInfo();
            }
        }

        #region 视频地址的转换

        private string getHtmlCode(string HtmlUrl, out string KeyStr)
        {
            string regStr = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regStr, System.Text.RegularExpressions.RegexOptions.Singleline);
            System.Text.RegularExpressions.MatchCollection mc = regex.Matches(HtmlUrl);
            //是合法的Http 网址
            if (mc.Count > 0)
            {
                //判断是否是土豆、优酷、酷六中的一种
                if (HtmlUrl.Contains("youku") || HtmlUrl.Contains("ku6") || HtmlUrl.Contains("tudou"))
                {
                    KeyStr = "";
                    return HtmlUrl;
                }
                if (HtmlUrl.Contains("126") || HtmlUrl.Contains("163"))
                {
                    KeyStr = GetImg(HtmlUrl);
                    return HtmlUrl;
                }
                if (HtmlUrl.Contains("you.video.sina.com.cn/api/sinawebApi/outplayrefer.php"))
                {
                    KeyStr = "";
                    return HtmlUrl;
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "不是合法的视频地址！");
                    KeyStr = "";
                    return "";
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "不是合法的视频地址！");
                KeyStr = "";
                return "";
            }
        }

        private string GetImg(string url)
        {
            string regStr = @"http:.+?/snapshot_movie/(?<ScriptSrc>.*?)-.swf";
            string SwfKey = string.Empty;
            Regex regex = new System.Text.RegularExpressions.Regex(regStr, System.Text.RegularExpressions.RegexOptions.Singleline);
            MatchCollection mc = regex.Matches(url);
            //是合法的Http 网址
            if (mc.Count > 0)
            {
                foreach (Match match in mc)
                {
                    SwfKey = match.Groups["ScriptSrc"].Value;
                }
            }
            return "http://vimg1.ws.126.net//image/snapshot_movie/" + SwfKey + ".jpg";
        }

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

        #endregion 视频地址的转换

        protected void btnUrlSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hfCourseID.Value) && PageValidate.IsNumber(this.hfCourseID.Value))
            {
                int cid = int.Parse(this.hfCourseID.Value);
                Model.Tao.Modules modleManage = null;
                if (!string.IsNullOrEmpty(this.hfMid.Value) && PageValidate.IsNumber(this.hfMid.Value))
                {
                    //修改
                    int mid = int.Parse(this.hfMid.Value);
                    modleManage = ModulesBLL.GetModel(mid);
                    modleManage.Sequence = int.Parse(this.txtUrlSeq.Value);
                    modleManage.ModuleName = this.txtUrlMName.Value;
                    //modleManage.Description = this.txtdesc.Value;
                    modleManage.Tags = this.txtUrlTags.Value;
                    string EditIamge = string.Empty;
                    string ModfyVideo = getHtmlCode(this.txtVideoContent.Value, out EditIamge);
                    if (!string.IsNullOrEmpty(ModfyVideo))
                    {
                        modleManage.VideoContent = ModfyVideo;
                        VideoInfo info = VideoSpiderBLL.GetInfo(ModfyVideo);
                        if (null != info)
                        {
                            if (!string.IsNullOrEmpty(EditIamge))
                            {
                                modleManage.ImageUrl = EditIamge;
                            }
                            else if (!string.IsNullOrEmpty(info.PicUrl))
                            {
                                modleManage.ImageUrl = info.PicUrl;
                            }
                            else
                            {
                                modleManage.ImageUrl = "static/img/novideopic.png";
                            } if (!string.IsNullOrEmpty(info.Time))
                            {
                                modleManage.TimeDuration = int.Parse(info.Time);
                            }
                            else
                            {
                                int totalSeconds = BLL.ConvertTime.TimeToSecond(int.Parse(txtTimeHour.Value), int.Parse(txtMinute.Value), int.Parse(txtSeconds.Value));
                                modleManage.TimeDuration = totalSeconds;
                            }
                        }

                        ModulesBLL.UpDateLocalModule(modleManage, cid);
                        Maticsoft.Common.MessageBox.Show(this, "修改成功！");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.ShowFailTip(this, "不是合法的视频地址！");
                        this.btnBack.Visible = true;
                        return;
                    }
                }
                else
                {
                    //保存
                    modleManage = new Model.Tao.Modules();
                    modleManage.Sequence = int.Parse(this.txtUrlSeq.Value);
                    modleManage.ModuleName = this.txtUrlMName.Value;
                    //modleManage.Description = this.txtdesc.Value;
                    modleManage.Tags = this.txtUrlTags.Value;

                    string ImgStr = string.Empty;
                    string contentStr = getHtmlCode(this.txtVideoContent.Value, out ImgStr);
                    if (!string.IsNullOrEmpty(contentStr))
                    {
                        modleManage.VideoContent = contentStr;
                        VideoInfo info = VideoSpiderBLL.GetInfo(contentStr);
                        if (null != info)
                        {
                            if (!string.IsNullOrEmpty(ImgStr))
                            {
                                modleManage.ImageUrl = ImgStr;
                            }
                            else if (!string.IsNullOrEmpty(info.PicUrl))
                            {
                                modleManage.ImageUrl = info.PicUrl;
                            }
                            else
                            {
                                modleManage.ImageUrl = "static/img/novideopic.png";
                            } if (!string.IsNullOrEmpty(info.Time))
                            {
                                modleManage.TimeDuration = int.Parse(info.Time);
                            }
                            else
                            {
                                int totalSeconds = BLL.ConvertTime.TimeToSecond(int.Parse(txtTimeHour.Value), int.Parse(txtMinute.Value), int.Parse(txtSeconds.Value));
                                modleManage.TimeDuration = totalSeconds;
                            }
                        }
                        modleManage.CreatedUserID = CurrentUser.UserID;
                        modleManage.Type = 1;

                        ModulesBLL.CreateNewModule(modleManage, cid);
                        ModuleCount(cid, modleManage.TimeDuration.Value);
                        Maticsoft.Common.MessageBox.ShowSuccessTip(this, "保存成功！");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.ShowFailTip(this, "不是合法的视频地址！");
                        this.btnBack.Visible = true;
                        return;
                    }
                }
                this.txtUrlSeq.Value = string.Empty;
                this.txtUrlMName.Value = string.Empty;
                //this.txtdesc.Value = string.Empty;
                this.txtVideoContent.Value = string.Empty;
                this.txtUrlTags.Value = string.Empty;
                this.txtTimeHour.Value = "0";
                this.txtMinute.Value = "0";
                this.txtSeconds.Value = "0";
                this.hfMid.Value = string.Empty;
                this.btnUrlSave.Text = "保存";
                InitCourseInfo();
            }
        }

        protected void btnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (Repeater1.Items.Count <= 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirects(this, "请先填写视频信息！", "UpSingleCourse.aspx?CourseId=" + this.hfCourseID.Value);
            }
            else
            {
                Response.Redirect("StudyMaterial2.aspx?CourseId=" + this.hfCourseID.Value);
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("TeacherDescription.aspx?CourseId=" + this.hfCourseID.Value);
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            this.txtSequence.Value = (int.Parse(this.txtSequence.Value) + 1).ToString();
            this.txtMName.Value = string.Empty;
            //this.txtDescription.Value = string.Empty;
            this.hfChoseCourse.Value = string.Empty;
            this.txtTags.Value = string.Empty;
            this.hfMid.Value = string.Empty;
            this.labOldVideo.Value = string.Empty;
            this.btnUp.Text = "上传";
            this.btnCancle.Visible = false;
        }

        protected void btnNext_Click1(object sender, EventArgs e)
        {
            if (Repeater1.Items.Count <= 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirects(this, "请先填写视频信息！", "UpSingleCourse.aspx?CourseId=" + this.hfCourseID.Value);
            }
            else
            {
                Response.Redirect("UpLoadCourseMater.aspx?CourseId=" + this.hfCourseID.Value);
            }
        }
    }
}