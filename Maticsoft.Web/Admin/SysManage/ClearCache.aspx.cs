using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace Maticsoft.Web.Admin.SysManage
{
    public partial class ClearCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, System.EventArgs e)
        {
            IDictionaryEnumerator de = Cache.GetEnumerator();
            ArrayList list = new ArrayList();
            StringBuilder str = new StringBuilder();

            while (de.MoveNext())
            {
                list.Add(de.Key.ToString());
            }
            foreach (string key in list)
            {
                Cache.Remove(key);
                str.Append("<li>"+key + "......OK! <br>");
            }
            Label1.Text = "<br>" + str.ToString() + "<br>清除成功！";
        }
    }
}