using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin
{
    public partial class MLShow : PageBaseAdmin
    {
        Maticsoft.BLL.SysManage.MultiLanguage bllML = new Maticsoft.BLL.SysManage.MultiLanguage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                BindLanguage();

                if ((Request.Params["f"] != null) && (Request.Params["f"].ToString() != ""))
                {
                    if ((Request.Params["k"] != null) && (Request.Params["k"].ToString() != ""))
                    {
                        lblF.Text = Request.Params["f"];
                        lblK.Text = Request.Params["k"];
                        gridView.OnBind();
                    }                   
                }
                
            }
        }


        public void BindLanguage()
        {
            DataSet ds = bllML.GetLanguageListByCache();
            dropLanguage.DataSource = ds;
            dropLanguage.DataTextField = "Language_cName";
            dropLanguage.DataValueField = "Language_cCode";
            dropLanguage.DataBind();
        }

        public void btnAddMValue_Click(object sender, System.EventArgs e)
        {           
            try
            {
                if (txtMValue.Text.Length > 0)
                {
                    if (bllML.Exists(lblF.Text, Convert.ToInt32(lblK.Text), dropLanguage.SelectedValue))
                    {
                        lblML.Text = Resources.Site.TooltipDataExist;
                        return;
                    }
                    bllML.Add(lblF.Text, Convert.ToInt32(lblK.Text), dropLanguage.SelectedValue, txtMValue.Text);
                    txtMValue.Text = "";
                    gridView.OnBind();
                }
            }
            catch
            {
                lblML.Text = Resources.Site.TooltipSaveError;
            }
        }

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            ds = bllML.GetLangListByValue(lblF.Text,Convert.ToInt32(lblK.Text));
            gridView.DataSetSource = ds;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.OnBind();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object obj1 = DataBinder.Eval(e.Row.DataItem, "MultiLang_cLang");
                if ((obj1 != null) && ((obj1.ToString() != "")))
                {
                    e.Row.Cells[0].Text = bllML.GetLanguageNameByCache(obj1.ToString());
                }     
            }
        }
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            bllML.Delete(ID);
            gridView.OnBind();
        }
        
        #endregion


    }
}
