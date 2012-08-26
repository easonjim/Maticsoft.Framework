using System;
using System.Web.UI;

namespace Maticsoft.Web.Ms.Enterprise
{
    public partial class Show : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.Enterprise bll = new Maticsoft.BLL.Tao.Enterprise();
        public string strid = string.Empty;
        public string strImgUrlLogo = string.Empty;
        public string strImgUrlBusinessLicense = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    strid = Request.Params["id"];
                    int EnterpriseID = (Convert.ToInt32(strid));
                    ShowInfo(EnterpriseID);
                }
            }
        }

        private void ShowInfo(int EnterpriseID)
        {
            Maticsoft.Model.Tao.Enterprise model = bll.GetModel(EnterpriseID);
            if (null != model)
            {
                this.lblEnterpriseID.Text = model.EnterpriseID.ToString();
                this.lblName.Text = model.Name;
                this.lblIntroduction.Text = model.Introduction;
                this.lblRegisteredCapital.Text = model.RegisteredCapital.ToString();
                this.lblTelPhone.Text = model.TelPhone;
                this.lblCellPhone.Text = model.CellPhone;
                this.lblContactMail.Text = model.ContactMail;
                this.RegionDropList1.RegionId = model.RegionID;
                this.lblAddress.Text = model.Address;
                this.lblRemark.Text = model.Remark;
                this.lblContact.Text = model.Contact;
                this.lblUserName.Text = model.UserName;
                this.lblEstablishedDate.Text = model.EstablishedDate.ToString();
                this.lblEstablishedCity.Text = model.EstablishedCity.ToString();
                strImgUrlLogo = GetImage(model.LOGO, 45, 45);
                this.lblFax.Text = model.Fax;
                this.lblPostCode.Text = model.PostCode;
                this.lblHomePage.Text = model.HomePage;
                this.lblArtiPerson.Text = model.ArtiPerson;
                this.lblEnteRank.Text = model.EnteRank.ToString();
                this.lblEnteClassID.Text = model.EnteClassID.ToString();
                this.lblCompanyType.Text = GetCompanyType(model.CompanyType);
                strImgUrlBusinessLicense = GetImage(model.BusinessLicense, 45, 45);
                this.lblTaxNumber.Text = model.TaxNumber;
                this.lblAccountBank.Text = model.AccountBank;
                this.lblAccountInfo.Text = model.AccountInfo;
                this.lblServicePhone.Text = model.ServicePhone;
                this.lblQQ.Text = model.QQ;
                this.lblMSN.Text = model.MSN;
                this.lblStatus.Text = GetEnterpriseState(model.Status);
                this.lblCreatedDate.Text = model.CreatedDate.ToString();
                this.lblCreatedUserID.Text = GetUserName(model.CreatedUserID);
                this.lblUpdatedDate.Text = model.UpdatedDate.ToString();
                this.lblUpdatedUserID.Text = GetUserName(model.UpdatedUserID);
                this.lblAgentID.Text = model.AgentID.ToString();
            }
        }
    }
}