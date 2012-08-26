using System;
using System.Web;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserAvatarEdit : PageBaseUser
    {
        private string uploadFolder = string.Empty;//头像上传路径

        protected void Page_Load(object sender, EventArgs e)
        {
            uploadFolder = BLL.SysManage.ConfigSystem.GetValue("TestFile");//获得头像上传路径
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uploadFolder))
            {
                string savePath = uploadFolder;
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
                    //头像截取失败
                }
            }
            else
            {
                //保存路径为空 后台没有配置头像的保存路径
                Maticsoft.Common.MessageBox.ShowFailTip(this, "系统配置错误！");
                return;
            }
        }

        protected void btnUpdateGravatar_Click(object sender, EventArgs e)
        {
            BLL.UserExp.UsersExp UsersExpBLL = new BLL.UserExp.UsersExp();
            int imageWidth = Int32.Parse(txt_width.Text);
            int imageHeight = Int32.Parse(txt_height.Text);
            int cutTop = Int32.Parse(txt_top.Text);
            int cutLeft = Int32.Parse(txt_left.Text);
            int dropWidth = Int32.Parse(txt_DropWidth.Text);
            int dropHeight = Int32.Parse(txt_DropHeight.Text);
            string filename = Maticsoft.Common.CutPhotoHelp.SaveCutPic(Server.MapPath(ImageIcon.ImageUrl), Server.MapPath("/" + uploadFolder), 0, 0, dropWidth, dropHeight, cutLeft, cutTop, imageWidth, imageHeight);
            if (CurrentUser.UserID > 0)
            {
                Model.UserExp.UsersExp UsersExpModel = new Model.UserExp.UsersExp();

                UsersExpModel.UserAvatar = "/" + uploadFolder + "/" + filename;
                UsersExpModel.UserID = CurrentUser.UserID;
                if (UsersExpBLL.UpdateGravatar(UsersExpModel))
                {
                    //Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改头像成功！", "UserBaseInfo.aspx");
                    Response.Redirect("UserBaseInfo.aspx");
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "修改头像失败！");
                    return;
                }
            }
        }
    }
}