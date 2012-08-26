using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class AccountsList : System.Web.UI.UserControl
    {
        BLL.Tao.TradeDetails tradeBll = new BLL.Tao.TradeDetails();
        public override void DataBind()
        {
            if (Flag)
            {
                AspNetPager1.RecordCount = tradeBll.CurrentMonthRecord(UserID);
                Binddata(WheresStr);
            }
            else
            {
                AspNetPager1.RecordCount = tradeBll.AllMonthRecord(UserID);
                Binddata(WheresStr);
            }
        }

        private void Binddata(string WheresStr)
        {
            decimal Balance = 0.0M;
            DataSet ds = tradeBll.GetTradeRecord(AspNetPager1.StartRecordIndex,AspNetPager1.PageSize,  UserID, WheresStr, out Balance);
            this.Resbalance = Balance;
            this.rpt_ThreeRecord.DataSource = ds;
            this.rpt_ThreeRecord.DataBind();
        }

        private bool _flag;
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        private decimal? _resbalance;

        public decimal? Resbalance
        {
            get { return _resbalance; }
            set { _resbalance = value; }
        }


        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string wheresStr;
        public string WheresStr
        {
            get { return wheresStr; }
            set { wheresStr = value; }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Binddata(WheresStr);
        }
    }
}