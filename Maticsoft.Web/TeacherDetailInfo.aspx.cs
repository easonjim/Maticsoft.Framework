using System;
using System.Data;
using System.Linq;

namespace Maticsoft.Web
{
    public partial class TeacherDetailInfo : PageBase
    {
        private BLL.UserExp.UsersExp userBll = new BLL.UserExp.UsersExp();
        public string sexStr = string.Empty;
        public string isTrueName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    int uid = int.Parse(Request.QueryString["uid"]);
                    InitData(uid);
                    BoundData(uid);
                }
            }
        }

        private void BoundData(int uid)
        {
            this.CourseView1.UserID = uid;
            this.CourseView1.Status = 3;
            this.CourseView1.TeacherName = litName.Text;
            this.CourseView1.CourseTypes = 0;
            this.CourseView1.DataBind();
        }

        private void InitData(int uid)
        {
            System.Data.DataSet ds = userBll.GetUserExpModel(uid);
            if (null != ds && 0 != ds.Tables.Count && 0 != ds.Tables[0].Rows.Count && 0 != ds.Tables[0].Columns.Count)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["TeachDescription"] != null)
                    {
                        this.litDescrit.Text = dr["TeachDescription"].ToString();
                    }
                    if (dr["Tags"] != null)
                    {
                        this.labTag.Text = SplitTag(dr["Tags"].ToString());
                    }
                    this.imgGravatar.Src = dr["UserAvatar"].ToString();
                    this.litName.Text = dr["TrueName"].ToString();
                    if (dr["Sex"].ToString().Trim().Equals("F"))
                    {
                        sexStr = "<img src=\"images/female.png\" title=\"女\" class=\"nameyes\"/>";
                    }
                    else if (dr["Sex"].ToString().Trim().Equals("M"))
                    {
                        sexStr = "<img src=\"images/man.png\" title=\"男\" class=\"nameyes\"/>";
                    }
                    else
                    {
                        sexStr = "保密";
                    }
                    if (dr["UserRegionID"] != null)
                    {
                        if (!string.IsNullOrEmpty(dr["UserRegionID"].ToString()))
                        {
                            int regid = int.Parse(dr["UserRegionID"].ToString());
                            BLL.Tao.Regions regionbll = new BLL.Tao.Regions();
                            this.litProvice.Text = regionbll.GetRegionAllName(regid);
                        }
                        else
                        {
                            this.litProvice.Text = "未知";
                        }
                    }
                    else
                    {
                        this.litProvice.Text = "未知";
                    }
                    if (dr["UserHobby"] != null)
                    {
                        this.litHobby.Text = dr["UserHobby"].ToString();
                    }
                    if (dr["UserCareer"] != null)
                    {
                        this.litCareer.Text = dr["UserCareer"].ToString();
                    }
                    isTrueName = isIdCardApprove(uid);
                }
            }
            System.Data.DataSet dsUser = userBll.GetUserCertificate(uid, null, 1);
            System.Text.StringBuilder strAuthenticArray = new System.Text.StringBuilder();
            for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
            {
                strAuthenticArray.Append(dsUser.Tables[0].Rows[i]["ApproveName"].ToString());
                strAuthenticArray.Append("</br>");
            }
            this.litRz.Text = strAuthenticArray.ToString();
        }

        private string isIdCardApprove(int userid)
        {
            BLL.UserExp.UsersApprove userApprove = new BLL.UserExp.UsersApprove();
            int result = userApprove.GetIdCardApprove(userid);
            if (result.Equals(2))
            {
                return "<img src=\"images/yes.jpg\" class=\"nameyes\"/>";//通过实名认证
            }
            else
            {
                return "";// "<img src=\"\" class=\"nameyes\"/>";//未通过实名认证
            }
        }

        /// <summary>
        /// 分割标签
        /// </summary>
        private string SplitTag(string tagStr)
        {
            string[] strArr = null;
            if (!string.IsNullOrEmpty(tagStr))
            {
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
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}