using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.Web.Components;

namespace Maticsoft.Web.TaoEntryForm
{
    public partial class List : PageBaseAdmin
    {
        private Maticsoft.BLL.Tao.EntryForm bll = new Maticsoft.BLL.Tao.EntryForm();

        //Maticsoft.BLL.SysManage.Users bllUsers = new Maticsoft.BLL.SysManage.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                //btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
                BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            bll.DeleteList(idlist);

            BindData();
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
            //    gridView.Columns[6].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[7].Visible = true;
            //}

            #endregion gridView

            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat(" UserName like '%{0}%'", txtKeyword.Text.Trim());
            }
            if (this.dropState.SelectedValue != "")
            {
                if (strWhere.Length > 0)
                {
                    strWhere.AppendFormat(" AND State={0} ", this.dropState.SelectedValue);
                }
                else
                {
                    strWhere.AppendFormat(" State={0} ", this.dropState.SelectedValue);
                }
            }
            ds = bll.GetList(strWhere.ToString());
            //ds = bll.GetList(strWhere.ToString(), UserPrincipal.PermissionsID, UserPrincipal.PermissionsID.Contains(GetPermidByActID(Act_ShowInvalid)));
            gridView.DataSetSource = ds;
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");

                //object obj1 = DataBinder.Eval(e.Row.DataItem, "Levels");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    e.Row.Cells[1].Text = obj1.ToString();
                //}
            }
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

        #region 获取处理状态

        /// <summary>
        /// 获取处理状态
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string GetState(object target)
        {
            string state = string.Empty;
            if (target != null)
            {
                if (!StringPlus.IsNullOrEmpty(target.ToString()))
                {
                    switch (target.ToString())
                    {
                        case "0":
                            state = "未处理";
                            break;

                        case "1":
                            state = "已处理";
                            break;
                        default:
                            break;
                    }
                }
            }
            return state;
        }

        #endregion 获取处理状态

        #region 获取性别信息

        /// <summary>
        /// 获取性别信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string GetSex(object target)
        {
            string state = string.Empty;
            if (target != null)
            {
                if (!StringPlus.IsNullOrEmpty(target.ToString()))
                {
                    switch (target.ToString().Trim())
                    {
                        case "0":
                            state = "女";
                            break;

                        case "1":
                            state = "男";
                            break;
                        default:
                            break;
                    }
                }
            }
            return state;
        }

        #endregion 获取性别信息

        #endregion

        public string GetRegionNameByRID(object target)
        {
            string regionName = "";
            if (null != target && "" != target.ToString())
            {
                string rid = target.ToString();
                if (PageValidate.IsNumber(rid))
                {
                    regionName = EntryFormProc.GetRegionNameByRID(int.Parse(rid));
                }
            }
            return regionName;
        }

        protected void btnBatch_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            if (!string.IsNullOrEmpty(this.dropType.SelectedValue) && PageValidate.IsNumber(this.dropType.SelectedValue))
            {
                if (bll.UpdateList(idlist, " State=" + this.dropType.SelectedValue))
                {
                    gridView.OnBind();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0) return;
            bll.DeleteList(idlist);
            Maticsoft.Common.MessageBox.ShowSuccessTip(this, Resources.Site.TooltipDelOK);
            gridView.OnBind();
        }
    }
}