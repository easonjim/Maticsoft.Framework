using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Maticsoft.Web
{
    public partial class shopcart : System.Web.UI.Page
    {
        private BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        private BLL.Tao.Modules moduleBll = new BLL.Tao.Modules();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Maticsoft.Common.MessageBox.Show(this, "请先登录！");
                Response.Redirect("NLogin.aspx?return=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
            if (!IsPostBack)
            {
                string CourseStr = Request.QueryString["CourseId"];
                string ModuleId = Request.QueryString["mid"];
                if (!string.IsNullOrEmpty(CourseStr))
                {
                    int cid = int.Parse(CourseStr);
                    this.hfCid.Value = CourseStr;
                    DataSet ds = courseBll.getShopCourseInfo(cid);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(ModuleId))
                            {
                                int mid = int.Parse(ModuleId);
                                this.hfMid.Value = ModuleId;
                                if (mid.Equals(0))
                                {
                                    labTotalMoney.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                                }
                                else
                                {
                                    labTotalMoney.Text = moduleBll.GetModulePrice(mid).ToString("0.00");
                                }
                            }
                            this.hfSellerId.Value = ds.Tables[0].Rows[0]["CreatedUserID"].ToString();
                            this.Repeater_Cart.DataSource = ds;
                            this.Repeater_Cart.DataBind();

                            Maticsoft.Accounts.Bus.User currentUser = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
                            this.hfUid.Value = currentUser.UserID.ToString();
                            this.hfEmail.Value = currentUser.Email;
                            this.hfUName.Value = currentUser.TrueName;
                        }
                    }
                }
                else
                {
                    Session["CurrentError"] = "参数错误";
                    Server.Transfer("~/ErrorPage.aspx");
                }
            }
        }

        protected void Repeater_Cart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater list = (Repeater)e.Item.FindControl("rptCarts");
                Label labCid = (Label)e.Item.FindControl("labCid");
                if (labCid == null)
                {
                    return;
                }
                int cid = int.Parse(labCid.Text);
                if (string.IsNullOrEmpty(this.hfMid.Value))
                {
                    return;
                }
                int mid = int.Parse(this.hfMid.Value);
                if (list != null && mid != 0)
                {
                    list.DataSource = moduleBll.GetModuleInfo(cid, mid);
                    list.DataBind();
                }
                else
                {
                    list.DataSource = moduleBll.GetModuleInfo(cid, null);
                    list.DataBind();
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //this.btnConfirm.Enabled = false;
            //if (Session["UserInfo"] == null)
            //{
            //    Maticsoft.Common.MessageBox.Show(this, "请先登录！");
            //    Response.Redirect("Login.aspx?return=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            //}
            //if (string.IsNullOrEmpty(this.labTotalMoney.Text))
            //{
            //    Maticsoft.Common.MessageBox.Show(this, "请重新选择课程");
            //    Response.Redirect("Login.aspx?return=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            //}
            //Maticsoft.Accounts.Bus.User currentUser = (Maticsoft.Accounts.Bus.User)Session["UserInfo"];
            //Model.Tao.Orders orderList = new Model.Tao.Orders();
            //orderList.BuyerID = currentUser.UserID;
            //orderList.Email = currentUser.Email;
            //orderList.Amount = decimal.Parse(this.labTotalMoney.Text);
            //orderList.UserName = currentUser.TrueName;
            //if (string.IsNullOrEmpty(this.hfSellerId.Value))
            //{
            //    Session["CurrentError"] = "错误的课程ID，请重新选择课程！";
            //    Server.Transfer("~/ErrorPage.aspx");
            //}
            //orderList.SellerID = int.Parse(this.hfSellerId.Value);
            //if (string.IsNullOrEmpty(this.hfCid.Value))
            //{
            //    Session["CurrentError"] = "错误的课程ID，请重新选择课程！";
            //    Server.Transfer("~/ErrorPage.aspx");
            //}
            //int cid = int.Parse(this.hfCid.Value);
            //BLL.Tao.Orders orderBll = new BLL.Tao.Orders();
            //if (string.IsNullOrEmpty(this.hfMid.Value))
            //{
            //    return;
            //}
            //int mid = int.Parse(this.hfMid.Value);
            //int OId = orderBll.CreateNewOrderInfo(orderList, cid, mid);
            //if (OId > 0)
            //{
            //    Response.Redirect("OrderConfirm.aspx?OrderId=" + OId);
            //}
            //else
            //{
            //    Maticsoft.Common.MessageBox.Show(this, "提交人数过多，请稍后再试！");
            //}
        }

        public string ConvertTimme(object time)
        {
            if (time != null)
            {
                if (!string.IsNullOrEmpty(time.ToString()))
                {
                    int timedur = int.Parse(time.ToString());
                    return BLL.ConvertTime.SecondToDateTime(timedur);
                }
                else
                {
                    return "未&nbsp;&nbsp;&nbsp;知";
                }
            }
            else
            {
                return "未&nbsp;&nbsp;&nbsp;知";
            }
        }
    }
}