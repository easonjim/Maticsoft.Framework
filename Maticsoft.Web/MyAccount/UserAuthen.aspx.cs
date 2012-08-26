using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserAuthen : PageBaseUser
    {
        private string uploadFile = Maticsoft.Common.ConfigHelper.GetConfigString("UploadDocument");
        public string strImgBusinessLicense, strStatus, strImgUrl, strEnterpriseStatus = string.Empty;
        private BLL.UserExp.UsersApprove usersApproveBLL = new BLL.UserExp.UsersApprove();
        private BLL.UserExp.ApproveType approveTypeBLL = new BLL.UserExp.ApproveType();
        private BLL.Tao.Enterprise enterpriseBLL = new BLL.Tao.Enterprise();
        private BLL.Tao.UserEmailAc userEBll = new BLL.Tao.UserEmailAc();
        private Model.Tao.UserEmailAc userEModel = new Model.Tao.UserEmailAc();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowInfo();
                BindDrop();
                DataSet ds = usersApproveBLL.GetUserApprove(CurrentUser.UserID);
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();
                showEnterpriseInfo();
            }
        }

        public void ShowInfo()
        {
            if (null != CurrentUser)
            {
                this.lblUserName.InnerText = HttpUtility.HtmlEncode(CurrentUser.UserName);
                this.lblTrueUserName.InnerText = HttpUtility.HtmlEncode(CurrentUser.TrueName);
                this.txtTrueName.Text = CurrentUser.TrueName;
                int uid = CurrentUser.UserID;

                //this.txtEmail.Value = CurrentUser.Email;

                //userEModel = userEBll.GetModel(CurrentUser.UserID);
                //if (userEModel != null)
                //{
                //    if (userEModel.IsActive)
                //    {
                //        this.txtEmail.Visible = false;
                //        litMsg.Text = "已通过邮箱认证！";
                //        this.btnEmail.Visible = false;
                //    }
                //}

                //身份证
                if (usersApproveBLL.Exists(uid, 1))
                {
                    Model.UserExp.UsersApprove model = usersApproveBLL.GetModelByUidAndType(uid, 1);
                    if (null != model)
                    {
                        this.hfIDCard.Value = model.IDCard;
                        this.txtIDCard.Text = model.IDCard;
                        if (model.Status.HasValue)
                        {
                            strStatus = GetStatus(model.Status);
                            if (1 == model.Status)
                            {
                                this.btnUplodIDCard.Enabled = false;
                            }
                        }
                        this.hfImgURL.Value = model.ImgURL;
                        strImgUrl = GetImage(model.ImgURL, 45, 45);
                    }
                }
                if (enterpriseBLL.ExistsByUserID(uid))
                {
                    Model.Tao.Enterprise model = enterpriseBLL.GetModelByUserID(uid);
                    if (null != model)
                    {
                        if (model.Status.HasValue)
                        {
                            strEnterpriseStatus = GetEnterpriseState(model.Status);
                            if (1 == model.Status)
                            {
                                this.btnSave.Enabled = false;
                                this.btnSave.Text = "您的机构信息已经审核通过，不能进行修改！";
                            }
                        }
                    }
                }
            }
        }

        private void BindDrop()
        {
            DataSet ds = approveTypeBLL.GetAllList();
            this.ddlUpType.DataSource = ds;
            this.ddlUpType.DataTextField = "ApproveName";
            this.ddlUpType.DataValueField = "ID";
            this.ddlUpType.DataBind();
            this.ddlUpType.Items.Insert(0, new ListItem("-- 请选择 --", ""));
        }

        protected void upDoc_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlUpType.SelectedIndex == 0)
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "请先选择认证类型！");
                return;
            }

            int iiaa = int.Parse(this.Hftype.Value);
            bool isExist = usersApproveBLL.Exists(CurrentUser.UserID, iiaa);
            if (isExist)
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "你已经上传了该类型的认证资料，请勿重复上传！");
                return;
            }

            if (!string.IsNullOrEmpty(uploadFile))
            {
                uploadFile += "/" + CurrentUser.UserID.ToString();
                HttpPostedFile hpf = DocUp.PostedFile;
                string outPath = string.Empty;
                Common.FileUpLoad.uploadFileControl(hpf, uploadFile, "pic", out outPath);
                if (!string.IsNullOrEmpty(outPath))
                {
                    this.FilePath.Value = outPath;
                    Model.UserExp.UsersApprove appModel = new Model.UserExp.UsersApprove();
                    appModel.UserID = CurrentUser.UserID;
                    appModel.CreatedDate = DateTime.Now;
                    appModel.Status = 0;
                    appModel.ImgURL = this.FilePath.Value;
                    appModel.ApproveType = int.Parse(this.Hftype.Value);
                    if (usersApproveBLL.Add(appModel) > 0)
                    {
                        Maticsoft.Common.MessageBox.ShowAndRedirect(this, "证书上传成功！", "UserAuthen.aspx");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.ShowFailTip(this, "证书上传失败！");
                    }
                }
                else
                {
                    //认证资料上传失败
                }
            }
            else
            {
                // 保存路径为空 后台没有配置认证资料保存路径
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (null == CurrentUser)
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "您尚未登录，无法进行身份验证！");
                return;
            }
            Model.UserExp.UsersApprove appModel = new Model.UserExp.UsersApprove();
            appModel.UserID = CurrentUser.UserID;
            appModel.CreatedDate = DateTime.Now;
            appModel.Status = 0;
            appModel.ImgURL = this.FilePath.Value;
            if (!string.IsNullOrEmpty(this.Hftype.Value) && Maticsoft.Common.PageValidate.IsNumber(this.Hftype.Value))
            {
                appModel.ApproveType = int.Parse(this.Hftype.Value);
            }
            if (usersApproveBLL.Add(appModel) > 0)
            {
                ShowInfo();
                Maticsoft.Common.MessageBox.ShowSuccessTip(this, "保存成功！", "UserAuthen.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "保存失败！");
            }
        }

        protected void btnUplodIDCard_Click(object sender, ImageClickEventArgs e)
        {
            if (null == CurrentUser)
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "您尚未登录，无法进行身份验证！");
                return;
            }
            if (!Maticsoft.Common.PageValidate.CheckIDCard(this.txtIDCard.Text))
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "对不起，您输入的身份证格式有误，请重新输入！");
                return;
            }
            Model.UserExp.UsersApprove model = new Model.UserExp.UsersApprove();
            model.UserID = CurrentUser.UserID;
            model.CreatedDate = DateTime.Now;
            model.Status = 0;//未审核
            model.ImgURL = this.hfImgURL.Value;
            if (!string.IsNullOrEmpty(uploadFile))
            {
                string outPath = string.Empty;
                Common.FileUpLoad.uploadFileControl(fileIDCard.PostedFile, uploadFile += "/" + CurrentUser.UserID, "pic", out outPath);
                if (!string.IsNullOrEmpty(outPath))
                {
                    model.ImgURL = outPath;
                }
            }
            model.IDCard = hfIDCard.Value;
            if (!string.IsNullOrEmpty(this.txtIDCard.Text))
            {
                model.IDCard = this.txtIDCard.Text;
            }
            model.ApproveType = 1;//身份证
            if (string.IsNullOrEmpty(model.ImgURL))
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "对不起，您尚未选择文件！");
                return;
            }
            if (usersApproveBLL.Exists(CurrentUser.UserID, 1))
            {
                Model.UserExp.UsersApprove usersApproveModel = usersApproveBLL.GetModelByUidAndType(CurrentUser.UserID, 1);
                if (null != usersApproveModel)
                {
                    if (usersApproveModel.Status.HasValue)
                    {
                        switch (usersApproveModel.Status)
                        {
                            case 0:
                            case 2:
                                model.Status = 0;
                                model.ID = usersApproveModel.ID;
                                usersApproveBLL.Update(model);
                                ShowInfo();
                                Maticsoft.Common.MessageBox.ShowSuccessTip(this, "保存成功！");
                                break;

                            case 1:
                                Maticsoft.Common.MessageBox.ShowFailTip(this, "你已经上传了该类型的认证资料并通过认证，请勿重复上传！");
                                break;
                        }
                    }
                }
            }
            else
            {
                if (0 < usersApproveBLL.Add(model))
                {
                    ShowInfo();
                    Maticsoft.Common.MessageBox.ShowSuccessTip(this, "保存成功！");
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowFailTip(this, "上传失败！");
                    return;
                }
            }
        }

        private Maticsoft.BLL.Tao.Enterprise BLL = new Maticsoft.BLL.Tao.Enterprise();

        ///<summary>
        ///展示机构（企业信息）
        ///</summary>
        private void showEnterpriseInfo()
        {
            if (null == CurrentUser)
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "您尚未登录，无法进行身份验证！");
                return;
            }
            Maticsoft.Model.Tao.Enterprise model = BLL.GetModelByUserID(CurrentUser.UserID);
            if (null != model)
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    this.txtEnterpriseName.Text = model.Name;
                    this.txtEnterpriseName.Enabled = false;
                    this.txtEnterpriseName.ReadOnly = true;//公司名称和公司别称填写后不能修改
                }
                this.txtIntroduction.Text = model.Introduction;
                if (model.RegisteredCapital.HasValue)
                {
                    this.txtRegisteredCapital.Text = model.RegisteredCapital.ToString();
                }
                this.txtPhone.Text = model.TelPhone;
                this.txtContactMail.Text = model.ContactMail;
                this.txtContact.Text = model.Contact;
                this.txtPostCode.Text = model.PostCode;
                this.txtHomePage.Text = model.HomePage;
                if (!string.IsNullOrEmpty(model.BusinessLicense))
                {
                    this.hfBusinessLicense.Value = model.BusinessLicense;
                    strImgBusinessLicense = GetImage(model.BusinessLicense, 45, 45);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (null == CurrentUser)
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "您尚未登录，无法进行注册机构！");
                return;
            }
            Maticsoft.Model.Tao.Enterprise model = new Maticsoft.Model.Tao.Enterprise();
            model.Name = this.txtEnterpriseName.Text;
            model.Introduction = this.txtIntroduction.Text;
            model.RegisteredCapital = int.Parse(this.txtRegisteredCapital.Text);
            model.TelPhone = this.txtPhone.Text;
            model.ContactMail = this.txtContactMail.Text;
            model.Contact = this.txtContact.Text;
            model.UserName = CurrentUser.TrueName;
            model.PostCode = this.txtPostCode.Text;
            model.HomePage = this.txtHomePage.Text;
            model.BusinessLicense = this.hfBusinessLicense.Value;
            if (!string.IsNullOrEmpty(uploadFile))
            {
                string outPath = string.Empty;
                Common.FileUpLoad.uploadFileControl(FileUploadBusinessLicense.PostedFile, uploadFile += "/" + CurrentUser.UserID, "pic", out outPath);
                if (!string.IsNullOrEmpty(outPath))
                {
                    model.BusinessLicense = outPath;
                }
            }
            model.Status = 0;
            model.CreatedDate = System.DateTime.Now;
            model.CreatedUserID = CurrentUser.UserID;
            model.UpdatedDate = System.DateTime.Now;
            model.UpdatedUserID = CurrentUser.UserID;
            model.AgentID = 0;
            if (BLL.ExistsByUserID(CurrentUser.UserID))
            {
                Maticsoft.Model.Tao.Enterprise enterpriseModel = BLL.GetModelByUserID(CurrentUser.UserID);
                if (null != enterpriseModel)
                {
                    model.EnterpriseID = enterpriseModel.EnterpriseID;
                    if (enterpriseModel.Status.HasValue)
                    {
                        //0未审核  1正常  2冻结   3删除
                        switch (enterpriseModel.Status.Value)
                        {
                            case 0:
                            case 1:
                                break;

                            case 2://冻结则修改状态为未审核，可以再次请求审核。
                            case 3://删除则修改状态为未审核，可以再次请求审核。
                                model.Status = 0;
                                break;
                        }
                    }
                    if (BLL.Update(model))
                    {
                        ShowInfo();
                        showEnterpriseInfo();
                        Maticsoft.Common.MessageBox.ShowSuccessTip(this, "保存成功！");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.ShowFailTip(this, "保存失败！");
                    }
                }
            }
            else
            {
                int rows = BLL.Add(model);
                if (0 < rows)
                {
                    CurrentUser.DepartmentID = rows.ToString();
                    CurrentUser.Update();
                    ShowInfo();
                    showEnterpriseInfo();
                    Maticsoft.Common.MessageBox.Show(this, "注册机构成功！");
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "注册机构失败！");
                }
            }
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            //userEModel = new Model.Tao.UserEmailAc();
            //userEModel.UserId = CurrentUser.UserID;
            //userEModel.IsActive = false;
            //userEModel.Email = this.txtEmail.Value;
            //userEModel.AvtiveCode = Guid.NewGuid().ToString().Substring(0, 6);
            //if (userEBll.Add(userEModel) > 0)
            //{
            //    //发送邮件
            //    try
            //    {
            //        string userMail = this.txtEmail.Value;
            //        string subject = "请激活您的账户！" + CurrentUser.UserName;
            //        string activeUrl = "http://127.0.0.1:6086/Active.aspx?activeCode=" + userEModel.AvtiveCode + "&userId=" + CurrentUser.UserID;
            //        string mailContent = "尊敬的用户，请点击下面的链接激活您的账户<a href=\"" + activeUrl + "\">" + activeUrl + "</a>，如果您的浏览器不能正常显示链接，请把上面的地址拷贝到浏览器地址栏访问！";
            //        Maticsoft.Common.MailSender.Send(userMail, subject, mailContent.ToString());
            //        Maticsoft.Common.MessageBox.Show(this, "发送成功！");
            //    }
            //    catch (Exception)
            //    {
            //        Maticsoft.Common.MessageBox.Show(this, "未知错误，请联系管理员！");
            //        return;
            //    }
            //}
        }
    }
}