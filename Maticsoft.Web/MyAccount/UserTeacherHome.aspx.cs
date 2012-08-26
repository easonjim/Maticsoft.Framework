using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserTeacherHome : PageBaseUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hfCid.Value = CurrentUser.UserID.ToString();
                InitData();
            }
        }

        private void InitData()
        {
            BLL.UserExp.UsersExp userBll = new BLL.UserExp.UsersExp();
            DataSet dsUserExp = userBll.GetUserExpModel(CurrentUser.UserID);
            if (dsUserExp != null && dsUserExp.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsUserExp.Tables[0].Rows[0];
                this.lblUserName.InnerText = dr["TrueName"].ToString();
                if (dr["UserAvatar"] != null && dr["UserAvatar"].ToString().Length > 3)
                {
                    this.imgGravatar.Src = dr["UserAvatar"].ToString();
                }

                if (dr["UserRegionID"] != null)
                {
                    int rid = Common.Globals.SafeInt(dr["UserRegionID"].ToString(), 0);
                    BLL.Tao.Regions regionbll = new BLL.Tao.Regions();
                    this.litProvice.Text = regionbll.GetRegionAllName(rid);
                }

                this.lblIntroduction.Text = HttpUtility.HtmlEncode(dr["TeachDescription"].ToString());
                this.txtDesc.Text = dr["TeachDescription"].ToString();

                DataSet dsUser = userBll.GetUserCertificate(CurrentUser.UserID, null, 1);
                System.Text.StringBuilder strAuthenticArray = new System.Text.StringBuilder();
                for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
                {
                    strAuthenticArray.Append(dsUser.Tables[0].Rows[i]["ApproveName"].ToString());
                    strAuthenticArray.Append("</br>");
                }
                if (strAuthenticArray.Length > 0)
                {
                    this.lblCertificate.Text = HttpUtility.HtmlEncode(strAuthenticArray.ToString());
                    //imgYYZ.Visible = true;
                }
                else
                {
                    //imgYYZ.Visible = false;
                }

                if (dr["Tags"] != null && dr["Tags"].ToString().Length > 0)
                {
                    this.hyLabel.Text = HttpUtility.HtmlEncode(SplitTag(dr["Tags"].ToString()));
                }
                this.txtTag.Text = HttpUtility.HtmlEncode(dr["Tags"].ToString().Replace('|', ' '));
                this.txtDesc.Visible = false;
                this.btnCom.Visible = false;
                this.txtTag.Visible = false;
            }
        }

        /// <summary>
        /// 分割标签
        /// </summary>
        private string SplitTag(string tagStr)
        {
            string[] strArr = null;
            if (tagStr.Contains('|'))
            {
                strArr = tagStr.Split('|');
                System.Text.StringBuilder strTags = new System.Text.StringBuilder();
                if (strArr != null)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        strTags.Append("#" + strArr[i] + "#,");
                    }
                }
                return strTags.ToString().TrimEnd(',');
            }
            else
            {
                return "#" + tagStr + "#";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.lblIntroduction.Visible = false;
            this.txtDesc.Visible = true;
            this.btnEdit.Visible = false;
            this.txtTag.Visible = true;
            this.hyLabel.Visible = false;
            this.btnCom.Visible = true;
        }

        protected void btnCom_Click(object sender, EventArgs e)
        {
            BLL.UserExp.UsersExp userBll = new BLL.UserExp.UsersExp();
            this.lblIntroduction.Visible = true;
            this.btnCom.Visible = false;
            this.txtDesc.Visible = false;
            this.btnEdit.Visible = true;
            this.txtTag.Visible = false;
            this.hyLabel.Visible = true;
            string destription = this.txtDesc.Text;
            string tags = this.txtTag.Text.Replace(' ', '|');
            if (userBll.UpdateTeacher(destription, tags, CurrentUser.UserID))
            {
                Maticsoft.Common.MessageBox.ShowSuccessTip(this, "保存成功！");
                InitData();
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowFailTip(this, "系统忙，请稍后再试！");
            }
        }
    }
}