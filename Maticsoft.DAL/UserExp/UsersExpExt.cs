using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.UserExp
{
    public partial class UsersExp
    {
        /// <summary>
        /// 是否存在该用户名
        /// </summary>
        public bool ExistsUserName(string ColsName, string ColType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where " + ColType + "=@ColsName");
            SqlParameter[] parameters = {
                    new SqlParameter("@ColsName", SqlDbType.VarChar,50)
};
            parameters[0].Value = ColsName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #region 更新用户头像

        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateGravatar(Model.UserExp.UsersExp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersExp set ");
            strSql.Append("UserAvatar=@UserAvatar");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserAvatar", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserAvatar;
            parameters[1].Value = model.UserID;

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

        #region Method

        /// <summary>
        /// 得到一个结果集
        /// </summary>
        public DataSet GetUserExpModel(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  Accounts_Users.UserID,UserName,TrueName,Password,TrueName,Sex,Birthday,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,AU.UserAvatar,AU.UserRegionID,AU.UserHobby,AU.UserCareer,AU.TeachDescription as TeachDescription,Tags,UserRegionID ");
            strSql.Append("FROM Accounts_Users  ");
            strSql.Append("LEFT JOIN Accounts_UsersExp AU ON AU.UserID=Accounts_Users.UserID ");
            strSql.Append(" where Accounts_Users.UserID=@userID");
            SqlParameter[] parameters = {
                    new SqlParameter("@userID", SqlDbType.Int,4)};
            parameters[0].Value = userID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        #endregion Method

        #endregion 更新用户头像

        /// <summary>
        /// 更新用户基本资料--PersonalInfor.aspx
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        public int UpDateUserInfo(string TrueName, string Sex, string Phone, Model.UserExp.UsersExp ExpModel)
        {
            int outRows = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@TrueName", SqlDbType.VarChar,50),
                    new SqlParameter("@Sex", SqlDbType.Char,10),
                    new SqlParameter("@Phone", SqlDbType.VarChar,20),
                    new SqlParameter("@UserCareer", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserHobby", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserBirthday", SqlDbType.DateTime),
                    new SqlParameter("@UserRegionID", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = TrueName;
            parameters[1].Value = Sex;
            parameters[2].Value = Phone;
            parameters[3].Value = ExpModel.UserCareer;
            parameters[4].Value = ExpModel.UserHobby;
            parameters[5].Value = ExpModel.Birthday;
            parameters[6].Value = ExpModel.UserRegionID;
            parameters[7].Value = ExpModel.UserID;

            DbHelperSQL.RunProcedure("sp_AccountsUserInfo_Update", parameters, out outRows);
            return outRows;
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        public int UpDatePwd(int uid, byte[] newPwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_Users  ");
            strSql.Append("SET Password=@newPwd ");
            strSql.Append("WHERE UserID=@uid");
            SqlParameter[] parameters = {
                    new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@newPwd", SqlDbType.Binary,20)
                                        };
            parameters[0].Value = uid;
            parameters[1].Value = newPwd;
            int res = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return res;
        }

        public bool UpdateTeacherAc(string imgPath, int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE dbo.Accounts_UsersExp ");
            strSql.AppendFormat("SET UserAvatar='{0}' ", imgPath);
            strSql.AppendFormat("WHERE UserID= {0}", uid);
            return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
        }

        /// <summary>
        /// 修改教师名称和教师简介信息
        /// </summary>
        /// <param name="TrueName">教师名称</param>
        /// <param name="dec">教师简介</param>
        /// <param name="UserId">教师ID</param>
        /// <returns></returns>
        public bool EditUesInfo(string TrueName, string dec, int UserId, string DeprtName)
        {
            int outRows = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@TrueName", SqlDbType.VarChar),
                    new SqlParameter("@UserID", SqlDbType.Int),
                    new SqlParameter("@TeachDescription", SqlDbType.VarChar),
                     new SqlParameter("@DeprtName", SqlDbType.NVarChar)
                                         };
            parameters[0].Value = TrueName;
            parameters[1].Value = UserId;
            parameters[2].Value = dec;
            parameters[3].Value = DeprtName;

            DbHelperSQL.RunProcedure("sp_UpdateTeacherInfo", parameters, out outRows);
            if (outRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //List<CommandInfo> cmdlist = new List<CommandInfo>();
            //CommandInfo cmd;
            //int rowsAffected = 0;
            ////更新教师名称
            //StringBuilder strSqlUser = new StringBuilder();
            //strSqlUser.Append("UPDATE Accounts_Users  ");
            //strSqlUser.Append("SET TrueName=@TrueName ");
            //strSqlUser.Append("WHERE UserID=@UserID ");
            //SqlParameter[] parametersUser = {
            //        new SqlParameter("@TrueName", SqlDbType.VarChar),
            //        new SqlParameter("@UserID", SqlDbType.Int)
            //                             };
            //parametersUser[0].Value = TrueName;
            //parametersUser[1].Value = UserId;
            //cmd = new CommandInfo(strSqlUser.ToString(), parametersUser);
            //cmdlist.Add(cmd);

            ////更新教师简介
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("UPDATE Accounts_UsersExp  ");
            //strSql.Append("SET TeachDescription=@TeachDescription ");
            //strSql.Append("WHERE UserID=@UserID ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@TeachDescription", SqlDbType.VarChar),
            //        new SqlParameter("@UserID", SqlDbType.Int)
            //                             };
            //parameters[0].Value = dec;
            //parameters[1].Value = UserId;
            //cmd = new CommandInfo(strSql.ToString(), parameters);
            //cmdlist.Add(cmd);

            ////
            //StringBuilder strSqlEnter = new StringBuilder();
            //strSqlEnter.Append("INSERT dbo.Tao_Enterprise (Name ,AgentID) VALUES ( @Name ,0) ");
            //SqlParameter[] para = {
            //        new SqlParameter("@Name", SqlDbType.NVarChar),
            //                             };
            //para[0].Value = DeprtName;
            //cmd = new CommandInfo(strSqlEnter.ToString(), para);
            //cmdlist.Add(cmd);

            //rowsAffected = DbHelperSQL.ExecuteSqlTran(cmdlist);
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 获取用户认证状态
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        /// <param name="iAuthenticType">认证类型</param>
        /// <param name="iStatus">认证状态</param>
        /// <returns>DataSet</returns>
        public DataSet GetUserCertificate(int? iUserId, int? iAuthenticType, int? iStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select U.*, AU.UserName,UA.ApproveName From (Accounts_UsersApprove U left join Accounts_ApproveType UA On U.ApproveType = UA.id) left join Accounts_Users AU ON AU.UserID = U.UserID  where 1=1");
            if (iUserId.HasValue)
            {
                strSql.Append(" And U.UserId = " + iUserId);
            }
            if (iAuthenticType.HasValue)
            {
                strSql.Append(" And U.ApproveType= " + iAuthenticType);
            }
            if (iStatus.HasValue)
            {
                strSql.Append(" And U.Status = " + iStatus);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 检测邮箱是否已经注册
        /// </summary>
        /// <param name="Email">将要注册的Email地址</param>
        /// <returns></returns>
        public bool EmailExist(string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM Accounts_Users ");
            strSql.Append("WHERE Email=@Email ");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.VarChar,100)};
            parameters[0].Value = Email;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新教师主页中的标签和教师简介
        /// </summary>
        public bool UpdateTeacher(string description, string tags, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_UsersExp  ");
            strSql.Append("SET TeachDescription=@TeachDescription,Tags=@Tags ");
            strSql.Append("WHERE UserID=@UserID ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@TeachDescription",SqlDbType.VarChar),
                                        new SqlParameter("@Tags",SqlDbType.NVarChar),
                                        new SqlParameter("@UserID",SqlDbType.Int),
                                        };
            parameters[0].Value = description;
            parameters[1].Value = tags;
            parameters[2].Value = userId;
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

        public DataSet SearchTeacher(string keyStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT AU.UserID,AU.TrueName,Tags ,UserAvatar,TeachDescription ");
            strSql.Append("FROM Accounts_Users AU ");
            strSql.Append("LEFT JOIN Accounts_UsersExp AUE ON AU.UserID=AUE.UserID ");
            strSql.Append("WHERE Activity=1 AND TrueName LIKE '%" + keyStr + "%' ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet ApproveStatue(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT UserID,ApproveType,ApproveName  ");
            strSql.Append("FROM Accounts_UsersApprove AUA ");
            strSql.Append("LEFT JOIN Accounts_ApproveType AAY ON AUA.ApproveType=AAY.ID ");
            strSql.Append("WHERE UserID =@Userid AND Status=1  ");
            SqlParameter[] parameters = {
                                       new SqlParameter("@Userid",SqlDbType.Int)
                                       };
            parameters[0].Value = uid;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int SumCourseCount(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Tao_Courses ");
            strSql.Append("WHERE CreatedUserID=@UserId AND Status=3 ");
            SqlParameter[] parameters = {
                                        new SqlParameter("UserId",SqlDbType.Int)
                                        };
            parameters[0].Value = uid;
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

        public int GetUserBalance(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Balance  ");
            strSql.Append("FROM Accounts_UsersExp  ");
            strSql.Append("WHERE UserID=@UsrId ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@UsrId",SqlDbType.Int)
                                        };
            parameters[0].Value = UserId;
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

        public DataSet GetUName(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TrueName,UserName ");
            strSql.Append("from Accounts_Users ");
            strSql.Append("where UserID=" + uid);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetReTeacher()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 5 au.UserID,TrueName,UserAvatar,te.Name,DepartmentID,aue.Singature ");
            strSql.Append("FROM dbo.Accounts_UsersExp aue ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON aue.UserID=au.UserID ");
            strSql.Append("LEFT JOIN dbo.Tao_Enterprise te ON te.EnterpriseID=au.DepartmentID ");
            strSql.Append("WHERE Recommended=1 AND Activity=1 AND UserType='UU' ");
            strSql.Append(" ORDER BY aue.UpdateTime");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetTeachCourse(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 2 CourseName ");
            strSql.Append("FROM    dbo.Tao_Courses ");
            strSql.Append("WHERE   CreatedUserID =  " + uid);
            strSql.Append(" AND Status=3");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 新版 名师推荐
        /// </summary>
        public DataSet GetReTeacher(int? top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ");
            if (top.HasValue)
            {
                strSql.Append(" TOP " + top.Value);
            }
            strSql.Append(" au.UserID,TrueName,UserAvatar,te.Name,DepartmentID,aue.Singature ,aue.Tags,aue.UserCareer ");
            strSql.Append("FROM dbo.Accounts_UsersExp aue ");
            strSql.Append("LEFT JOIN dbo.Accounts_Users au ON aue.UserID=au.UserID ");
            strSql.Append("LEFT JOIN dbo.Tao_Enterprise te ON te.EnterpriseID=au.DepartmentID ");
            strSql.Append("WHERE Recommended=1 AND Activity=1 AND UserType='UU' ");
            strSql.Append(" ORDER BY aue.UpdateTime");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetUserInfo(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.UserID,A.UserName,b.UserAvatar FROM dbo.Accounts_Users A ");
            strSql.Append("LEFT JOIN dbo.Accounts_UsersExp B ON A.UserID=B.UserID  ");
            strSql.Append("WHERE A.UserID = " + uid);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}