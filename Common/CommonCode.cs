using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;

namespace Maticsoft.Common
{
    public static class CommonCode
    {
        public static void ShowMessage(System.Web.UI.Page page, string msg)
        {
            msg = msg.Replace("'", "").Replace("\"", "").Replace("\r", "").Replace("\n", "");

            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(),
                string.Format("alert('{0}');", msg), true);
        }


        public static string Md5Compute(string txt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            //返回的这个数组长度一定是16
            byte[] hashBytes = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                //把第i个字节转化成    X表示转化成16进制   2表示转化成两位,如果不足两位前面补0
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }


        /// <summary>
        /// 检测用户是否登录,如果登录返回true,否则返回false
        /// </summary>
        /// <returns></returns>
        public static bool CheckUserLogin()
        {

            if (HttpContext.Current.Session["UserInfo"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GoLoginPage()
        {
            HttpResponse Response = HttpContext.Current.Response;
            HttpRequest Request = HttpContext.Current.Request;

            Response.Redirect("/login.aspx?return=" + Request.Url.ToString());
        }

        #region 清除HTML标记
        ///<summary>   
        ///清除HTML标记   
        ///</summary>   
        ///<param name="NoHTML">包括HTML的源码</param>   
        ///<returns>已经去除后的文字</returns>   
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML   
            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            Htmlstring = regex.Replace(Htmlstring, "");
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            return Htmlstring;
        }
        #endregion

        #region 生成Json数据

        #region Datatable转换为Json
        /// <summary>    
        /// Datatable转换为Json    
        /// </summary>    
        /// <param name="table">Datatable对象</param>    
        /// <returns>Json字符串</returns>    
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        #endregion

        #region 格式化字符型、日期型、布尔型
        /// <summary>   
        /// 格式化字符型、日期型、布尔型   
        /// </summary>   
        /// <param name="str"></param>   
        /// <param name="type"></param>   
        /// <returns></returns>   
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            return str;
        }
        #endregion

        #region 过滤特殊字符
        /// <summary>   
        /// 过滤特殊字符   
        /// </summary>   
        /// <param name="s"></param>   
        /// <returns></returns>   
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    //case '\"':
                    //    sb.Append("\\\""); break;
                    //case '\\':
                    //    sb.Append("\\\\"); break;
                    //case '/':
                    //    sb.Append("\\/"); break;
                    //case '\b':
                    //    sb.Append("\\b"); break;
                    //case '\f':
                    //    sb.Append("\\f"); break;
                    //case '\n':
                    //    sb.Append("\\n"); break;
                    //case '\r':
                    //    sb.Append("\\r"); break;
                    //case '\t':
                    //    sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        #endregion
        #endregion
    }
}
