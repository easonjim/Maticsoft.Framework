using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoCategories
{
    public partial class Add : PageBaseAdmin
    {
        private BLL.Tao.Categories CateBll = new BLL.Tao.Categories();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //得到现有菜单
                BiudTree();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string target = this.listTarget.SelectedValue;
            int parentid = int.Parse(target);
            Model.Tao.Categories CateModel = new Model.Tao.Categories();
            int path = CateBll.GetMaxId();
            CateModel.Name = this.txtCategoryName.Text;
            CateModel.Description = TextBox1.Text;
            if (parentid == 0)
            {
                CateModel.ParentCategoryId = 0;
            }
            else
            {
                CateModel.ParentCategoryId = Convert.ToInt32(this.listTarget.SelectedValue);
            }
            if (this.fileUpload.HasFile)
            {
                try
                {
                    CateModel.IconUrl = HiUploader.UploadCategoryImage(fileUpload.PostedFile);
                }
                catch
                {
                    return;
                }
            }
            CateBll.AddNewCate(CateModel);
            string selectVa = this.listTarget.SelectedValue;
            BiudTree();
            this.listTarget.SelectedValue = selectVa;
            MessageBox.Show(this, "保存成功！");
        }

        #region DropDpwnListTree

        private void BiudTree()
        {
            DataTable dt = CateBll.GetList("").Tables[0];

            this.listTarget.Items.Clear();
            //加载树
            this.listTarget.Items.Add(new ListItem("  ", "0"));
            DataRow[] drs = dt.Select("ParentCategoryId= " + 0);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryId"].ToString();
                string text = r["Name"].ToString();
                text = "╋" + text;
                this.listTarget.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";
                BindNode(sonparentid, dt, blank);
            }
            this.listTarget.DataBind();
        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentCategoryId= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryId"].ToString();
                string text = r["Name"].ToString();
                text = blank + "『" + text + "』";

                this.listTarget.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }

        #endregion DropDpwnListTree

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}