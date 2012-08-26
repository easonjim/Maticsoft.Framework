using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
using System.Drawing;
using Maticsoft.Accounts.Bus;
namespace Maticsoft.Web.Admin.Accounts.Admin
{
    public partial class UserAdmin : PageBaseAdmin
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
        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            string usertype = DropUserType.SelectedValue;           
            string keyword = "";
            if (txtKeyword.Text.Trim() != "")
            {
                keyword = txtKeyword.Text.Trim();
            }
            User userAdmin = new User();            
            if (usertype != "")
            {
                ds = userAdmin.GetUsersByType(usertype, keyword);
            }
            else
            {
                ds = userAdmin.GetUserList(keyword);
            }
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
                object obj1 = DataBinder.Eval(e.Row.DataItem, "EmployeeID");
                if ((obj1 != null) && ((obj1.ToString() != "")))
                {
                    //string EmployeeID = obj1.ToString().Trim();
                    //if (EmployeeID == "-1")
                    //{                        
                    //    e.Row.Cells[4].Text = "";
                    //}
                    //else
                    //{
                    //    e.Row.Cells[5].Text = EmployeeID;
                    //    //if (Maticsoft.Common.PageValidate.IsNumber(EmployeeID))
                    //    //{
                    //    //    e.Row.Cells[4].Text = GetEmpCode(int.Parse(EmployeeID));
                    //    //}
                    //}
                }
                         
            }
        }


        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = gridView.DataKeys[e.RowIndex].Value.ToString();            
            List<string> UserIDlist = Maticsoft.Common.StringPlus.GetStrArray(BLL.SysManage.ConfigSystem.GetValueByCache("AdminUserID"),',',true);
            if (UserIDlist.Contains(ID))
            {
                Maticsoft.Common.MessageBox.Show(this,"系统管理保留帐号，不能删除");
                return;
            }
            try
            {
                User User2 = new User(int.Parse(ID));
                User2.Delete();
                gridView.OnBind();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    Maticsoft.Common.MessageBox.Show(this, "该用户已被其他数据引用，不能删除！");                    
                }
            }
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

        #endregion




    }
}
