using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:CourseMaterial
    /// </summary>
    public partial class CourseMaterial
    {
        public CourseMaterial()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("MaterialID", "Tao_CourseMaterial");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MaterialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_CourseMaterial");
            strSql.Append(" where MaterialID=@MaterialID");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.Int,4)
};
            parameters[0].Value = MaterialID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.CourseMaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_CourseMaterial(");
            strSql.Append("CourseID,ModuleID,MaterialURL,Status,MaterialName)");
            strSql.Append(" values (");
            strSql.Append("@CourseID,@ModuleID,@MaterialURL,@Status,@MaterialName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@MaterialURL", SqlDbType.Text),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@MaterialName", SqlDbType.NVarChar,300),
                                        };
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.MaterialURL;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.Materialname;

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
        public bool Update(Maticsoft.Model.Tao.CourseMaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_CourseMaterial set ");
            strSql.Append("Materialname=@Materialname,");
            strSql.Append("CourseID=@CourseID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("MaterialURL=@MaterialURL,");
            strSql.Append("Status=@Status");
            strSql.Append(" where MaterialID=@MaterialID");
            SqlParameter[] parameters = {
                   new SqlParameter("@Materialname", SqlDbType.NVarChar,50),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@MaterialURL", SqlDbType.Text),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@MaterialID", SqlDbType.Int,4)};
            parameters[0].Value = model.Materialname;
            parameters[1].Value = model.CourseID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.MaterialURL;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.MaterialID;

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
        public bool Delete(int MaterialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_CourseMaterial ");
            strSql.Append(" where MaterialID=@MaterialID");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.Int,4)
};
            parameters[0].Value = MaterialID;

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
        public bool DeleteList(string MaterialIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_CourseMaterial ");
            strSql.Append(" where MaterialID in (" + MaterialIDlist + ")  ");
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
        public Maticsoft.Model.Tao.CourseMaterial GetModel(int MaterialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MaterialID,MaterialName,CourseID,ModuleID,MaterialURL,Status from Tao_CourseMaterial ");
            strSql.Append(" where MaterialID=@MaterialID");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.Int,4)
};
            parameters[0].Value = MaterialID;

            Maticsoft.Model.Tao.CourseMaterial model = new Maticsoft.Model.Tao.CourseMaterial();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MaterialID"] != null && ds.Tables[0].Rows[0]["MaterialID"].ToString() != "")
                {
                    model.MaterialID = int.Parse(ds.Tables[0].Rows[0]["MaterialID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaterialName"] != null && ds.Tables[0].Rows[0]["MaterialName"].ToString() != "")
                {
                    model.Materialname = ds.Tables[0].Rows[0]["MaterialName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaterialURL"] != null && ds.Tables[0].Rows[0]["MaterialURL"].ToString() != "")
                {
                    model.MaterialURL = ds.Tables[0].Rows[0]["MaterialURL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            strSql.Append("select MaterialID,MaterialName,CourseID,ModuleID,MaterialURL,Status ");
            strSql.Append(" FROM Tao_CourseMaterial ");
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
            strSql.Append(" MaterialID,CourseID,ModuleID,MaterialURL,Status ");
            strSql.Append(" FROM Tao_CourseMaterial ");
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
            parameters[0].Value = "Tao_CourseMaterial";
            parameters[1].Value = "MaterialID";
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