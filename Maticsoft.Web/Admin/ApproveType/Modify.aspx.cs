using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Tao.ApproveType
{
    public partial class Modify : Page
    {
        private Maticsoft.BLL.Tao.ApproveType bll = new Maticsoft.BLL.Tao.ApproveType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    if (PageValidate.IsNumber(Request.Params["id"]))
                    {
                        int ID = (Convert.ToInt32(Request.Params["id"]));
                        ShowInfo(ID);
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
                this.txtApproveName.Text = model.ApproveName;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lblID.Text))
            {
                if (PageValidate.IsNumber(this.lblID.Text))
                {
                    Maticsoft.Model.Tao.ApproveType model = new Maticsoft.Model.Tao.ApproveType();
                    model.ID = int.Parse(this.lblID.Text);
                    model.ApproveName = this.txtApproveName.Text;
                    bll.Update(model);
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");
                }
            }
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}