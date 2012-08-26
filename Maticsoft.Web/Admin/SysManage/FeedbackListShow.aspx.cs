using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Admin.SysManage
{
    public partial class FeedbackListShow : PageBaseAdmin
    {
        public string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    id = Request.Params["id"];
                    int Feedback_iID = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(Feedback_iID);
                }
            }

        }

        Maticsoft.BLL.SysManage.SA_Feedback bll = new BLL.SysManage.SA_Feedback();
        private void ShowInfo(int Feedback_iID)
        {
            Maticsoft.Model.SysManage.SA_Feedback model = bll.GetModel(Feedback_iID);
            this.lblFeedback_iID.Text = model.Feedback_iID.ToString();
            this.lblFeedback_cUserName.Text = model.Feedback_cUserName;
            this.lblFeedback_cPhone.Text = model.Feedback_cPhone;
            this.lblFeedback_cCompany.Text = model.Feedback_cCompany;
            this.lblFeedback_cMail.Text = model.Feedback_cMail;
            this.lbltxtFeedback_cContent.Text = model.Feedback_cContent;
            this.lblFeedback_bSolved.Text = model.Feedback_bSolved ? Resources.Site.lblTrue : Resources.Site.lblFalse;
            this.lblFeedback_cUserIP.Text = model.Feedback_cUserIP;
            this.lblFeedback_dateCreate.Text = model.Feedback_dateCreate.ToString();
            this.txtFeedback_cResult.Text = model.Feedback_cResult;
            if (model.Feedback_bSolved == true) 
            {
                this.btnSolve.Visible = false;
                this.txtFeedback_cResult.Visible = false;
                lblFeedback_cResult.Text = this.txtFeedback_cResult.Text;
            }



        }

        protected void btnSolve_Click(object sender, EventArgs e)
        {

            int Feedback_iID = int.Parse(this.lblFeedback_iID.Text);
            string Feedback_cUserName = this.lblFeedback_cUserName.Text;
            string Feedback_cPhone = this.lblFeedback_cPhone.Text;
            string Feedback_cCompany = this.lblFeedback_cCompany.Text;
            string Feedback_cMail = this.lblFeedback_cMail.Text;
            string Feedback_cContent = this.lbltxtFeedback_cContent.Text;
            string Feedback_cUserIP = this.lblFeedback_cUserIP.Text;
            string Feedback_cResult = this.txtFeedback_cResult.Text;
            DateTime Feedback_dateCreate = DateTime.Parse(this.lblFeedback_dateCreate.Text);
            Maticsoft.Model.SysManage.SA_Feedback model = new Model.SysManage.SA_Feedback();
            model.Feedback_iID = Feedback_iID;
            model.Feedback_cUserName = Feedback_cUserName;
            model.Feedback_cPhone = Feedback_cPhone;
            model.Feedback_cCompany = Feedback_cCompany;
            model.Feedback_cMail = Feedback_cMail;
            model.Feedback_cContent = Feedback_cContent;
            model.Feedback_cUserIP = Feedback_cUserIP;
            model.Feedback_dateCreate = Feedback_dateCreate;
            model.Feedback_bSolved = true;
            model.Feedback_cResult = Feedback_cResult;
            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "反馈已解决", "FeedbackList.aspx");
        }

      
    }
}