using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.Admin.TaoCategories
{
    public partial class Modify : PageBaseAdmin
    {
        private BLL.Tao.Categories CateBll = new BLL.Tao.Categories();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["CategoryId"]))
                {
                    BiudTree();
                    int CategoryId = (Convert.ToInt32(Request.Params["CategoryId"]));
                    this.hfCategoryId.Value = Request.Params["CategoryId"];

                    ShowInfo(CategoryId);
                }
            }

            AjaxPro.Utility.RegisterTypeForAjax(typeof(Maticsoft.Web.Admin.TaoCategories.Modify));
        }

        private void ShowInfo(int CategoryId)
        {
            Model.Tao.Categories CateModel = CateBll.GetModel(CategoryId);
            if (CateModel != null)
            {
                this.txtCategoryName.Text = CateModel.Name;
                this.listTarget.SelectedValue = CateModel.ParentCategoryId.ToString();
                this.txtRewriteName.Text = CateModel.RewriteName;
                this.txtPageDesc.Text = CateModel.Description;
                if (CateModel.IconUrl != null)
                {
                    this.hlkDeleteIco.Visible = true;
                }
                else
                {
                    this.hlkDeleteIco.Visible = false;
                }
            }
        }

        #region DropDpwnListTree

        private void BiudTree()
        {
            BLL.Tao.Categories CateBll = new BLL.Tao.Categories();
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

        public void btnSave_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.Tao.Categories CateBll = new Maticsoft.BLL.Tao.Categories();
            Model.Tao.Categories CateModel = new Model.Tao.Categories();
            CateModel.Name = this.txtCategoryName.Text;
            CateModel.Description = txtPageDesc.Text;
            //修改之前先删除以前的ICO
            int CategoryId = (Convert.ToInt32(Request.Params["CategoryId"]));
            CateModel.CategoryId = CategoryId;
            Model.Tao.Categories Val = CateBll.GetModel(CategoryId);
            if (Val.IconUrl != null)
            {
                HiUploader.DeleteImage(Val.IconUrl);
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
            CateBll.UpdateCategory(CateModel);
            Response.Redirect("list.aspx");
        }

        [AjaxPro.AjaxMethod]
        public void DeleteIco(int CategoryId)
        {
            BLL.Tao.Categories CateBll = new BLL.Tao.Categories();
            Model.Tao.Categories Val = CateBll.GetModel(CategoryId);
            if (Val.IconUrl != null)
            {
                HiUploader.DeleteImage(Val.IconUrl);
                CateBll.UpdateImgURL(CategoryId.ToString());
            }
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}