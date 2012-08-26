using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.Tao
{
    /// <summary>
    /// 数据访问类:UsersApprove
    /// </summary>
    public partial class UsersApprove
    {
        public UsersApprove()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Accounts_UsersApprove");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UsersApprove");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Tao.UsersApprove model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UsersApprove(");
            strSql.Append("UserID,ApproveType,ImgURL,CreatedDate,Status,ApprovedTime,ApprovedUserID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@ApproveType,@ImgURL,@CreatedDate,@Status,@ApprovedTime,@ApprovedUserID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveType", SqlDbType.Int,4),
					new SqlParameter("@ImgURL", SqlDbType.VarChar,200),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApprovedTime", SqlDbType.DateTime),
					new SqlParameter("@ApprovedUserID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ApproveType;
            parameters[2].Value = model.ImgURL;
            parameters[3].Value = model.CreatedDate;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.ApprovedTime;
            parameters[6].Value = model.ApprovedUserID;
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
        public bool Update(Maticsoft.Model.Tao.UsersApprove model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersApprove set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("ApproveType=@ApproveType,");
            strSql.Append("ImgURL=@ImgURL,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("Status=@Status,");
            strSql.Append("ApprovedTime=@ApprovedTime,");
            strSql.Append("ApprovedUserID=@ApprovedUserID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveType", SqlDbType.Int,4),
					new SqlParameter("@ImgURL", SqlDbType.VarChar,200),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApprovedTime", SqlDbType.DateTime),
					new SqlParameter("@ApprovedUserID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ApproveType;
            parameters[2].Value = model.ImgURL;
            parameters[3].Value = model.CreatedDate;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.ApprovedTime;
            parameters[6].Value = model.ApprovedUserID;
            parameters[7].Value = model.ID;

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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UsersApprove ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UsersApprove ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Maticsoft.Model.Tao.UsersApprove GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,ApproveType,ImgURL,CreatedDate,Status,ApprovedTime,ApprovedUserID from Accounts_UsersApprove ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.Tao.UsersApprove model = new Maticsoft.Model.Tao.UsersApprove();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApproveType"] != null && ds.Tables[0].Rows[0]["ApproveType"].ToString() != "")
                {
                    model.ApproveType = int.Parse(ds.Tables[0].Rows[0]["ApproveType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ImgURL"] != null && ds.Tables[0].Rows[0]["ImgURL"].ToString() != "")
                {
                    model.ImgURL = ds.Tables[0].Rows[0]["ImgURL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApprovedTime"] != null && ds.Tables[0].Rows[0]["ApprovedTime"].ToString() != "")
                {
                    model.ApprovedTime = DateTime.Parse(ds.Tables[0].Rows[0]["ApprovedTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApprovedUserID"] != null && ds.Tables[0].Rows[0]["ApprovedUserID"].ToString() != "")
                {
                    model.ApprovedUserID = int.Parse(ds.Tables[0].Rows[0]["ApprovedUserID"].ToString());
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
            strSql.Append("select ID,UserID,ApproveType,ImgURL,CreatedDate,Status,ApprovedTime,ApprovedUserID ");
            strSql.Append(" FROM Accounts_UsersApprove ");
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
            strSql.Append(" ID,UserID,ApproveType,ImgURL,CreatedDate,Status,ApprovedTime,ApprovedUserID ");
            strSql.Append(" FROM Accounts_UsersApprove ");
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
            strSql.Append("select count(1) FROM Accounts_UsersApprove ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Accounts_UsersApprove T ");
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
            parameters[0].Value = "Accounts_UsersApprove";
            parameters[1].Value = "ID";
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
                strSql.Append("update Accounts_UsersApprove set " + strWhere);
                strSql.Append(" where ID in (" + IDlist + ")");
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

        #endregion NewMethod
    }
}