﻿namespace Maticsoft.Web.Controls
{
    using System.Web;
    using System.Web.UI;

    public class DeleteImageLinkButton : ImageLinkButton
    {
        private string deleteMsg = string.Empty;

        protected override void Render(HtmlTextWriter writer)
        {
            string globalResourceObject = string.Empty;
            if (string.IsNullOrEmpty(this.DeleteMsg))
            {
                globalResourceObject = (string)HttpContext.GetGlobalResourceObject("Resources", "IDS_Button_Confirm_Text");
            }
            else
            {
                globalResourceObject = this.DeleteMsg;
            }
            string str2 = string.Format("return   confirm('{0}');", globalResourceObject);
            base.Attributes.Add("OnClick", str2);
            base.Attributes.Add("name", this.NamingContainer.UniqueID + "$" + this.ID);
            base.Render(writer);
        }

        public string DeleteMsg
        {
            get
            {
                return this.deleteMsg;
            }
            set
            {
                this.deleteMsg = value;
            }
        }
    }
}