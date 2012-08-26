using System;
using System.Web;

namespace Maticsoft.Web.PubCourse
{
    public partial class CourseAvatarEdit : PageBaseUser
    {
        private string uploadFolder = Maticsoft.Common.ConfigHelper.GetConfigString("CourseThumbnai");//获取课程缩略图保存的路径
        private int CourseId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["courseId"]))
            {
                CourseId = int.Parse(Request.QueryString["courseId"]);
            }
            if (!IsPostBack)
            {
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uploadFolder))
            {
                string savePath = uploadFolder;
                savePath += "/" + CurrentUser.UserID + "/" + CourseId;
                HttpPostedFile hpf = fuPhoto.PostedFile;
                string outPath = string.Empty;
                Common.FileUpLoad.uploadFileControl(hpf, savePath, "pic", out outPath);
                if (!string.IsNullOrEmpty(outPath))
                {
                    ImageDrag.ImageUrl = outPath;
                    ImageIcon.ImageUrl = outPath;
                }
                else
                {
                    //课程缩略图截取失败
                }
            }
            else
            {
                //保存路径为空 后台没有配置课程缩略图保存路径
            }
        }

        protected void btnUpdateGravatar_Click(object sender, EventArgs e)
        {
            BLL.Tao.Courses CourseBll = new BLL.Tao.Courses();
            int imageWidth = Int32.Parse(txt_width.Text);
            int imageHeight = Int32.Parse(txt_height.Text);
            int cutTop = Int32.Parse(txt_top.Text);
            int cutLeft = Int32.Parse(txt_left.Text);
            int dropWidth = Int32.Parse(txt_DropWidth.Text);
            int dropHeight = Int32.Parse(txt_DropHeight.Text);
            uploadFolder += "/" + CurrentUser.UserID + "/" + CourseId;
            string filename = Maticsoft.Common.CutPhotoHelp.SaveCutPic(Server.MapPath(ImageIcon.ImageUrl), Server.MapPath("/" + uploadFolder), 0, 0, dropWidth, dropHeight, cutLeft, cutTop, imageWidth, imageHeight);
            if (CourseId > 0)
            {
                Model.Tao.Courses CourseModle = new Model.Tao.Courses();
                CourseModle.ImageUrl = "/" + uploadFolder + "/" + filename;
                CourseModle.CourseID = CourseId;
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (CourseBll.EditCourseThumbnai(CourseModle))
                {
                    Response.Redirect(returnUrl);
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "课程图片上传失败！");
                    Response.Redirect(returnUrl);
                    return;
                }
            }
        }

        public void btnCancel_Click(object sender, EventArgs e)
        {
            string returnUrl = Request.QueryString["ReturnUrl"];
            Response.Redirect(returnUrl);
        }
    }
}