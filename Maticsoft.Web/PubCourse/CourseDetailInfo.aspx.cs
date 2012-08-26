using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.PubCourse
{
    public partial class CourseDetailInfo : PageBaseUser
    {
        private BLL.Tao.Modules moduleBll = new BLL.Tao.Modules();
        private string courseType = string.Empty;
        public string CourseIdStr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ctypes"]))
            {
                courseType = Request.QueryString["ctypes"];
            }
            CourseIdStr = Request.Params["CourseId"];
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(CourseIdStr))
                {
                    return;
                }
                this.hfCid.Value = CourseIdStr;
                int Cid = int.Parse(CourseIdStr);
                InitData(Cid);
            }
        }

        private void InitData(int cid)
        {
            DataSet ds = moduleBll.getModuleInfo(CurrentUser.UserID, cid);
            this.Repeater_PubCourse.DataSource = ds;
            this.Repeater_PubCourse.DataBind();
            this.detailInfo.Visible = false;
        }

        protected void Repeater_PubCourse_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label labMid = e.Item.FindControl("labMId") as Label;
            Label labUid = e.Item.FindControl("labUid") as Label;
            if (labMid == null || labUid == null)
            {
                return;
            }
            int mid = int.Parse(labMid.Text);
            if (e.CommandArgument.Equals("Close"))
            {
                if (moduleBll.CloseModule(mid) > 0)
                {
                    int cid = int.Parse(this.hfCid.Value);
                    InitData(cid);
                }
            }
            if (e.CommandArgument.Equals("btnModify"))
            {
                if (courseType.Equals("1"))
                {
                    if (string.IsNullOrEmpty(labUid.Text)) return;
                    if (int.Parse(labUid.Text).Equals(CurrentUser.UserID))
                    {
                        this.txtPrice.Enabled = true;
                    }
                    else
                    {
                        this.txtPrice.Enabled = false;
                    }
                }
                this.detailInfo.Visible = true;
                this.labMod.Text = labMid.Text;
                Model.Tao.Modules module = moduleBll.GetModel(mid);
                this.txtModuleName.Text = module.ModuleName;
                this.txtContent.Text = module.Description;
                this.txtTags.Text = module.Tags;
                this.txtPrice.Text = module.Price.ToString();
            }
        }

        protected void Repeater_PubCourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label labUid = e.Item.FindControl("labUid") as Label;
                Button btnClose = e.Item.FindControl("btnClose") as Button;
                Button btnModify = e.Item.FindControl("btnEdit") as Button;
                object obj = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[4];
                if (obj == null)
                {
                    return;
                }
                if (labUid == null)
                {
                    return;
                }

                if (obj.ToString() == "5")
                {
                    btnClose.Visible = false;
                }
                if (courseType.Equals("0"))
                {
                    HtmlTableCell td = e.Item.FindControl("teach") as HtmlTableCell;
                    td.Visible = false;
                }
                if (courseType.Equals("1"))
                {
                    if (string.IsNullOrEmpty(labUid.Text)) return;
                    if (int.Parse(labUid.Text).Equals(CurrentUser.UserID))
                    {
                        btnModify.Visible = true;
                    }
                }
                if (courseType.Equals("2"))
                {
                    if (string.IsNullOrEmpty(labUid.Text)) return;
                    if (int.Parse(labUid.Text).Equals(CurrentUser.UserID))
                    {
                        btnModify.Visible = true;
                    }
                    else
                    {
                        btnModify.Visible = false;
                        btnClose.Visible = false;
                    }
                }
            }
        }

        public string addtd()
        {
            if (courseType.Equals("0"))
            {
                return "";
            }
            else
            {
                return "<td  align='center' valign='middle' class='a2'>参与老师</td>";
            }
        }

        public string ModuleDes(string desStr)
        {
            if (string.IsNullOrEmpty(desStr))
            {
                return "暂无简介";
            }
            else if (desStr.Length > 50)
            {
                return desStr.Substring(0, 50) + "...";
            }
            else
            {
                return desStr;
            }
        }

        public string SplitTag(string tagStr)
        {
            string[] strArr = null;
            if (tagStr.Contains("|"))
            {
                strArr = tagStr.Split('|');
                System.Text.StringBuilder strTags = new System.Text.StringBuilder();
                if (strArr != null)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        strTags.Append("#" + strArr[i] + "#</br>");
                    }
                }
                return strTags.ToString();
            }
            else if (string.IsNullOrEmpty(tagStr))
            {
                return "空";
            }
            else
            {
                return "#" + tagStr + "#";
            }
        }

        public string GetModuleStatus(object intValue)
        {
            if (intValue != null)
            {
                switch (intValue.ToString())
                {
                    case "0":
                        return "未发布";
                    case "1":
                        return "未审核";
                    case "2":
                        return "审核通过";
                    case "3":
                        return "已发布";
                    case "4":
                        return "审核未通过";
                    case "5":
                        return "已下架";
                    default:
                        return "错误的状态";
                }
            }
            else
            {
                return "错误的状态";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int mid = int.Parse(this.labMod.Text);
            Model.Tao.Modules moduleModel = moduleBll.GetModel(mid);
            moduleModel.ModuleName = this.txtModuleName.Text;
            moduleModel.Price = Convert.ToDecimal(this.txtPrice.Text);
            moduleModel.Tags = this.txtTags.Text;
            moduleModel.Description = this.txtContent.Text;
            if (moduleBll.UpdatePubCourseInfo(moduleModel))
            {
                this.detailInfo.Visible = false;
                int cid = int.Parse(this.hfCid.Value);
                InitData(cid);
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "保存失败！");
                this.detailInfo.Visible = false;
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            this.detailInfo.Visible = false;
        }
    }
}