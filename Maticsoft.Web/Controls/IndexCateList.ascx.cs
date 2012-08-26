using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class IndexCateList : System.Web.UI.UserControl
    {
        private int _catrId;

        public int CatrId
        {
            get { return _catrId; }
            set { _catrId = value; }
        }

        BLL.Tao.Courses courseBll = new BLL.Tao.Courses();

        public override void DataBind()
        {
            this.AspNetPager1.RecordCount = courseBll.IndexListCount(CatrId);
            InitData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            DataSet ds = courseBll.GetIndexList(AspNetPager1.StartRecordIndex, AspNetPager1.PageSize, CatrId);
            if (ds != null)
            {
                this.Repeater_Last.DataSource = ds;
                this.Repeater_Last.DataBind();
            }
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
                    return "未知";
                }
            }
            else
            {
                return "未知";
            }
        }

        public string SubCourseName(object OldName)
        {
            if (OldName != null)
            {
                string EndName = string.Empty;
                if (OldName.ToString().Length >= 13)
                {
                    EndName = OldName.ToString().Substring(0, 12) + "...";
                    return EndName;
                }
                else
                {
                    return OldName.ToString();
                }
            }
            else
            {
                return "未知课程名";
            }
        }
    }
}