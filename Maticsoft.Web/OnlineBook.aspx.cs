using System;

namespace Maticsoft.Web
{
    public partial class OnlineBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CourseID <= 0)
                {
                    Session["CurrentError"] = "您将要报名的课程信息不存在，请重新选择！";
                    Server.Transfer("~/ErrorPage.aspx");
                    return;
                }
            }
        }

        public int CourseID
        {
            get
            {
                int cid = 0;
                if (!string.IsNullOrEmpty(Request.Params["cid"]))
                {
                    cid = Common.Globals.SafeInt(Request.Params["cid"], 0);
                }
                return cid;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.btnSubmit.Enabled = false;
            Model.Tao.EntryForm model = new Model.Tao.EntryForm();
            model.UserName = this.txtUserName.Value;
            model.TelPhone = this.txtPhone.Value;
            if (RadioButton1.Checked)
            {
                model.Sex = 1;
            }
            else
            {
                model.Sex = 0;
            }
            if (!string.IsNullOrEmpty(ucRegionAjax.SelectedValue))
            {
                model.RegionId = int.Parse(ucRegionAjax.SelectedValue);
            }
            model.Email = this.txtMail.Value;
            model.HouseAddress = this.txtAddress.Value;
            model.QQ = this.txtQQ.Value;
            model.CourseID = CourseID;
            model.State = 0;
            BLL.Tao.EntryForm bll = new BLL.Tao.EntryForm();
            if (bll.Add(model) > 0)
            {
                Common.MessageBox.ShowLoadingTip(this, "报名成功，正在跳转...", "index.aspx");
            }
            else
            {
                Common.MessageBox.ShowFailTip(this, "系统忙，请稍后再试！");
                this.btnSubmit.Enabled = true;
            }
        }
    }
}