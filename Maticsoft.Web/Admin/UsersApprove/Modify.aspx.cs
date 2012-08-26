using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Accounts.Bus;
using Maticsoft.Common;

namespace Maticsoft.Web.Tao.UsersApprove
{
    public partial class Modify : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.ApproveType ApproveTypebll = new Maticsoft.BLL.Tao.ApproveType();
        private Maticsoft.BLL.Tao.UsersApprove bll = new Maticsoft.BLL.Tao.UsersApprove();
        public string strImgUrlLogo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUsers();
                LoadApproveType();
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    if (PageValidate.IsNumber(Request.Params["id"]))
                    {
                        ShowInfo(Convert.ToInt32(Request.Params["id"]));
                    }
                }
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

        private void ShowInfo(int ID)
        {
            Maticsoft.Model.Tao.UsersApprove model = bll.GetModel(ID);
            if (null != model)
            {
                this.lblID.Text = model.ID.ToString();
                this.ddlUserID.SelectedValue = model.UserID.ToString();
                if (null != model.ApproveType)
                {
                    this.ddlApproveType.SelectedValue = model.ApproveType.ToString();
                }
                if (null != model.Status)
                {
                    this.ddlStatus.SelectedValue = model.Status.ToString();
                }
                hfImgUrlLogo.Value = model.ImgURL;
                strImgUrlLogo = GetImage(model.ImgURL, 45, 45);
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
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
                string strAppId = Request.QueryString["id"];
                if (string.IsNullOrEmpty(strAppId))
                {
                    return;
                }
                int appId = int.Parse(strAppId);
                Maticsoft.Model.Tao.UsersApprove model = bll.GetModel(appId);//new Maticsoft.Model.Tao.UsersApprove();
                model.UserID = int.Parse(ddlUserID.SelectedValue);
                model.ApproveType = int.Parse(ddlApproveType.SelectedValue);
                model.ImgURL = hfImgUrlLogo.Value;
                if (!string.IsNullOrEmpty(UploadImage(fileImgURL, 2)))
                {
                    model.ImgURL = UploadImage(fileImgURL, 2);
                }
                model.CreatedDate = System.DateTime.Now;
                model.Status = int.Parse(ddlStatus.SelectedValue);
                model.ApprovedTime = System.DateTime.Now;
                model.ApprovedUserID = CurrentUser.UserID;
                model.ID = int.Parse(this.lblID.Text);
                bll.Update(model);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");
            }
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}