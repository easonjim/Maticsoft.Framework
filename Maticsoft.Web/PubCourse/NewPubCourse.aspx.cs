using System;

namespace Maticsoft.Web.PubCourse
{
    public partial class NewPubCourse : PageBaseUser
    {
        private BLL.Tao.Courses CourseBll = new BLL.Tao.Courses();
        private Model.Tao.Courses model = new Model.Tao.Courses();
        private int CourseId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["CourseId"]))
            {
                CourseId = int.Parse(Request.Params["CourseId"]);
            }
            if (!IsPostBack)
            {
                BoundData();
            }
            //BindUnFinshCourse();
        }

        private void BoundData()
        {
            if (CourseId.Equals(-1)) { return; }
            model = CourseBll.GetModel(CourseId);
            if (model == null)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "没有找到你要修改的课程信息！", "NewPubCourse.aspx");
                return;
            }
            if (!string.IsNullOrEmpty(model.CourseName))
            {
                this.txtTitle.Text = model.CourseName;
            }
            if (!string.IsNullOrEmpty(model.ShortDescription))
            {
                this.txtDec.Value = model.ShortDescription;
            }
            this.Categories1.CateId = model.CategoryId.Value;
            this.txtTag.Value = model.Tags;
            this.hfTypes.Value = model.CategoryId.ToString();
        }

        //private void BindUnFinshCourse()
        //{
        //    model = new Model.Tao.Courses();
        //    model.CreatedUserID = CurrentUser.UserID;
        //    model.Status = 0;
        //    model.CourseTypes = 0;
        //    System.Data.DataSet ds = CourseBll.PublishCourseInfo(model);
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        this.ErrorMsg.Visible = false;
        //        Session["courseId"] = CourseId;
        //        this.Repeater_CourseView.DataSource = ds;
        //        this.Repeater_CourseView.DataBind();
        //    }
        //    else
        //    {
        //        this.ErrorMsg.Visible = false;
        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strErr = string.Empty;
            if (string.IsNullOrEmpty(txtTitle.Text) || txtTitle.Text.Length < 1)
            {
                strErr += "课程标题不能为空!";
            }
            if (string.IsNullOrEmpty(txtDec.Value) || txtDec.Value.Length < 1)
            {
                strErr += "描述内容不能为空!";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            if (!CourseId.Equals(-1))
            {
                model = CourseBll.GetModel(CourseId);
            }
            model.CourseName = this.txtTitle.Text;
            if (!string.IsNullOrEmpty(this.hfTypes.Value))
            {
                model.CategoryId = int.Parse(this.hfTypes.Value);
            }
            else
            {
                model.CategoryId = int.Parse(this.hfty1.Value);
            }
            model.CreatedDate = DateTime.Now;
            model.CreatedUserID = CurrentUser.UserID;
            model.ShortDescription = this.txtDec.InnerText;
            model.UpdatedDate = DateTime.Now;
            model.Tags = this.txtTag.Value;
            model.CourseTypes = 0;
            model.Status = 0;
            if (CourseId != -1)
            {
                model.CourseID = CourseId;
                if (CourseBll.Update(model))
                {
                    Response.Redirect("TeacherInfo.aspx?CourseId=" + CourseId);
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "课程信息保存失败！");
                }
            }
            else
            {
                model.PV = 0;
                model.Sequence = 0;
                model.ModuleNum = 0;
                model.Recommended = false;
                model.Latest = false;
                model.Hotsale = false;
                model.SpecialOffer = false;
                int resCid = CourseBll.Add(model);

                if (resCid > 0)
                {
                    Response.Redirect("TeacherInfo.aspx?CourseId=" + resCid);
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "课程信息保存失败！");
                }
            }
        }
    }
}