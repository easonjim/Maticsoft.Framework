using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Jayrock.Json;
using Maticsoft.Common;
namespace Maticsoft.Web.AjaxHandle
{
    public class RegisterValidateHandler : IHttpHandler, IRequiresSessionState
    {
        public const string TAO_KEY_STATUS = "STATUS";
        public const string TAO_KEY_DATA = "DATA";

        public const string TAO_STATUS_SUCCESS = "SUCCESS";
        public const string TAO_STATUS_FAILED = "FAILED";
        public const string TAO_STATUS_ERROR = "ERROR";
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            string Action = Request.Params["action"];
            switch (Action)
            {
                case "CheckUser":
                    CheckUser(Request, Response);
                    break;
                case "CheckEmil":
                    CheckEmail(Request, Response);
                    break;
                case "getCitys":
                    getCitys(Request, Response);
                    break;
                case "getAreas":
                    getAreas(Request, Response);
                    break;
                case "CheckCode":
                    CheckCode(Request, Response);
                    break;
                case "ValidateEmail":
                    ValidateEmail(Request, Response);
                    break;
                default:
                    break;
            }
        }


        #region 充值检查邮箱
        /// <summary>
        /// 检查邮箱唯一性
        /// </summary>
        private void ValidateEmail(HttpRequest Request, HttpResponse Response)
        {
            JsonObject json = new JsonObject();
            if (!string.IsNullOrEmpty(Request.Params["Email"]) && !string.IsNullOrEmpty(Request.Params["Uid"]))
            {
                string Email = Request.Params["Email"];
                string strId = Request.Params["Uid"];
                int uid = Common.Globals.SafeInt(strId, -1);
                Maticsoft.Model.SysManage.Users model = new BLL.SysManage.Users().GetModel(uid);
                if (new BLL.SysManage.Users().ExistsByEmail(Email) && model.Email == Email)
                {
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_SUCCESS);
                }
                else if (new BLL.SysManage.Users().ExistsByEmail(Email) && model.Email != Email)
                {
                    json.Put(TAO_KEY_STATUS, "WARNING");
                }
                else
                {
                    json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
                }
            }
            else
            {
                json.Put(TAO_KEY_STATUS, TAO_STATUS_FAILED);
            }
            Response.Write(json.ToString());
        }
        #endregion

        #region 检查验证码是否输入正确
        /// <summary>
        /// 检查验证码是否输入正确
        /// </summary>
        private void CheckCode(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Params["InputCode"]))
            {
                string InputCode = Request.Params["InputCode"];
                object objCode = System.Web.HttpContext.Current.Session["CheckCode"];
                if (objCode != null)
                {
                    if (string.IsNullOrEmpty(objCode.ToString()))
                    {
                        Response.Write("FAILED");//验证码错误
                    }
                    if (objCode.ToString().ToLower() == InputCode.ToLower())
                    {
                        Response.Write("SUCCESS");//验证码错误正确
                    }
                    else
                    {
                        Response.Write("FAILED");//验证码错误
                    }
                }
                else
                {
                    Response.Write("SESSIONERROR");//验证码失效
                    Response.End();
                }
            }
            else
            {
                Response.Write("ERRORPARA");
                Response.End();
            }
        }
        #endregion

        #region 检查用户名唯一性
        /// <summary>
        /// 检查用户名唯一性
        /// </summary>
        private void CheckUser(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Params["UserName"]))
            {
                string UserName = Request.Params["UserName"];
                if (new Maticsoft.Accounts.Data.User().HasUser(UserName))
                {
                    Response.Write("COUNTREG");//已存在该用户名，不允许注册
                }
                else
                {
                    Response.Write("CANREG");//不存在该用户名，可以注册
                }
            }
            else
            {
                Response.Write("ERRORPARA");
            }
        }
        #endregion

        #region 检查邮箱唯一性
        /// <summary>
        /// 检查邮箱唯一性
        /// </summary>
        private void CheckEmail(HttpRequest Request, HttpResponse Response)
        {
            if (!string.IsNullOrEmpty(Request.Params["Email"]))
            {
                string Email = Request.Params["Email"];
                if (new BLL.SysManage.Users().ExistsByEmail(Email))
                {
                    Response.Write("COUNTREG");
                }
                else
                {
                    Response.Write("CANREG");
                }
            }
            else
            {
                Response.Write("ERRORPARA");
            }
        }
        #endregion

        #region 省市选择
        Maticsoft.BLL.Tao.Regions bll = new Maticsoft.BLL.Tao.Regions();
        private void getCitys(HttpRequest Request, HttpResponse Response)
        {
            int pid = Globals.SafeInt(Request.Params["ProvinceID"], 0);
            DataSet ds = bll.GetDisByParentId(pid);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string str = ToJson(ds);
                    Response.Write(str);
                }
                else
                {
                    Response.Write("");
                }
            }
            else
            {
                Response.Write("");
            }
        }

        private void getAreas(HttpRequest Request, HttpResponse Response)
        {
            int cid = Globals.SafeInt(Request.Params["CityID"], 0);
            DataSet ds = bll.GetDisByParentId(cid);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string str = ToJson(ds);
                    Response.Write(str);
                }
                else
                {
                    Response.Write("");
                }
            }
            else
            {
                Response.Write("");
            }
        }
        #endregion

        #region DataSet转换为Json
        /// <summary> 
        /// DataSet转换为Json 
        /// </summary> 
        /// <param name="dataSet">DataSet对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        #endregion

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
                    strValue = String.Format(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("'" + strValue + "',");
                    }
                    else
                    {
                        jsonString.Append("'" + strValue + "'");
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        #endregion
    }
}