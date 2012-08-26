using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.UserExp
{
    public partial class UsersApprove
    {
        /// <summary>
        /// 根据UserId获取对应的认证资料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetUserApprove(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT UserID, ApproveName, ImgURL, CreatedDate, Status, ApprovedTime, ApprovedUserID ");
            strSql.Append("FROM Accounts_UsersApprove AUA  ");
            strSql.Append("LEFT JOIN Accounts_ApproveType AAT ON  AUA. ApproveType=AAT.ID ");
            strSql.Append("WHERE UserID=@UserID AND ImgURL<>'' AND AUA.Status=1 ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int GetIdCardApprove(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  Status ");
            strSql.Append("FROM    Accounts_UsersApprove ");
            strSql.Append("WHERE   UserID = @UserID AND ApproveType = 1 ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UserID",SqlDbType.Int)
                                        };
            parameters[0].Value = userid;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return -1;
            }
        }
    }
}