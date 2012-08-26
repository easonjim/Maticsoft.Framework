using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Tao.ApproveType
{
    public partial class Show : Page
    {
        private Maticsoft.BLL.Tao.ApproveType bll = new Maticsoft.BLL.Tao.ApproveType();
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    if (PageValidate.IsNumber(Request.Params["id"]))
                    {
                        strid = Request.Params["id"];
                        ShowInfo(int.Parse(strid));
                    }
                }
            }
        }

        private void ShowInfo(int ID)
        {
            Maticsoft.Model.Tao.ApproveType model = bll.GetModel(ID);
            if (null != model)
            {
                this.lblID.Text = model.ID.ToString();
                this.lblApproveName.Text = model.ApproveName;
            }
        }
    }
}