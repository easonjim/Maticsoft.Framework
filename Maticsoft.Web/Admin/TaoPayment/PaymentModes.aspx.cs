using System;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Payment.BLL;
using Maticsoft.Payment.Configuration;
using Maticsoft.Web.Controls;

namespace Maticsoft.Web.Admin.TaoPayment
{
    public partial class PaymentModes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lkbDelectCheck.Click += new EventHandler(this.lkbDelectCheck_Click);
            this.grdPaymentMode.RowDataBound += new GridViewRowEventHandler(this.grdPaymentMode_RowDataBound);
            this.grdPaymentMode.RowDeleting += new GridViewDeleteEventHandler(this.grdPaymentMode_RowDeleting);
            this.grdPaymentMode.RowCommand += new GridViewCommandEventHandler(this.grdPaymentMode_RowCommand);
            if (!this.Page.IsPostBack)
            {
                grdPaymentMode.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                grdPaymentMode.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                this.BindData();
                CheckBoxColumn.RegisterClientCheckEvents(this.Page, this.Page.Form.ClientID);
            }
        }

        private void BindData()
        {
            this.grdPaymentMode.DataSource = PaymentModeManage.GetPaymentModes();
            this.grdPaymentMode.DataBind();
            CheckBoxColumn.RegisterClientCheckEvents(this.Page, this.Page.Form.ClientID);
        }

        private void grdPaymentMode_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
                string commandName = e.CommandName;
                if (commandName != null)
                {
                    if (!(commandName == "Fall"))
                    {
                        if (!(commandName == "Rise"))
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (rowIndex != this.grdPaymentMode.Rows.Count)
                        {
                            PaymentModeManage.DescPaymentMode((int)this.grdPaymentMode.DataKeys[rowIndex].Value);
                            this.BindData();
                        }
                        return;
                    }
                    if (rowIndex != 0)
                    {
                        PaymentModeManage.AscPaymentMode((int)this.grdPaymentMode.DataKeys[rowIndex].Value);
                        this.BindData();
                    }
                }
            }
        }

        private void grdPaymentMode_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.FindControl("lblGatawayType");
                if (label != null)
                {
                    GatewayProvider provider = PayConfiguration.GetConfig().Providers[label.Text.ToLower()] as GatewayProvider;
                    if (provider != null)
                    {
                        label.Text = provider.DisplayName;
                    }
                }
            }
        }

        private void grdPaymentMode_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (PaymentModeManage.DeletePaymentMode((int)this.grdPaymentMode.DataKeys[e.RowIndex].Value))
            {
                this.BindData();
                this.ShowMsg((string)HttpContext.GetGlobalResourceObject("PaymentModes", "IDS_Message_Delete_Success"), true);
            }
            else
            {
                this.ShowMsg((string)HttpContext.GetGlobalResourceObject("PaymentModes", "IDS_ErrorMessage_UnKownError"), false);
            }
        }

        private void lkbDelectCheck_Click(object sender, EventArgs e)
        {
            int num = 0;
            foreach (GridViewRow row in this.grdPaymentMode.Rows)
            {
                CheckBox box = (CheckBox)row.FindControl("checkboxCol");
                if (box.Checked && PaymentModeManage.DeletePaymentMode(Convert.ToInt32(this.grdPaymentMode.DataKeys[row.RowIndex].Value, CultureInfo.InvariantCulture)))
                {
                    num++;
                }
            }
            if (num == 0)
            {
                this.ShowMsg((string)HttpContext.GetGlobalResourceObject("PaymentModes", "IDS_ErrorMessage_No_Check"), false, true);
            }
            else
            {
                this.BindData();
                this.ShowMsg(string.Format(CultureInfo.InvariantCulture, (string)HttpContext.GetGlobalResourceObject("PaymentModes", "IDS_Message_Delete_Number"), new object[] { num }), true);
            }
        }

        protected virtual void ShowMsg(string msg, bool success)
        {
            this.ShowMsg(msg, success, false);
        }

        private void ShowMsg(string msg, bool success, bool isWarning)
        {
            this.statusMessage.Success = success;
            this.statusMessage.IsWarning = isWarning;
            this.statusMessage.Text = msg;
            this.statusMessage.Visible = true;
        }
    }
}