using System;

namespace Maticsoft.Web.PubCourse
{
    public partial class TeacherInfo : PageBaseUser
    {
        private BLL.UserExp.UsersExp UserBll = new BLL.UserExp.UsersExp();
        private int CourseId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["CourseId"]))
            {
                string courseStr = Request.QueryString["CourseId"];
                CourseId = int.Parse(courseStr);
                this.hfCourseID.Value = courseStr;
            }
            else
            {
                Maticsoft.Common.MessageBox.ResponseScript(this, "alert('请先填写课程信息！');history.back()");
            }

            if (!IsPostBack)
            {
                this.hfRuturnUrl.Value = Request.Url.ToString();
                BindSource();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPubCourse.aspx?CourseId=" + CourseId);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            SaveInfo(true);
        }

        private void BindSource()
        {
            System.Data.DataSet ds = UserBll.GetUserExpModel(CurrentUser.UserID);
            System.Data.DataTable dt = ds.Tables[0];
            Model.UserExp.UsersExp expModel = UserBll.GetModel(CurrentUser.UserID);
            if (dt != null && dt.Rows.Count > 0)
            {
                System.Data.DataRow dr = dt.Rows[0];
                this.txtName.Text = dr["TrueName"].ToString();
                object userAvatar = dr["UserAvatar"];
                if (userAvatar != null)
                {
                    if (userAvatar.ToString() != "")
                    {
                        this.imgLogo.Src = dr["UserAvatar"].ToString();
                        this.HiddenField_ICOPath.Value = dr["UserAvatar"].ToString();
                    }
                }
                else
                {
                    this.imgLogo.Src = "/Images/tx.gif";
                }
            }

            this.txtDepartmentName.Value = "个人";
            BLL.Tao.Enterprise enterBll = new BLL.Tao.Enterprise();
            Model.Tao.Enterprise enterModel = enterBll.GetModelByDepartmentID(int.Parse(CurrentUser.DepartmentID));
            if (enterModel != null)
            {
                if (enterModel.Status.HasValue && enterModel.Status.Value.Equals(1))
                {
                    this.txtDepartmentName.Value = enterModel.Name;
                }
            }
            this.txtDec.Value = expModel.TeachDescription;
        }

        private void SaveInfo(bool type)
        {
            string TrueName = this.txtName.Text;//教师名称
            string TeachDec = this.txtDec.Value;//教师简介------注意替换HTML标签和JS脚本
            if (UserBll.EditUesInfo(TrueName, TeachDec, CurrentUser.UserID, this.txtDepartmentName.Value))
            {
                UserBll.UpdateTeacherAc(this.HiddenField_ICOPath.Value, CurrentUser.UserID);
                CurrentUser = new Maticsoft.Accounts.Bus.User(CurrentUser.UserID);
                Session["UserInfo"] = CurrentUser;
                if (type)
                {
                    Response.Redirect("UploadCourse.aspx?CourseId=" + CourseId);
                }
                else
                {
                    Response.Redirect("/PublishCourse/TeacherAvatarEdit.aspx?CourseId=" + this.hfCourseID.Value + "&ReturnUrl=" + this.hfRuturnUrl.Value);
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "教师信息保存失败！");
            }
        }
    }
}