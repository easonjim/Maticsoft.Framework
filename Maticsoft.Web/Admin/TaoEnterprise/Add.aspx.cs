using System;
using Maticsoft.Accounts.Bus;
using Maticsoft.Common;

namespace Maticsoft.Web.TaoEnterprise.Enterprise
{
    public partial class Add : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.Enterprise bll = new Maticsoft.BLL.Tao.Enterprise();

        protected void Page_Load(object sender, EventArgs e)
        {
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
            User newUser = new User();
            if (newUser.HasUser(this.txtUserName.Text))
            {
                strErr += Resources.Site.TooltipUserExist;
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
            int EnterpriseID = 0;
            try
            {
                Maticsoft.Model.Tao.Enterprise model = new Maticsoft.Model.Tao.Enterprise();
                model.Name = this.txtName.Text;
                model.Introduction = this.txtIntroduction.Text;
                model.RegisteredCapital = 0;//this.txtRegisteredCapital.Text;
                model.TelPhone = this.txtTelPhone.Text;
                model.CellPhone = this.txtCellPhone.Text;
                model.ContactMail = this.txtContactMail.Text;
                model.RegionID = Convert.ToInt32(this.hfRegionID.Value);
                model.Address = this.txtAddress.Text;
                model.Remark = this.txtRemark.Text;
                model.Contact = this.txtContact.Text;
                model.UserName = this.txtUserName.Text;
                model.EstablishedDate = Convert.ToDateTime(this.txtEstablishedDate.Text);
                model.EstablishedCity = 0;// this.txtEstablishedCity.Text;
                model.LOGO = UploadImage(FileUploadLogo, 2);
                model.Fax = this.txtFax.Text;
                model.PostCode = this.txtPostCode.Text;
                model.HomePage = this.txtHomePage.Text;
                model.ArtiPerson = this.txtArtiPerson.Text;
                model.EnteRank = 0;// this.txtEnteRank.Text;
                model.EnteClassID = 0;// this.txtEnteClassID.Text;
                model.CompanyType = int.Parse(this.ddlCompanyType.Text);
                model.BusinessLicense = UploadImage(FileUploadBusinessLicense, 2);
                model.TaxNumber = this.txtTaxNumber.Text;
                model.AccountBank = this.txtAccountBank.Text;
                model.AccountInfo = this.txtAccountInfo.Text;
                model.ServicePhone = this.txtServicePhone.Text;
                model.QQ = this.txtQQ.Text;
                model.MSN = this.txtMSN.Text;
                model.Status = Convert.ToInt32(this.ddlStatus.SelectedValue);
                model.CreatedDate = System.DateTime.Now;
                model.CreatedUserID = CurrentUser.UserID;
                model.UpdatedDate = System.DateTime.Now;
                model.UpdatedUserID = CurrentUser.UserID;
                model.AgentID = 0;

                EnterpriseID = bll.Add(model);

                newUser.UserName = txtUserName.Text;
                newUser.Password = AccountsPrincipal.EncryptPassword("111111");
                newUser.TrueName = "";
                newUser.Sex = "1";
                newUser.Phone = this.txtCellPhone.Text;
                newUser.Email = this.txtContactMail.Text;
                newUser.EmployeeID = 0;
                newUser.DepartmentID = EnterpriseID.ToString();
                newUser.Activity = true;
                newUser.UserType = "UU";
                newUser.Style = 1;
                newUser.User_dateCreate = System.DateTime.Now;
                newUser.User_iCreator = CurrentUser.UserID;
                newUser.User_dateValid = DateTime.Now;
                newUser.User_cLang = "zh-CN";

                int userid = newUser.Create();
                if (userid == -100)
                {
                    Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipUserExist);
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "List.aspx");
                }
            }
            catch (Exception ex)
            {
                //若创建用户失败则删除创建的企业编号。
                bll.Delete(EnterpriseID);
                throw ex;
            }
            finally
            {
            }
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}