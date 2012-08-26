using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Maticsoft.Web.TaoModules
{
    public partial class List : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.Modules bll = new Maticsoft.BLL.Tao.Modules();
        public string strCourseID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                BindData();
            }
        }

        #region gridView

        public void BindData()
        {
            if (!string.IsNullOrEmpty(Request.Params["CourseID"]))
            {
                if (PageValidate.IsNumber(Request.Params["CourseID"]))
                {
                    strCourseID = Request.Params["CourseID"];

                    #region

                    //if (!Context.User.Identity.IsAuthenticated)
                    //{
                    //    return;
                    //}
                    //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    //if (user.HasPermissionID(PermId_Modify))
                    //{
                    //    gridView.Columns[6].Visible = true;
                    //}
                    //if (user.HasPermissionID(PermId_Delete))
                    //{
                    //    gridView.Columns[7].Visible = true;
                    //}

                    #endregion gridView

                    DataSet ds = new DataSet();
                    //StringBuilder strWhere = new StringBuilder();
                    //if (txtKeyword.Text.Trim() != "")
                    //{
                    //    strWhere.AppendFormat("ModuleName like '%{0}%'", txtKeyword.Text.Trim());
                    //}
                    //Status=-1查询全部章节
                    ds = bll.GetList(int.Parse(Request.Params["CourseID"]), -1);
                    gridView.DataSource = ds;
                    gridView.DataBind();
                }

                if (!string.IsNullOrEmpty(Request.Params["type"]))
                {
                    this.ddlStatus.Visible = false;
                    this.btnUpdate.Visible = false;
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            bll.Delete(ID);
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

        #endregion

        private void UpdateStatus(int Status)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            string strWhere = "";
            switch (Status)
            {
                //状态：0:未完成,1:完成待审核,2:审核通过,3:审核未通过,4:发布上架;5:下架
                case 0:
                    strWhere = " Status=" + 0;
                    break;

                case 1:
                    strWhere = " Status=" + 1;
                    break;

                case 2:
                    strWhere = " Status=" + 2;
                    break;

                case 3:
                    strWhere = " Status=" + 3;
                    break;

                case 4:
                    strWhere = " Status=" + 4;
                    break;

                case 5:
                    strWhere = " Status=" + 5;
                    break;
                default:
                    strWhere = "";
                    break;
            }

            bll.UpdateList(idlist, strWhere);
            Maticsoft.Common.MessageBox.Show(this, Resources.Site.TooltipUpdateOK);
            gridView.OnBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ddlStatus.SelectedValue))
            {
                if (PageValidate.IsNumber(this.ddlStatus.SelectedValue))
                {
                    UpdateStatus(int.Parse(this.ddlStatus.SelectedValue));
                }
            }
        }
    }
}