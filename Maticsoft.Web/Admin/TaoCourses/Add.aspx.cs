using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoCourses
{
    public partial class Add : PageBaseAdmin
    {
        private BLL.Tao.Courses bll = new BLL.Tao.Courses();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BiudTree();
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
            CourseModel.CourseName = this.txtCourseName.Text;
            CourseModel.ShortDescription = this.txtShortDescription.Text;
            CourseModel.Description = this.txtContent.Text;
            CourseModel.CategoryId = Convert.ToInt32(this.listTarget.SelectedValue);
            CourseModel.ModuleNum = Convert.ToInt32(this.txtModuleCount.Text);
            CourseModel.TimeDuration = BLL.ConvertTime.TimeToSecond(int.Parse(txtTimeHour.Value), int.Parse(txtMinute.Value), int.Parse(txtSeconds.Value));
            CourseModel.ExpiryDate = Convert.ToDateTime(this.txtExpiryDate.Text);
            CourseModel.Tags = this.txtTags.Text;
            string imgPath = UploadImage(fileImageUrl, 1);
            if (string.IsNullOrEmpty(imgPath))
            {
                return;
            }
            CourseModel.ImageUrl = imgPath;
            CourseModel.Status = Convert.ToInt32(this.ddlStatus.SelectedValue);
            CourseModel.CreatedUserID = CurrentUser.UserID;
            CourseModel.Recommended = rbRec.Checked ? true : false;
            CourseModel.SpecialOffer = rbCheap.Checked ? true : false;
            CourseModel.Hotsale = rbHot.Checked ? true : false;
            CourseModel.Latest = rbNew.Checked ? true : false;
            CourseModel.Price = Convert.ToDecimal(this.txtPrince.Text);
            CourseModel.Sequence = Convert.ToInt32(this.txtOrder.Text);
            bll.Add(CourseModel);
            Response.Redirect("list.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}