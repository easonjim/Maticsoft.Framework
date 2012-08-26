using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.Tao
{
    public partial class SendInvite
    {
        public static Maticsoft.Accounts.Bus.User GetUNameByMid(int mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TrueName ");
            strSql.Append("FROM    dbo.Tao_SendInvite tsi ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON InviteeID=au.UserID ");
            strSql.Append("WHERE   ModuleID = @ModuleID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@ModuleID",SqlDbType.Int)
                                        };
            parameters[0].Value = mid;
            Maticsoft.Accounts.Bus.User user = new Accounts.Bus.User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    user.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                return user;
            }
            else
            {
                return null;
            }
        }

        public static DataSet GetInviteCourseByID(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  tc.CourseID,CourseName,tcm.ModuleID ,tm.ModuleName,tc.Price,tc.ModuleNum,tc.ImageUrl,tsi.InviteDate,tcm.Status ,tc.CreatedUserID,TrueName,InviteStatus ,tcm.ID,InviteID  ");
            strSql.Append("FROM dbo.Tao_CourseModule tcm ");
            strSql.Append("LEFT JOIN dbo.Tao_Courses tc ON tcm.CourseID=tc.CourseID ");
            strSql.Append("LEFT JOIN dbo.Tao_SendInvite tsi ON tsi.ModuleID=tcm.ModuleID ");
            strSql.Append("LEFT JOIN dbo.Tao_Modules tm ON tm.ModuleID=tcm.ModuleID ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON tc.CreatedUserID=au.UserID ");
            strSql.Append("WHERE tcm.ModuleID IN ( ");
            strSql.Append("SELECT ModuleID FROM dbo.Tao_SendInvite ");

            strSql.Append("WHERE InviteeID=@Uid) AND tcm.Status IN(1,2,3)  ");
            SqlParameter[] para = {
                                  new SqlParameter("@Uid",SqlDbType.Int)
                                  };
            para[0].Value = uid;
            return DbHelperSQL.Query(strSql.ToString(), para);
        }
    }
}