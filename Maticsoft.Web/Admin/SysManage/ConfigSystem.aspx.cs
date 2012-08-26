using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using Maticsoft.Common;
using System.Drawing;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin.SysManage
{
    public partial class ConfigSystem : PageBaseAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                gridView.OnBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {            
            if (txtKeyName.Text.Trim() == "")
            {
                lblToolTip.ForeColor = Color.Red;
                lblToolTip.Text = "KeyName不能为空!";
                return;
            }
            if (txtValue.Text.Trim() == "")
            {
                lblToolTip.ForeColor = Color.Red;
                lblToolTip.Text = "Value不能为空!";
                return;
            }

            Maticsoft.BLL.SysManage.ConfigSystem.Add(txtKeyName.Text.Trim(), txtValue.Text.Trim(), txtDescription.Text.Trim());
            lblToolTip.ForeColor = Color.Green;
            lblToolTip.Text = "添加成功!";
            gridView.OnBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        { }

        #region gridView

        public void BindData()
        { 
            DataSet ds = new DataSet();
            string strWhere = "";
            if (txtKeyWord.Text.Trim() != "")
            {
                strWhere = " KeyName = " + this.txtKeyWord.Text.Trim();
            }
            ds = Maticsoft.BLL.SysManage.ConfigSystem.GetList(strWhere);
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
            }
        }


        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            Maticsoft.BLL.SysManage.ConfigSystem.Delete(ID);
            gridView.OnBind();
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
        public void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gridView.DataKeys[e.RowIndex].Values[0].ToString();
            string keyname = (gridView.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox).Text;
            string Value = (gridView.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text;
            string Description = (gridView.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox).Text;
            
            if ((Value.Length ==0)||(Description.Length==0))
            {
                Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipNoNull);
                return;
            }

            Maticsoft.BLL.SysManage.ConfigSystem.Update(int.Parse(id),keyname,Value, Description);
            gridView.EditIndex = -1;
            gridView.OnBind();

        }
        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl(gridView.CheckBoxID);
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    if (gridView.Rows[i].Cells[8].Text != "")
                    {
                        idlist += gridView.Rows[i].Cells[8].Text + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
          
            return idlist;
        }

        
        #endregion



    }
}
