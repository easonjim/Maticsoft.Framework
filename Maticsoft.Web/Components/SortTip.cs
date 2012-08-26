using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace Maticsoft.Web.Controls
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SortTip
    {
        private string _descImg = @"~/Images/down.JPG";
        private string _ascImg = @"~/Images/up.JPG";
        /// <summary>
        /// ������ʾͼƬ
        /// </summary>
        [
        Description("������ʾͼƬ"),
        Category("��չ"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue(""),
        NotifyParentProperty(true)
        ]
        public string DescImg
        {
            get
            {               
                return _descImg;
            }
            set
            {
                _descImg = value;
            }
        }
        /// <summary>
        /// ������ʾͼƬ
        /// </summary>
        [
        Description("������ʾͼƬ"),
        Category("��չ"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue(""),
        NotifyParentProperty(true)
        ]
        public string AscImg
        {
            get
            {
                return _ascImg;
            }
            set
            {
                _ascImg = value;
            }
        }

        public bool IsNotSet
        {
            get
            {
                return string.IsNullOrEmpty(AscImg) || string.IsNullOrEmpty(DescImg);
            }            
        }

    }
}
