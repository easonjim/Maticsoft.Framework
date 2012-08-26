using System;
using System.Web.UI;

namespace Maticsoft.Web.PubCourse
{
    public partial class OrganizeCourse : PageBaseUser
    {
        private BLL.Tao.Courses CourseBll = new BLL.Tao.Courses();
        private BLL.Tao.Categories CategoriesBll = new BLL.Tao.Categories();
        private BLL.Tao.OffLineCourse bll = new BLL.Tao.OffLineCourse();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["courseId"]))
                {
                    this.hfCourseId.Value = Request.Params["courseId"];
                }
                else
                {
                    this.btnModify.Visible = false;
                }

                InitData();
            }
        }

        private void InitData()
        {
            if (!string.IsNullOrEmpty(this.hfCourseId.Value))
            {
                this.btnNext.Visible = false;

                Model.Tao.OffLineCourse model = bll.GetModel(int.Parse(this.hfCourseId.Value));
                if (model == null)
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "没有找到你要修改的课程信息！");
                    return;
                }
                this.txtTitle.Text = model.CourseName;
                this.txtStartTime.Value = model.StartTime.ToString("yyyy-MM-dd");
                this.txtEndTime.Value = model.EndTime.ToString("yyyy-MM-dd");
                this.txtDec.Value = model.Description;
                this.txtTag.Value = model.Tags;
                this.txtAddress.Value = model.Address;
                this.txtCoursePrice.Value = model.CoursePrice.ToString("0.00");
                this.Categories2.CateId = model.CategoryId;
                this.hfTypes.Value = model.CategoryId.ToString();
                this.RegionAjax1.Area_iID = model.RegionID;
                this.RegionAjax1.SelectedValue = model.RegionID.ToString();
                this.imgURL.Src = model.ImageURL;
                this.HiddenField_ICOPath.Value = model.ImageURL;
            }
        }

        private void SaveRes(bool type)
        {
            this.btnNext.Enabled = false;
            this.btnModify.Enabled = false;
            if (string.IsNullOrEmpty(this.hfTypes.Value) && string.IsNullOrEmpty(this.hfty1.Value))
            {
                Common.MessageBox.ShowFailTip(this, "请选择课程分类！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtTitle.Text.Trim()))
            {
                Common.MessageBox.ShowFailTip(this, "请输入课程名称！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtStartTime.Value.Trim()) || string.IsNullOrEmpty(this.txtEndTime.Value.Trim()))
            {
                Common.MessageBox.ShowFailTip(this, "请选择开课日期！");
                return;
            }
            if (!Common.PageValidate.IsNumber(this.txtCoursePrice.Value) && !Common.PageValidate.IsDecimal(this.txtCoursePrice.Value))
            {
                Common.MessageBox.ShowFailTip(this, "请输入正确的价格！");
                return;
            }
            if (string.IsNullOrEmpty(this.RegionAjax1.SelectedValue))
            {
                Common.MessageBox.ShowFailTip(this, "请选择开课地点！");
                return;
            }
            Model.Tao.OffLineCourse model = null;

            if (type)
            {
                model = bll.GetModel(int.Parse(hfCourseId.Value));
            }
            else
            {
                model = new Model.Tao.OffLineCourse();
            }
            model.CourseName = this.txtTitle.Text;
            model.Description = this.txtDec.Value;
            if (!string.IsNullOrEmpty(this.hfTypes.Value))
            {
                model.CategoryId = int.Parse(this.hfTypes.Value);
            }
            else
            {
                model.CategoryId = int.Parse(this.hfty1.Value);
            }
            model.CreatedUserID = CurrentUser.UserID;
            model.ImageURL = this.HiddenField_ICOPath.Value;
            model.RegionID = int.Parse(this.RegionAjax1.SelectedValue);
            model.Address = this.txtAddress.Value;
            model.Tags = this.txtTag.Value;
            model.TimeSpan = "";
            model.StartTime = Convert.ToDateTime(this.txtStartTime.Value);
            model.EndTime = Convert.ToDateTime(this.txtEndTime.Value);
            model.CoursePrice = decimal.Parse(this.txtCoursePrice.Value);

            if (type)
            {
                int courseId = int.Parse(hfCourseId.Value);
                model.CourseID = courseId;
                model.UpdatedDate = DateTime.Now;
                if (bll.Update(model))
                {
                    Response.Redirect("OffLineTeacherInfo.aspx?CourseId=" + courseId + "&ReturnUrl=" + Request.Url.ToString());
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "课程信息修改失败！");
                    return;
                }
            }
            else
            {
                int CourseId = bll.Add(model);
                if (CourseId > 0)
                {
                    Response.Redirect("OffLineTeacherInfo.aspx?CourseId=" + CourseId + "&ReturnUrl=" + Request.Url.ToString());
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "课程信息保存失败！");
                    return;
                }
            }

            //Model.Tao.Courses CourseModel = new Model.Tao.Courses();
            //CourseModel.CourseName = this.txtTitle.Text;
            //if (!string.IsNullOrEmpty(this.hfTypes.Value))
            //{
            //    CourseModel.CategoryId = int.Parse(this.hfTypes.Value);
            //}
            //else
            //{
            //    CourseModel.CategoryId = int.Parse(this.hfty1.Value);
            //}
            //CourseModel.CreatedDate = DateTime.Now;
            //CourseModel.CreatedUserID = CurrentUser.UserID;
            //CourseModel.ShortDescription = this.txtDec.Value;
            //CourseModel.UpdatedDate = DateTime.Now;
            //CourseModel.Tags = this.txtTag.Value;
            //CourseModel.CourseTypes = 1;//组织课程
            //CourseModel.Status = 0;
            //CourseModel.Price = Convert.ToDecimal(this.txtCoursePrice.Value);

            //if (type)
            //{
            //    int courseId = int.Parse(hfCourseId.Value);
            //    CourseModel.CourseID = courseId;
            //    if (CourseBll.updateOrgCourse(CourseModel))
            //    {
            //        Response.Redirect("OrganizeCourseList.aspx?CourseId=" + courseId + "&ReturnUrl=" + Request.Url.ToString());
            //    }
            //    else
            //    {
            //        Maticsoft.Common.MessageBox.Show(this, "课程信息修改失败！");
            //    }
            //}
            //else
            //{
            //    int CourseId = CourseBll.Add(CourseModel);
            //    if (CourseId > 0)
            //    {
            //        Response.Redirect("OrganizeCourseList.aspx?CourseId=" + CourseId + "&ReturnUrl=" + Request.Url.ToString());
            //    }
            //    else
            //    {
            //        Maticsoft.Common.MessageBox.Show(this, "课程信息保存失败！");
            //    }
            //}
        }

        protected void btnModify_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hfCourseId.Value))
            {
                Model.Tao.Courses model = CourseBll.GetModel(int.Parse(this.hfCourseId.Value));
                if (model != null)
                {
                    SaveRes(true);
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "没有找到你要修改的课程信息！");
                }
            }
        }

        public string GetCateInfo(int cateId)
        {
            Model.Tao.Categories model = CategoriesBll.GetModel(cateId);
            System.Text.StringBuilder cateStrBuilder = new System.Text.StringBuilder();
            if (model == null)
            {
                return "";
            }
            string[] cateArr = model.Path.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cateArr.Length; i++)
            {
                int cid = int.Parse(cateArr[i]);
                Model.Tao.Categories models = CategoriesBll.GetModel(cid);
                cateStrBuilder.Append(models.Name + "&nbsp;>");
            }
            return cateStrBuilder.Remove(cateStrBuilder.Length - 7, 7).ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            SaveRes(false);
        }
    }
}