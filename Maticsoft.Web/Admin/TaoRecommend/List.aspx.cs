using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.TaoRecommend
{
    public partial class List : PageBaseAdmin
    {
        //int Act_ShowInvalid = -1; //查看失效数据行为

        private Maticsoft.BLL.Tao.Courses bll = new Maticsoft.BLL.Tao.Courses();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //btnDelete.Attributes.Add("onclick", "return confirm(\"" + Resources.Site.TooltipDelConfirm + "\")");
                //if (!UserPrincipal.HasPermissionID(GetPermidByActID(Act_DeleteList)))
                //{
                //    btnDelete.Visible = false;
                //}

                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                gridView.OnBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            bll.DeleteList(idlist);
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipDelOK);
            gridView.OnBind();
        }

        public string ConvertTimme(object time)
        {
            if (time != null)
            {
                if (!string.IsNullOrEmpty(time.ToString()))
                {
                    int timedur = int.Parse(time.ToString());
                    return BLL.ConvertTime.SecondToDateTime(timedur);
                }
                else
                {
                    return "未&nbsp;&nbsp;&nbsp;知";
                }
            }
            else
            {
                return "未&nbsp;&nbsp;&nbsp;知";
            }
        }

        public string GetRecomStatus(object status)
        {
            if (status != null)
            {
                if (status.ToString().Equals("True"))
                {
                    return "已推荐";
                }
                else
                {
                    return "未推荐";
                }
            }
            else
            {
                return "";
            }
        }

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            string strSelectValue = ddlSearch.SelectedValue;
            if (!string.IsNullOrEmpty(strSelectValue))
            {
                switch (strSelectValue)
                {
                    case "-1":
                    case "0":
                        strWhere.AppendFormat(" Status=3 ");
                        break;

                    case "1":
                        strWhere.AppendFormat(" Status=3 AND Recommended=1");
                        break;

                    case "2":
                        strWhere.AppendFormat(" Status=3 AND Recommended=0");
                        break;
                    default:
                        break;
                }
            }
            ds = bll.GetList(strWhere.ToString());
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
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"" + Resources.Site.TooltipDelConfirm + "\")");
            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
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
                    if (gridView.DataKeys[i].Value != null)
                    {
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

        #endregion gridView

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlModfy.SelectedIndex > 0 && !string.IsNullOrEmpty(this.ddlModfy.SelectedValue))
            {
                int status = int.Parse(this.ddlModfy.SelectedValue);
                switch (status)
                {
                    case 0:
                        UpdateStatus(1, "Recommended");
                        break;

                    case 1:
                        UpdateStatus(0, "Recommended");
                        break;
                    default:
                        break;
                }
            }
        }

        private void UpdateStatus(int Status, string colum)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            bll.UpdateRecommendedList(idlist, Status, colum);
            gridView.OnBind();
        }
    }
}