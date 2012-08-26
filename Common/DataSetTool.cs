using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.Common
{
    public class DataSetTool
    {
        /// <summary>
        /// 从DataSet获取所有行
        /// </summary>
        /// <returns></returns>
        public static DataRowCollection GetDataSetRows(DataSet ds)
        {            
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows;
            }
            else
            {
                return null;
            }
        }
    }
}
