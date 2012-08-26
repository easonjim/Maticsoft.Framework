using System;
using Maticsoft.Common;

namespace Maticsoft.BLL
{
    /// <summary>
    /// PubConstant 的摘要说明。
    /// </summary>
    public class PubConstant
    {
        public static string GetConstantConfig()
        {
            string CacheKey = "IsKeysReg";
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    string iskeyreg = Maticsoft.Common.ConfigHelper.GetConfigString("IsKeysReg");
                    int CacheTime = Maticsoft.Common.ConfigHelper.GetConfigInt("CacheTime");
                    DataCache.SetCache(CacheKey, iskeyreg, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                }
                catch
                { }
            }
            return objModel.ToString();
        }
    }
}