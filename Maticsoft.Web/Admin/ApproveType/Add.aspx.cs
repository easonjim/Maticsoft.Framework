using System;
using System.Web.UI;
using Maticsoft.Common;

namespace Maticsoft.Web.Tao.ApproveType
{
    public partial class Add : Page
    {
        private Maticsoft.BLL.Tao.ApproveType bll = new Maticsoft.BLL.Tao.ApproveType();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (bll.Exists(this.txtApproveName.Text))
            {
                strErr += "认证资料类型名称已存在！\\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            Maticsoft.Model.Tao.ApproveType model = new Maticsoft.Model.Tao.ApproveType();
            model.ApproveName = this.txtApproveName.Text;
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "List.aspx");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}