using System;
using System.Web.UI.WebControls;
using Maticsoft.Model;

namespace Maticsoft.Web.PubCourse
{
    public partial class OrganizeCourseList : PageBaseUser
    {
        private Maticsoft.BLL.Tao.CourseModule courseModuleBll = new Maticsoft.BLL.Tao.CourseModule();
        private Maticsoft.BLL.Tao.Modules modulesBll = new Maticsoft.BLL.Tao.Modules();
        private Maticsoft.Model.Tao.Modules module = null;
        private BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        private BLL.Tao.Enterprise enBll = new BLL.Tao.Enterprise();
        public string price = null;
        public int cid = -1;
        public string strDepart = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int iCourseId = 0;
                if (Request.QueryString["CourseId"] == null)
                {
                    Maticsoft.Common.MessageBox.ResponseScript(this, "alert('请先填写课程信息！');history.back()");
                    return;
                }

                iCourseId = int.Parse(Request.QueryString["CourseId"].ToString());
                cid = iCourseId;
                Model.Tao.Courses model = courseBll.GetModel(iCourseId);
                if (!string.IsNullOrEmpty(model.ImageUrl))
                {
                    CourseThumbnai.Src = model.ImageUrl;
                }
                if (!string.IsNullOrEmpty(model.CourseName))
                {
                    this.labCourseName.Text = model.CourseName;
                }
                if (model.Price.HasValue)
                {
                    price = model.Price.Value.ToString("C");
                }
                this.btnSava.CommandArgument = string.Empty;
                Maticsoft.Accounts.Bus.User user = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                if (!string.IsNullOrEmpty(user.DepartmentID))
                {
                    if (user.DepartmentID.Equals("-1")) { return; }
                    Model.Tao.Enterprise modle = enBll.GetModel(user.DepartmentID);
                    if (!string.IsNullOrEmpty(modle.Name))
                    {
                        strDepart = " <p>机构名称：" + modle.Name + "</p>";
                    }
                }
                this.HiddenFieldAddresser.Value = user.UserName;
                this.hfRuturnUrl.Value = Server.UrlEncode(Request.Url.ToString());
                BindData(iCourseId);
            }
            this.AspNetPager1.RecordCount = 0;
        }

        protected void btnSava_Click(object sender, EventArgs e)
        {
            int iCourseId = 0;
            if (Request.QueryString["CourseId"] != null)
            {
                iCourseId = int.Parse(Request.QueryString["CourseId"]);
                cid = iCourseId;
            }
            if (string.IsNullOrEmpty(this.txtModuleName.Text.Trim()))
            {
                this.ErrorMsg.Visible = true;
                this.ErrorMsg.Text = "小节名称不能为空";
                return;
            }
            if (string.IsNullOrEmpty(this.btnSava.CommandArgument))
            {
                module = new Model.Tao.Modules();
            }
            else
            {
                int mId = int.Parse(this.btnSava.CommandArgument);
                module = modulesBll.GetModel(mId);
            }
            //Maticsoft.Model.Tao.Modules module = new Maticsoft.Model.Tao.Modules();
            module.ModuleName = this.txtModuleName.Text.Trim();
            module.Description = this.txtDescription.Text.Trim();

            int iResult = 0;
            //判断是否为新增小节，当this.btnSava.CommandArgument有值，则为”新增“，否则为”修改“
            if (string.IsNullOrEmpty(this.btnSava.CommandArgument))
            {
                //添加课程小节
                module.CreatedDate = DateTime.Now;
                iResult = modulesBll.Add(module);

                if (iResult > 0)
                {
                    Maticsoft.Model.Tao.CourseModule courseModule = new Maticsoft.Model.Tao.CourseModule();
                    courseModule.CourseID = iCourseId;
                    courseModule.ModuleID = iResult;
                    courseModule.ModuleIndex = courseModuleBll.GetMaxModuleIndex(iCourseId);

                    if (courseModuleBll.Add(courseModule) > 0)
                    {
                        this.ErrorMsg.Text = "新增课程成功！";
                    }
                }
                else
                {
                    modulesBll.Delete(iResult);
                    this.ErrorMsg.Text = "新增课程小节失败，请重试！";
                }
            }
            else
            {
                module.ModuleID = int.Parse(this.btnSava.CommandArgument);
                this.btnSava.CommandArgument = null;
                module.UpdatedDate = DateTime.Now;
                modulesBll.Update(module);
            }

            this.txtDescription.Text = string.Empty;
            this.txtModuleName.Text = string.Empty;
            this.ErrorMsg.Visible = false;

            BindData(iCourseId);
        }

        private void BindData(int iCourseId)
        {
            QueryCourses query = new QueryCourses();
            query.CourseID = iCourseId;
            query.PageIndex = this.AspNetPager1.CurrentPageIndex;
            query.PageSize = this.AspNetPager1.PageSize = 10;
            query.CourseTypes = 1;
            GridView_ModuleList.DataSource = courseModuleBll.GetModuleList(query);
            GridView_ModuleList.DataBind();
        }

        protected void GridView_ModuleList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        public string InviteUser(object moduleId)
        {
            if (moduleId != null)
            {
                if (!string.IsNullOrEmpty(moduleId.ToString()))
                {
                    int mid = int.Parse(moduleId.ToString());
                    Maticsoft.Accounts.Bus.User user = BLL.Tao.SendInvite.GetUNameByMid(mid);
                    if (user == null)
                    {
                        return "未邀请";
                    }
                    else
                    {
                        return user.TrueName;
                    }
                }
                else
                {
                    return "未邀请";
                }
            }
            else
            {
                return "未邀请";
            }
        }

        public string ModuleStatus(object Mid, object status)
        {
            if (Mid == null || status == null)
            {
                return "<div id='ele9' class='tigger' align='center'>" + getStatusStr(status.ToString()) + "</div>";
            }
            BLL.Tao.Modules mbll = new BLL.Tao.Modules();
            int mid = int.Parse(Mid.ToString());
            Model.Tao.Modules m = mbll.GetModel(mid);
            if (!string.IsNullOrEmpty(m.VideoContent))
            {
                return "<div id='ele9'  align='center'>" + getStatusStr(status.ToString()) + "</div>";
            }
            else
            {
                return "<div id='ele9' class='tigger' align='center'>" + getStatusStr(status.ToString()) + "</div>";
            }
        }

        protected void GridView_ModuleList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label labStatus = e.Row.FindControl("lblStatsu") as Label;
                LinkButton lb1 = e.Row.FindControl("LinkButton_Del") as LinkButton;
                if (labStatus != null && labStatus.Text == "2")
                {
                    lb1.Visible = false;
                }
                else
                {
                    lb1.Attributes.Add("onclick", " return confirm('确定要移除？')");
                }
                if (labStatus.Text == "-1")
                {
                }
            }
        }

        private bool isCreate;

        public bool IsCreate
        {
            get { return isCreate; }
            set { isCreate = value; }
        }

        protected void GridView_ModuleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataKey key = this.GridView_ModuleList.DataKeys[e.RowIndex];
            courseModuleBll.Delete((int)key[0], (int)key[1]);
            BindData((int)key[0]);
        }

        protected void GridView_ModuleList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent)); //此得出的值是表示那行被选中的索引值
            Label Label_Description = (Label)this.GridView_ModuleList.Rows[e.NewEditIndex].FindControl("lblDescription");
            Label Label_ModuleName = (Label)this.GridView_ModuleList.Rows[e.NewEditIndex].FindControl("lblModuleName");

            DataKey key = this.GridView_ModuleList.DataKeys[e.NewEditIndex];
            this.btnSava.CommandArgument = key[1].ToString();
            this.txtDescription.Text = Label_Description.Text;
            this.txtModuleName.Text = Label_ModuleName.Text;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.UserExp.UsersExp userExpBll = new BLL.UserExp.UsersExp();
            BLL.Tao.SendInvite inviteBll = new BLL.Tao.SendInvite();
            if (this.HiddenFieldRadio.Value == "0")
            {
                if (Session["UserInfo"] == null)
                {
                    Common.CommonCode.GoLoginPage();
                }
                Maticsoft.Accounts.Bus.User user = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];

                int iAddresseeId = userExpBll.GetUserIDByUserName(this.HiddenFieldUserName.Value);

                //新增站内信阅读信息
                BLL.Messages.ReceivedMessages receivedBll = new BLL.Messages.ReceivedMessages();
                Model.Messages.ReceivedMessages reveivedModel = new Model.Messages.ReceivedMessages();
                reveivedModel.AddresserId = user.UserID;
                reveivedModel.AddresseeId = iAddresseeId;
                reveivedModel.PublishContent = HiddenFieldtxtContent.Value;
                reveivedModel.PublishDate = DateTime.Now;
                reveivedModel.Title = "开课邀请";
                reveivedModel.LastTime = DateTime.Now;
                reveivedModel.IsRead = false;
                long iReslut = receivedBll.Add(reveivedModel);

                //新增站内信发送信息
                BLL.Messages.SendedMessages sendBll = new BLL.Messages.SendedMessages();
                Model.Messages.SendedMessages sendModel = new Model.Messages.SendedMessages();
                sendModel.AddresserId = user.UserID;
                sendModel.AddresseeId = iAddresseeId;
                sendModel.PublishContent = HiddenFieldtxtContent.Value;
                sendModel.PublishDate = DateTime.Now;
                sendModel.Title = "开课邀请";
                sendModel.ReceiveMessageId = iReslut;
                sendBll.Add(sendModel);

                Model.Tao.SendInvite inviteModel = new Model.Tao.SendInvite();
                inviteModel.ConstitutorID = int.Parse(this.HiddenField1.Value);
                inviteModel.InviteeID = iAddresseeId;
                inviteModel.InviteDate = DateTime.Now;
                inviteModel.InviteStatus = 0;
                inviteModel.ModuleID = int.Parse(this.HiddenField2.Value);
                if (inviteBll.Add(inviteModel) > 0)
                {
                    courseModuleBll.SendEmailSuccess(int.Parse(this.HiddenField2.Value), 1);
                    this.ErrorMsg.Visible = true;
                    this.ErrorMsg.Text = "邀请发送成功！";
                }
                else
                {
                    this.ErrorMsg.Visible = false;
                    this.ErrorMsg.Text = "邀请发送失败！";
                    return;
                }
            }
            else
            {
                int moduleId = int.Parse(this.HiddenField2.Value);
                int status = 1;
                if (courseModuleBll.SendEmailSuccess(moduleId, status))
                {
                    try
                    {
                        //l 给操作者发送邮件
                        string userMail = this.HiddenFieldUserEmail.Value;
                        string mailContent = this.HiddenFieldtxtEmailContent.Value;
                        string subject = "开课邀请";
                        Maticsoft.Common.MailSender.Send(userMail, subject, mailContent.ToString());
                    }
                    catch
                    {
                        this.ErrorMsg.Visible = false;
                        this.ErrorMsg.Text = "邀请发送失败！";
                        status = 0;
                        courseModuleBll.SendEmailSuccess(moduleId, status);
                        return;
                    }
                    this.ErrorMsg.Visible = true;
                    this.ErrorMsg.Text = "邀请发送成功！";
                    BindData(int.Parse(Request.QueryString["CourseId"]));
                }
                else
                {
                    this.ErrorMsg.Visible = false;
                    this.ErrorMsg.Text = "邀请发送失败！";
                    return;
                }
            }
        }

        public string getStatusStr(string status)
        {
            switch (status)
            {
                case "-1":
                    return "已上传";
                case "0":
                    return "发送邀请";
                case "1":
                case "3":
                    return "重新发送";
                case "2":
                    return "邀请已接收";
                default:
                    return "发送邀请";
            }
        }
    }
}