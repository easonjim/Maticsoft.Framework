using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class IndexHotCourse : System.Web.UI.UserControl
    {
        BLL.Tao.Courses courseBll = new BLL.Tao.Courses();
        private string _andStr;

        public string AndStr
        {
            get { return _andStr; }
            set { _andStr = value; }
        }

        public override void DataBind()
        {
            DataSet ds = courseBll.GetHotCourse(AndStr);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                this.Repeater_Hot.DataSource = ds;
                this.Repeater_Hot.DataBind();
            }
        }

        protected void Repeater_Hot_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label labName = (Label)(e.Item.FindControl("labName"));
                object objNum = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[0];
                object objName = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[2];
                object objId = ((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[1];

                string EndName = string.Empty;
                if (objName.ToString().Length >= 7)
                {
                    EndName = objName.ToString().Substring(0, 6) + "...";
                }
                else
                {
                    EndName = objName.ToString();
                }
                labName.Text = "<a href=\"/Videoshow.aspx?id=" + objId + "\" title=\"" + objName + "\"> <div class=\"oLleft" + objNum + "\">" + EndName + "</div></a>";
            }
        }
    }
}