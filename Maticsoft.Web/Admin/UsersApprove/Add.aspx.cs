using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Tao.UsersApprove
{
    public partial class Add : PageBaseAdmin
    {
        Maticsoft.BLL.Tao.ApproveType ApproveTypebll = new Maticsoft.BLL.Tao.ApproveType();
        Maticsoft.BLL.Tao.UsersApprove UsersApproveBLL = new Maticsoft.BLL.Tao.UsersApprove();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUsers();
                LoadApproveType();
            }
        }
        private void LoadUsers()
        {
            User userAdmin = new User();
            DataSet ds = userAdmin.GetUsersByType("UU", "");
            if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Columns.Count != 0)
            {
                this.ddlUserID.DataSource = ds.Tables[0];
                this.ddlUserID.DataTextField = "UserName";
                this.ddlUserID.DataValueField = "UserID";
                this.ddlUserID.DataBind();
                this.ddlUserID.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }
        private void LoadApproveType()
        {
            DataSet ds = ApproveTypebll.GetAllList();
            if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Columns.Count != 0)
            {
                this.ddlApproveType.DataSource = ds.Tables[0];
                this.ddlApproveType.DataTextField = "ApproveName";
                this.ddlApproveType.DataValueField = "ID";
                this.ddlApproveType.DataBind();
                this.ddlApproveType.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
		{
            if (!string.IsNullOrEmpty(ddlUserID.SelectedValue.Trim()) &&
               !string.IsNullOrEmpty(ddlApproveType.SelectedValue.Trim()) &&
               !string.IsNullOrEmpty(ddlStatus.SelectedValue.Trim())
                )
            {
                this.lblUserID.Text = "";
                if ("0" == ddlUserID.SelectedValue.Trim())
                {
                    this.lblUserID.Text = "*请选择用户!";
                    return;
                }
                this.lblApproveType.Text = "";
                if ("0" == ddlApproveType.SelectedValue.Trim())
                {
                    this.lblApproveType.Text = "*请选择认证资料类型!";
                    return;
                }
                this.lblStatus.Text = "";
                if ("-1" == ddlStatus.SelectedValue.Trim())
                {
                    this.lblStatus.Text = "*请选择审核状态!";
                    return;
                }
                this.lblfileImgURL.Text = "";
                if (string.IsNullOrEmpty(UploadImage(fileImgURL, 2)))
                {
                    this.lblfileImgURL.Text = "*请选择上传认证资料!";
                    return;
                }
                Maticsoft.Model.Tao.UsersApprove model = new Maticsoft.Model.Tao.UsersApprove();
                model.UserID = int.Parse(ddlUserID.SelectedValue);
                model.ApproveType = int.Parse(ddlApproveType.SelectedValue);
                model.ImgURL = UploadImage(fileImgURL, 2);
                model.CreatedDate = System.DateTime.Now;
                model.Status = int.Parse(ddlStatus.SelectedValue);
                model.ApprovedTime = System.DateTime.Now;
                model.ApprovedUserID = CurrentUser.UserID;
                UsersApproveBLL.Add(model);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "List.aspx");
            }

		}

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
