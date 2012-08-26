using System;
using System.Data;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.PubCourse
{
    public partial class CoursePrice : PageBaseUser
    {
        private BLL.Tao.Modules moduleBll = new BLL.Tao.Modules();
        private Model.Tao.Courses courseModule = new Model.Tao.Courses();
        private BLL.Tao.Courses courseBll = new BLL.Tao.Courses();

        public string CourseName = "";
        public string TotalMoney = "";
        private string cStr = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 设置价格

            if (!string.IsNullOrEmpty(Request.Form["action"]) && !string.IsNullOrEmpty(Request.Form["moduleId"]) && !string.IsNullOrEmpty(Request.Form["price"]))
            {
                int moduleId = int.Parse(Request.Form["moduleId"]);
                decimal price = Convert.ToDecimal(Request.Form["price"]);
                if (moduleBll.UpDateModulePrice(moduleId, price) > 0)
                {
                    Response.Write("Succ");
                    Response.End();
                }
                else
                {
                    Response.Write("Faile");
                    Response.End();
                }
            }

            #endregion 设置价格

            if (!IsPostBack)
            {
                cStr = Request.QueryString["CourseId"];
                int CourseId = -1;
                if (!string.IsNullOrEmpty(cStr) && cStr != "-1")
                {
                    CourseId = int.Parse(cStr);
                    this.hfCourseID.Value = CourseId.ToString();
                    CourseExistTime(CourseId);
                }
                else
                {
                    Maticsoft.Common.MessageBox.ResponseScript(this, "alert('课程信息不完整！');history.back()");
                }
                BindRpt(CourseId);
            }
        }

        private void CourseExistTime(int cid)
        {
            courseModule = courseBll.GetModel(cid);
            if (courseModule.CourseSpan == 1)
            {
                if (courseModule.ViewCount == -1)
                {
                    this.rbNolimit.Checked = true;
                }
                else
                {
                    this.rbSum.Checked = true;
                    this.limitSum.Value = courseModule.ViewCount.ToString();
                }
            }
            if (courseModule.ExpiryDate.HasValue)
            {
                TimeSpan ts1 = new TimeSpan(courseModule.ExpiryDate.Value.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                if (ts.Days > 365)
                {
                    this.rbForever.Checked = true;
                }
                else
                {
                    this.rbExpTime.Checked = true;
                    this.txtExpTime.Value = courseModule.ExpiryDate.Value.ToString("yyyy-MM-dd");
                }
            }
            if (courseModule.Price.HasValue)
            {
                this.priceName.Value = courseModule.Price.ToString();
            }
            else
            {
                this.priceName.Value = "0.00";
            }
        }

        private void BindRpt(int CourseId)
        {
            System.Data.DataSet dsCourse = moduleBll.GetCourseInfo(CurrentUser.UserID, CourseId);
            DataTable dt = dsCourse.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                TotalMoney = dr["TotalMoney"] != null ? dr["TotalMoney"].ToString() : "0";
                this.litCName.Text = dr["CourseName"] != null ? dr["CourseName"].ToString() : "";
            }
            System.Data.DataSet ds = moduleBll.SetCoursePricr(CurrentUser.UserID, CourseId);
            rptPrice.DataSource = ds;
            rptPrice.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpLoadCourseMater.aspx?CourseId=" + Request.Params["CourseId"]);
        }

        protected void imgBtnPreview_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void BtnPreview_Click(object sender, EventArgs e)
        {
            int CourseId = -1;
            cStr = Request.QueryString["CourseId"];
            if (!string.IsNullOrEmpty(cStr) && cStr != "-1")
            {
                CourseId = int.Parse(cStr);
            }

            if (CourseId.Equals(-1))
            {
                Maticsoft.Common.MessageBox.Show(this, "没有找到相关的课程信息！");
                return;
            }
            if (rbExpTime.Checked)
            {
                if (!PageValidate.IsDateTime(this.txtExpTime.Value))
                {
                    Maticsoft.Common.MessageBox.Show(this, "时间格式不正确！");
                    return;
                }
                courseModule.CourseSpan = 0;//课程时效
                courseModule.ExpiryDate = Convert.ToDateTime(this.txtExpTime.Value);//截止日期
            }
            else if (rbForever.Checked)
            {
                courseModule.CourseSpan = 0;//课程时效
                courseModule.ExpiryDate = DateTime.Now.AddYears(10);//永久
            }
            if (rbNolimit.Checked)
            {
                courseModule.CourseSpan = 1;//课程时效
                courseModule.ViewCount = -1;//无限次
            }
            else
            {
                courseModule.CourseSpan = 1;//课程时效
                courseModule.ViewCount = int.Parse(this.limitSum.Value);//限制次数
            }
            courseModule.Price = Convert.ToDecimal(this.priceName.Value);//课程发布价格
            courseModule.CourseID = CourseId;//课程ID
            courseModule.UpdatedDate = DateTime.Now;//更新时间

            if (courseBll.UPdateCoursePrice(courseModule) > 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "保存成功");
                Response.Redirect("~/PreviewVideo.aspx?id=" + hfCourseID.Value);
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "保存失败");
            }
            //Response.Redirect("~/PreviewVideo.aspx?id=" + hfCourseID.Value);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int CourseId = -1;
            cStr = Request.QueryString["CourseId"];
            if (!string.IsNullOrEmpty(cStr) && cStr != "-1")
            {
                CourseId = int.Parse(cStr);
            }

            if (CourseId.Equals(-1))
            {
                Maticsoft.Common.MessageBox.Show(this, "没有找到相关的课程信息！");
                return;
            }
            if (rbForever.Checked)
            {
                courseModule.CourseSpan = 0;//课程时效
                courseModule.ExpiryDate = DateTime.Now.AddYears(10);//永久
            }
            else if (rbExpTime.Checked)
            {
                if (!PageValidate.IsDateTime(this.txtExpTime.Value))
                {
                    Maticsoft.Common.MessageBox.Show(this, "时间格式不正确！");
                    return;
                }
                courseModule.CourseSpan = 0;//课程时效
                courseModule.ExpiryDate = Convert.ToDateTime(this.txtExpTime.Value);//截止日期
            }
            if (rbNolimit.Checked)
            {
                courseModule.CourseSpan = 1;//课程时效
                courseModule.ViewCount = -1;//无限次
            }
            else
            {
                courseModule.CourseSpan = 1;//课程时效
                courseModule.ViewCount = int.Parse(this.limitSum.Value);//限制次数
            }
            courseModule.Price = Convert.ToDecimal(this.priceName.Value);//课程发布价格
            courseModule.CourseID = CourseId;//课程ID
            courseModule.UpdatedDate = DateTime.Now;//更新时间

            if (courseBll.UPdateCoursePrice(courseModule) > 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "保存成功");
                Response.Redirect("publishCourse.aspx?CourseId=" + CourseId);
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "保存失败");
            }
        }
    }
}