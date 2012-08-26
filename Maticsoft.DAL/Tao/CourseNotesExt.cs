using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class CourseNotes
    {
        /// <summary>
        /// 获取课程笔记信息
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        public DataSet GetCourseNote(int? uid, int startindex, int pagesize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM (SELECT ROW_NUMBER()OVER (ORDER BY NoteID DESC) AS RNum,* FROM ( ");
            strSql.Append("SELECT  TC.ImageUrl,TC.CourseName,TC.CourseID, TM.ModuleName,TM.ModuleID,TCN.NoteID,TCN.Contents ");
            strSql.Append("FROM Tao_OrderItemHistory TOIH ");
            strSql.Append("LEFT JOIN Tao_OrderHistory TOH ON TOIH.OrderID=TOH.OrderID ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TC.CourseID=TOIH.CourseID ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TOIH.ModuleID ");
            strSql.Append("LEFT JOIN Tao_CourseNotes TCN ON TCN.UserID=TOH.BuyerID AND TCN.CourseID=TOIH.CourseID AND TCN.ModuleID=TOIH.ModuleID ");
            strSql.Append("WHERE BuyerID=@UserID ");
            strSql.Append(")A )AS TEMP	WHERE RNum  BETWEEN  @pi AND @pi+@si-1");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@pi",SqlDbType.Int),
                                        new SqlParameter("@si",SqlDbType.Int)
                                        };
            parameters[0].Value = uid.Value;
            parameters[1].Value = startindex;
            parameters[2].Value = pagesize;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        public int SumNoteCourse(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(1) ");
            strSql.Append("FROM Tao_OrderItemHistory TOIH ");
            strSql.Append("LEFT JOIN Tao_OrderHistory TOH ON TOIH.OrderID=TOH.OrderID ");
            strSql.Append("LEFT JOIN Tao_Courses TC ON TC.CourseID=TOIH.CourseID ");
            strSql.Append("LEFT JOIN Tao_Modules TM ON TM.ModuleID=TOIH.ModuleID ");
            strSql.Append("LEFT JOIN Tao_CourseNotes TCN ON TCN.UserID=TOH.BuyerID AND TCN.CourseID=TOIH.CourseID AND TCN.ModuleID=TOIH.ModuleID ");
            strSql.Append("WHERE BuyerID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public static DataSet GetCourseNotes(int uid, int mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT NoteID, UserID, CourseID, ModuleID, Updatetime, Contents  ");
            strSql.Append("FROM dbo.Tao_CourseNotes ");
            strSql.Append("WHERE UserID=@UserID AND ModuleID=@mid ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        new SqlParameter("@mid",SqlDbType.Int)
                                        };
            parameters[0].Value = uid;
            parameters[1].Value = mid;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
    }
}