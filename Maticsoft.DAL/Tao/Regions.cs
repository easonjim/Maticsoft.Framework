using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:Regions
    /// </summary>
    public partial class Regions
    {
        public Regions()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RegionId", "Tao_Regions");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RegionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Regions");
            strSql.Append(" where RegionId=@RegionId");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionId", SqlDbType.Int,4)
};
            parameters[0].Value = RegionId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Regions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_Regions(");
            strSql.Append("AreaId,ParentId,RegionName,DisplaySequence,Path,Depth)");
            strSql.Append(" values (");
            strSql.Append("@AreaId,@ParentId,@RegionName,@DisplaySequence,@Path,@Depth)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@RegionName", SqlDbType.NVarChar,100),
					new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,4000),
					new SqlParameter("@Depth", SqlDbType.Int,4)};
            parameters[0].Value = model.AreaId;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.RegionName;
            parameters[3].Value = model.DisplaySequence;
            parameters[4].Value = model.Path;
            parameters[5].Value = model.Depth;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Tao.Regions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Regions set ");
            strSql.Append("AreaId=@AreaId,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("RegionName=@RegionName,");
            strSql.Append("DisplaySequence=@DisplaySequence,");
            strSql.Append("Path=@Path,");
            strSql.Append("Depth=@Depth");
            strSql.Append(" where RegionId=@RegionId");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@RegionName", SqlDbType.NVarChar,100),
					new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,4000),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RegionId", SqlDbType.Int,4)};
            parameters[0].Value = model.AreaId;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.RegionName;
            parameters[3].Value = model.DisplaySequence;
            parameters[4].Value = model.Path;
            parameters[5].Value = model.Depth;
            parameters[6].Value = model.RegionId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RegionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Regions ");
            strSql.Append(" where RegionId=@RegionId");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionId", SqlDbType.Int,4)
};
            parameters[0].Value = RegionId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string RegionIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Regions ");
            strSql.Append(" where RegionId in (" + RegionIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Tao.Regions GetModel(int RegionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AreaId,RegionId,ParentId,RegionName,DisplaySequence,Path,Depth from Tao_Regions ");
            strSql.Append(" where RegionId=@RegionId");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionId", SqlDbType.Int,4)
};
            parameters[0].Value = RegionId;

            Maticsoft.Model.Tao.Regions model = new Maticsoft.Model.Tao.Regions();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AreaId"] != null && ds.Tables[0].Rows[0]["AreaId"].ToString() != "")
                {
                    model.AreaId = int.Parse(ds.Tables[0].Rows[0]["AreaId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegionId"] != null && ds.Tables[0].Rows[0]["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(ds.Tables[0].Rows[0]["RegionId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentId"] != null && ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegionName"] != null && ds.Tables[0].Rows[0]["RegionName"].ToString() != "")
                {
                    model.RegionName = ds.Tables[0].Rows[0]["RegionName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DisplaySequence"] != null && ds.Tables[0].Rows[0]["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(ds.Tables[0].Rows[0]["DisplaySequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AreaId,RegionId,ParentId,RegionName,DisplaySequence,Path,Depth ");
            strSql.Append(" FROM Tao_Regions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AreaId,RegionId,ParentId,RegionName,DisplaySequence,Path,Depth ");
            strSql.Append(" FROM Tao_Regions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Tao_Regions";
            parameters[1].Value = "RegionId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method
    }
}