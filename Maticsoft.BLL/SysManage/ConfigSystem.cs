using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.Model.SysManage;
namespace Maticsoft.BLL.SysManage
{
    /// <summary>
    /// 系统参数配置
    /// </summary>
    public class ConfigSystem
    {
        private static Maticsoft.DAL.SysManage.ConfigSystem dal = new DAL.SysManage.ConfigSystem();

        #region  Method

        /// <summary>
        /// Whether there is Exists
        /// </summary>
        public static bool Exists(string Keyname)
        {
            return dal.Exists(Keyname);
        }

        /// <summary>
        /// Add a record
        /// </summary>
        public static int Add(string Keyname, string Value, string Description)
        {
            return dal.Add(Keyname,Value,Description);
        }

        public static void Update(int ID, string Keyname, string Value, string Description)
        {
            dal.Update(ID, Keyname, Value, Description);
        }

        /// <summary>
        /// Update a record
        /// </summary>
        public static void Update(string Keyname, string Value, string Description)
        {
            dal.Update(Keyname, Value, Description);
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public static void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        public static string GetValue(int ID)
        {
            return dal.GetValue(ID);
        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public static string GetValue(string Keyname)
        {
            return dal.GetValue(Keyname);
        }

        /// <summary>
        ///  Get an object entity，From cache
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public static string GetValueByCache(string Keyname)
        { 
            Hashtable ht=GetHashListByCache();
            return ht[Keyname].ToString();
        }

        /// <summary>
        ///  Get an object entity for INT，From cache
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public static int GetIntValueByCache(string Keyname)
        {
            Hashtable ht = GetHashListByCache();
            return Convert.ToInt32(ht[Keyname]);
        }

        /// <summary>
        ///  Get an object entity for bool，From cache
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public static bool GetBoolValueByCache(string Keyname)
        {
            Hashtable ht = GetHashListByCache();
            return Convert.ToBoolean(ht[Keyname]);
        }

        /// <summary>
        ///  Get an object entity for bool，From cache
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public static decimal GetDecimalValueByCache(string Keyname)
        {
            Hashtable ht = GetHashListByCache();
            return Convert.ToDecimal(ht[Keyname]);
        }

        /// <summary>
        /// Get an object list
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetHashList()
        {
            DataSet ds = dal.GetList("");
            Hashtable ht = new Hashtable();
            if ((ds.Tables.Count > 0) && (ds.Tables[0] != null))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string Keyname = dr["Keyname"].ToString();
                    string Value = dr["Value"].ToString();
                    ht.Add(Keyname, Value);
                }
            }
            return ht;
        }

        /// <summary>
        /// Get an object list，From the cache
        /// </summary>
        public static Hashtable GetHashListByCache()
        {
            string CacheKey = "ConfigSystemHashList";
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetHashList();
                    if (objModel != null)
                    {
                        int CacheTime = Maticsoft.Common.ConfigHelper.GetConfigInt("CacheTime");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Hashtable)objModel;
        }
        
        

        /// <summary>
        /// Query data list
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        #endregion  Method

    }
}
