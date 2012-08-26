using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Tao.UsersApprove
{
    public partial class Show : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.UsersApprove bll = new Maticsoft.BLL.Tao.UsersApprove();
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    if (PageValidate.IsNumber(Request.Params["id"]))
                    {
                        strid = Request.Params["id"];
                        ShowInfo(Convert.ToInt32(strid));
                    }
                }
            }
        }

        private void ShowInfo(int ID)
        {
            Maticsoft.Model.Tao.UsersApprove model = bll.GetModel(ID);
            if (null != model)
            {
                this.lblID.Text = model.ID.ToString();
                this.lblUserID.Text = GetUserName(model.UserID);
                this.lblApproveType.Text = GetApproveName(model.ApproveType);
                this.imgUrl.ImageUrl = model.ImgURL;
                if (null != model.CreatedDate)
                {
                    this.lblCreatedDate.Text = model.CreatedDate.ToString();
                }
                this.lblStatus.Text = GetStatus(model.Status);
                if (null != model.ApprovedTime)
                {
                    this.lblApprovedTime.Text = model.ApprovedTime.ToString();
                }
                this.lblApprovedUserID.Text = GetUserName(model.ApprovedUserID);
            }
        }
    }
}