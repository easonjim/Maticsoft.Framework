using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin.SysManage
{
    public partial class MultiLanguage : PageBaseAdmin
    {
        Maticsoft.BLL.SysManage.MultiLanguage bll = new Maticsoft.BLL.SysManage.MultiLanguage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindLanguage();
                gridView.OnBind();
            }
        }
               
        public void BindLanguage()
        {
            DataSet ds = bll.GetLanguageList();
            dropLanguage.DataSource = ds;
            dropLanguage.DataTextField = "Language_cName";
            dropLanguage.DataValueField = "Language_cCode";
            dropLanguage.DataBind();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtMultiLang_cField.Text.Length > 0) && (txtMultiLang_cValue.Text.Length > 0) && txtMultiLang_iPKValue.Text.Length>0)
             {
                 this.lbltip1.Text = Resources.Site.TooltipNoNull; // "Name not null！";
             }
             else
             {
                 string MultiLang_cField = txtMultiLang_cField.Text.Trim();
                 int MultiLang_iPKValue = Convert.ToInt32(txtMultiLang_iPKValue.Text.Trim());
                 string MultiLang_cValue = txtMultiLang_cValue.Text.Trim();
                 string lang = dropLanguage.SelectedValue;
                 bll.Add(MultiLang_cField, MultiLang_iPKValue, lang, MultiLang_cValue);
                 gridView.OnBind();
             }
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }
        #region gridView

        public void BindData()
        {
            #region
            //if (!Context.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    gridView.Columns[5].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[6].Visible = true;
            //}
            #endregion
            string strWhere = "";
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere = "MultiLang_cField like '%" + txtKeyword.Text.Trim() +
                    "%' or MultiLang_cValue like '%" + txtKeyword.Text.Trim() + "%'";               
            }
            DataSet ds = bll.GetList(strWhere);
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
                //object obj1 = DataBinder.Eval(e.Row.DataItem, "userid");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    int userid = Convert.ToInt32(obj1);
                //    Maticsoft.Accounts.Bus.User user = new User(userid);
                //    e.Row.Cells[3].Text = user.TrueName;
                //}              
            }
        }

        public void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            gridView.OnBind();
        }
        public void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            gridView.OnBind();
        }
        public void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gridView.DataKeys[e.RowIndex].Value != null)
            {
                int id = Convert.ToInt32(gridView.DataKeys[e.RowIndex].Value);
                bll.Delete(id);
                gridView.OnBind();
            }
        }

        public void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gridView.DataKeys[e.RowIndex].Values[0].ToString();
            string Description = ((TextBox)gridView.Rows[e.RowIndex].FindControl("TBDescription")).Text;
            if (Description == "")
            {
                Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipNoNull);
                return;
            }

            bll.Update(int.Parse(id), Description);            
            gridView.EditIndex = -1;
            gridView.OnBind();
        }

        #endregion                
    }
}
