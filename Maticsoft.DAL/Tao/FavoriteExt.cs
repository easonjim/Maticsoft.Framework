using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class Favorite
    {
        /// <summary>
        /// 获得CateID获得记录数
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int GetRecordCount(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Tao_Favorite ");
            strSql.Append("WHERE UserID = " + UserId);
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
        /// 得到分页数据源
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSinglePageRecord(int? UserId, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ROW_NUMBER()OVER (ORDER BY FavoriteID DESC) AS RNum,* FROM ( ");
            strSql.Append("SELECT FavoriteID,TF.CourseID,CourseName,ImageUrl,TimeDuration,Price,SalesVolume ,CreatedUserID,TC.CategoryId ");
            strSql.Append("FROM Tao_Favorite TF ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TC.CourseID=TF.CourseID ");
            strSql.Append("LEFT JOIN Accounts_Users AU ON AU.UserID= TF.UserID ");
            strSql.Append("WHERE TF.UserID=@UserID ");
            strSql.Append(")A )AS TEMP	WHERE RNum  BETWEEN @startIndex and (@startIndex+@endIndex-1)");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@startIndex",SqlDbType.Int),
                                        new SqlParameter("@endIndex",SqlDbType.Int),
                                        };
            parameters[0].Value = UserId.Value;
            parameters[1].Value = startIndex;
            parameters[2].Value = endIndex;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        public int CourseFavCount(int CourseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*)  ");
            strSql.Append("FROM dbo.Tao_Favorite ");
            strSql.Append("WHERE CourseID=@CourseId ");
            SqlParameter[] paramrates = {
                                        new SqlParameter("@CourseId",SqlDbType.Int)
                                        };
            paramrates[0].Value = CourseId;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), paramrates);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public int GetFavCourseCount(int courseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM dbo.Tao_Favorite ");
            strSql.AppendFormat("WHERE CourseID={0} ", courseId);
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
    }
}