using System;

namespace Maticsoft.Web.Admin
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        public string _tabtitle = "";

        public string TabTitle
        {
            get
            {
                return _tabtitle;
            }
            set
            {
                _tabtitle = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}