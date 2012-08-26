using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace Maticsoft.DAL.UserExp
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
        public bool Exists(int UserID, int ApproveType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UsersApprove");
            strSql.Append(" where UserID=@UserID and ApproveType=@ApproveType");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ApproveType", SqlDbType.Int,4)
                                        };
            parameters[0].Value = UserID;
            parameters[1].Value = ApproveType;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.UserExp.UsersApprove model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UsersApprove(");
            strSql.Append("UserID,ApproveType,ImgURL,CreatedDate,Status,ApprovedTime,ApprovedUserID,IDCard)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@ApproveType,@ImgURL,@CreatedDate,@Status,@ApprovedTime,@ApprovedUserID,@IDCard)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveType", SqlDbType.Int,4),
					new SqlParameter("@ImgURL", SqlDbType.VarChar,200),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApprovedTime", SqlDbType.DateTime),
					new SqlParameter("@ApprovedUserID", SqlDbType.Int,4),
                    new SqlParameter("@IDCard", SqlDbType.NVarChar,200)
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ApproveType;
            parameters[2].Value = model.ImgURL;
            parameters[3].Value = model.CreatedDate;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.ApprovedTime;
            parameters[6].Value = model.ApprovedUserID;
            parameters[7].Value = model.IDCard;
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
        public bool Update(Maticsoft.Model.UserExp.UsersApprove model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersApprove set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("ApproveType=@ApproveType,");
            strSql.Append("ImgURL=@ImgURL,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("Status=@Status,");
            strSql.Append("ApprovedTime=@ApprovedTime,");
            strSql.Append("ApprovedUserID=@ApprovedUserID,");
            strSql.Append("IDCard=@IDCard");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveType", SqlDbType.Int,4),
					new SqlParameter("@ImgURL", SqlDbType.VarChar,200),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApprovedTime", SqlDbType.DateTime),
					new SqlParameter("@ApprovedUserID", SqlDbType.Int,4),
                    new SqlParameter("@IDCard", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ApproveType;
            parameters[2].Value = model.ImgURL;
            parameters[3].Value = model.CreatedDate;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.ApprovedTime;
            parameters[6].Value = model.ApprovedUserID;
            parameters[7].Value = model.IDCard;
            parameters[8].Value = model.ID;

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
        public Maticsoft.Model.UserExp.UsersApprove GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,ApproveType,ImgURL,CreatedDate,Status,ApprovedTime,ApprovedUserID from Accounts_UsersApprove ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Maticsoft.Model.UserExp.UsersApprove model = new Maticsoft.Model.UserExp.UsersApprove();
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
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.UserExp.UsersApprove GetModelByUidAndType(int userId, int approveType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,UserID,ApproveType,ImgURL,CreatedDate,Status,ApprovedTime,ApprovedUserID,IDCard from Accounts_UsersApprove ");
            strSql.Append(" where UserID=@UserID and ApproveType=@ApproveType");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ApproveType", SqlDbType.Int,4)
                                        };
            parameters[0].Value = userId;
            parameters[1].Value = approveType;
            Maticsoft.Model.UserExp.UsersApprove model = new Maticsoft.Model.UserExp.UsersApprove();
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
                if (ds.Tables[0].Rows[0]["IDCard"] != null && ds.Tables[0].Rows[0]["IDCard"].ToString() != "")
                {
                    model.IDCard = ds.Tables[0].Rows[0]["IDCard"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion NewMethod
    }
}