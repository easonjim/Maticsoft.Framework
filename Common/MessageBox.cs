using System;
using System.Text;
namespace Maticsoft.Common
{
   
    /// <summary>
    /// ��ʾ��Ϣ��ʾ�Ի���
    /// ����׿Խ	
    /// </summary>
    public class MessageBox
    {
        #region Method
        private MessageBox()
        {
        }
         
        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// �ؼ���� ��Ϣȷ����ʾ��
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            //Response.Write("<script>alert('�ʻ����ͨ��������ȥΪ��ҵ��ֵ��');window.location=\"" + pageurl + "\"</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');window.location=\"" + url + "\"</script>");


        }
        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���(��ҳ��)������ҳ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowAndRedirects(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript'defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

        /// <summary>
        /// ����Զ���ű���Ϣ
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="script">����ű�</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");

        } 
    #endregion

        #region NewMethod
        /// <summary>
        /// ��ʾ�Ѻõ���ʾ�Ի���,���趨����ʾ���ٺ�������,�Զ�����һ��ʱ��������
        /// ������ʾ��ʹ�ø÷���ǰҳ��������msgbox.css��msgbox.js
        /// </summary>
        /// <param name="page"></param>
        /// <param name="tip">��ʾ��Ϣ</param>
        /// <param name="type">ͼ������</param>
        public static void ZENGmsgboxShow(System.Web.UI.Page page, string tip, int type)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("<script language=\"javascript\" defer>ZENG.msgbox.show('{0}',{1});</script>", tip, type);
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", script.ToString());
        }

        /// <summary>
        /// ��ʾ�Ѻõ���ʾ�Ի���,�Զ�����ʾ���ٺ�������
        /// ��ܰ��ʾ��ʹ�ø÷���ǰҳ��������msgbox.css��msgbox.js
        /// </summary>
        /// <param name="page"></param>
        /// <param name="tip">��ʾ��Ϣ</param>
        /// <param name="type">ͼ������</param>
        /// <param name="timeout">���ٺ����˳�</param>
        public static void ZENGmsgboxShow(System.Web.UI.Page page, string tip, int type, int timeout)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("<script language=\"javascript\" defer>ZENG.msgbox.show('{0}',{1},{2});</script>", tip, type, timeout);
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", script.ToString());
        }
        
        /// <summary>
        /// ��ʾ��������æ��ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowServerBusyTip(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowServerBusyTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }

        /// <summary>
        /// ��ʾ�����ɹ���ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowSuccessTip(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowSuccessTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }

        /// <summary>
        /// ��ʾ����ʧ�ܵ���ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowFailTip(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowFailTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }

        /// <summary>
        /// ��ʾ���ڼ��ص���ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowLoadingTip(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowLoadingTip('" + msg + "');function jump(count){window.setTimeout(function(){count--;if(count>0){jump(count)}else{window.location.href=\"" + url + "\"}},1000)}jump(3);</script>");
        }

        /// <summary>
        /// ��ʾ��������æ��ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowServerBusyTip(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowServerBusyTip('" + msg + "');</script>");
        }

        /// <summary>
        /// ��ʾ�����ɹ���ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowSuccessTip(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowSuccessTip('" + msg + "');</script>");
        }

        /// <summary>
        /// ��ʾ����ʧ�ܵ���ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowFailTip(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowFailTip('" + msg + "');</script>");
        }

        /// <summary>
        /// ��ʾ���ڼ��ص���ʾ��Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowLoadingTip(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ShowLoadingTip('" + msg + "');</script>");
        }
        #endregion
	}
}
