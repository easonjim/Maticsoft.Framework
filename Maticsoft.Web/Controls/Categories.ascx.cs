using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Controls
{
    public partial class Categories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            if (CateId.HasValue)
            {
                InitDate(CateId.Value);
            }
            else
            {
                BindCate();
            }
        }

        private int? _cateId;

        public int? CateId
        {
            get { return _cateId; }
            set { _cateId = value; }
        }

        private void BindCate()
        {
            this.ddlCate0.DataSource = AjaxMethod.GetCate0(0);
            this.ddlCate0.DataTextField = "Name";
            this.ddlCate0.DataValueField = "CategoryId";
            this.ddlCate0.DataBind();
            this.ddlCate0.Items.Insert(0, new ListItem("请选择", ""));
            this.ddlCate0.Attributes.Add("onChange", "Cate1Result();");
            this.ddlCate1.Attributes.Add("onChange", "Cate2Result();");
        }

        private void InitDate(int cateId)
        {

            BLL.Tao.Categories cateBll = new BLL.Tao.Categories();
            Model.Tao.Categories model = cateBll.GetModel(cateId);
            if (model != null)
            {

                string[] cateArr = model.Path.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                switch (cateArr.Length)
                {
                    case 3:
                        InitFullCateInfo(cateId, cateArr, 3);
                        break;
                    case 2:
                        InitFullCateInfo(cateId, cateArr, 0);
                        break;
                    default:
                        break;
                }
            }
        }

        private void InitFullCateInfo(int cateId, string[] cateArr, int type)
        {
            int secId = int.Parse(cateArr[1]);
            int FirId = int.Parse(cateArr[0]);

            this.ddlCate0.DataSource = AjaxMethod.GetCate0(0);
            this.ddlCate0.DataTextField = "Name";
            this.ddlCate0.DataValueField = "CategoryId";
            this.ddlCate0.DataBind();
            ddlCate0.SelectedValue = cateArr[0];
            this.ddlCate0.Items.Insert(0, new ListItem("请选择", ""));
            this.ddlCate0.Attributes.Add("onChange", "Cate1Result();");
            this.ddlCate1.Attributes.Add("onChange", "Cate2Result();");


            if (ddlCate0.SelectedValue != "")
            {
                this.ddlCate1.DataSource = AjaxMethod.GetCate(FirId);
                this.ddlCate1.DataTextField = "Name";
                this.ddlCate1.DataValueField = "CategoryId";
                this.ddlCate1.DataBind();
                ddlCate1.SelectedValue = secId.ToString();
            }
            if (type > 0)
            {
                if (ddlCate1.SelectedValue != "")
                {
                    this.ddlCate2.DataSource = AjaxMethod.GetCate(secId);
                    this.ddlCate2.DataTextField = "Name";
                    this.ddlCate2.DataValueField = "CategoryId";
                    this.ddlCate2.DataBind();
                    ddlCate2.SelectedValue = cateId.ToString();
                }
            }
        }
    }
}