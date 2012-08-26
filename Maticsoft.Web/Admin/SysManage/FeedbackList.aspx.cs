using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Text;

namespace Maticsoft.Web
{
    public partial class FeedbackList : PageBaseAdmin
    {

        Maticsoft.BLL.SysManage.SA_Feedback bll = new BLL.SysManage.SA_Feedback();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DeleteList)))
                {
                    btnDelete.Visible = false;
                }
                btnDelete.Attributes.Add("onclick", "return confirm(\"" + Resources.Site.TooltipDelConfirm + "\")");
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            bll.DeleteList(idlist);
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipDelOK);
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
                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridView.DataKeys[i].Value != null)
                    {
                        //idlist += gridView.Rows[i].Cells[1].Text + ",";
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }
        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();

            ds = bll.GetList(strWhere.ToString());
            gridView.DataSetSource = ds;
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
                object obj1 = DataBinder.Eval(e.Row.DataItem, "Feedback_cContent");
                if ((obj1 != null) && ((obj1.ToString() != "")))
                {
                    if (obj1.ToString().Length > 20)
                    {
                        e.Row.Cells[6].Text = obj1.ToString().Substring(0, 20);
                    }

                    object obj2 = DataBinder.Eval(e.Row.DataItem, "Feedback_cResult");
                    if ((obj2 != null) && ((obj2.ToString() != "")))
                    {
                        if (obj2.ToString().Length > 20)
                        {
                            e.Row.Cells[8].Text = obj2.ToString().Substring(0, 20);
                        }
                    }
                }
            }
        }
    }
}
