using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:Comment
    /// </summary>
    public partial class Comment
    {
        public Comment()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("CommentID", "Tao_Comment");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CommentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tao_Comment");
            strSql.Append(" where CommentID=@CommentID");
            SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.Int,4)
};
            parameters[0].Value = CommentID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tao_Comment(");
            strSql.Append("OrderID,CourseID,ModuleID,UserID,Comment,CommentDate,ParentID,Score,Status,Type)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@CourseID,@ModuleID,@UserID,@Comment,@CommentDate,@ParentID,@Score,@Status,@Type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Comment", SqlDbType.NVarChar),
					new SqlParameter("@CommentDate", SqlDbType.DateTime),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2),
                    new SqlParameter("@Type", SqlDbType.SmallInt,2)
                                        };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CourseID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.Comments;
            parameters[5].Value = model.CommentDate;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.Score;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Type;

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
        public bool Update(Maticsoft.Model.Tao.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tao_Comment set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("CourseID=@CourseID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Comment=@Comment,");
            strSql.Append("CommentDate=@CommentDate,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Score=@Score,");
            strSql.Append("Status=@Status");
            strSql.Append(" where CommentID=@CommentID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Comment", SqlDbType.NVarChar),
					new SqlParameter("@CommentDate", SqlDbType.DateTime),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2),
                    new SqlParameter("@CommentID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CourseID;
            parameters[2].Value = model.ModuleID;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.Comments;
            parameters[5].Value = model.CommentDate;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.Score;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.CommentID;

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
        public bool Delete(int CommentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Comment ");
            strSql.Append(" where CommentID=@CommentID");
            SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.Int,4)
};
            parameters[0].Value = CommentID;

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
        public bool DeleteList(string CommentIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tao_Comment ");
            strSql.Append(" where CommentID in (" + CommentIDlist + ")  ");
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
        public Maticsoft.Model.Tao.Comment GetModel(int CommentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CommentID,OrderID,CourseID,ModuleID,UserID,Comment,CommentDate,ParentID,Score,Status from Tao_Comment ");
            strSql.Append(" where CommentID=@CommentID");
            SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.Int,4)
};
            parameters[0].Value = CommentID;

            Maticsoft.Model.Tao.Comment model = new Maticsoft.Model.Tao.Comment();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CommentID"] != null && ds.Tables[0].Rows[0]["CommentID"].ToString() != "")
                {
                    model.CommentID = int.Parse(ds.Tables[0].Rows[0]["CommentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
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
                if (ds.Tables[0].Rows[0]["Comment"] != null && ds.Tables[0].Rows[0]["Comment"].ToString() != "")
                {
                    model.Comments = ds.Tables[0].Rows[0]["Comment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CommentDate"] != null && ds.Tables[0].Rows[0]["CommentDate"].ToString() != "")
                {
                    model.CommentDate = DateTime.Parse(ds.Tables[0].Rows[0]["CommentDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Score"] != null && ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = Int16.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            strSql.Append("select CommentID,OrderID,CourseID,ModuleID,UserID,Comment,CommentDate,ParentID,Score,Status ");
            strSql.Append(" FROM Tao_Comment ");
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
            strSql.Append(" CommentID,OrderID,CourseID,ModuleID,UserID,Comment,CommentDate,ParentID,Score,Status ");
            strSql.Append(" FROM Tao_Comment ");
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
            parameters[0].Value = "Tao_Comment";
            parameters[1].Value = "CommentID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region NewMethod

        /// <summary>
        /// 批量处理数据
        /// </summary>
        public bool UpdateList(string IDlist, string strWhere)
        {
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("update Tao_Comment set " + strWhere);
                strSql.Append(" where CommentID in (" + IDlist + ")");
                rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            }
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Tao_Comment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CommentID desc");
            }
            strSql.Append(")AS Row, T.*  from Tao_Comment T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion NewMethod
    }
}