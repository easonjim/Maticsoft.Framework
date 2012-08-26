using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class Comment
    {
        /// <summary>
        /// 对已选课程进行评论和评分
        /// </summary>
        public bool CourseComment(Model.Tao.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Tao_Comment ( CourseID, UserID, Comment, CommentDate, ParentID, Score) ");
            strSql.Append("VALUES(@CourseID,@UserID,@Comment,GETDATE(),-1,@Score) ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@CourseID",SqlDbType.Int),
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@Comment",SqlDbType.NVarChar),
                                        new SqlParameter("@Score",SqlDbType.Int)
                                        };
            parameters[0].Value = model.CourseID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Comments;
            parameters[3].Value = model.Score;
            int res = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetCourseMoule(int iCourseID, int iPageIndex, int iPageSize)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = {
					new SqlParameter("@PageIndex", DbType.Int32),
					new SqlParameter("@PageSize", DbType.Int32),
					new SqlParameter("@SqlPopulate", DbType.String)
                };
            parameters[0].Value = iPageIndex;
            parameters[1].Value = iPageSize;
            parameters[2].Value = GetCommentSql(iCourseID);

            using (IDataReader reader = DbHelperSQL.RunProcedure("sp_cc_CourseMouleComment_Get", parameters))
            {
                dt = ConverDataReaderToDataTable(reader);
            }
            return dt;
        }

        public int GetCommentCount(int iCourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) FROM Tao_Comment TC Left Join Accounts_Users AU On AU.UserID = TC.UserID where TC.CourseID = " + iCourseID);
            return Convert.ToInt32(DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0]);
        }

        public string GetCommentSql(int iCourseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TC.CommentID FROM Tao_Comment TC Left Join Accounts_Users AU On AU.UserID = TC.UserID where TC.CourseID = " + iCourseID + " Order By TC.CommentDate DESC");
            return strSql.ToString();
        }

        public static DataTable ConverDataReaderToDataTable(IDataReader reader)
        {
            if (reader == null)
            {
                return null;
            }
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            int fieldCount = reader.FieldCount;
            for (int i = 0; i < fieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }
            table.BeginLoadData();
            object[] values = new object[fieldCount];
            while (reader.Read())
            {
                reader.GetValues(values);
                table.LoadDataRow(values, true);
            }
            table.EndLoadData();
            return table;
        }

        public int CommentCount(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Count(1) ");
            strSql.Append("FROM Tao_Comment TC ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID=TC.UserID ");
            strSql.Append("LEFT JOIN Accounts_UsersExp AUE ON TC.UserID=AUE.UserID ");
            strSql.Append("WHERE CourseID=@CourseId ");
            SqlParameter[] parametes = {
                                       new SqlParameter("@CourseId",SqlDbType.Int)
                                       };
            parametes[0].Value = courseId;
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

        public DataSet GetCommentsInfo(int CourseId, int startIndex, int pagesize, int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM (SELECT ROW_NUMBER()OVER (ORDER BY CommentDate desc) AS RNum,* FROM ( ");
            strSql.Append("SELECT CommentID,CourseID,tc.UserID,TrueName,Comment, CommentDate,ParentID,AUE.UserAvatar ");
            strSql.Append("FROM Tao_Comment TC ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID=TC.UserID ");
            strSql.Append("LEFT JOIN Accounts_UsersExp AUE ON TC.UserID=AUE.UserID ");
            strSql.Append("WHERE CourseID=@CourseId ");
            if (ModuleID > 0)
            {
                strSql.Append(" and ModuleID=" + ModuleID);
            }
            strSql.Append(")A )AS TEMP	WHERE RNum  BETWEEN  @startIndex and @startIndex+@pagesize-1 ");
            SqlParameter[] parametes = {
                                       new SqlParameter("@CourseId",SqlDbType.Int),
                                       new SqlParameter("@startIndex",SqlDbType.Int),
                                       new SqlParameter("@pagesize",SqlDbType.Int)
                                       };
            parametes[0].Value = CourseId;
            parametes[1].Value = startIndex;
            parametes[2].Value = pagesize;
            return DbHelperSQL.Query(strSql.ToString(), parametes);
        }

        public int GetAveScore(int cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT FLOOR((SUM(Score))/(SELECT COUNT(1) FROM Tao_Comment ");
            strSql.Append("WHERE ParentID=0 AND CourseID=@CourseId))ave FROM Tao_Comment ");
            strSql.Append("WHERE CourseID=@CourseId AND ParentID=0 ");

            SqlParameter[] parametes = {
                                       new SqlParameter("@CourseId",SqlDbType.Int)
                                       };
            parametes[0].Value = cid;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parametes);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public DataSet GetComment(out int rowCount, out int pageCount, Model.Tao.PageModel model, int type)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@CourseID", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@RowsCount", SqlDbType.Float),
                    new SqlParameter("@PageCount", SqlDbType.Float),
                    new SqlParameter("@ModuleID", SqlDbType.Int),
                    new SqlParameter("@OrderID", SqlDbType.Int),
                    new SqlParameter("@Type", SqlDbType.Int),
                    new SqlParameter("@UserID", SqlDbType.Int)
                    };
            parameters[0].Value = model.Courseid;
            parameters[1].Value = model.PageIndex;
            parameters[2].Value = model.PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Value = model.Moduleid;
            parameters[6].Value = model.Orderid;
            parameters[7].Value = type;
            parameters[8].Value = model.Userid;
            DataSet ds = DbHelperSQL.RunProcedure("sp_CommentForAjax", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            return ds;
        }

        public DataSet GetChildComment(int parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *,0 AS CCount FROM dbo.Tao_Comment ");
            strSql.Append("WHERE ParentID=@ParentID ORDER BY CommentDate ASC ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentID", SqlDbType.Int)
                    };
            parameters[0].Value = parentId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
    }
}