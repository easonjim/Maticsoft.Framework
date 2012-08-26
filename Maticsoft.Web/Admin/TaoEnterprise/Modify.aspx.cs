using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.TaoEnterprise.Enterprise
{
    public partial class Modify : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.Enterprise bll = new Maticsoft.BLL.Tao.Enterprise();
        public string strImgUrlLogo = string.Empty;
        public string strImgUrlBusinessLicense = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    if (PageValidate.IsNumber(Request.Params["id"]))
                    {
                        ShowInfo(Convert.ToInt32(Request.Params["id"]));
                    }
                }
            }
        }

        private void ShowInfo(int EnterpriseID)
        {
            Maticsoft.Model.Tao.Enterprise model = bll.GetModel(EnterpriseID);
            if (null != model)
            {
                this.hfEnterpriseID.Value = model.EnterpriseID.ToString();
                this.txtName.Text = model.Name;
                this.txtIntroduction.Text = model.Introduction;
                if (null != model.RegisteredCapital)
                {
                    this.txtRegisteredCapital.Text = model.RegisteredCapital.ToString();
                }
                this.txtTelPhone.Text = model.TelPhone;
                this.txtCellPhone.Text = model.CellPhone;
                this.txtContactMail.Text = model.ContactMail;
                if (null != model.RegionID)
                {
                    this.hfRegionID.Value = model.RegionID.ToString();
                    this.RegionDropList1.RegionId = model.RegionID;
                }
                this.txtAddress.Text = model.Address;
                this.txtRemark.Text = model.Remark;
                this.txtContact.Text = model.Contact;
                this.txtUserName.Text = model.UserName;
                if (null != model.EstablishedDate)
                {
                    this.txtEstablishedDate.Text = model.EstablishedDate.ToString();
                }
                if (null != model.EstablishedCity)
                {
                    this.txtEstablishedCity.Text = model.EstablishedCity.ToString();
                }
                this.hfImgUrlLogo.Value = model.LOGO;
                strImgUrlLogo = GetImage(model.LOGO, 45, 45);
                this.txtFax.Text = model.Fax;
                this.txtPostCode.Text = model.PostCode;
                this.txtHomePage.Text = model.HomePage;
                this.txtArtiPerson.Text = model.ArtiPerson;
                if (null != model.EnteRank)
                {
                    this.txtEnteRank.Text = model.EnteRank.ToString();
                }
                if (null != model.EnteClassID)
                {
                    this.txtEnteClassID.Text = model.EnteClassID.ToString();
                }
                if (null != model.CompanyType)
                {
                    this.ddlCompanyType.SelectedValue = model.CompanyType.ToString();
                }
                hfImgUrlBusinessLicense.Value = model.BusinessLicense;
                strImgUrlBusinessLicense = GetImage(model.BusinessLicense, 45, 45);
                this.txtTaxNumber.Text = model.TaxNumber;
                this.txtAccountBank.Text = model.AccountBank;
                this.txtAccountInfo.Text = model.AccountInfo;
                this.txtServicePhone.Text = model.ServicePhone;
                this.txtQQ.Text = model.QQ;
                this.txtMSN.Text = model.MSN;
                if (null != model.Status)
                {
                    this.ddlStatus.SelectedValue = model.Status.ToString();
                }
                if (null != model.CreatedDate)
                {
                    this.hfCreatedDate.Value = model.CreatedDate.ToString();
                }
                if (null != model.CreatedUserID)
                {
                    this.hfCreatedUserID.Value = model.CreatedUserID.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtIntroduction.Text.Trim().Length == 0)
            {
                strErr += "企业介绍不能为空！\\n";
            }
            if (!PageValidate.IsDateTime(txtEstablishedDate.Text))
            {
                strErr += "成立时间格式错误！\\n";
            }
            if (string.IsNullOrEmpty(hfRegionID.Value))
            {
                strErr += "请选择省/市！\\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            Maticsoft.Model.Tao.Enterprise model = new Maticsoft.Model.Tao.Enterprise();
            model.Name = this.txtName.Text;
            model.Introduction = this.txtIntroduction.Text;
            model.RegisteredCapital = 0;// int.Parse(this.txtRegisteredCapital.Text);
            model.TelPhone = this.txtTelPhone.Text;
            model.CellPhone = this.txtCellPhone.Text;
            model.ContactMail = this.txtContactMail.Text;
            model.RegionID = Convert.ToInt32(this.hfRegionID.Value);
            model.Address = this.txtAddress.Text;
            model.Remark = this.txtRemark.Text;
            model.Contact = this.txtContact.Text;
            model.UserName = this.txtUserName.Text;
            model.EstablishedDate = Convert.ToDateTime(this.txtEstablishedDate.Text);
            model.EstablishedCity = -1;// int.Parse(this.txtEstablishedCity.Text);
            model.LOGO = this.hfImgUrlLogo.Value;
            if (!string.IsNullOrEmpty(UploadImage(FileUploadLogo, 2)))
            {
                model.LOGO = UploadImage(FileUploadLogo, 2);
            }
            model.Fax = this.txtFax.Text;
            model.PostCode = this.txtPostCode.Text;
            model.HomePage = this.txtHomePage.Text;
            model.ArtiPerson = this.txtArtiPerson.Text;
            model.EnteRank = 0;// int.Parse(this.txtEnteRank.Text);
            model.EnteClassID = 0;// int.Parse(this.txtEnteClassID.Text);
            model.CompanyType = int.Parse(this.ddlCompanyType.Text);
            model.BusinessLicense = hfImgUrlBusinessLicense.Value;
            if (!string.IsNullOrEmpty(UploadImage(FileUploadBusinessLicense, 2)))
            {
                model.BusinessLicense = UploadImage(FileUploadBusinessLicense, 2);
            }
            model.TaxNumber = this.txtTaxNumber.Text;
            model.AccountBank = this.txtAccountBank.Text;
            model.AccountInfo = this.txtAccountInfo.Text;
            model.ServicePhone = this.txtServicePhone.Text;
            model.QQ = this.txtQQ.Text;
            model.MSN = this.txtMSN.Text;
            model.Status = Convert.ToInt32(this.ddlStatus.SelectedValue);
            model.CreatedDate = System.DateTime.Now;
            if (!string.IsNullOrEmpty(hfCreatedDate.Value) && PageValidate.IsDateTime(hfCreatedDate.Value))
            {
                model.CreatedDate = DateTime.Parse(hfCreatedDate.Value);
            }
            model.CreatedUserID = CurrentUser.UserID;
            if (!string.IsNullOrEmpty(hfCreatedUserID.Value) && PageValidate.IsNumber(hfCreatedUserID.Value))
            {
                model.CreatedUserID = int.Parse(hfCreatedUserID.Value);
            }
            model.UpdatedDate = System.DateTime.Now;
            model.UpdatedUserID = CurrentUser.UserID;
            model.AgentID = 0;
            model.EnterpriseID = int.Parse(hfEnterpriseID.Value);
            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功！", "List.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}