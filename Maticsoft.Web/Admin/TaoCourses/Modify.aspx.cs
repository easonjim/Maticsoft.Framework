using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.Common.Video;

namespace Maticsoft.Web.Admin.TaoCourses
{
    public partial class Modify : PageBaseAdmin
    {
        private VideoSpider VideoSpiderBLL = new VideoSpider();
        private BLL.Tao.Courses bll = new BLL.Tao.Courses();
        public string strImgUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["CourseID"]))
                {
                    BiudTree();
                    int CourseID = Convert.ToInt32(Request.Params["CourseID"]);
                    this.hfCourseID.Value = Request.Params["CourseID"];
                    ShowInfo(CourseID);
                }
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Maticsoft.Web.Admin.TaoCourses.Modify));
        }

        private void ShowInfo(int CourseID)
        {
            Model.Tao.Courses model = bll.GetModel(CourseID);
            if (null != model)
            {
                this.txtCourseName.Text = model.CourseName;
                if (model.CategoryId.HasValue)
                {
                    this.listTarget.SelectedValue = model.CategoryId.Value.ToString();
                }
                this.txtShortDescription.Text = model.ShortDescription;
                this.txtContent.Text = model.Description;
                if (model.ModuleNum.HasValue)
                {
                    this.txtModuleCount.Text = model.ModuleNum.ToString();
                }

                if (model.TimeDuration.HasValue)
                {
                    TimeSpan tss = new TimeSpan(0, 0, model.TimeDuration.Value);
                    this.txtTimeHour.Value = tss.Hours.ToString();
                    this.txtMinute.Value = tss.Minutes.ToString();
                    this.txtSeconds.Value = tss.Seconds.ToString();
                }
                if (model.ExpiryDate.HasValue)
                {
                    this.txtExpiryDate.Text = model.ExpiryDate.ToString();
                }
                if (model.Status.HasValue)
                {
                    this.ddlStatus.SelectedValue = GetCourseStatus(model.Status);
                }
                this.txtTags.Text = model.Tags;

                if (model.CreatedUserID.HasValue)
                {
                    this.lblCreatedUserID.Text = GetUserName(model.CreatedUserID);
                    this.hfCreatedUserID.Value = model.CreatedUserID.ToString();
                }

                if (model.Recommended.HasValue)
                {
                    if (model.Recommended.Value)
                    {
                        rbRec.Checked = true;
                    }
                    else
                    {
                        rbNoREc.Checked = true;
                    }
                }
                if (model.Latest.HasValue)
                {
                    if (model.Latest.Value)
                    {
                        rbNew.Checked = true;
                    }
                    else
                    {
                        rbNo.Checked = true;
                    }
                }
                if (model.Hotsale.HasValue)
                {
                    if (model.Hotsale.Value)
                    {
                        rbHot.Checked = true;
                    }
                    else
                    {
                        rbNormal.Checked = true;
                    }
                }
                if (model.SpecialOffer.HasValue)
                {
                    if (model.SpecialOffer.Value)
                    {
                        rbCheap.Checked = true;
                    }
                    else
                    {
                        rbN.Checked = true;
                    }
                }
                if (model.Price.HasValue)
                {
                    this.txtPrince.Text = model.Price.ToString();
                }
                if (model.Sequence.HasValue)
                {
                    this.txtOrder.Text = model.Sequence.Value.ToString();
                }
                strImgUrl = GetImage(model.ImageUrl, 45, 45);
                this.hfImgUrl.Value = model.ImageUrl;
                if (null != model.Status)
                {
                    this.ddlStatus.SelectedValue = model.Status.ToString();
                }

                if (model.ViewCount.HasValue)
                {
                    this.hfViewCount.Value = model.ViewCount.ToString();
                }
                if (model.PV.HasValue)
                {
                    this.hfPV.Value = model.PV.ToString();
                }
                if (model.CourseSpan.HasValue)
                {
                    this.hfCourseSpan.Value = model.CourseSpan.ToString();
                }
                if (model.CourseTypes.HasValue)
                {
                    this.hfCourseSpan.Value = model.CourseTypes.ToString();
                }
                if (model.CreatedDate.HasValue)
                {
                    this.hfCreatedDate.Value = model.CreatedDate.ToString();
                }
            }
        }

        #region DropDpwnListTree

        private void BiudTree()
        {
            BLL.Tao.Categories CateBll = new BLL.Tao.Categories();
            DataTable dt = CateBll.GetList("").Tables[0];

            this.listTarget.Items.Clear();
            //加载树
            this.listTarget.Items.Add(new ListItem("  ", "0"));
            DataRow[] drs = dt.Select("ParentCategoryId= " + 0);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryId"].ToString();
                string text = r["Name"].ToString();
                text = "╋" + text;
                this.listTarget.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";
                BindNode(sonparentid, dt, blank);
            }
            this.listTarget.DataBind();
        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentCategoryId= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryId"].ToString();
                string text = r["Name"].ToString();
                text = blank + "『" + text + "』";

                this.listTarget.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }

        #endregion DropDpwnListTree

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (!PageValidate.IsDateTime(txtExpiryDate.Text))
            {
                strErr += "有效期格式错误！\\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            Model.Tao.Courses CourseModel = new Model.Tao.Courses();

            CourseModel.CourseID = Convert.ToInt32(hfCourseID.Value);
            CourseModel.CourseName = this.txtCourseName.Text;
            CourseModel.ShortDescription = this.txtShortDescription.Text;
            CourseModel.Description = this.txtContent.Text;
            CourseModel.ImageUrl = UploadImage(fileImageUrl, 2);
            if (string.IsNullOrEmpty(CourseModel.ImageUrl))
            {
                CourseModel.ImageUrl = hfImgUrl.Value;
            }
            CourseModel.CategoryId = Convert.ToInt32(this.listTarget.SelectedValue);
            CourseModel.ModuleNum = Convert.ToInt32(this.txtModuleCount.Text);
            CourseModel.TimeDuration = BLL.ConvertTime.TimeToSecond(int.Parse(txtTimeHour.Value), int.Parse(txtMinute.Value), int.Parse(txtSeconds.Value));
            CourseModel.ExpiryDate = Convert.ToDateTime(this.txtExpiryDate.Text);
            CourseModel.Tags = this.txtTags.Text;
            CourseModel.Status = Convert.ToInt32(this.ddlStatus.SelectedValue);
            CourseModel.Recommended = rbRec.Checked ? true : false;
            CourseModel.SpecialOffer = rbCheap.Checked ? true : false;
            CourseModel.Hotsale = rbHot.Checked ? true : false;
            CourseModel.Latest = rbNew.Checked ? true : false;
            if (!string.IsNullOrEmpty(txtPrince.Text))
            {
                if (PageValidate.IsDecimal(txtPrince.Text) || PageValidate.IsNumber(txtPrince.Text))
                {
                    CourseModel.Price = Convert.ToDecimal(this.txtPrince.Text);
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "输入格式不正确！");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtOrder.Text))
            {
                if (PageValidate.IsNumber(txtOrder.Text))
                {
                    CourseModel.Sequence = Convert.ToInt32(this.txtOrder.Text);
                }
            }
            if (!string.IsNullOrEmpty(hfCreatedUserID.Value))
            {
                if (PageValidate.IsNumber(hfCreatedUserID.Value))
                {
                    CourseModel.CreatedUserID = Convert.ToInt32(hfCreatedUserID.Value);
                }
            }
            if (!string.IsNullOrEmpty(hfViewCount.Value))
            {
                if (PageValidate.IsNumber(hfViewCount.Value))
                {
                    CourseModel.ViewCount = Convert.ToInt32(hfViewCount.Value);
                }
            }
            if (!string.IsNullOrEmpty(hfCourseSpan.Value))
            {
                if (PageValidate.IsNumber(hfCourseSpan.Value))
                {
                    CourseModel.CourseSpan = Convert.ToInt32(hfCourseSpan.Value);
                }
            }
            if (!string.IsNullOrEmpty(hfPV.Value))
            {
                if (PageValidate.IsNumber(hfPV.Value))
                {
                    CourseModel.PV = Convert.ToInt32(hfPV.Value);
                }
            }
            if (!string.IsNullOrEmpty(hfCourseTypes.Value))
            {
                if (PageValidate.IsNumber(hfCourseTypes.Value))
                {
                    CourseModel.CourseTypes = Convert.ToInt32(hfCourseTypes.Value);
                }
            }
            if (!string.IsNullOrEmpty(hfCreatedDate.Value))
            {
                if (PageValidate.IsDateTime(hfCreatedDate.Value))
                {
                    CourseModel.CreatedDate = Convert.ToDateTime(hfCreatedDate.Value);
                }
            }
            bll.Update(CourseModel);
            Response.Redirect("list.aspx");
        }

        [AjaxPro.AjaxMethod]
        public void DeleteIco(int CourseId)
        {
            Model.Tao.Courses Val = bll.GetModel(CourseId);
            if (null != Val)
            {
                if (Val.Attachment != null)
                {
                    HiUploader.DeleteImage(Val.Attachment);
                    bll.UpdateAttachUrl(CourseId);
                }
            }
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}