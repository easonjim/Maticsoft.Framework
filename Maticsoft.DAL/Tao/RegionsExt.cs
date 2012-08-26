using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class Regions
    {
        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPrivoceName()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TR.RegionId,RegionName FROM Tao_Regions TR ");
            strSql.Append("WHERE AreaId BETWEEN 1 AND 10 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据省份获取城市
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public static DataSet GetRegionName(string parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT RegionId,RegionName  ");
            strSql.Append("FROM Tao_Regions  ");
            strSql.Append("WHERE ParentId= " + parentID);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取读取父Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetParentId(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ParentId  ");
            strSql.Append("FROM Tao_Regions  ");
            strSql.Append("WHERE RegionId= " + id);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static int GetRegPath(int? regid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Depth FROM Tao_Regions ");
            strSql.Append("WHERE RegionId= " + regid.Value);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public DataSet GetDistrictByParentId(int iParentId)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT *  ");
            str.Append("FROM Tao_Regions  ");
            str.Append("WHERE ParentId= " + iParentId);
            return DbHelperSQL.Query(str.ToString());
        }

        public DataSet GetAllCityList()
        {
            string strSql = "SELECT * FROM Tao_Regions where Depth=2";
            return DbHelperSQL.Query(strSql);
        }

        public string GetPath(int regid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Path FROM Tao_Regions ");
            strSql.Append("WHERE RegionId= " + regid);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "0.";
            }
        }

        public string GetRegionNameByRID(int RID)
        {
            string path = GetPath(RID) + RID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Tao_Regions ");
            strSql.Append("WHERE RegionId in (" + path + ")");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            StringBuilder strReg = new StringBuilder();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    strReg.Append(dr["RegionName"].ToString());
                }
            }
            return strReg.ToString();
        }

        public DataSet GetParentIDs(int regID, out int Count)
        {
            SqlParameter[] para = {
                                  new SqlParameter("@Region",SqlDbType.Int),
                                  new SqlParameter("@Count",SqlDbType.Int)
                                  };
            para[0].Value = regID;
            para[1].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("sp_Accounts_GetRegionID", para, "ds");
            Count = Convert.ToInt32(para[1].Value);
            return ds;
        }

        public DataSet GetPrivoces()
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM Tao_Regions  ");
            str.Append("WHERE Depth=1 ");
            return DbHelperSQL.Query(str.ToString());
        }
    }
}