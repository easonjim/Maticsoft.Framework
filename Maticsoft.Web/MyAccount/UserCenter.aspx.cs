using System;

namespace Maticsoft.Web.MyAccount
{
    public partial class UserCenter : PageBaseUser
    {
        private BLL.UserExp.UsersExp UserBll = new BLL.UserExp.UsersExp();
        private BLL.Tao.TradeDetails trderBll = new BLL.Tao.TradeDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
                BindData();
            }
        }

        private void BindData()
        {
            this.rpt_trade.DataSource = trderBll.GetTradeDetials(CurrentUser.UserID);
            this.DataBind();
        }

        private void InitData()
        {
            this.litName.Text = CurrentUser.UserName;
            System.Data.DataSet ds = UserBll.GetUserExpModel(CurrentUser.UserID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                object userAvatar = ds.Tables[0].Rows[0]["UserAvatar"];
                if (userAvatar != null)
                {
                    if (!string.IsNullOrEmpty(userAvatar.ToString()))
                    {
                        this.imgGravatar.Src = userAvatar.ToString();
                    }
                }
                else
                {
                    this.imgGravatar.Src = "/Images/tx.gif";
                }
            }
        }
    }
}