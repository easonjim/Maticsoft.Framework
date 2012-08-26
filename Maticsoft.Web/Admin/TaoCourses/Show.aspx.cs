using System;
using System.Web.UI;

namespace Maticsoft.Web.Admin.TaoCourses
{
    public partial class Show : PageBaseAdmin
    {
        private BLL.Tao.Courses CoursesBLL = new BLL.Tao.Courses();
        private BLL.Tao.Categories CategoriesBLL = new BLL.Tao.Categories();
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["CourseID"]))
                {
                    strid = Request.Params["CourseID"];
                    int CourseID = (Convert.ToInt32(strid));
                    ShowInfo(CourseID);
                }
            }
        }

        private void ShowInfo(int CourseID)
        {
            Model.Tao.Courses model = CoursesBLL.GetModel(CourseID);

            if (null != model)
            {
                this.lblCourseID.Text = model.CourseID.ToString();
                this.lblCourseName.Text = model.CourseName;
                this.ltlContent.Text = model.Description;
                this.ltlShortDescription.Text = model.ShortDescription;
                if (null != model.CategoryId)
                {
                    this.lblCategoryId.Text = CategoriesBLL.GetCateNameById(model.CategoryId.Value);
                }
                if (null != model.TimeDuration)
                {
                    this.lblTimeDuration.Text = model.TimeDuration.ToString();
                }
                if (null != model.ExpiryDate)
                {
                    this.lblExpiryDate.Text = model.ExpiryDate.ToString();
                }
                this.lblStatus.Text = GetCourseStatus(model.Status);
                this.lblTags.Text = model.Tags;
                this.imgImageUrl.ImageUrl = model.ImageUrl;
                if (null != model.CreatedDate)
                {
                    this.lblCreatedDate.Text = model.CreatedDate.ToString();
                }
                this.lblCreatedUserID.Text = GetUserName(model.CreatedUserID);
                this.lblRecommended.Text = GetboolText(model.Recommended);
                this.lblLatest.Text = GetboolText(model.Latest);
                this.lblHotsale.Text = GetboolText(model.Hotsale);
                this.lblSpecialOffer.Text = GetboolText(model.SpecialOffer);

                this.lblPrice.Text = model.Price.ToString();
                if (null != model.PV)
                {
                    this.lblPV.Text = model.PV.ToString();
                }
                if (null != model.SalesVolume)
                {
                    this.lblSalesVolume.Text = model.SalesVolume.ToString();
                }
                if (null != model.Sequence)
                {
                    this.lblSequence.Text = model.Sequence.ToString();
                }
                if (null != model.ModuleNum)
                {
                    this.lblModuleNum.Text = model.ModuleNum.ToString();
                }
                if (null != model.UpdatedDate)
                {
                    this.lblUpdatedDate.Text = model.UpdatedDate.ToString();
                }
            }
        }
    }
}