using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.SQLServerDAL.SysManage
{
    /// <summary>
    /// 数据访问类:Users
    /// </summary>
    public partial class Users
    {
        public Users()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "Accounts_Users");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.SysManage.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_Users(");
            strSql.Append("UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@TrueName,@Sex,@Phone,@Email,@EmployeeID,@DepartmentID,@Activity,@UserType,@Style,@User_iCreator,@User_dateCreate,@User_dateValid,@User_dateExpire,@User_iApprover,@User_dateApprove,@User_iApproveState,@User_cLang)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.Binary,20),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,10),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,15),
					new SqlParameter("@Activity", SqlDbType.Bit,1),
					new SqlParameter("@UserType", SqlDbType.Char,2),
					new SqlParameter("@Style", SqlDbType.Int,4),
					new SqlParameter("@User_iCreator", SqlDbType.Int,4),
					new SqlParameter("@User_dateCreate", SqlDbType.DateTime),
					new SqlParameter("@User_dateValid", SqlDbType.DateTime),
					new SqlParameter("@User_dateExpire", SqlDbType.DateTime),
					new SqlParameter("@User_iApprover", SqlDbType.Int,4),
					new SqlParameter("@User_dateApprove", SqlDbType.DateTime),
					new SqlParameter("@User_iApproveState", SqlDbType.Int,4),
					new SqlParameter("@User_cLang", SqlDbType.VarChar,10)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.EmployeeID;
            parameters[7].Value = model.DepartmentID;
            parameters[8].Value = model.Activity;
            parameters[9].Value = model.UserType;
            parameters[10].Value = model.Style;
            parameters[11].Value = model.User_iCreator;
            parameters[12].Value = model.User_dateCreate;
            parameters[13].Value = model.User_dateValid;
            parameters[14].Value = model.User_dateExpire;
            parameters[15].Value = model.User_iApprover;
            parameters[16].Value = model.User_dateApprove;
            parameters[17].Value = model.User_iApproveState;
            parameters[18].Value = model.User_cLang;

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
        public bool Update(Maticsoft.Model.SysManage.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_Users set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("EmployeeID=@EmployeeID,");
            strSql.Append("DepartmentID=@DepartmentID,");
            strSql.Append("Activity=@Activity,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("Style=@Style,");
            strSql.Append("User_iCreator=@User_iCreator,");
            strSql.Append("User_dateCreate=@User_dateCreate,");
            strSql.Append("User_dateValid=@User_dateValid,");
            strSql.Append("User_dateExpire=@User_dateExpire,");
            strSql.Append("User_iApprover=@User_iApprover,");
            strSql.Append("User_dateApprove=@User_dateApprove,");
            strSql.Append("User_iApproveState=@User_iApproveState,");
            strSql.Append("User_cLang=@User_cLang");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.Binary,20),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,10),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,15),
					new SqlParameter("@Activity", SqlDbType.Bit,1),
					new SqlParameter("@UserType", SqlDbType.Char,2),
					new SqlParameter("@Style", SqlDbType.Int,4),
					new SqlParameter("@User_iCreator", SqlDbType.Int,4),
					new SqlParameter("@User_dateCreate", SqlDbType.DateTime),
					new SqlParameter("@User_dateValid", SqlDbType.DateTime),
					new SqlParameter("@User_dateExpire", SqlDbType.DateTime),
					new SqlParameter("@User_iApprover", SqlDbType.Int,4),
					new SqlParameter("@User_dateApprove", SqlDbType.DateTime),
					new SqlParameter("@User_iApproveState", SqlDbType.Int,4),
					new SqlParameter("@User_cLang", SqlDbType.VarChar,10),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.EmployeeID;
            parameters[7].Value = model.DepartmentID;
            parameters[8].Value = model.Activity;
            parameters[9].Value = model.UserType;
            parameters[10].Value = model.Style;
            parameters[11].Value = model.User_iCreator;
            parameters[12].Value = model.User_dateCreate;
            parameters[13].Value = model.User_dateValid;
            parameters[14].Value = model.User_dateExpire;
            parameters[15].Value = model.User_iApprover;
            parameters[16].Value = model.User_dateApprove;
            parameters[17].Value = model.User_iApproveState;
            parameters[18].Value = model.User_cLang;
            parameters[19].Value = model.UserID;

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
        public bool Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

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
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
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
        public Maticsoft.Model.SysManage.Users GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang from Accounts_Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            Maticsoft.Model.SysManage.Users model = new Maticsoft.Model.SysManage.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = (byte[])ds.Tables[0].Rows[0]["Password"];
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EmployeeID"] != null && ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentID"] != null && ds.Tables[0].Rows[0]["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Activity"] != null && ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UserType"] != null && ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Style"] != null && ds.Tables[0].Rows[0]["Style"].ToString() != "")
                {
                    model.Style = int.Parse(ds.Tables[0].Rows[0]["Style"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iCreator"] != null && ds.Tables[0].Rows[0]["User_iCreator"].ToString() != "")
                {
                    model.User_iCreator = int.Parse(ds.Tables[0].Rows[0]["User_iCreator"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateCreate"] != null && ds.Tables[0].Rows[0]["User_dateCreate"].ToString() != "")
                {
                    model.User_dateCreate = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateCreate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateValid"] != null && ds.Tables[0].Rows[0]["User_dateValid"].ToString() != "")
                {
                    model.User_dateValid = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateExpire"] != null && ds.Tables[0].Rows[0]["User_dateExpire"].ToString() != "")
                {
                    model.User_dateExpire = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateExpire"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApprover"] != null && ds.Tables[0].Rows[0]["User_iApprover"].ToString() != "")
                {
                    model.User_iApprover = int.Parse(ds.Tables[0].Rows[0]["User_iApprover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateApprove"] != null && ds.Tables[0].Rows[0]["User_dateApprove"].ToString() != "")
                {
                    model.User_dateApprove = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateApprove"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApproveState"] != null && ds.Tables[0].Rows[0]["User_iApproveState"].ToString() != "")
                {
                    model.User_iApproveState = int.Parse(ds.Tables[0].Rows[0]["User_iApproveState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_cLang"] != null && ds.Tables[0].Rows[0]["User_cLang"].ToString() != "")
                {
                    model.User_cLang = ds.Tables[0].Rows[0]["User_cLang"].ToString();
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
            strSql.Append("select UserID,UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang ");
            strSql.Append(" FROM Accounts_Users ");
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
            strSql.Append(" UserID,UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang ");
            strSql.Append(" FROM Accounts_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Accounts_Users ");
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
                strSql.Append("order by T.UserID desc");
            }
            strSql.Append(")AS Row, T.*  from Accounts_Users T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "Accounts_Users";
            parameters[1].Value = "UserID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region MethodEx

        /// <summary>
        /// 根据DepartmentID删除一条数据
        /// </summary>
        public bool DeleteByDepartmentID(int DepartmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where DepartmentID=@DepartmentID");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4)
			};
            parameters[0].Value = DepartmentID;

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
        /// 根据DepartmentID批量删除数据
        /// </summary>
        public bool DeleteListByDepartmentID(string DepartmentIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where DepartmentID in (" + DepartmentIDlist + ")  ");
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
        /// 判断电话是否一件存在
        /// </summary>
        public bool ExistByPhone(string Phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Accounts_Users ");
            strSql.Append(" where Phone=@Phone ");
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.VarChar)
			};
            parameters[0].Value = Phone;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据用户邮箱判断是否存在该记录
        /// </summary>
        public bool ExistsByEmail(string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *  from Accounts_Users ");
            strSql.Append(" where Email=@Email");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.VarChar,100)
			};
            parameters[0].Value = Email;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Maticsoft.Model.SysManage.Users GetModelByEmail(string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Accounts_Users ");
            strSql.Append(" where Email=@Email");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.VarChar,100)
			};
            parameters[0].Value = Email;

            Maticsoft.Model.SysManage.Users model = new Maticsoft.Model.SysManage.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = (byte[])ds.Tables[0].Rows[0]["Password"];
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EmployeeID"] != null && ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentID"] != null && ds.Tables[0].Rows[0]["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Activity"] != null && ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UserType"] != null && ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Style"] != null && ds.Tables[0].Rows[0]["Style"].ToString() != "")
                {
                    model.Style = int.Parse(ds.Tables[0].Rows[0]["Style"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iCreator"] != null && ds.Tables[0].Rows[0]["User_iCreator"].ToString() != "")
                {
                    model.User_iCreator = int.Parse(ds.Tables[0].Rows[0]["User_iCreator"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateCreate"] != null && ds.Tables[0].Rows[0]["User_dateCreate"].ToString() != "")
                {
                    model.User_dateCreate = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateCreate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateValid"] != null && ds.Tables[0].Rows[0]["User_dateValid"].ToString() != "")
                {
                    model.User_dateValid = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateExpire"] != null && ds.Tables[0].Rows[0]["User_dateExpire"].ToString() != "")
                {
                    model.User_dateExpire = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateExpire"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApprover"] != null && ds.Tables[0].Rows[0]["User_iApprover"].ToString() != "")
                {
                    model.User_iApprover = int.Parse(ds.Tables[0].Rows[0]["User_iApprover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateApprove"] != null && ds.Tables[0].Rows[0]["User_dateApprove"].ToString() != "")
                {
                    model.User_dateApprove = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateApprove"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApproveState"] != null && ds.Tables[0].Rows[0]["User_iApproveState"].ToString() != "")
                {
                    model.User_iApproveState = int.Parse(ds.Tables[0].Rows[0]["User_iApproveState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_cLang"] != null && ds.Tables[0].Rows[0]["User_cLang"].ToString() != "")
                {
                    model.User_cLang = ds.Tables[0].Rows[0]["User_cLang"].ToString();
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
        public DataSet GetListEx(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AU.*,AUEX.*  FROM Accounts_Users AU ");
            strSql.Append(" LEFT JOIN Accounts_UsersExp AUEX ON AU.UserID=AUEX.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by " + orderby);
            }
            else
            {
                strSql.Append(" order by AU.UserID desc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.SysManage.Users GetModelEx(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AU.*,AUEX.*  FROM Accounts_Users AU LEFT JOIN Accounts_UsersExp AUEX ON AU.UserID=AUEX.UserID ");
            strSql.Append(" where AU.UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            Maticsoft.Model.SysManage.Users model = new Maticsoft.Model.SysManage.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PersonalStatus"] != null && ds.Tables[0].Rows[0]["PersonalStatus"].ToString() != "")
                {
                    model.PersonalStatus = ds.Tables[0].Rows[0]["PersonalStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QQ"] != null && ds.Tables[0].Rows[0]["QQ"].ToString() != "")
                {
                    model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Aliwangwang"] != null && ds.Tables[0].Rows[0]["Aliwangwang"].ToString() != "")
                {
                    model.Aliwangwang = ds.Tables[0].Rows[0]["Aliwangwang"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MSN"] != null && ds.Tables[0].Rows[0]["MSN"].ToString() != "")
                {
                    model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birthday"] != null && ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Activity"] != null && ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["User_dateCreate"] != null && ds.Tables[0].Rows[0]["User_dateCreate"].ToString() != "")
                {
                    model.User_dateCreate = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateCreate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateValid"] != null && ds.Tables[0].Rows[0]["User_dateValid"].ToString() != "")
                {
                    model.User_dateValid = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateValid"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 批量更新用户状态
        /// </summary>
        /// <param name="UserIDlist">用户ID</param>
        /// <param name="Activity">状态</param>
        /// <returns></returns>
        public bool UpdateActivity(string UserIDlist, bool Activity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_Users set ");
            strSql.Append(" Activity=@Activity");
            SqlParameter[] parameters = {
					new SqlParameter("@Activity", SqlDbType.Bit),
                                         };
            parameters[0].Value = Activity;
            strSql.Append(" where UserID in(" + UserIDlist + ")  ");
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

        #endregion MethodEx

        public DataSet GetList(string type, string keyWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.Accounts_Users ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append(" AND UserType=" + type);
            }
            if (!string.IsNullOrEmpty(keyWord))
            {
                strSql.AppendFormat(" AND UserName LIKE '%{0}%' ", keyWord);
            }
            strSql.Append(" AND Activity=1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}