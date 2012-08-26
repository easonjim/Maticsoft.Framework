using System;
using System.Web.UI;

namespace Maticsoft.Web.Admin.TaoFavorite
{
    public partial class Show : PageBaseAdmin
    {
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    strid = Request.Params["id"];
                    int FavoriteID = (Convert.ToInt32(strid));
                    ShowInfo(FavoriteID);
                }
            }
        }

        private void ShowInfo(int FavoriteID)
        {
            BLL.Tao.Favorite bll = new BLL.Tao.Favorite();
            Model.Tao.Favorite model = bll.GetModel(FavoriteID);
            this.lblFavoriteID.Text = model.FavoriteID.ToString();
            this.lblCourseID.Text = model.CourseID.ToString();
            this.lblModuleID.Text = model.ModuleID.ToString();
            this.lblUserID.Text = model.UserID.ToString();
            this.lblTags.Text = model.Tags;
            this.lblRemark.Text = model.Remark;
        }
    }
}