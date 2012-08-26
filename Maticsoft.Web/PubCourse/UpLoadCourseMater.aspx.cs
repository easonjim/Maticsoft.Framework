using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.PubCourse
{
    public partial class UpLoadCourseMater : PageBaseUser
    {
        public string strCourseId = string.Empty;
        private string uploadFile = Maticsoft.Common.ConfigHelper.GetConfigString("CoursePath");
        private BLL.Tao.CourseMaterial courseMaterialBLL = new BLL.Tao.CourseMaterial();
        public string cancleStr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["CourseId"]) && PageValidate.IsNumber(Request.Params["CourseId"]))
                {
                    if (!string.IsNullOrEmpty(Request.Params["MaterialID"]) && PageValidate.IsNumber(Request.Params["MaterialID"]))
                    {
                        this.hfMaterialID.Value = Request.Params["MaterialID"];
                        cancleStr = "";
                    }
                    else
                    {
                        cancleStr = "display:none;";
                    }
                    strCourseId = hfCourseId.Value = Request.Params["CourseId"];
                    BindData();
                    ShowInfo();
                }
                else
                {
                    Maticsoft.Common.MessageBox.ResponseScript(this, "alert('请先上传视频信息！');history.back()");
                }
            }
            if (!string.IsNullOrEmpty(Request.Params["MaterialID"]) && PageValidate.IsNumber(Request.Params["MaterialID"]))
            {
                cancleStr = "";
            }
            else
            {
                cancleStr = "display:none;";
            }
        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(hfCourseId.Value) && PageValidate.IsNumber(hfCourseId.Value))
            {
                rpt.DataSource = courseMaterialBLL.GetCourseMaterialList(int.Parse(hfCourseId.Value), 0);
                rpt.DataBind();
            }
        }

        protected void btnUpload_Click(object sender, ImageClickEventArgs e)
        {
            if (!FileUpload1.HasFile && string.IsNullOrEmpty(this.hfMaterialURL.Value))
            {
                Maticsoft.Common.MessageBox.Show(this, "请先选择学习资料！");
                return;
            }
            if (!string.IsNullOrEmpty(hfCourseId.Value) && PageValidate.IsNumber(hfCourseId.Value))
            {
                Model.Tao.CourseMaterial model = new Model.Tao.CourseMaterial();
                model.CourseID = int.Parse(hfCourseId.Value);
                model.Materialname = this.txtMaterialName.Text;
                model.ModuleID = -1;
                model.Status = 0;
                if (!string.IsNullOrEmpty(hfMaterialID.Value) && PageValidate.IsNumber(hfMaterialID.Value))
                {
                    model.MaterialID = int.Parse(hfMaterialID.Value);
                    model.MaterialURL = this.hfMaterialURL.Value;
                    courseMaterialBLL.Update(model);
                    Response.Redirect("UpLoadCourseMater.aspx?CourseId=" + this.hfCourseId.Value);
                }
                else
                {
                    if (!string.IsNullOrEmpty(uploadFile))
                    {
                        uploadFile += CurrentUser.UserID.ToString() + "/" + hfCourseId.Value + "/CourseSource";
                        HttpPostedFile hpf = FileUpload1.PostedFile;

                        string outPath = string.Empty;
                        Common.FileUpLoad.uploadFileControl(hpf, uploadFile, "material", out outPath);
                        if (!string.IsNullOrEmpty(outPath))
                        {
                            model.MaterialURL = outPath;
                        }
                        else
                        {
                            Maticsoft.Common.MessageBox.Show(this, "资料格式不正确！");
                            return;
                        }
                        courseMaterialBLL.Add(model);
                    }
                }
                this.txtMaterialName.Text = "";
                BindData();
            }
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument.Equals("del"))
            {
                courseMaterialBLL.Delete(int.Parse(e.CommandName));
                BindData();
                this.hfMaterialURL.Value = string.Empty;
                this.hfMaterialID.Value = string.Empty;
                this.txtMaterialName.Text = string.Empty;
                cancleStr = "display:none;";
            }
        }

        private void ShowInfo()
        {
            if (!string.IsNullOrEmpty(hfMaterialID.Value) && PageValidate.IsNumber(hfMaterialID.Value))
            {
                Model.Tao.CourseMaterial model = courseMaterialBLL.GetModel(int.Parse(hfMaterialID.Value));
                if (null != model)
                {
                    this.txtMaterialName.Text = model.Materialname;
                    this.hfMaterialURL.Value = model.MaterialURL;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadCourse.aspx?CourseId=" + this.hfCourseId.Value);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoursePrice.aspx?CourseId=" + this.hfCourseId.Value);
        }
    }
}