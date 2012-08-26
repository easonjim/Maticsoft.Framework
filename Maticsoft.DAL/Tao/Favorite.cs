using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:Favorite
    /// </summary>
    public partial class Favorite
    {
        public Favorite()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("FavoriteID", "Tao_Favorite");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FavoriteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Favorite");
            strSql.Append(" where FavoriteID=@FavoriteID");
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4)
};
            parameters[0].Value = FavoriteID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Favorite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_Favorite(");
            strSql.Append("CourseID,ModuleID,UserID,Tags,Remark)");
            strSql.Append(" values (");
            strSql.Append("@CourseID,@ModuleID,@UserID,@Tags,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Tags;
            parameters[4].Value = model.Remark;

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
        public bool Update(Maticsoft.Model.Tao.Favorite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Favorite set ");
            strSql.Append("CourseID=@CourseID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Tags=@Tags,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where FavoriteID=@FavoriteID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@FavoriteID", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Tags;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.FavoriteID;

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
        public bool Delete(int FavoriteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Favorite ");
            strSql.Append(" where FavoriteID=@FavoriteID");
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4)
};
            parameters[0].Value = FavoriteID;

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
        public bool DeleteList(string FavoriteIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Favorite ");
            strSql.Append(" where FavoriteID in (" + FavoriteIDlist + ")  ");
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
        public Maticsoft.Model.Tao.Favorite GetModel(int FavoriteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FavoriteID,CourseID,ModuleID,UserID,Tags,Remark from Tao_Favorite ");
            strSql.Append(" where FavoriteID=@FavoriteID");
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4)
};
            parameters[0].Value = FavoriteID;

            Maticsoft.Model.Tao.Favorite model = new Maticsoft.Model.Tao.Favorite();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FavoriteID"] != null && ds.Tables[0].Rows[0]["FavoriteID"].ToString() != "")
                {
                    model.FavoriteID = int.Parse(ds.Tables[0].Rows[0]["FavoriteID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseID"] != null && ds.Tables[0].Rows[0]["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"] != null && ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tags"] != null && ds.Tables[0].Rows[0]["Tags"].ToString() != "")
                {
                    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select FavoriteID,CourseID,ModuleID,UserID,Tags,Remark ");
            strSql.Append(" FROM Tao_Favorite ");
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
            strSql.Append(" FavoriteID,CourseID,ModuleID,UserID,Tags,Remark ");
            strSql.Append(" FROM Tao_Favorite ");
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
            parameters[0].Value = "Tao_Favorite";
            parameters[1].Value = "FavoriteID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region NewMethod

        #region 是否存在该收藏记录

        /// <summary>
        /// 是否存在该收藏记录
        /// </summary>
        public bool ExistsFavorite(int courseID, int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Favorite");
            strSql.Append(" where CourseID=@CourseID and UserID=UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.Int,4)
};
            parameters[0].Value = courseID;
            parameters[1].Value = userID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #endregion 是否存在该收藏记录

        #region 取消收藏

        /// <summary>
        /// 取消收藏
        /// </summary>
        public bool DelFavorite(int courseID, int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Favorite ");
            strSql.Append(" where CourseID=@CourseID  and UserID=UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.Int,4)
};
            parameters[0].Value = courseID;
            parameters[1].Value = userID;
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

        #endregion 取消收藏

        #endregion NewMethod
    }
}