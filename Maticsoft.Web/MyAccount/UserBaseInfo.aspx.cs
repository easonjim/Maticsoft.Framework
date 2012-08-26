using System;
using Maticsoft.Common;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserBaseInfo : PageBaseUser
    {
        private BLL.UserExp.UsersExp UserBll = new BLL.UserExp.UsersExp();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSource(CurrentUser.UserID);
            }
        }

        private void BindSource(int uid)
        {
            Model.UserExp.UsersExp model = UserBll.GetModel(uid);
            if (model != null)
            {
                this.txtTel.Value = CurrentUser.Phone;
                this.litEmail.Text = CurrentUser.Email;
                this.txtTrueName.Value = CurrentUser.TrueName;
                this.litUName.Text = CurrentUser.UserName;
                this.txthobby.Value = model.UserHobby;
                this.txtProfession.Value = model.UserCareer;
                if (model.Birthday != null)
                {
                    this.txtBir.Value = model.Birthday.Value.ToString("yyyy-MM-dd");
                }
                else
                    this.txtBir.Value = "";

                if (model.UserRegionID != null)
                {
                    this.RegionAjax1.Area_iID = model.UserRegionID.Value;
                    this.RegionAjax1.SelectedValue = model.UserRegionID.Value.ToString();
                }

                if (CurrentUser.Sex != null && CurrentUser.Sex.Trim() == "F")
                {
                    this.rbWomen.Checked = true;
                }
                else if (CurrentUser.Sex != null && CurrentUser.Sex.Trim() == "M")
                {
                    this.rbMan.Checked = true;
                }
                else
                {
                    this.rbSec.Checked = true;
                }
                if (!string.IsNullOrEmpty(model.UserAvatar))
                {
                    this.imgGravatar.Src = model.UserAvatar;
                }
                else
                {
                    this.imgGravatar.Src = "/Images/none.gif";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.UserExp.UsersExp UserExp = new Model.UserExp.UsersExp();
            string TrueName = this.txtTrueName.Value;
            string Phone = this.txtTel.Value;
            string sex = String.Empty;
            UserExp.UserHobby = this.txthobby.Value;
            UserExp.UserCareer = this.txtProfession.Value;
            UserExp.UserID = CurrentUser.UserID;
            if (this.rbMan.Checked)
            {
                sex = "M";
            }
            else if (this.rbWomen.Checked)
            {
                sex = "F";
            }
            else
            {
                sex = "S";
            }
            if (!string.IsNullOrEmpty(this.RegionAjax1.SelectedValue))
            {
                UserExp.UserRegionID = int.Parse(this.RegionAjax1.SelectedValue);
            }
            string strBir = this.txtBir.Value;
            if (!string.IsNullOrEmpty(strBir))
            {
                if (PageValidate.IsDateTime(strBir))
                {
                    UserExp.Birthday = DateTime.Parse(strBir);
                }
            }
            if (UserBll.UpDateUserInfo(TrueName, sex, Phone, UserExp) > 0)
            {
                Maticsoft.Common.MessageBox.ShowSuccessTip(this, "修改成功！");//, "/MyAccount/UserBaseInfo.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "修改失败！");
            }
        }
    }
}